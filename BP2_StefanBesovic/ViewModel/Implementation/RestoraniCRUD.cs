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
    public class RestoraniCRUD : IRestoraniCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();
        public void DodajRestoran(string naziv, string adresa, string grad, string brojTelefona, string vlasnikJmbg)
        {
            if (db.Vlasnici.Find(vlasnikJmbg) != null)
            {
                Restoran v = new Restoran()
                {
                    Naziv = naziv,
                    Adresa = adresa,
                    Grad = grad,
                    BrojTelefona = brojTelefona,
                    VlasnikJmbg = vlasnikJmbg
                };

                db.Restorani.Add(v);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Ne moze se dodati restoran !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void IzmeniRestoran(string naziv, string adresa, string grad, string brojTelefona, string vlasnikJmbg)
        {

            try
            {
                var vl = db.Restorani.Find(naziv);
                vl.Adresa = adresa;
                vl.Grad = grad;
                vl.BrojTelefona = brojTelefona;
                vl.VlasnikJmbg = vlasnikJmbg;

                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ne moze se izmeniti restoran !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ObrisiRestoran(string naziv)
        {
            try
            {
                Restoran v = db.Restorani.Find(naziv);
                if (v != null)
                {
                    List<Nudi> nudis = db.Nudis.ToList();
                    List<Kupuje> kupovine = db.Kupovine.ToList();

                    foreach (Kupuje k in kupovine)
                    {
                        if (k.NudiRestoranNaziv.Equals(v.Naziv))
                        {
                            db.Kupovine.Remove(k);
                        }
                    }

                    foreach (Nudi k in nudis)
                    {
                        if (k.RestoranNaziv.Equals(v.Naziv))
                        {
                            db.Nudis.Remove(k);
                        }
                    }

                    db.Restorani.Remove(v);
                }

            }
            catch
            {
                MessageBox.Show("Ne moze se obrisati restoran !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            db.SaveChanges();
        }

        public List<Restoran> UcitajSveRestorane()
        {
            List<Restoran> restorani = new List<Restoran>();

            try
            {
                restorani = db.Restorani.ToList();
            }
            catch
            {
                MessageBox.Show("Ne mogu se ucitati restorani !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return restorani;
        }
    }
}
