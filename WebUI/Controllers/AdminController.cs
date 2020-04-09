using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdminController:Controller
    {
        private IAuthService _authService;

        public AdminController(IAuthService authService)
        {
            _authService = authService;
        }


        public IActionResult Index()
        {
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
            var exist = _authService.Exists(registerDto.UserName);
            if (!exist.Success)
            {
                ViewBag.AlreadyUsername = exist.Message;
                return RedirectToAction("Register", "Admin");
            }
           
            var adminResult = _authService.Register(registerDto);
            return RedirectToAction("Login", "Admin");

        }

    }


}
