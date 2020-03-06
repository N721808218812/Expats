using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expats.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expats.Controllers
{
    public class SubCategoriesController : Controller
    {
        ExpatsDatabaseContext entitites;

        public SubCategoriesController()
        {
            entitites = new ExpatsDatabaseContext();
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult AllSubCategories(int id)
        {
            List<SubCategories> lista = new List<SubCategories>();
            var rez = entitites.SubCategories.Where(s => s.Idcategory == id).ToList();

            foreach(var s in rez)
            {
                lista.Add(s);
            }

            return View(lista);
        }
    }
}