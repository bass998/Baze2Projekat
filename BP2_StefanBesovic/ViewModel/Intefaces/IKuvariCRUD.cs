using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IKuvariCRUD
    {
        void DodajKuvara(string jmbg, string ime, string prezime, string brojTelefona);
        void ObrisiKuvara(string jmbg);
        void IzmeniKuvara(string jmbg, string ime, string prezime, string brojTelefona);
        List<Radnik> UcitajSveKuvare();
    }
}
