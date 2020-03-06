using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Expats.Models;

namespace Expats.Controllers
{
    public class ListController : Controller
    {
        ExpatsDatabaseContext entities;

        public ListController()
        {
            entities = new ExpatsDatabaseContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllList(int id)
        {
            List<Models.List> lista = new List<Models.List>();
            var rez = entities.List.Where(s => s.Idsubcategory == id).ToList();

            foreach (var s in rez)
            {
                lista.Add(s);
            }

            return View(lista);
        }
    }
}