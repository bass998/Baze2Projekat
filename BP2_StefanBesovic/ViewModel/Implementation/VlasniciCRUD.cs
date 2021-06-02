using BP2_StefanBesovic.ViewModel.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLogic;
using System.Windows;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class VlasniciCRUD : IVlasniciCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();
        public void DodajVlasnika(string jmbg, string ime, string prezime, string brojTelefona)
        {   
            try{
                Vlasnik v = new Vlasnik()
                {
                    Jmbg = jmbg,
                    Ime = ime,
                    Prezime = prezime,
                    BrojTelefona = brojTelefona
                };

                 db.Vlasnici.Add(v);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ne moze se dodati vlasnik !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void IzmeniVlasnika(string jmbg, string ime, string prezime, string brojTelefona)
        {
            
            try
            {
                var vl = db.Vlasnici.Find(jmbg);
                vl.Ime = ime;
                vl.Prezime = prezime;
                vl.BrojTelefona = brojTelefona;
                db.SaveChanges();

            }
            catch
            {
                MessageBox.Show("Ne moze se izmeniti vlasnik !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ObrisiVlasnika(string jmbg)
        {
            try
            {
                Vlasnik v = db.Vlasnici.Find(jmbg);
                if(v != null)
                {
                    List<Restoran> restorani = db.Restorani.ToList();
                    List<Nudi> nudis = db.Nudis.ToList();
                    List<Kupuje> kupovine = db.Kupovine.ToList();

                    string imeRestorana = "";

                    foreach(Restoran r in restorani)
                    {
                        if(r.VlasnikJmbg.Equals(jmbg))
                        {
                            imeRestorana = r.Naziv;

                            foreach (Kupuje k in kupovine)
                            {
                                if(k.NudiRestoranNaziv.Equals(imeRestorana))
                                {
                                    db.Kupovine.Remove(k);
                                }
                            }

                            foreach (Nudi k in nudis)
                            {
                                if (k.RestoranNaziv.Equals(imeRestorana))
                                {
                                    db.Nudis.Remove(k);
                                }
                            }

                            db.Restorani.Remove(r);
                            break;

                        }
                    }

                    db.Vlasnici.Remove(v);
                }
                    
            }
            catch
            {
                MessageBox.Show("Ne moze se obrisati vlasnik !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            db.SaveChanges();
        }

        public List<Vlasnik> UcitajSveVlasnike()
        {
            List<Vlasnik> vlasnici = new List<Vlasnik>();

            try
            {
                vlasnici = db.Vlasnici.ToList();
            }
            catch
            {
                MessageBox.Show("Ne mogu se ucitati vlasnici !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return vlasnici;
        }
    }
}
