using BusinessLogicLayer.Functionality;
using BusinessLogicLayer.Model;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Crypto_Monitor.DataTransferModels;
using AutoMapper;

namespace Сrypto_Monitor.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private UserRegistredServices _user;
        private IMapper _mapper;
        public LoginController(UserRegistredServices user, IMapper mapper) 
        {
            _user = user;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Registration")]
        public IActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromForm] UserRegistred user) 
        {
            if (ModelState.IsValid) 
            {
                UserRegistredBL userBL = _mapper.Map<UserRegistredBL>(user);
                await _user.Create(userBL);
                userBL = _user.FindByEmail(user.Email);
                if (user != null) 
                {
                    await Authenticate(userBL.Email, userBL.Id.ToString(), userBL.Role);

                    return RedirectToAction("StartPage", "Main");
                }
            }
            return View("Registration");
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] UserLogin user) 
        {
            if (ModelState.IsValid) 
            {
                var us = _user.FindByEmail(user.Email);
                if (us != null)
                {
                    await Authenticate(us.Email, us.Id.ToString(), us.Role);
                    
                    return RedirectToAction("PersonalData", "PersonalCab");
                }
                ViewBag.Message = "not found user in database";
            }
            return View("Login");
        }

        public async Task Authenticate(string userEmail, string userId, string Role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role),
                new Claim("Email", userEmail),
                new Claim("Id", userId)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
