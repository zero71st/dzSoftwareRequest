using System;
using System.Threading.Tasks;
using dz.SoftwareRequest.Models;
using dz.SoftwareRequest.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dz.SoftwareRequest.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManger = signInManager;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManger.PasswordSignInAsync(model.Email,model.Password,false,lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Request");
                }
                else
                {
                    ModelState.AddModelError(String.Empty,"Invalid username or password");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model,string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if(ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName = model.Email,Email = model.Email};
                var result = await _userManager.CreateAsync(user,model.Password);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Account");
                }
                AddErrors(result);
            }
            
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty,error.Description);
            }
        }
    }
}