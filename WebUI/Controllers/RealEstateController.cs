using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Security;
using DataTransferObjects;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class RealEstateController : Controller
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
        private IAuthService _authService;
        private IPhotoService _photoService;

        public RealEstateController(IAuthService authService, IRealEstateService realEstateService, IDistrictService districtService, IPlaceService placeService, INeighborhoodService neighborhoodService, IAdvertTypeService advertTypeService, IHeatingService heatingService, IWebHostEnvironment hostEnvironment, IProvinceService provinceService, IAdvertService advertService, IPhotoService photoService)
        {
            _authService = authService;
            _realEstateService = realEstateService;
            _districtService = districtService;
            _placeService = placeService;
            _neighborhoodService = neighborhoodService;
            _advertTypeService = advertTypeService;
            _heatingService = heatingService;
            _hostEnvironment = hostEnvironment;
            _provinceService = provinceService;
            _advertService = advertService;
            _photoService = photoService;
        }

        public IActionResult List()
        {

            return View(_realEstateService.GetList().ToList());
        }

        public IActionResult Index()
        {

            return View(_realEstateService.GetList().ToList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var realEstate = _realEstateService.GetById(id);
            return View(realEstate.Data);
        }

        [HttpPost]
        public IActionResult Edit(RealEstate realEstate, string password)
        {
            var realEstateUsername = realEstate.UserName;
            var realEstateIsAlready = _authService.RealEstateExists(realEstateUsername);

            var passwordHash = realEstate.PasswordHash;
            var passwordSalt = realEstate.PasswordSalt;

            if (realEstateIsAlready.Success)
            {
                if (ModelState.IsValid)
                {
                    HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                    var realEstateUpdated = new RealEstate
                    {
                        Id = realEstate.Id,
                        UserName = realEstate.UserName,
                        CompanyName = realEstate.CompanyName,
                        Mail = realEstate.Mail,
                        Address = realEstate.Address,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    };
                    var realEstateUpdate = _realEstateService.Update(realEstateUpdated);
                    TempData["WarningMessage"] = realEstateUpdate.Message;
                    return RedirectToAction("List", "RealEstate");
                }
            }
            else
            {
                TempData["DangerMessage"] = realEstateIsAlready.Message;
            }

            return View(realEstate);

        }

        [HttpGet]
        public IActionResult ChangePassword(int id)
        {
            var realEstate = _realEstateService.GetById(id);
            return View(realEstate.Data);
        }

        [HttpPost]

        public IActionResult ChangePassword(RealEstate realEstate, string password)
        {
            var currentRealEstate = _realEstateService.GetById(realEstate.Id);
            var passwordHash = realEstate.PasswordHash;
            var passwordSalt = realEstate.PasswordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var changePassword = new RealEstate
            {
                Id = currentRealEstate.Data.Id,
                UserName = currentRealEstate.Data.UserName,
                CompanyName = currentRealEstate.Data.CompanyName,
                Mail = currentRealEstate.Data.Mail,
                Address = currentRealEstate.Data.Address,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            var passwordUpdate = _realEstateService.Update(changePassword);
            TempData["WarningMessage"] = passwordUpdate.Message;
            return RedirectToAction("AdvertList", "RealEstate");



        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterDto registerDto)
        {
            var exist = _authService.RealEstateExists(registerDto.UserName);
            if (!exist.Success)
            {
                TempData["DangerMessage"] = exist.Message;
                return RedirectToAction("Create", "RealEstate");
            }

            var realEstateResult = _authService.RegisterRealEstate(registerDto);
            TempData["SuccessMessage"] = realEstateResult.Message;
            return RedirectToAction("Index", "Admin");
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            var realEstateToLogin = _authService.LoginRealEstate(loginDto);
            if (!realEstateToLogin.Success)
            {
                return View(realEstateToLogin);
            }
            var realEstateInfo = _realEstateService.GetByUsername(realEstateToLogin.Data.UserName);
            HttpContext.Session.SetObject("realestate", realEstateInfo);
           
            return RedirectToAction("AdvertList", "RealEstate");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("realestate");
            HttpContext.Session.Clear();
            return RedirectToAction("AdvertList", "RealEstate");
        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            var realEstate = _realEstateService.GetById(id);
            return View(realEstate.Data);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirm(RealEstate realEstate)
        {
            var realEstateDelete = _realEstateService.Delete(realEstate);
            TempData["DangerMessage"] = realEstateDelete.Message;
            return RedirectToAction("Index", "RealEstate");
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



        public IActionResult AdvertAdd(int id)
        {
            ViewBag.ProvinceList = _provinceService.GetList();
            ViewBag.HeatingList = _heatingService.GetList();
            ViewBag.AdvertTypeList = _advertTypeService.GetList();
            var realEstate = _realEstateService.GetById(id);

            var realEstateData = realEstate.Data;
           
            

            return View(realEstateData);
        } 

        [HttpPost]
        public IActionResult AdvertAdd(Advert advert)
        {
            advert.ListingDate = DateTime.Now;

            var advertAdd = _advertService.Add(advert);
            if (ModelState.IsValid)
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

                    advert.Photos.Add(new Photo { FileName = item.FileName , AdvertId = advert.Id});
                    
                }
                foreach (var photo in advert.Photos)
                {
                    _photoService.Add(photo);
                }
          
             
                TempData["SuccessMessage"] = advertAdd.Message;

                return RedirectToAction("AdvertList","RealEstate");

            }


            return View();


        }


        public IActionResult AdvertList(string sortOrder)
        {
            ViewBag.PriceSortParam = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";

            
            var realEstateSession = HttpContext.Session.GetObject<RealEstate>("realestate");

            if (realEstateSession == null)
            {
                return RedirectToAction("Login", "RealEstate");
            }
           
            ViewBag.ProvinceList = _provinceService.GetList();
            ViewBag.HeatingList = _heatingService.GetList();
            ViewBag.AdvertTypeList = _advertTypeService.GetList();
            ViewBag.AdvertList = _advertService.GetAll().Count;

            List<AdvertForListDto> advertList= _advertService.GetList(realEstateSession.Id);

            var Adverts = advertList;
            switch (sortOrder)
            {
                case "price_desc":
                    Adverts = Adverts.OrderByDescending(x => x.Price).ToList();
                    break;
                default:
                    Adverts = Adverts.OrderBy(x => x.Price).ToList();
                    break;
            }

            return View(advertList);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var advert = _advertService.GetById(id);
            var advertModel = _advertService.Get(advert.Data.Id);
            return View(advertModel);
        }


        public IActionResult AdvertEdit(int id)
        {
            ViewBag.ProvinceList = _provinceService.GetList();
            ViewBag.HeatingList = _heatingService.GetList();
            ViewBag.AdvertTypeList = _advertTypeService.GetList();
            var advert = _advertService.GetById(id);
            var advertModel = _advertService.GetByPhoto(advert.Data.Id);
            return View(advertModel);
        }

        [HttpPost]
        public IActionResult AdvertEdit(Advert advert)
        {
            var advertModel = _advertService.GetByPhoto(advert.Id);
            var realEstateSession = HttpContext.Session.GetObject<RealEstate>("realestate");
            if (ModelState.IsValid)
            {
                var advertUpdated = new Advert
                {
                    Id = advert.Id,
                    RoomCount = advert.RoomCount,
                    BuildAge = advert.BuildAge,
                    BuildFloor = advert.BuildFloor,
                    Floor = advert.Floor,
                    SquareMeter = advert.SquareMeter,
                    Description = advert.Description,
                    Title = advert.Title,
                    Address = advert.Address,
                    IsLive = advert.IsLive,
                    Price = advert.Price,
                    RealEstateId = realEstateSession.Id,
                    AdvertTypeId = advert.AdvertTypeId,
                    HeatingId = advert.HeatingId,
                    PlaceId = advert.PlaceId,
                    ProvinceId = advert.ProvinceId,
                    DistrictId = advert.DistrictId,
                    NeighborhoodId = advert.NeighborhoodId,
                    ListingDate = DateTime.Now,
                    Photos = advertModel.Photos
                    


                };
                var advertUpdate = _advertService.Update(advertUpdated);
                TempData["WarningMessage"] = advertUpdate.Message;
                return RedirectToAction("AdvertList", "RealEstate");
            }

            return View();

        }

    }
}