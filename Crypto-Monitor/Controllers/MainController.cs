using BusinessLogicLayer.Functionality;
using Crypto_Monitor.DataTransferModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_Monitor.Controllers
{
    [Route("Main")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private CryptaServices _CryptaApi;

        public MainController(ILogger<MainController> logger, CryptaServices CryptaApi)
        {
            _logger = logger;
            _CryptaApi = CryptaApi;
        }

        [Route("StartPage")]
        public IActionResult StartPage()
        {
            return View("StartPage");
        }
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
