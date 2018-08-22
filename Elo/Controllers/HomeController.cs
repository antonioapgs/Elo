using Elo.Business.Contract;
using Elo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;

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
                return Json(new { success = true, response = retorno });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, response = ex.Message });
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
