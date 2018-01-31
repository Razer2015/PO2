using System.Collections.Generic;

namespace PO2Sovellus.Services
{
    public interface IData<T>
    {
        IEnumerable<T> HaeKaikki();
        T Hae(int id);
        T Lisaa(T uusi);
    }
}
