namespace Balanzas.Models.Drivers
{
    public class DummyDriver : IDriver
    {
        public string DriverName => "Dummy";

        public DatoLeido GetLectura(Dispositivo dispositivo)
        {
            return new DatoLeido
            {
                DeviceLog = "OK",
                Error = false,
                Text = "44,4"
            };
        }
    }
}