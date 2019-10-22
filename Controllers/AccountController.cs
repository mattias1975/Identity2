using System.Linq;
using System.Threading.Tasks;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity.Models;

namespace Identity.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public Microsoft.AspNetCore.Identity.SignInResult SignInResultr { get; private set; }

        public AccountController(RoleManager<IdentityRole> roleManager,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager)// Constructor Injection´s
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginVM SignIn)
        {

            if (ModelState.IsValid) 
                
            {
                SignInResultr = await _signInManager.PasswordSignInAsync(SignIn.UserName, SignIn.Password, false, false);

                switch (SignInResultr.ToString())
                {
                    case "Succeeded":
                        return RedirectToAction("Index", "Home");

                    case "Failed":
                        ViewBag.msg = "Failed - Username of/and Password is incorrect";
                        break;
                    case "Lockedout":
                        ViewBag.msg = "Locked Out";
                        break;
                    default:
                        ViewBag.msg = SignInResultr.ToString();
                        break;
                }
            }



            return View();

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserVM createUser)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser() { UserName = createUser.UserName, Email = createUser.Email };
                var result = await _userManager.CreateAsync(user, createUser.Password);

                if (result.Succeeded)
                {
                    ViewBag.msg = "User was created.";
                    return RedirectToAction("CreateUser");
                }
                else
                {
                    ViewBag.errorlist = result.Errors;
                }
            }

            return View(createUser);
        }

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return View();
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(name));

            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }

            return View("AddRole", name);
        }

        [HttpGet]
        public IActionResult AddUserToRole(string role)
        {
            ViewBag.Role = role;

            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToRoleSave(string userId, string roleId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            //var result = await _userManager.AddToRoleAsync(user, roleId);
            return RedirectToAction(nameof(RoleList));
        }
    }
}


 

  

    
