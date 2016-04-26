using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using ProfileMaker.Models;
using ProfileMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMaker.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<ProfileUser> _signInManager;

        public AuthController(SignInManager<ProfileUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ProfileUser", "App");
            }


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.UserName,
                                                                      vm.Password,
                                                                      true, false);
                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl)
                    {
                        return RedirectToAction("ProfileUser", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                }
            }


            return View();
        }
    }
}
