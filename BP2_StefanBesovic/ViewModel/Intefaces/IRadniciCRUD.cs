using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IRadniciCRUD
    {
        void DodajRadnika(string jmbg, string ime, string prezime, string brojTelefona, string uloga);
        void ObrisiRadnika(string jmbg);
        void IzmeniRadnika(string jmbg, string ime, string prezime, string brojTelefona);
        List<Radnik> UcitajSveRadnike();
    }
}
