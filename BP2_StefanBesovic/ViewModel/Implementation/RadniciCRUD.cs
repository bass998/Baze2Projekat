﻿using BP2_StefanBesovic.ViewModel.Intefaces;
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
                    BrojTelefona = brojTelefona,
                    TipRadnika = "Konobar",
                    BrojNaplacenihKupovina = 0
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
                    BrojTelefona = brojTelefona,
                    TipRadnika = "Kuvar",
                    BrojNapravljenihJela = 0
                };
                db.Radnici.Add(v);
            }

            db.SaveChanges();
        }

        public void IzmeniRadnika(string jmbg, string ime, string prezime, string brojTelefona, string uloga)
        {
            try
            {
                var vl = db.Radnici.Find(jmbg);
                vl.Ime = ime;
                vl.Prezime = prezime;
                vl.BrojTelefona = brojTelefona;
                vl.TipRadnika = uloga;
                
                db.SaveChanges();

            }
            catch
            {

            }
        }

        public void ObrisiRadnika(string jmbg)
        {
            try
            {
                Radnik v = db.Radnici.Find(jmbg);
                if (v != null)
                {
                    if (v.TipRadnika == "Konobar")
                    {
                        List<Kupuje> kupovine = db.Kupovine.ToList();

                        foreach (Kupuje k in kupovine)
                        {
                            if (k.KupacJmbg.Equals(v.Jmbg))
                            {
                                db.Kupovine.Remove(k);
                            }
                        }
                    }
                    else if(v.TipRadnika == "Kuvar")
                    {
                        List<Proizvod> proizvodi = db.Proizvodi.ToList();

                        foreach (Jelo k in proizvodi)
                        {
                            if (k.KuvarJmbg == v.Jmbg)
                            {
                                db.Proizvodi.Remove(k);
                            }
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
