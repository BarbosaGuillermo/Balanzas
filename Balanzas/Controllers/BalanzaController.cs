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

        public BalanzaController(BalanzasEntities db, DeviceQuery deviceQuery)
        {
            _db = db;
            _deviceQuery = deviceQuery;
        }

        public ActionResult LeerBalanza(string id)
        {
            try
            {
                var balanza = _db.Dispositivos.SingleOrDefault(x => x.Puesto == id);
                if (balanza == null)
                {
                    return Json(new LecturaBalanza
                    {
                        Text = "E",
                        Error = true,
                        ErrorText = string.Format("Balanza \'{0}\' no encontrada", id)
                    }, JsonRequestBehavior.AllowGet);
                }

                var lectura = _deviceQuery.Query(balanza);

                if (lectura == null)
                {
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
                    return Json(new LecturaBalanza
                    {
                        Text = lectura.Text,
                        Error = false,
                        ErrorText = "OK",
                        Value = peso
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new LecturaBalanza
                {
                    Text = "E",
                    Error = true,
                    ErrorText = "No se pudo convertir la lectura a decimal"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
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