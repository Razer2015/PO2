using Microsoft.AspNetCore.Mvc;
using System;

namespace PO2Sovellus.Controllers
{
    [Route("[controller]")]
    public class TietojaController : Controller
    {
        [Route("")]
        public string Oikeudet() {
            return ("Copyright (c) Softafirma Co.");
        }

        [Route("[action]/{id}")]
        public string Palaute(string id = "") {
            if (id.Length > 50) {
                id = id.Substring(0, 50) + "...";
            }
            return ($"Palaute saatu {DateTime.Now.ToLocalTime()}. Teksti: {id}");
        }
    }
}
