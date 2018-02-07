using System.Collections.Generic;

namespace Sovellus.Model.Entities
{
    public class Kaupunki
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public int AlueId { get; set; }
        public Alue Alue { get; set; }
        public ICollection<Ravintola> Ravintolat { get; set; }
    }
}
