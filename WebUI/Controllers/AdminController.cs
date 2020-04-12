using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Security;
using DataTransferObjects;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AdminController:Controller
    {
        private IAuthService _authService;
        private IRealEstateService _realEstateService;
        private IAdvertService _advertService;
        private IAdvertTypeService _advertTypeService;
        private IHeatingService _heatingService;
        private IAdminService _adminService;

        public AdminController(IAuthService authService, IHeatingService heatingService, IAdvertTypeService advertTypeService, IAdvertService advertService, IRealEstateService realEstateService, IAdminService adminService)
        {
            _authService = authService;
            _heatingService = heatingService;
            _advertTypeService = advertTypeService;
            _advertService = advertService;
            _realEstateService = realEstateService;
            _adminService = adminService;
        }


        public IActionResult Index()
        {
            ViewBag.AdvertListCount = _advertService.GetList().Count;
            ViewBag.AdvertTypeListCount = _advertTypeService.GetList().Count;
            ViewBag.RealEstateListCount = _realEstateService.GetList().Count;
            ViewBag.HeatingListCount = _heatingService.GetList().Count;
            return View();
        }


        

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginDto logingDto)
        {
            var adminToLogin = _authService.Login(logingDto);
            if (!adminToLogin.Success)
            {
                return View(adminToLogin);
            }
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(RegisterDto registerDto)
        {
            var exist = _authService.AdminExists(registerDto.UserName);
            if (!exist.Success)
            {
                ViewBag.AlreadyUsername = exist.Message;
                return RedirectToAction("Register", "Admin");
            }
           
            var adminResult = _authService.Register(registerDto);
            return RedirectToAction("Login", "Admin");

        }

        
        public IActionResult List()
        {
            return View(_adminService.GetList());
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var admin = _adminService.GetById(id);
            return View(admin.Data);
        }

        [HttpPost]
        // TODO : Bu kısıma bakılacak update işlmei sırasında aynı Username girildiğinde else düşme durumu
        public IActionResult Edit(Admin admin, string password)
        {
            var adminUsername = admin.UserName;
            var adminIsAlready = _authService.AdminExists(adminUsername);

            var passwordHash = admin.PasswordHash;
            var passwordSalt = admin.PasswordSalt;

            if (adminIsAlready.Success)
            {
                if (ModelState.IsValid)
                {
                    HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                    var adminUpdated = new Admin
                    {
                        Id = admin.Id,
                        UserName = admin.UserName,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    };
                    var adminUpdate = _adminService.Update(adminUpdated);
                    TempData["WarningMessage"] = adminUpdate.Message;
                    return RedirectToAction("List", "Admin");
                }
            }
            else
            {
                TempData["DangerMessage"] = adminIsAlready.Message;

            }

            return View(admin);


        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            var admin = _adminService.GetById(id);
            return View(admin.Data);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirm(Admin admin)
        {
            var adminDelete = _adminService.Delete(admin);
            TempData["DangerMessage"] = adminDelete.Message;
            return RedirectToAction("List", "Admin");
        }



    }


}
