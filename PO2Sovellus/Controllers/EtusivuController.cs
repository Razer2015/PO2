using Microsoft.AspNetCore.Mvc;
using Sovellus.Model.Entities;
using PO2Sovellus.Services;
using PO2Sovellus.ViewModels;
using System.Linq;
using Sovellus.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace PO2Sovellus.Controllers
{
    [Authorize]
    public class EtusivuController : Controller
    {
        ITervehtija _tervehtija;
        private IRavintolaRepository _ravintolaData;


        public EtusivuController(ITervehtija tervehtija, IRavintolaRepository ravintolaData) {
            _tervehtija = tervehtija;
            _ravintolaData = ravintolaData;
        }

        [AllowAnonymous]
        public IActionResult Index() {
            var data = new EtusivuViewModel {
                Ravintolat = _ravintolaData.HaeKaikki(true),
                Otsikko = _tervehtija.GetTervehdys()
            };

            return View(data);
        }

        public IActionResult Tiedot(int id) {
            var ravintola = _ravintolaData.Hae(id, true);

            if (ravintola == null) {
                return RedirectToAction(nameof(Index));
            }

            return View(ravintola);
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

        [HttpGet]
        public IActionResult Muuta(int id) {
            var ravintola = _ravintolaData.Hae(id);
            if (ravintola == null) {
                return RedirectToAction(nameof(Index));
            }

            var nakyma = new RavintolaEditViewModel {
                Id = ravintola.Id,
                Katuosoite = ravintola.Katuosoite,
                KaupunkiId = ravintola.KaupunkiId,
                KotisivuUrl = ravintola.KotisivuUrl,
                KuvaUrl = ravintola.KuvaUrl,
                Nimi = ravintola.Nimi,
                Postinro = ravintola.Postinro,
                TyyppiId = ravintola.TyyppiId,
                RavintolaTyypit = _ravintolaData.HaeRavintolaTyypit(),
                Kaupungit = _ravintolaData.HaeKaupungit()
            };

            return View(nakyma);
        }

        [HttpPost]
        public IActionResult Muuta(int id, RavintolaEditViewModel muutettu) {
            var ravintola = _ravintolaData.Hae(id);
            if (!ModelState.IsValid) {
                muutettu.RavintolaTyypit = _ravintolaData.HaeRavintolaTyypit();
                muutettu.Kaupungit = _ravintolaData.HaeKaupungit();
                return View(muutettu);
            }

            ravintola.Nimi = muutettu.Nimi;
            ravintola.KaupunkiId = muutettu.KaupunkiId;
            ravintola.TyyppiId = muutettu.TyyppiId;
            ravintola.Katuosoite = muutettu.Katuosoite;
            ravintola.Postinro = muutettu.Postinro;
            ravintola.KotisivuUrl = muutettu.KotisivuUrl;
            ravintola.KuvaUrl = muutettu.KuvaUrl;

            _ravintolaData.Muuta(ravintola);

            return RedirectToAction("Tiedot", new { id = muutettu.Id });
        }
    }
}
