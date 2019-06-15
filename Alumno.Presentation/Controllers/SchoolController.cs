using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alumno.BusinessLogic.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alumno.Presentation.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            var sheet = HttpContext.Session.GetString("Sheet");
            var path = HttpContext.Session.GetString("Path");
            if (sheet != null)
            {
                var management = Manager.GetPageData(path, sheet);
                if (management != null)
                {
                    return View(management.Students);
                }
            }
            return View();
        }
    }
}