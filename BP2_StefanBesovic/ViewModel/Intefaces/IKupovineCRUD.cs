using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IKupovineCRUD
    {
        void DodajKupovinu(string nazivRestorana, string nazivProizvoda, string kupacJmbg, string konobarJmbg);
        void ObrisiKupovinu(string nazivRestorana, string nazivProizvoda, string kupacJmbg, string konobarJmbg);
        void ImeVlasnika(string kupacJmbg, string nazivRestorana);
        List<Kupuje> UcitajKupovine();
    }
}
