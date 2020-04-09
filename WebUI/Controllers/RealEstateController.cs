using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
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
                ViewBag.AlreadyUsername = exist.Message;
                return RedirectToAction("Create", "RealEstate");
            }

            var realEstateResult = _authService.RegisterRealEstate(registerDto);
            return RedirectToAction("Index", "Admin");
        }
    }
}