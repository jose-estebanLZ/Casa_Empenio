using CasaEmpeño.Filters;
using CasaEmpeñoService.ProductStatusService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasaEmpeño.Controllers
{
    [SessionFilter]
    public class EstadoProductoController : Controller
    {
        private readonly ProductStatusService _productStatusService;

        public EstadoProductoController()
        {
            _productStatusService = new ProductStatusService();
        }

        [HttpGet]
        public ActionResult GetDropDownProductStatus()
        {
            var lstProductStatus = _productStatusService.GetAll().Select(x => new SelectListItem()
            {
                Value = x.EstadoProductoId.ToString(),
                Text = x.Nombre
            }).ToList();

            return Json(lstProductStatus, JsonRequestBehavior.AllowGet);
        }
    }
}