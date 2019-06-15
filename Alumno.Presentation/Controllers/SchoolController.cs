using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alumno.BusinessLogic.Implementation;
using Alumno.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
                ViewBag.SelectedSizePage = 5;
                ViewBag.Page = 1;
                ViewBag.TotalStudent = 11;
                var management = Manager.GetPageData(path, sheet);
                if (management != null)
                {
                    var usersAsIPagedList = new StaticPagedList<StudentData>(management.Students, ViewBag.Page, ViewBag.SelectedSizePage, ViewBag.TotalStudent);
                    return View(usersAsIPagedList);
                }
            }
            return View();
        }
    }
}