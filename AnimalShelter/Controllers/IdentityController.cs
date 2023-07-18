using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.identity;
using Models.Identity;

namespace AnimalShelterMVC.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public AccountController(UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromForm] LoginVm loginVm)
        {
            var user = await _userManager.FindByNameAsync(loginVm.UserNama);

            if (user == null)
                return Unauthorized();
            else if (await _userManager.IsLockedOutAsync(user))
                return Forbid("Locked");
            else if(await _signInManager.CanSignInAsync(user))
                return Forbid("Locked");

            var signIn = await _signInManager.PasswordSignInAsync(user, loginVm.Password, true, true);

            if(!signIn.Succeeded)
                return Unauthorized("login or pasword faill");


            return View();
        } 
        
        
        public async Task<IActionResult> Registration([FromForm] RegistrationVm registrationVm)
        {
            return View();
        }
    }
}
