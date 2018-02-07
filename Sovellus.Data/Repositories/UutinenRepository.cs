using System;
using System.Collections.Generic;
using System.Text;
using Sovellus.Model.Entities;
using System.Linq;

namespace Sovellus.Data.Repositories
{
    public class UutinenRepository : EntityBaseRepository, IUutinenRepository
    {
        public UutinenRepository(SovellusContext sovellusContext) : base(sovellusContext) {
        }

        public Uutinen Hae(long id) {
            return _context.Uutiset.FirstOrDefault(r => r.Id == id);
        }

        public ICollection<Uutinen> HaeKaikki() {
            return _context.Uutiset.ToList();
        }

        public Uutinen Lisaa(Uutinen uusi) {
            var id = _context.Uutiset.Count() > 0 ? _context.Uutiset.Max(r => r.Id) + 1 : 1;
            uusi.Id = id;
            _context.Uutiset.Add(uusi);
            _context.SaveChanges();
            return uusi;
        }

        public Uutinen Muuta(Uutinen muutettava) {
            var r = Hae(muutettava.Id);
            if (r == null) {
                return null;
            }

            r.RavintolaId = muutettava.RavintolaId;
            r.Teksti = muutettava.Teksti;
            r.Aika = muutettava.Aika;
            r.JulkaisuAika = muutettava.JulkaisuAika;
            _context.SaveChanges();
            return r;
        }

        public bool Poista(Uutinen poistettava) {
            var r = Hae(poistettava.Id);
            if (r == null) {
                return false;
            }

            _context.Uutiset.Remove(r);
            _context.SaveChanges();
            return true;
        }
    }
}
