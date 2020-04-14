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

        
      
      
    }
}