namespace Balanzas.Controllers
{
    using Balanzas.Models;
    using Balanzas.ViewModels;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class BalanzaController : Controller
    {
        private readonly BalanzasEntities _db;
        private readonly DeviceQuery _deviceQuery;
        private readonly SysLogger _logger;

        public BalanzaController(BalanzasEntities db, DeviceQuery deviceQuery, SysLogger logger)
        {
            _db = db;
            _deviceQuery = deviceQuery;
            _logger = logger;
        }

        public ActionResult LeerBalanza(string id)
        {
            try
            {
                var balanza = _db.Dispositivos.SingleOrDefault(x => x.Puesto == id);

                if (balanza == null)
                {
                    _logger.Log(string.IsNullOrEmpty(id) ? "" : id, "Balanza no encontrada", null);

                    return Json(new LecturaBalanza
                    {
                        Text = "E",
                        Error = true,
                        ErrorText = string.Format("Balanza '{0}' no encontrada", id)
                    }, JsonRequestBehavior.AllowGet);
                }

                var lectura = _deviceQuery.Query(balanza);

                if (lectura == null)
                {
                    _logger.Log(id, "No se pudo realizar la lectura", balanza.Id);

                    return Json(new LecturaBalanza
                    {
                        Text = "E",
                        Error = true,
                        ErrorText = "No se pudo realizar la lectura"
                    }, JsonRequestBehavior.AllowGet);
                }

                decimal peso;

                if (decimal.TryParse(lectura.Text, out peso))
                {
                    _db.Lecturas.Add(new Lectura
                    {
                        DatoDespachado = peso.ToString(),
                        DatoLeido = lectura.Text,
                        DispositivoId = balanza.Id,
                        TimePrint = DateTime.Now
                    });

                    _db.SaveChanges();

                    return Json(new LecturaBalanza
                    {
                        Text = lectura.Text,
                        Error = false,
                        ErrorText = "OK",
                        Value = peso
                    }, JsonRequestBehavior.AllowGet);
                }

                _logger.Log(lectura.Text, "No se pudo convertir la lectura a un valor decimal", balanza.Id);

                return Json(new LecturaBalanza
                {
                    Text = "E",
                    Error = true,
                    ErrorText = "No se pudo convertir la lectura a un valor decimal"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                _logger.Log(string.IsNullOrEmpty(id) ? "" : id,
                    e.ToString().Length > 999 ? e.ToString().Substring(0, 999) : e.ToString(), 
                    null);

                return Json(new LecturaBalanza
                {
                    Text = "E",
                    Error = true,
                    ErrorText = e.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}