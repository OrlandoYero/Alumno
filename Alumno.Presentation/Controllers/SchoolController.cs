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
        public IActionResult Index(int? selectedSizePage = 5, int? page = 1)
        {
            var sheet = HttpContext.Session.GetString("Sheet");
            var path = HttpContext.Session.GetString("Path");
            if (sheet != null)
            {
                ViewBag.SelectedSizePage = selectedSizePage;
                ViewBag.Page = page;

                var management = Manager.GetPageData(path, sheet, page ?? 1, selectedSizePage ?? 5);
                if (management != null)
                {
                    ViewBag.TotalStudent = management.StudentCount;
                    var usersAsIPagedList = new StaticPagedList<StudentData>(management.Students, ViewBag.Page, ViewBag.SelectedSizePage, ViewBag.TotalStudent);
                    return View(usersAsIPagedList);
                }
            }
            return Redirect("../");
        }

        public IActionResult Statistic()
        {
            var sheet = HttpContext.Session.GetString("Sheet");
            var path = HttpContext.Session.GetString("Path");
            if (sheet != null)
            {
                var management = Manager.GetSourceData(path, sheet);
                if (management != null)
                {
                    ViewBag.BestStudent = management.BestStudent;
                    ViewBag.WorstStudent = management.WorstStudent;
                    ViewBag.StudentAverage = management.StudentAverage;                    
                    string value = "[";
                    management.CounterByNote.Values.ToList().ForEach(item =>
                    {
                        if (item != 5) {
                            value += item + ",";
                        }
                    });
                    ViewBag.CounterByNote = value + "10]";
                }
                return View();
            }
            return Redirect("../");
        }
    }
}