using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AdvertController : Controller
    {
        private IAdvertService _advertService;
        private IProvinceService _provinceService;
        private IWebHostEnvironment _hostEnvironment;
        private IHeatingService _heatingService;
        private IAdvertTypeService _advertTypeService;
        private IRealEstateService _realEstateService;

        public AdvertController(IAdvertService advertService, IWebHostEnvironment hostEnvironment, IProvinceService provinceService, IAdvertTypeService advertTypeService, IHeatingService heatingService)
        {
            _advertService = advertService;
            _hostEnvironment = hostEnvironment;
            _provinceService = provinceService;
            _advertTypeService = advertTypeService;
            _heatingService = heatingService;

        }

        public IActionResult Index()
        {
            var model = new AdvertListViewModel
            {
                Adverts = _advertService.GetList()

            };

            return View(model.Adverts);

        }

        public IActionResult Create(int id )
        {
            ViewBag.ProvinceList = _provinceService.GetList();
            ViewBag.HeatingList = _heatingService.GetList();
            ViewBag.AdvertTypeList = _advertTypeService.GetList();

            var realEstate = _realEstateService.GetById(id);

            return View(realEstate.Data.ToString());
        }

        [HttpPost]
        public IActionResult Create(Advert advert)
        {
            
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "resimler");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            foreach (var item in advert.Files)
            {
                using (var fileStream = new FileStream(Path.Combine(filePath, item.FileName), FileMode.Create))
                {
                    item.CopyTo(fileStream);
                }

                advert.Photos.Add(new Photo{FileName = item.FileName});
            }

            _advertService.Add(advert);
            return RedirectToAction(nameof(Index));

        }
    }
}