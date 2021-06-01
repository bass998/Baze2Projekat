using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IRestoraniCRUD
    {
        void DodajRestoran(string naziv, string adresa, string grad, string brojTelefona, string vlasnikJmbg);
        void ObrisiRestoran(string naziv);
        void IzmeniRestoran(string naziv, string adresa, string grad, string brojTelefona, string vlasnikJmbg);
        List<Restoran> UcitajSveRestorane();
    }
}
