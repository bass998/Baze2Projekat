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
    public class KupciCRUD : IKupciCRUD
    {

        private RestoranDbModelContainer db = new RestoranDbModelContainer();

        public void DodajKupca(string jmbg, string ime, string prezime, string brojTelefona)
        {
            try
            {
                Kupac v = new Kupac()
                {
                    Jmbg = jmbg,
                    Ime = ime,
                    Prezime = prezime,
                    BrojTelefona = brojTelefona
                };

                db.Kupci.Add(v);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ne moze se dodati kupac !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void IzmeniKupca(string jmbg, string ime, string prezime, string brojTelefona)
        {
            try
            {
                var vl = db.Kupci.Find(jmbg);
                vl.Ime = ime;
                vl.Prezime = prezime;
                vl.BrojTelefona = brojTelefona;
                db.SaveChanges();

            }
            catch
            {
                MessageBox.Show("Ne moze se izmeniti kupac !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ObrisiKupca(string jmbg)
        {
            try
            {
                Kupac v = db.Kupci.Find(jmbg);
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

                    db.Kupci.Remove(v);
                }

            }
            catch
            {
                MessageBox.Show("Ne moze se obrisati kupac !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            db.SaveChanges();
        }

        public List<Kupac> UcitajSveKupce()
        {
            List<Kupac> kupci = new List<Kupac>();

            try
            {
                kupci = db.Kupci.ToList();
            }
            catch
            {
                MessageBox.Show("Ne mogu se ucitati kupci!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return kupci;
        }

        public void UkupnaPotrosnja(string jmbg)
        {

            var conString = ConfigurationManager.ConnectionStrings["RestoranDbModelContainer"].ConnectionString;
            if (conString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conString);
                conString = efBuilder.ProviderConnectionString;
            }

            int ukupnaPotrosnja = 0;
            string imeKupca = "";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand com = new SqlCommand("ProcedureKupacPotrosnja", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;

                    com.Parameters.Add("@KupacJmbg", System.Data.SqlDbType.VarChar, 13).Value = jmbg;

                    com.Parameters.Add("@ImeKupca", System.Data.SqlDbType.VarChar, 50);
                    com.Parameters["@ImeKupca"].Direction = System.Data.ParameterDirection.Output;

                    com.Parameters.Add("@UkupnaPotrosnja", System.Data.SqlDbType.Int);
                    com.Parameters["@UkupnaPotrosnja"].Direction = System.Data.ParameterDirection.Output;


                    try
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        ukupnaPotrosnja = (Int32)com.Parameters["@UkupnaPotrosnja"].Value;
                        imeKupca = com.Parameters["@ImeKupca"].Value.ToString();
                        MessageBox.Show(String.Format("Kupac {0} je potrosio {1} RSD.", imeKupca, ukupnaPotrosnja), "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Neka greska se desila", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }
    }
}
