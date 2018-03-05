using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PO2Sovellus.Entities;
using PO2Sovellus.ViewModels;
using System.Threading.Tasks;

namespace PO2Sovellus.Controllers
{
    [Authorize]
    public class TiliController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public TiliController(UserManager<User> userManager,
                                SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Rekisteroi() {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Rekisteroi(RekisteroiUserViewModel malli) {
            if (ModelState.IsValid) {
                await _userManager.CreateAsync();
            }
            return View();
        }
    }
}
