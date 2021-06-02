using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IKonobariCRUD
    {
        void DodajKonobara(string jmbg, string ime, string prezime, string brojTelefona);
        void ObrisiKonobara(string jmbg);
        void IzmeniKonobara(string jmbg, string ime, string prezime, string brojTelefona);
        List<Radnik> UcitajSveKonobare();
    }
}
