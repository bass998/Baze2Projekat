using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class JelaCRUD : IJelaCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();

        public void DodajJelo(string naziv, int cena, string sastojci, string kuvarJmbg)
        {
            Jelo v = new Jelo()
            {
                Naziv = naziv,
                Cena = cena,
                TipProizvoda = "Jelo",
                Sastojci = sastojci,
                KuvarJmbg = kuvarJmbg
            };

            db.Proizvodi.Add(v);

            var d = db.Radnici.Find(kuvarJmbg);
            if (d.TipRadnika == "Kuvar")
            {
                ((Kuvar)d).BrojNapravljenihJela++;
            }

            db.SaveChanges();
        }

        public void IzmeniJelo(string naziv, int cena, string sastojci)
        {
            Jelo vl = (Jelo)db.Proizvodi.Find(naziv);
            vl.Cena = cena;
            vl.Sastojci = sastojci;


            db.SaveChanges();
        }

        public void ObrisiJelo(string naziv)
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

                var d = db.Radnici.Find(((Jelo)v).KuvarJmbg);
                if (d.TipRadnika == "Kuvar")
                {
                    ((Kuvar)d).BrojNapravljenihJela--;
                }


                db.Proizvodi.Remove(v);
            }
            db.SaveChanges();
        }

        public List<Proizvod> UcitajSvaJela()
        {
            List<Proizvod> jela = new List<Proizvod>();

            try
            {
                jela = db.Proizvodi.Where(x => x.TipProizvoda == "Jelo").ToList();
            }
            catch
            {

            }

            return jela;
        }
    }
}
