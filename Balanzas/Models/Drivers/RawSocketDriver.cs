namespace Balanzas.Models.Drivers
{
    using System;
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
                    using (var stream = client.GetStream())
                    {
                        var data = new byte[256];

                        int bytes = stream.Read(data, 0, data.Length);
                        var responseData = Encoding.ASCII.GetString(data, 0, bytes);

                        return new DatoLeido
                        {
                            DeviceLog = "OK",
                            Error = false,
                            Text = responseData
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