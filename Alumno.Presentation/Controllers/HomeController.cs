﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Alumno.Presentation.Models;
using Alumno.BusinessLogic.Implementation;

namespace Alumno.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<string> LoadSheetInformation(string path) {
            return Manager.GetSheetList(path);
        }

        [HttpPost]
        public bool LoadData(string path, string sheet) {
            if (Manager.AddSourceData(path, sheet, 1, 5, true) != null) {
                HttpContext.Session.SetString("Path", Manager.CalculateMD5Hash(path));
                HttpContext.Session.SetString("Sheet", sheet);
                return true;
            }
            HttpContext.Session.Remove("Sheet");
            HttpContext.Session.Remove("Path");
            return false;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
