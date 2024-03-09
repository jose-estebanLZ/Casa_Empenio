using CasaEmpeñoModel.ViewModels;
using CasaEmpeñoService.ProductService;
using CasaEmpeñoService.ProductStatusService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasaEmpeño.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductService _productService;

        public ProductoController()
        {
            _productService = new ProductService();
        }

        public ActionResult List()
        {          
            return View();
        }
        
        public ActionResult Product()
        {
            return View();
        }

        public JsonResult GetGrid() => 
            Json(_productService.GetGrid(), JsonRequestBehavior.AllowGet);

        public void Add(ProductViewModel product)
        {
            var productId = _productService.Add(product);
            _productService.AddTransaction(productId, 1);
        }

        public void AddTransaction(int productId, int transactionType) => 
            _productService.AddTransaction(productId, transactionType);
    }
}