using System.Collections.Generic;

namespace Sovellus.Model.Entities
{
    public class Alue
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public ICollection<Kaupunki> Kaupungit { get; set; }
    }
}
