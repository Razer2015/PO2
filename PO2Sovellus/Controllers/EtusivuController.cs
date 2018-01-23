using Microsoft.AspNetCore.Mvc;
using PO2Sovellus.Models;
using PO2Sovellus.Services;

namespace PO2Sovellus.Controllers
{
    public class EtusivuController : Controller
    {
        private IData<Henkilo> _henkiloData;

        public EtusivuController(IData<Henkilo> henkiloData) {
            _henkiloData = henkiloData;
        }

        public IActionResult Index() {
            //return Content("Terveisiä Etusivu-ohjaimesta (EtusivuController)");
            //return new ObjectResult(Henkilo.GeneroiData(10));
            var data = _henkiloData.HaeKaikki();
            return View(data);
        }
    }
}
