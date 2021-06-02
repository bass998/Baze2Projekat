using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IPicaCRUD
    {
        void DodajPice(string naziv, int cena, string velicina);
        void ObrisiPice(string naziv);
        void IzmeniPice(string naziv, int cena, string velicina);
        List<Proizvod> UcitajSvaPica();
    }
}
