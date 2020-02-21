using System;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PerreraTeam.Domain.Models;
using PerreraTeam.Services;
using ExceptionContext = System.Web.Mvc.ExceptionContext;

namespace PerreraTeam.Controllers
{
    //public class BaseController<T> : Controller where T : class
    public class BaseController : Controller
    {
        //private IGenericRepository<T> _repository = null;

        //public BaseController()
        //{
        //    _repository = new GenericRepository<T>();
        //}

        //public BaseController(IGenericRepository<T> repository)
        //{
        //    _repository = repository;
        //}

        protected override void OnException(ExceptionContext context)
        {
            // Catch invalid operation exception
            if (!(context.Exception is InvalidOperationException)) return;
            var controllerName = context.RouteData.Values["controller"].ToString();
            var actionName = context.RouteData.Values["action"].ToString();
            var model = new HandleErrorInfo(context.Exception, controllerName, actionName);
            var result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                //Save pass the current Temp Data to the Error view, because it often contains
                //diagnostic information
                TempData = context.Controller.TempData
            };
            context.Result = result;
        }
    }
}