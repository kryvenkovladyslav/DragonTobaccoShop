using EmailMessaging.Common.Data.Models;
using EmailMessaging.Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Messages;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailManagerService emailManagerService;

        public HomeController(IEmailManagerService emailManagerService)
        {
            this.emailManagerService = emailManagerService;
        }

        public IActionResult Index()
        {
           var email = new ConfirmAccountMessage("feredico.gattuso@gmail.com")
            {
                To = "feredico.gattuso@gmail.com",
                From = "vladyslav.kryvenko@nure.ua"
            };

            emailManagerService.SendEmail(email);

            return View();
        }
    }
}