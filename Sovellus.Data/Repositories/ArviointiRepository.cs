using System;
using System.Collections.Generic;
using System.Text;
using Sovellus.Model.Entities;
using System.Linq;

namespace Sovellus.Data.Repositories
{
    public class ArviointiRepository : EntityBaseRepository, IArviointiRepository
    {
        public ArviointiRepository(SovellusContext sovellusContext) : base(sovellusContext) {
        }

        public Arviointi Hae(long id) {
            return _context.Arvioinnit.FirstOrDefault(r => r.Id == id);
        }

        public ICollection<Arviointi> HaeKaikki() {
            return _context.Arvioinnit.ToList();
        }

        public List<Arviointi> HaeRavintolanUusimmat(int id, int lkm = 5) {
            return _context.Arvioinnit
                        .Where(a => a.RavintolaId == id)
                        .OrderByDescending(a => a.Aika)
                        .Take(lkm)
                        .ToList();
        }

        public Arviointi Lisaa(Arviointi uusi) {
            //var id = _context.Arvioinnit.Count() > 0 ? _context.Arvioinnit.Max(r => r.Id) + 1 : 1;
            //uusi.Id = id;
            _context.Arvioinnit.Add(uusi);
            _context.SaveChanges();
            return uusi;
        }

        public Arviointi Muuta(Arviointi muutettava) {
            var r = Hae(muutettava.Id);
            if (r == null) {
                return null;
            }

            r.RavintolaId = muutettava.RavintolaId;
            r.Arvio = muutettava.Arvio;
            r.Teksti = muutettava.Teksti;
            r.HintaLaatu = muutettava.HintaLaatu;
            r.Palvelu = muutettava.Palvelu;
            r.Ymparisto = muutettava.Ymparisto;
            r.Aika = muutettava.Aika;
            _context.SaveChanges();
            return r;
        }

        public bool Poista(Arviointi poistettava) {
            var r = Hae(poistettava.Id);
            if (r == null) {
                return false;
            }

            _context.Arvioinnit.Remove(r);
            _context.SaveChanges();
            return true;
        }
    }
}
