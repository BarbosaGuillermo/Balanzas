namespace Balanzas.Models
{
    using System;

    public class SysLogger
    {
        private readonly BalanzasEntities _db;

        public SysLogger(BalanzasEntities db)
        {
            _db = db;
        }

        public void Log(string rawdata, string error, int? id)
        {
            _db.SystemLogs.Add(new SystemLog
            {
                DispositivoId = id,
                Error = error,
                Nivel = "Error",
                RawData = rawdata,
                TimePrint = DateTime.Now
            });

            _db.SaveChanges();
        }
    }
}