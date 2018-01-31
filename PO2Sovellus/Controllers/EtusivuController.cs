using Microsoft.AspNetCore.Mvc;
using PO2Sovellus.Entities;
using PO2Sovellus.Services;
using PO2Sovellus.ViewModels;
using System.Linq;

namespace PO2Sovellus.Controllers
{
    public class EtusivuController : Controller
    {
        ITervehtija _tervehtija;
        private IData<Ravintola> _ravintolaData;

        public EtusivuController(ITervehtija tervehtija, IData<Ravintola> ravintolaData) {
            _tervehtija = tervehtija;
            _ravintolaData = ravintolaData;
        }

        public IActionResult Index() {
            var data = new EtusivuViewModel {
                Ravintolat = _ravintolaData.HaeKaikki(),
                Otsikko = _tervehtija.GetTervehdys()
            };

            return View(data);
        }

        public IActionResult Tiedot(int id) {
            var ravintolat = _ravintolaData.HaeKaikki();
            return View(ravintolat.FirstOrDefault(x => x.Id.Equals(id)));
        }

        [HttpGet]
        public IActionResult Uusi() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Uusi(RavintolaEditViewModel malli) {
            if (!ModelState.IsValid) {
                return View();
            }

            var uusi = new Ravintola {
                Nimi = malli.Nimi
            };

            uusi = _ravintolaData.Lisaa(uusi);

            //return View("Tiedot", uusi);

            return RedirectToAction("Tiedot", new { id = uusi.Id });
        }
    }
}
