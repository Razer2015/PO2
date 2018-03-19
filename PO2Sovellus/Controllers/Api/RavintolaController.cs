using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PO2Sovellus.ViewModels;
using Sovellus.Data.Repositories;
using Sovellus.Model.Entities;
using System;

namespace PO2Sovellus.Controllers.Api
{
    [Route("api/ravintola")]
    public class RavintolaController : Controller
    {
        private IRavintolaRepository _ravintolaData;

        public RavintolaController(IRavintolaRepository ravintolaData) {
            _ravintolaData = ravintolaData;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            Ravintola malli = _ravintolaData.Hae(id);
            if (malli == null) {
                return BadRequest("Ravintolaa ei löytynyt.");
            }

            return Ok(malli);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]RavintolaApiViewModel malli) {
            if (ModelState.IsValid) {
                Mapper.Initialize(config => { config.CreateMap<RavintolaApiViewModel, Ravintola>(); });
                Ravintola uusi = Mapper.Map<Ravintola>(malli);

                uusi = _ravintolaData.Lisaa(uusi);
                if (uusi != null) {
                    return Created($"api/ravintola/{uusi.Id}", uusi);
                }
            }
            return BadRequest(ModelState);
            //return BadRequest("Ravintolaa ei voitu lisätä.");
        }

        [HttpPut("")]
        public IActionResult Put([FromBody]RavintolaApiViewModel malli) {
            if (ModelState.IsValid) {
                Mapper.Initialize(config => {
                    config.CreateMap<RavintolaApiViewModel, Ravintola>();
                });
                Ravintola muutettava = Mapper.Map<Ravintola>(malli);
                muutettava = _ravintolaData.Muuta(muutettava);
                if (muutettava != null) {
                    return Ok(muutettava);
                }
            }
            return BadRequest(ModelState);
            //return BadRequest("Ravintolaa ei voitu muuttaa.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            Ravintola poistettava = _ravintolaData.Hae(id);
            if (poistettava != null) {
                if (_ravintolaData.Poista(poistettava)) {
                    return Ok();
                }
            }
            return BadRequest("Ravintolaa ei voitu poistaa.");
        }
    }
}
