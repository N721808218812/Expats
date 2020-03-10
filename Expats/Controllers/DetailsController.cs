using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Expats.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expats.Controllers
{

    public class DetailsController : Controller
    {
        ExpatsDatabaseContext entities;

        public DetailsController()
        {
            entities = new ExpatsDatabaseContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllDetails(int id)
        {
            var rez = entities.Details.Where(s => s.Idlist == id).FirstOrDefault();


            if (rez == null)
            {
                return View("NoCategories");
            }
            else
            {
                return View(rez);

            }
        }
    }
}