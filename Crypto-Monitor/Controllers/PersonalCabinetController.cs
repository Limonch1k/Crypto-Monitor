using AutoMapper;
using BusinessLogicLayer.Functionality;
using BusinessLogicLayer.Model;
using Crypto_Monitor.DataTransferModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сrypto_Monitor.Controllers
{
    [Route("PersonalCab")]
    public class PersonalCabinetController : Controller
    {
        private UserRegistredServices _user;
        private IMapper _mapper;
        private OrderCryptaServices _order;
        private ExpectedCostApi _exp;
        public PersonalCabinetController(UserRegistredServices user, OrderCryptaServices order, ExpectedCostApi exp, IMapper mapper) 
        {
            _user = user;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("PersonalData")]
        public async Task<IActionResult> PersonalData()
        {
            string id = HttpContext.User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            UserRegistredBL userBL = null;
            try
            {
                userBL = await _user.FindById(Int32.Parse(id));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            var user = _mapper.Map<UserRegistred>(userBL);
            return View("PersonalData", user);
        }


        [Authorize]
        [HttpGet("OrderStory")]
        public async Task<IActionResult> OrderStory() 
        {
            string id = HttpContext.User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            UserRegistredBL userBL = null;
            IEnumerable<OrderBL> orderStory = null;
            try
            {
                userBL = await _user.FindById(Int32.Parse(id));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("OrderStory", orderStory);
            }
            var user = _mapper.Map<UserRegistred>(userBL);
            try
            {
                orderStory = _order.GetAll().Where(c => c.UserId == Int32.Parse(id));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("OrderStory", orderStory);
            }
            return View("OrderStory", orderStory);
        }

        [Authorize]
        [HttpGet("ExpectedCostList")]
        public async Task<IActionResult> ExpectedCostList()
        {
            string id = HttpContext.User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            UserRegistredBL userBL = null;
            try
            {
                userBL = await _user.FindById(Int32.Parse(id));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            var user = _mapper.Map<UserRegistred>(userBL);
            var expCostStory = _exp.GetAll().Where(c => c.UserId == Int32.Parse(id));
            return View("ExpectedCostList", expCostStory);
        }
    }
}
