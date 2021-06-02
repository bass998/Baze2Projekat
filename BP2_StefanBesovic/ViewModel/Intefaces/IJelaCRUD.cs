using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IJelaCRUD
    {
        void DodajJelo(string naziv, int cena, string sastojci, string kuvarJmbg);
        void ObrisiJelo(string naziv);
        void IzmeniJelo(string naziv, int cena, string sastojci);
        List<Proizvod> UcitajSvaJela();
    }
}
