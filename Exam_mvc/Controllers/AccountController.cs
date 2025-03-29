using Exam_mvc.Models;
using Exam_mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;


namespace Exam_mvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager { get; } 
        public SignInManager<AppUser> SignInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
         

                AppUser userModel = new AppUser();
                userModel.UserName = newUserVM.UserName;
                userModel.FirstName = newUserVM.FirstName;
                userModel.LastName = newUserVM.LastName;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Job = newUserVM.Job;

                IdentityResult result = await UserManager.CreateAsync(userModel, newUserVM.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(userModel, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Element", errorItem.Description);
                    }
                }
            }

            return View(newUserVM);
        }


        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();  
            return RedirectToAction("Login", "Account");
           
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
             

                AppUser UserFromDb = await UserManager.FindByNameAsync(userVM.UserName);

                if (UserFromDb != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(UserFromDb, userVM.Password);

                    if (found == true)
                    {
                        await SignInManager.SignInAsync(UserFromDb, userVM.RememberMe);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Sorry!! ,Wrong UserName Or Passsword");
            return View(userVM);
        }

    }
}
