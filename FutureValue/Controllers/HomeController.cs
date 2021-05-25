using FutureValue.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValue.Controllers
{
    public class HomeController : Controller
    {
        //happens when theres a get request, for this app it is on startup
        [HttpGet]
        public IActionResult Index()
        {
            //temporary values we did when starting the app. 
            ViewBag.Name = "Mary";
            //temporary values we did when starting the app. 
            ViewBag.FV = 99999.99;
            return View();
        }
        /// <summary>
        /// Http post request, verifies there were no errors and then does the calculations
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(FutureValueModel model)
        {
            //if there were no errors we continue to call the calculatefuturevalue method and assign it to the Viewbag.FV variable.
            if (ModelState.IsValid)
            {
            ViewBag.FV = model.CalculateFutureValue();

            }
            //else we assign Viewbag.fv the value of 0.
            else
            {
                ViewBag.FV = 0;
            }
            //returns the FutureValueModel passed in
            return View(model);
        }
    }
}
