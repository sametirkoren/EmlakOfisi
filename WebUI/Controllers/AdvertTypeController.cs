using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdvertTypeController:Controller
    {
        private IAdvertTypeService _advertTypeService;

        public AdvertTypeController(IAdvertTypeService advertTypeService)
        {
            _advertTypeService = advertTypeService;
        }


        public IActionResult Index()
        {
            return View(_advertTypeService.GetList().ToList());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var advertType = _advertTypeService.GetById(id);
            return View(advertType.Data);
        }

        [HttpPost]

        public IActionResult Edit(AdvertType advertType)
        {
            if (ModelState.IsValid)
            {
                var advertTypeUpdated = new AdvertType
                {
                    Id = advertType.Id,
                    Name = advertType.Name
                };
                var advertTypeUpdate = _advertTypeService.Update(advertTypeUpdated);
                TempData["WarningMessage"] = advertTypeUpdate.Message;
                return RedirectToAction("Index", "AdvertType");
            }

            return View(advertType);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(AdvertType advertType)
        {
            var advertTypeResult = _advertTypeService.Add(advertType);
            TempData["SuccessMessage"] = advertTypeResult.Message;
            return RedirectToAction("Index", "Admin");
        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            var advertType = _advertTypeService.GetById(id);
            return View(advertType.Data);
        }


        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirm(AdvertType advertType)
        {
            var advertTypeDelete = _advertTypeService.Delete(advertType);
            TempData["DangerMessage"] = advertTypeDelete.Message;
            return RedirectToAction("Index", "AdvertType");
        }
    }
}
