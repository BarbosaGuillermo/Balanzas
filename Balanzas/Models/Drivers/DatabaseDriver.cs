namespace Balanzas.Models.Drivers
{
    using System.Linq;

    public class DatabaseDriver : IDriver
    {
        private readonly BalanzasEntities _db;

        public  DatabaseDriver(BalanzasEntities db)
        {
            _db = db;
        }

        public string DriverName => "Database";

        public DatoLeido GetLectura(Dispositivo dispositivo)
        {
            var driver = _db.Drivers.First(x => x.Nombre == DriverName);

            return new DatoLeido
            {
                DeviceLog = "OK",
                Error = false,
                Text = driver.Descripcion
            };
        }
    }
}