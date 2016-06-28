using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WiFiAuth.Web.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
//using Dapper;

namespace WiFiAuth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWiFiAuthService _wifiAuthService;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public HomeController(
            IWiFiAuthService wifiAuthService,
            IEmailSender emailSender,
            ISmsSender smsSender)
        {
            _wifiAuthService = wifiAuthService;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            _wifiAuthService.TestLite();
            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpPost("api/sendcode")]
        public async Task<IActionResult> SendCode(string phoneNumber)
        {
            string result = await _smsSender.SendSmsAsync(phoneNumber, Convert.ToString(((int)(new Random().NextDouble() * 0x100000) << 0)).PadLeft(6, '0'));

            return Content(result);
        }
    }
}
