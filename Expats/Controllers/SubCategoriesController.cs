using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Expats.Controllers
{
    public class SubCategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}