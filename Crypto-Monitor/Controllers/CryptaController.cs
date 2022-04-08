using AutoMapper;
using BusinessLogicLayer.Functionality;
using BusinessLogicLayer.Model;
using Crypto_Monitor.DataTransferModels;
using DataAccessLayer.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Сrypto_Monitor.Controllers
{
    [Route("Crypta")]
    public class CryptaController : Controller
    {
        private OrderCryptaServices _order;
        private ExpectedCostApi _expCost;
        private CryptaServices _crypta;
        private IMapper _mapper;
        public CryptaController(CryptaServices cry, OrderCryptaServices oci, ExpectedCostApi exp, IMapper mapper) 
        {
            _order = oci;
            _expCost = exp;
            _crypta = cry;
            _mapper = mapper;
        }

        [HttpGet("CryptaList")]
        public IActionResult CryptaList()
        {
            var role = HttpContext.User.Claims.Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType).Select(c => c.Value).FirstOrDefault();
            if (role == "admin")
            {
                ViewBag.Role = role;
            }
            IEnumerable<CryptaBL> listBL = null;
            try
            {
                listBL = _crypta.GetAll();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            List<CryptaPL> list = _mapper.Map<List<CryptaPL>>(listBL);
            return View("CryptaList", list);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("CryptaChange")]
        public IActionResult CryptaChange([FromForm]CryptaPL item)
        {
            var i = 10;
            return View("CryptaChange");
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("CreateCrypta")]
        public IActionResult CreateCrypta()
        {
            return View("CreateCrypta");
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("CreateCrypta")]
        public async Task<IActionResult> CreateCrypta([FromForm]CryptaPL item)
        {
            string id = HttpContext.User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).FirstOrDefault();            
            var cryptaBL = _mapper.Map<CryptaBL>(item);
            try
            {
                await _crypta.Create(cryptaBL);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction("CryptaList", "Crypta");
            }
            ViewBag.Message = "crypta succesful add";
            return RedirectToAction("CryptaList", "Crypta");
        }
    }
}
