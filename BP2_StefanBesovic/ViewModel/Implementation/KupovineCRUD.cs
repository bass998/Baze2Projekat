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
    public class KupovineCRUD : IKupovineCRUD
    {
        private RestoranDbModelContainer db = new RestoranDbModelContainer();
        public void DodajKupovinu(string nazivRestorana, string nazivProizvoda, string kupacJmbg, string konobarJmbg)
        {
            try
            {
                if(db.Radnici.Find(konobarJmbg) != null && db.Kupci.Find(kupacJmbg) != null)
                {
                    if(db.Radnici.Find(konobarJmbg).TipRadnika == "Konobar")
                    {
                        Kupuje n = new Kupuje()
                        {
                            NudiRestoranNaziv = nazivRestorana,
                            NudiProizvodNaziv = nazivProizvoda,
                            KupacJmbg = kupacJmbg,
                            KonobarJmbg = konobarJmbg
                        };

                        db.Kupovine.Add(n);

                        ((Konobar)db.Radnici.Find(konobarJmbg)).BrojNaplacenihKupovina++;

                        db.SaveChanges();
                    }

                }

            }
            catch(Exception e)
            {
                MessageBox.Show("Ne moze se dodati kupovina !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ObrisiKupovinu(string nazivRestorana, string nazivProizvoda, string kupacJmbg, string konobarJmbg)
        {
            try
            {
                if (db.Kupovine.Find(nazivRestorana, nazivProizvoda, kupacJmbg) != null)
                {
                    db.Kupovine.Remove(db.Kupovine.Find(nazivRestorana, nazivProizvoda, kupacJmbg));

                    ((Konobar)db.Radnici.Find(konobarJmbg)).BrojNaplacenihKupovina--;

                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Ne moze se obrisati kupovina !", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public List<Kupuje> UcitajKupovine()
        {
           List<Kupuje> kupovine = new List<Kupuje>();

           try
           {
               kupovine = db.Kupovine.ToList();
           }
           catch
           {
               MessageBox.Show("Ne mogu se ucitati kupovine!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
           }

           return kupovine;
        }

        public void ImeVlasnika(string kupacJmbg, string nazivRestorana)
        {
            var conString = ConfigurationManager.ConnectionStrings["RestoranDbModelContainer"].ConnectionString;
            if (conString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conString);
                conString = efBuilder.ProviderConnectionString;
            }

            string imeVlasnika = "";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand com = new SqlCommand("ProcedureImeVlasnika", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;

                    com.Parameters.Add("@KupacJmbg", System.Data.SqlDbType.VarChar, 13).Value = kupacJmbg;
                    com.Parameters.Add("@NazivRestorana", System.Data.SqlDbType.VarChar, 50).Value = nazivRestorana;
                    com.Parameters.Add("@ImeVlasnikaRestorana", System.Data.SqlDbType.VarChar, 50);
                    com.Parameters["@ImeVlasnikaRestorana"].Direction = System.Data.ParameterDirection.Output;

                    try
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        imeVlasnika = (String)com.Parameters["@ImeVlasnikaRestorana"].Value;
                        MessageBox.Show(String.Format("Vlasnik restorana {0} je {1}.", nazivRestorana, imeVlasnika), "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Neka greska se desila", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }


    }
}
