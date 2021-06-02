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
    public class ProizvodiCRUD : IProizvodiCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();
        public void DodajProizvod(string naziv, int cena, string tip, string dodatno, string kuvarJmbg)
        {
            try
            {
                if (tip == "Pice")
                {
                    Pice v = new Pice()
                    {
                        Naziv = naziv,
                        Cena = cena,
                        TipProizvoda = tip,
                        Velicina = dodatno
                    };

                    db.Proizvodi.Add(v);

                }
                else if (tip == "Jelo")
                {
                    Jelo v = new Jelo()
                    {
                        Naziv = naziv,
                        Cena = cena,
                        TipProizvoda = tip,
                        Sastojci = dodatno,
                        KuvarJmbg = kuvarJmbg
                    };

                    db.Proizvodi.Add(v);

                    var d = db.Radnici.Find(kuvarJmbg);
                    if (d.TipRadnika == "Kuvar")
                    {
                        ((Kuvar)d).BrojNapravljenihJela++;
                    }
                }

                db.SaveChanges();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.InnerException.InnerException.Message, "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void IzmeniProizvod(string naziv, int cena, string dodatno)
        {
            try
            {
                var vl = db.Proizvodi.Find(naziv);
                if (vl.TipProizvoda == "Jelo")
                {
                    ((Jelo)vl).Sastojci = dodatno;
                }
                else
                {
                    ((Pice)vl).Velicina = dodatno;
                }
                vl.Cena = cena;

                db.SaveChanges();

            }
            catch
            {
                MessageBox.Show("Ne moze se izmeniti proizvod !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ObrisiProizvod(string naziv)
        {
            try
            {
                Proizvod v = db.Proizvodi.Find(naziv);
                if (v != null)
                {
                    List<Nudi> ponude = db.Nudis.ToList();

                    foreach(Nudi n in ponude)
                    {
                        if(n.ProizvodNaziv == v.Naziv)
                        {
                            db.Nudis.Remove(n);
                        }
                    }

                    if (v.TipProizvoda == "Jelo")
                    {
                        var d = db.Radnici.Find(((Jelo)v).KuvarJmbg);
                        if (d.TipRadnika == "Kuvar")
                        {
                            ((Kuvar)d).BrojNapravljenihJela--;
                        }
                    }

                    db.Proizvodi.Remove(v);

                }

            }
            catch
            {
                MessageBox.Show("Ne moze se obrisati proizvod !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            db.SaveChanges();
        }

        public List<Proizvod> UcitajSveProizvode()
        {
            List<Proizvod> proizvodi = new List<Proizvod>();

            try
            {
                proizvodi = db.Proizvodi.ToList();
            }
            catch
            {
                MessageBox.Show("Ne mogu se ucitati proizvodi!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return proizvodi;
        }
    }
}
