using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        private INeighborhoodService _neighborhoodService;
        private IPlaceService _placeService;
        private IDistrictService _districtService;

        public AdvertController(IAdvertService advertService, IWebHostEnvironment hostEnvironment, IProvinceService provinceService, IAdvertTypeService advertTypeService, IHeatingService heatingService, INeighborhoodService neighborhoodService, IDistrictService districtService, IPlaceService placeService)
        {
            _advertService = advertService;
            _hostEnvironment = hostEnvironment;
            _provinceService = provinceService;
            _advertTypeService = advertTypeService;
            _heatingService = heatingService;
            _neighborhoodService = neighborhoodService;
            _districtService = districtService;
            _placeService = placeService;
        }

        public IActionResult Index()
        {
            var model = new AdvertListViewModel
            {
                Adverts = _advertService.GetList()

            };

            return View(model.Adverts);

        }
      
      
        public JsonResult GetDistrictById(int id)
        {
            var districtList = _districtService.GetDistrict(id);
            return Json(new SelectList(districtList, "Id", "Name"));
        }


        public JsonResult GetPlaceGetById(int id)
        {
            var placeList = _placeService.GetPlace(id);
            return Json(new SelectList(placeList, "Id", "Name"));
        }

        public JsonResult GetNeighborhoodById(int id)
        {
            var neighborHoodList = _neighborhoodService.GetNeighborhood(id);
            return Json(new SelectList(neighborHoodList, "Id", "Name"));
        }



        public IActionResult Create()
        {

                ViewBag.ProvinceList = _provinceService.GetList();
                ViewBag.HeatingList = _heatingService.GetList();
                ViewBag.AdvertTypeList = _advertTypeService.GetList();

            return View();
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