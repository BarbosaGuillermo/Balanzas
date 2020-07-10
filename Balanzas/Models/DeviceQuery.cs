namespace Balanzas.Models
{
    using Balanzas.Models.Drivers;

    public class DeviceQuery
    {
        private readonly DriverFactory _factory;

        public DeviceQuery(DriverFactory factory)
        {
            _factory = factory;
        }

        public DatoLeido Query(Dispositivo dispositivo)
        {
            var driver = _factory.GetDriver(dispositivo.Driver.Nombre);
            return driver.GetLectura(dispositivo);
        }
    }
}