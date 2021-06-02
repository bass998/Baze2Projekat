using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Intefaces
{
    public interface INudiCRUD
    {
        void DodajPonudu(string nazivRestorana, string nazivProizvoda);
        void ObrisiPonudu(string nazivRestorana, string nazivProizvoda);
        List<Nudi> UcitajPonude();
    }
}
