using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IKupciCRUD
    {
        void DodajKupca(string jmbg, string ime, string prezime, string brojTelefona);
        void ObrisiKupca(string jmbg);
        void IzmeniKupca(string jmbg, string ime, string prezime, string brojTelefona);
        void UkupnaPotrosnja(string jmbg);
        List<Kupac> UcitajSveKupce();
    }
}
