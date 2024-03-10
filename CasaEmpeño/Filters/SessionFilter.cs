using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasaEmpeño.Filters
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            var sessionUser = controller.Session["User"];
            
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Login" &&
                filterContext.ActionDescriptor.ActionName == "Index")
            {                
                base.OnActionExecuting(filterContext);
                return;
            }

            if (sessionUser != null && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Login" && filterContext.ActionDescriptor.ActionName == "Index")
            {
                filterContext.Result = new RedirectResult("~/Producto/List");
                return;
            }
            
            if(sessionUser != null)
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
        }
    }
}