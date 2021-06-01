using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class RadniciCRUD : IRadniciCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();

        public void DodajRadnika(string jmbg, string ime, string prezime, string brojTelefona, string uloga)
        {
            if(uloga == "Konobar")
            {
                Konobar v = new Konobar()
                {
                    Jmbg = jmbg,
                    Ime = ime,
                    Prezime = prezime,
                    BrojTelefona = brojTelefona
                };

                db.Radnici.Add(v);

            }
            else if(uloga == "Kuvar")
            {
                Kuvar v = new Kuvar()
                {
                    Jmbg = jmbg,
                    Ime = ime,
                    Prezime = prezime,
                    BrojTelefona = brojTelefona
                };
                db.Radnici.Add(v);
            }

            db.SaveChanges();
        }

        public void IzmeniRadnika(string jmbg, string ime, string prezime, string brojTelefona)
        {
            throw new NotImplementedException();
        }

        public void ObrisiRadnika(string jmbg)
        {
            throw new NotImplementedException();
        }

        public List<Radnik> UcitajSveRadnike()
        {
            List<Radnik> radnici = new List<Radnik>();

            try
            {
                radnici = db.Radnici.ToList();
            }
            catch
            {

            }

            return radnici;
        }
    }
}
