using CasaEmpeñoModel.ViewModels;
using CasaEmpeñoService.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasaEmpeño.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly LoginService _loginService;
        public LoginController()
        {
            _loginService = new LoginService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel user)
        {
            var userExists = _loginService.IsValidUser(user.Usuario, user.Contraseña);
            if (userExists)
            {
                return Redirect("~/Producto/Index");
            }

            ViewBag.Message = "Usuario y/o contraseña inválidos";
            return View();
        }
    }
}