using CasaEmpeño.Filters;
using CasaEmpeñoService.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasaEmpeño.Controllers
{
    [SessionFilter]
    public class TipoProductoController : Controller
    {
        private readonly ProductTypeService _productTypeService;

        public TipoProductoController()
        {
            _productTypeService = new ProductTypeService();            
        }

        [HttpGet]
        public ActionResult GetDropDownProductType()
        {
            var lstProductType = _productTypeService.GetAll().Select(x => new SelectListItem()
            {
                Value = x.TipoProductoId.ToString(),
                Text = x.Nombre
            }).ToList();

            return Json(lstProductType, JsonRequestBehavior.AllowGet);
        }
    }
}