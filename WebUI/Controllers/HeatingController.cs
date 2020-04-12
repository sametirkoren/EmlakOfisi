using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class HeatingController : Controller
    {
        private  IHeatingService _heatingService;

        public HeatingController(IHeatingService heatingService)
        {
            _heatingService = heatingService;
        }


        public IActionResult Index()
        {
            return View(_heatingService.GetList().ToList());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var heatingType = _heatingService.GetById(id);
            return View(heatingType.Data);
        }

        [HttpPost]

        public IActionResult Edit(Heating heating)
        {
            if (ModelState.IsValid)
            {
                var heatingUpdated = new Heating
                {
                    Id = heating.Id,
                    Name = heating.Name
                };
                var heatingUpdate = _heatingService.Update(heatingUpdated);
                TempData["WarningMessage"] = heatingUpdate.Message;
                return RedirectToAction("Index", "Heating");
            }

            return View(heating);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Heating heating)
        {
            var heatingResult = _heatingService.Add(heating);
            TempData["SuccessMessage"] = heatingResult.Message;
            return RedirectToAction("Index", "Admin");
        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            var heating= _heatingService.GetById(id);
            return View(heating.Data);
        }


        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirm(Heating heating)
        {
            var heatingDelete = _heatingService.Delete(heating);
            TempData["DangerMessage"] = heatingDelete.Message;
            return RedirectToAction("Index", "Heating");
        }
    }
}