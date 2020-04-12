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
    public class RealEstateController : Controller
    {
        private IAuthService _authService;
        private IRealEstateService _realEstateService;

        public RealEstateController(IAuthService authService, IRealEstateService realEstateService)
        {
            _authService = authService;
            _realEstateService = realEstateService;
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
        public IActionResult Edit(RealEstate realEstate , string password)
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
                    return RedirectToAction("Index", "RealEstate");
                }
            }
            else
            {
                TempData["DangerMessage"] = realEstateIsAlready.Message;
               
            }
           

            return View(realEstate);


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
            return RedirectToAction("Index", "RealEstate");
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

    }
}