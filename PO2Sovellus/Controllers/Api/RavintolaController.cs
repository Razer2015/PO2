using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger<RavintolaController> _logger;

        public RavintolaController(IRavintolaRepository ravintolaData, ILogger<RavintolaController> logger) {
            _ravintolaData = ravintolaData;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                Ravintola malli = _ravintolaData.Hae(id);
                if (malli == null) {
                    return BadRequest("Ravintolaa ei löytynyt.");
                }

                return Ok(malli);
            }
            catch (Exception e) {
                _logger.LogError($"Ravintolan haku epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei löytynyt.");
            }
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]RavintolaApiViewModel malli) {
            try {
                if (ModelState.IsValid) {
                    // Siirretty App_Start -> AutoMapperConfig, jota kutsutaan kerran Startup luokasta, koska
                    // Mapper.Initialize kutsu kaksi kertaa peräkkäin tuottaa virheen. Virhe johtuu vissiin Mapperin uudesta versiosta.

                    //Mapper.Initialize(config =>
                    //{
                    //    config.CreateMap<RavintolaApiViewModel, Ravintola>();
                    //});
                    Ravintola uusi = Mapper.Map<Ravintola>(malli);

                    uusi = _ravintolaData.Lisaa(uusi);
                    if (uusi != null) {
                        return Created($"api/ravintola/{uusi.Id}", uusi);
                    }
                }
                return BadRequest(ModelState);
                //return BadRequest("Ravintolaa ei voitu lisätä.");
            }
            catch (Exception e) {
                _logger.LogError($"Ravintolan lisääminen epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei voitu lisätä.");
            }
        }

        [HttpPut("")]
        public IActionResult Put([FromBody]RavintolaApiViewModel malli) {
            try {
                if (ModelState.IsValid) {
                    // Siirretty App_Start -> AutoMapperConfig, jota kutsutaan kerran Startup luokasta, koska
                    // Mapper.Initialize kutsu kaksi kertaa peräkkäin tuottaa virheen. Virhe johtuu vissiin Mapperin uudesta versiosta.

                    //Mapper.Initialize(config =>
                    //{
                    //    config.CreateMap<RavintolaApiViewModel, Ravintola>();
                    //});
                    Ravintola muutettava = Mapper.Map<Ravintola>(malli);
                    muutettava = _ravintolaData.Muuta(muutettava);
                    if (muutettava != null) {
                        return Ok(muutettava);
                    }
                }
                return BadRequest(ModelState);
                //return BadRequest("Ravintolaa ei voitu muuttaa.");
            }
            catch (Exception e) {
                _logger.LogError($"Ravintolan muuttaminen epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei voitu muuttaa.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                Ravintola poistettava = _ravintolaData.Hae(id);
                if (poistettava != null) {
                    if (_ravintolaData.Poista(poistettava)) {
                        return Ok();
                    }
                }
                return BadRequest("Ravintolaa ei voitu poistaa.");
            }
            catch (Exception e) {
                _logger.LogError($"Ravintolan poistaminen epäonnistui: {e.Message} {e.InnerException?.Message}");
                return BadRequest("Ravintolaa ei voitu poistaa.");
            }
        }
    }
}
