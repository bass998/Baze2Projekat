using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class KonobariCRUD : IKonobariCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();

        public void DodajKonobara(string jmbg, string ime, string prezime, string brojTelefona)
        {
            Konobar v = new Konobar()
            {
                Jmbg = jmbg,
                Ime = ime,
                Prezime = prezime,
                BrojTelefona = brojTelefona,
                TipRadnika = "Konobar",
                BrojNaplacenihKupovina = 0
            };

            db.Radnici.Add(v);
            db.SaveChanges();
        }

        public void IzmeniKonobara(string jmbg, string ime, string prezime, string brojTelefona)
        {
            try
            {
                var vl = db.Radnici.Find(jmbg);
                vl.Ime = ime;
                vl.Prezime = prezime;
                vl.BrojTelefona = brojTelefona;

                db.SaveChanges();

            }
            catch
            {

            }
        }

        public void ObrisiKonobara(string jmbg)
        {
            try
            {
                Radnik v = db.Radnici.Find(jmbg);

                if (v != null)
                {
                    List<Kupuje> kupovine = db.Kupovine.ToList();

                    foreach (Kupuje k in kupovine)
                    {
                        if (k.KupacJmbg.Equals(v.Jmbg))
                        {
                            db.Kupovine.Remove(k);
                        }
                    }

                    db.Radnici.Remove(v);
                }

            }
            catch
            {

            }

            db.SaveChanges();
        }

        public List<Radnik> UcitajSveKonobare()
        {
            List<Radnik> konobari = new List<Radnik>();

            try
            {
                konobari = db.Radnici.Where(x => x.TipRadnika == "Konobar").ToList();
            }
            catch
            {

            }

            return konobari;
        }
    }
}
