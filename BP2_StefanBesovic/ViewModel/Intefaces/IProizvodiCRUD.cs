using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface IProizvodiCRUD
    {
        void DodajProizvod(string naziv, int cena, string tip, string dodatno, string kuvarJmbg);
        void ObrisiProizvod(string naziv);
        void IzmeniProizvod(string naziv, int cena, string dodatno);
        List<Proizvod> UcitajSveProizvode();
    }
}
