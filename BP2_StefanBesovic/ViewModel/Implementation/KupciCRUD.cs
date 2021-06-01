using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class KupciCRUD : IKupciCRUD
    {

        private RestoranDbModelContainer db = new RestoranDbModelContainer();

        public void DodajKupca(string jmbg, string ime, string prezime, string brojTelefona)
        {
            Kupac v = new Kupac()
            {
                Jmbg = jmbg,
                Ime = ime,
                Prezime = prezime,
                BrojTelefona = brojTelefona
            };

            db.Kupci.Add(v);
            db.SaveChanges();
        }

        public void IzmeniKupca(string jmbg, string ime, string prezime, string brojTelefona)
        {
            try
            {
                var vl = db.Kupci.Find(jmbg);
                vl.Ime = ime;
                vl.Prezime = prezime;
                vl.BrojTelefona = brojTelefona;
                db.SaveChanges();

            }
            catch
            {

            }
        }

        public void ObrisiKupca(string jmbg)
        {
            try
            {
                Kupac v = db.Kupci.Find(jmbg);
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

                    db.Kupci.Remove(v);
                }

            }
            catch
            {

            }

            db.SaveChanges();
        }

        public List<Kupac> UcitajSveKupce()
        {
            List<Kupac> kupci = new List<Kupac>();

            try
            {
                kupci = db.Kupci.ToList();
            }
            catch
            {

            }

            return kupci;
        }
    }
}
