using BP2_StefanBesovic.ViewModel.Intefaces;
using ProjectLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BP2_StefanBesovic.ViewModel.Implementation
{
    public class KonobariCRUD : IKonobariCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();

        public void DodajKonobara(string jmbg, string ime, string prezime, string brojTelefona)
        {
            try
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
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ne moze se dodati konobar !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void IzmeniKonobara(string jmbg, string ime, string prezime, string brojTelefona)
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
                MessageBox.Show("Ne moze se izmeniti konobar !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ObrisiKonobara(string jmbg)
        {
            try
            {
                Radnik v = db.Radnici.Find(jmbg);

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

                    db.Radnici.Remove(v);
                }

            }
            catch
            {
                MessageBox.Show("Ne moze se obrisati konobar !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            db.SaveChanges();
        }

        public List<Radnik> UcitajSveKonobare()
        {
            List<Radnik> konobari = new List<Radnik>();

            try
            {
                konobari = db.Radnici.Where(x => x.TipRadnika == "Konobar").ToList();
            }
            catch
            {
                MessageBox.Show("Ne mogu se ucitati konobari !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return konobari;
        }
        /*
        public void UkupnoNaplaceno(string jmbg)
        {

            var conString = ConfigurationManager.ConnectionStrings["RestoranDbModelContainer"].ConnectionString;
            if (conString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conString);
                conString = efBuilder.ProviderConnectionString;
            }

            int ukupnaPotrosnja = 0;

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand com = new SqlCommand("ProcedureKonobarNaplatio", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;

                    com.Parameters.Add("@KonobarJmbg", System.Data.SqlDbType.VarChar, 13).Value = jmbg;
                    com.Parameters.Add("@UkupnoNaplatio", System.Data.SqlDbType.Int);
                    com.Parameters["@UkupnoNaplatio"].Direction = System.Data.ParameterDirection.Output;

                    try
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        ukupnaPotrosnja = (Int32)com.Parameters["@UkupnoNaplatio"].Value;
                        MessageBox.Show(String.Format("Ukupno Naplatio: {0} RSD.", ukupnaPotrosnja), "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Neka greska se desila", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }
        */
    }
}
