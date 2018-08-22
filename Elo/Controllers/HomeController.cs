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

        public JsonResult GetTaxasDeCambio(string moeda)
        {
            try
            {
                var retorno = cambioBusiness.GetTaxasDeCambio(moeda);
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
