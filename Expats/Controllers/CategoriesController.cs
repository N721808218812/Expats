using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expats.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Expats.Controllers
{

    public class CategoriesController : Controller
    {
        public ExpatsDatabaseContext entities;

        public CategoriesController()
        {
            entities = new ExpatsDatabaseContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        
        public IEnumerable<Categories> All()
        {
            List<Categories> lista = new List<Categories>();
           foreach(Categories c in entities.Categories)
            {
                lista.Add(c);
            }

            return lista;
        }

        public IActionResult AllCategories()
        {
            return View(All());
        }
    }
}