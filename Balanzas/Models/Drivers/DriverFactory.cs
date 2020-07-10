namespace Balanzas.Models.Drivers
{
    using System.Collections.Generic;
    using System.Linq;

    public class DriverFactory
    {
        private readonly IEnumerable<IDriver> _drivers;

        public DriverFactory(IEnumerable<IDriver> drivers)
        {
            _drivers = drivers;
        }

        public IDriver GetDriver(string driverName)
        {
            return _drivers.FirstOrDefault(x => x.DriverName == driverName) ?? new DummyDriver();
        }
    }
}