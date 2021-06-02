using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class KupovineCRUD : IKupovineCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();
        public void DodajKupovinu(string nazivRestorana, string nazivProizvoda, string kupacJmbg, string konobarJmbg)
        {
            try
            {
                if(db.Radnici.Find(konobarJmbg) != null && db.Kupci.Find(kupacJmbg) != null)
                {
                    if(db.Radnici.Find(konobarJmbg).TipRadnika == "Konobar")
                    {
                        Kupuje n = new Kupuje()
                        {
                            NudiRestoranNaziv = nazivRestorana,
                            NudiProizvodNaziv = nazivProizvoda,
                            KupacJmbg = kupacJmbg,
                            KonobarJmbg = konobarJmbg
                        };

                        db.Kupovine.Add(n);

                        ((Konobar)db.Radnici.Find(konobarJmbg)).BrojNaplacenihKupovina++;

                        db.SaveChanges();
                    }

                }

            }
            catch
            {

            }
        }

        public void ObrisiKupovinu(string nazivRestorana, string nazivProizvoda, string kupacJmbg, string konobarJmbg)
        {
            try
            {
                if (db.Kupovine.Find(nazivRestorana, nazivProizvoda, kupacJmbg) != null)
                {
                    db.Kupovine.Remove(db.Kupovine.Find(nazivRestorana, nazivProizvoda, kupacJmbg));

                    ((Konobar)db.Radnici.Find(konobarJmbg)).BrojNaplacenihKupovina--;

                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }

        public List<Kupuje> UcitajKupovine()
        {
            List<Kupuje> kupovine = new List<Kupuje>();

            try
            {
                kupovine = db.Kupovine.ToList();
            }
            catch
            {

            }

            return kupovine;
        }
    }
}
