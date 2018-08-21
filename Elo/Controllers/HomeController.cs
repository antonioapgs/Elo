using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Elo.Models;
using Elo.Business.Contract;

namespace Elo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICambioBusiness cambioBusiness;

        public HomeController(ICambioBusiness cambioBusiness)
        {
            this.cambioBusiness = cambioBusiness;
        }

        public IActionResult Index()
        {
            var retorno = cambioBusiness.GetTaxasDeCambio("EUR");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
