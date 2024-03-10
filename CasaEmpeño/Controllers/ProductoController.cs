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

        public void AddTransaction(int productId, int transactionType, decimal amount = 0, string comment = "") => 
            _productService.AddTransaction(productId, transactionType, amount, comment);

        public JsonResult AddProductOffer(ProductOfferViewModel productOffer)
        {            
            var productOfferId = _productService.AddProductOffer(productOffer);
            var isMaxOffer = _productService.IsLargestOffer(productOfferId, productOffer.ProductoId);
            _productService.MakeSale(productOffer.ProductoId);

            return Json(new { isMaxOffer = isMaxOffer }, JsonRequestBehavior.AllowGet);
        }
            
    }
}