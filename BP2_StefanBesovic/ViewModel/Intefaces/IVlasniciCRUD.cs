using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IVlasniciCRUD
    {
        void DodajVlasnika(string jmbg, string ime, string prezime, string brojTelefona);
        void ObrisiVlasnika(string jmbg);
        void IzmeniVlasnika(string jmbg, string ime, string prezime, string brojTelefona);
        List<Vlasnik> UcitajSveVlasnike();
    }
}
