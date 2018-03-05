using Microsoft.AspNetCore.Mvc;

namespace PO2Sovellus.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() {
            return View("Oletus");
        }
    }
}
