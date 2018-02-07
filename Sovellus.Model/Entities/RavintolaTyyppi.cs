using System.Collections.Generic;

namespace Sovellus.Model.Entities
{
    public class RavintolaTyyppi
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public ICollection<Ravintola> Ravintolat { get; set; }
    }
}
