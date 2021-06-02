using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class NudiCRUD : INudiCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();
        public void DodajPonudu(string nazivRestorana, string nazivProizvoda)
        {
            try
            {
                Nudi n = new Nudi()
                {
                    RestoranNaziv = nazivRestorana,
                    ProizvodNaziv = nazivProizvoda
                };

                db.Nudis.Add(n);
                db.SaveChanges();
             }
            catch
            {

            }
        }

        public void ObrisiPonudu(string nazivRestorana, string nazivProizvoda)
        {
            try
            {
                if(db.Nudis.Find(nazivRestorana, nazivProizvoda) != null)
                {
                    db.Nudis.Remove(db.Nudis.Find(nazivRestorana, nazivProizvoda));
                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }

        public List<Nudi> UcitajPonude()
        {
            List<Nudi> ponude = new List<Nudi>();

            try
            {
                ponude = db.Nudis.ToList();
            }
            catch
            {

            }

            return ponude;
        }
    }
}
