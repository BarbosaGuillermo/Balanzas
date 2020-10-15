namespace Balanzas.Models.Drivers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;

    public class RawSocketDriver : IDriver
    {
        private readonly BalanzasEntities _db;

        public RawSocketDriver(BalanzasEntities db)
        {
            _db = db;
        }

        public string DriverName => "RawSocket";

        public DatoLeido GetLectura(Dispositivo dispositivo)
        {
            var driver = _db.Drivers.First(x => x.Nombre == DriverName);

            try
            {
                var uri = new Uri(dispositivo.URI);

                using (var client = new TcpClient(uri.Host, uri.Port))
                {
                    client.ReceiveTimeout = 6000;
                    client.SendTimeout = 6000;

                    using (var reader = new StreamReader(client.GetStream(), Encoding.UTF8))
                    {
                        string line;

                        try
                        {
                            reader.BaseStream.ReadTimeout = 6000;
                            line = reader.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            client.GetStream().Close();
                            client.Close();

                            return new DatoLeido
                            {
                                DeviceLog = "Error",
                                Error = true,
                                Text = string.Format("Exception: {0}", ex)
                            };
                        }

                        return new DatoLeido
                        {
                            DeviceLog = "OK",
                            Error = false,
                            Text = line
                        };
                    }
                }
            }
            catch (SocketException e)
            {
                return new DatoLeido
                {
                    DeviceLog = "Error",
                    Error = true,
                    Text = string.Format("SocketException: {0}", e)
                };
            }
            catch (Exception e)
            {
                return new DatoLeido
                {
                    DeviceLog = "Error",
                    Error = true,
                    Text = string.Format("Exception: {0}", e)
                };
            }
        }
    }
}