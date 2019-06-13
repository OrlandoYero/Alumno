using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alumno.Presentation.Controllers
{
    public class ListStudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}