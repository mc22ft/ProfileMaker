using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using ProfileMaker.Models;
using ProfileMaker.Services;
using ProfileMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileMaker.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailSevice;
        private IWorldRepository _repository;
        private IProfileMakerRepository _profileMakerRepository;

        public AppController(IMailService service, 
            IWorldRepository repository,
            IProfileMakerRepository profileMakerRepository)
        {
            _mailSevice = service;
            _repository = repository;
            _profileMakerRepository = profileMakerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ProfileUser()
        {
            //ProfileUser
            var users = _profileMakerRepository.GetAllProfileUsers();
            //World - Not in use...
            var trips = _repository.GetAllTrips();
            return View(users);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Kunde inte sände email, config error!");
                }

                if (_mailSevice.SendMail(email,
                    email,
                    $"Contact Page from {model.Name} ({model.Email})",
                    model.Message))
                {
                    ModelState.Clear();

                    ViewBag.Message = "Meddelandet är skickat, tack!";
                }
               
            }

            return View();
        }
    }



}
