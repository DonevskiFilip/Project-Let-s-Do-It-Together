using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebViewModels;

namespace LDTWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult LogInUser()
        {
            return View(new LogInViewModel());
        }
        [HttpPost]
        public IActionResult LogInUser(LogInViewModel user)
        {
            var LogedInUser = _userService.LogInUser(user);
            return RedirectToAction("UserProfilePage", LogedInUser);
        }
        public IActionResult UserProfilePage(UserViewModel user)
        {
            return View(user);
        }
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public IActionResult RegisterUser(RegisterViewModel user)
        {
            _userService.RegisterUser(user);
            return RedirectToAction("GetAllUsers");
        }
        public IActionResult GetAllUsers()
        {
            return View(_userService.GetAllUsers());
        }

    }
}