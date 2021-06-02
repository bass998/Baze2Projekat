using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class KuvariCRUD : IKuvariCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();
        public void DodajKuvara(string jmbg, string ime, string prezime, string brojTelefona)
        {
            try
            {
                Kuvar v = new Kuvar()
                {
                    Jmbg = jmbg,
                    Ime = ime,
                    Prezime = prezime,
                    BrojTelefona = brojTelefona,
                    TipRadnika = "Kuvar",
                    BrojNapravljenihJela = 0
                };

                db.Radnici.Add(v);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ne moze se dodati kuvar !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void IzmeniKuvara(string jmbg, string ime, string prezime, string brojTelefona)
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
                MessageBox.Show("Ne moze se izmeniti kuvar !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ObrisiKuvara(string jmbg)
        {
            try
            {
                Radnik v = db.Radnici.Find(jmbg);

                if (v != null)
                {
                    List<Proizvod> proizvodi = db.Proizvodi.ToList();

                    foreach (Jelo k in proizvodi)
                    {
                        if (k.KuvarJmbg == v.Jmbg)
                        {
                            db.Proizvodi.Remove(k);
                        }
                    }

                    db.Radnici.Remove(v);
                }

            }
            catch
            {
                MessageBox.Show("Ne moze se obrisati kuvar !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            db.SaveChanges();
        }

        public List<Radnik> UcitajSveKuvare()
        {
            List<Radnik> kuvari = new List<Radnik>();

            try
            {
                kuvari = db.Radnici.Where(x => x.TipRadnika == "Kuvar").ToList();
            }
            catch
            {
                MessageBox.Show("Ne mogu se ucitati kuvari!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return kuvari;
        }

    }
}
