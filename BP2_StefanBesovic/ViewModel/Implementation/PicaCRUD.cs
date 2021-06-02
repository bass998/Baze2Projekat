using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class PicaCRUD : IPicaCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();

        public void DodajPice(string naziv, int cena, string velicina)
        {

            Pice v = new Pice()
            {
                Naziv = naziv,
                Cena = cena,
                TipProizvoda = "Pice",
                Velicina = velicina
            };

            db.Proizvodi.Add(v);


            db.SaveChanges();
        }

        public void IzmeniPice(string naziv, int cena, string velicina)
        {
            try
            {
                Pice vl = (Pice)db.Proizvodi.Find(naziv);
                vl.Cena = cena;
                vl.Velicina = velicina;

                db.SaveChanges();

            }
            catch
            {

            }
        }

        public void ObrisiPice(string naziv)
        {
            try
            {
                Proizvod v = db.Proizvodi.Find(naziv);
                if (v != null)
                {
                    List<Nudi> ponude = db.Nudis.ToList();

                    foreach (Nudi n in ponude)
                    {
                        if (n.ProizvodNaziv == v.Naziv)
                        {
                            db.Nudis.Remove(n);
                        }
                    }

                    db.Proizvodi.Remove(v);
                }

            }
            catch
            {

            }

            db.SaveChanges();
        }

        public List<Proizvod> UcitajSvaPica()
        {
            List<Proizvod> pica = new List<Proizvod>();

            try
            {
                pica = db.Proizvodi.Where(x => x.TipProizvoda == "Pice").ToList();
            }
            catch
            {

            }

            return pica;
        }
    }
}
