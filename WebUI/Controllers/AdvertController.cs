using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AdvertController : Controller
    {
        private IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public IActionResult Index()
        {
            var model = new AdvertListViewModel
            {
                Adverts = _advertService.GetList()

            };

            return View(model.Adverts);

        }
    }
}