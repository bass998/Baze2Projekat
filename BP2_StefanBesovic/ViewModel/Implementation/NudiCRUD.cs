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
                MessageBox.Show("Ne moze se dodati ponuda !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Ne moze se obrisati ponuda !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Ne mogu se ucitati ponude !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return ponude;
        }
    }
}
