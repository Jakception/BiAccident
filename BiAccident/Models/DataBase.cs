using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

using System.Configuration;

namespace BiAccident.Models
{
    public static class DataBase
    {
        private static DbConnection Connexion { get; set; }
        private static DbCommand Command { get; set; }
        private static DbDataReader DataReader { get; set; }

        public static DbConnection CreateDbConnection(string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                }
            }
            // Return the connection.
            return connection;
        }
        public static DbConnection GetConnexion()
        {
            return Connexion;
        }

        public static void OpenConnexion(DbConnection connexion)
        {
            connexion.Open();
        }
        public static void DeConnexion(DbConnection connexion)
        {
            connexion.Close();
        }

        public static string ConnexionToDataBase()
        {
            string messErreur = "";

            //string providerName = ConfigurationManager.ConnectionStrings["MaConnection"].ProviderName;
            //string connectionString = ConfigurationManager.ConnectionStrings["MaConnection"].ConnectionString;

            string providerName = "MySql.Data.MySqlClient";
            string connectionString = "Server = localhost; User ID = root; Database = bi_accident; Password =;";

            Connexion = CreateDbConnection(providerName, connectionString);

            if (Connexion != null)
            {
                try
                {
                    OpenConnexion(Connexion);
                    messErreur = "";
                }
                catch (Exception err)
                {
                    messErreur += (err.Message);
                }
                //finally
                //{
                //    DeConnexion(connexion);
                //}
            }
            return messErreur;
        }
        // FONCTION A VIRER DES QUE TOUT LES MONDE A TESTER
        public static string TestConnexion()
        {
            // INSERT INTO `client`(`NOMCLIENT`) VALUES ('TEST');

            string messRes = "";
            string messErreur = "";

            string providerName = "MySql.Data.MySqlClient";
            string connectionString = "Server = localhost; User ID = root; Database = bi_accident; Password =;";

            DbConnection connexion = CreateDbConnection(providerName, connectionString);

            if (connexion != null)
            {
                try
                {
                    OpenConnexion(connexion);
                    messErreur = "";
                }
                catch (Exception err)
                {
                    messErreur = (err.Message);
                }
                //finally
                //{
                //    DeConnexion(connexion);
                //}
            }

            if (messErreur == "")
            {
                Command = connexion.CreateCommand();
                Command.CommandText = "SELECT Num_Acc FROM lieux WHERE Num_Acc = '201500000001'; ";
                DataReader = Command.ExecuteReader();
                if (DataReader.Read())
                {
                    messRes = DataReader[0].ToString();
                }
                DataReader.Close();
            }
            else
            {
                messRes = messErreur;
            }

            return messRes;
        }
        public static string GetCatrt(string catr)
        {
            string result = "";

            switch (catr)
            {
                case "1":
                    result = "Autoroute";
                    break;
                case "2":
                    result = "Nationale";
                    break;
                case "3":
                    result = "Départementale";
                    break;
                case "4":
                    result = "Voie Communale";
                    break;
                case "5":
                    result = "Hors réseau public";
                    break;
                case "6":
                    result = "Parc de stationnement ouvert à la circulation public";
                    break;
                default:
                    result = "Autre";
                    break;
            }

            return result;
        }
        public static NbAccidentLieux ReqNbAccidentLieux(string annee)
        {
            string messErreur = "";
            NbAccidentLieux nbAccidentLieux = new NbAccidentLieux(annee);

            messErreur = ConnexionToDataBase();

            if (messErreur == "")
            {
                Command = GetConnexion().CreateCommand();
                Command.CommandText = "SELECT count(*) as nbAcc, catr as TypeLieux " +
                                      "FROM lieux " +
                                      "WHERE Num_Acc like '" + annee + "%' " +
                                      "GROUP BY catr; ";
                DataReader = Command.ExecuteReader();
                while(DataReader.Read())
                {
                    nbAccidentLieux.GetListAccidentLieux().Add(new AccidentLieux(DataReader[0].ToString(), GetCatrt(DataReader[1].ToString())));
                }
                DataReader.Close();
            }

            DeConnexion(Connexion);

            return nbAccidentLieux;
        }
        public static string GetCatu(string catu)
        {
            string result = "";

            switch (catu)
            {
                case "1":
                    result = "Conducteur";
                    break;
                case "2":
                    result = "Passager";
                    break;
                case "3":
                    result = "Pièton";
                    break;
                case "4":
                    result = "Pièton en roller ou trotinette";
                    break;
            }

            return result;
        }
        public static NbCategUser ReqCategUser(string annee)
        {
            string messErreur = "";
            NbCategUser nbCategUser = new NbCategUser(annee);

            messErreur = ConnexionToDataBase();

            if (messErreur == "")
            {
                Command = GetConnexion().CreateCommand();
                Command.CommandText = "SELECT count(*) as nbAcc, catu as CategUser " +
                                      "FROM usager " +
                                      "WHERE Num_Acc like '" + annee + "%' " +
                                      "GROUP BY catu; ";
                DataReader = Command.ExecuteReader();
                while (DataReader.Read())
                {
                    nbCategUser.GetListCategUser().Add(new CategUser(DataReader[0].ToString(), GetCatu(DataReader[1].ToString())));
                }
                DataReader.Close();
            }

            DeConnexion(Connexion);

            return nbCategUser;
        }
        public static string GetCatv(string catv)
        {
            string result = "";

            switch (catv)
            {
                case "1":
                    result = "Bicyclette";
                    break;
                case "2":
                    result = "Cyclomoteur 50cm3";
                    break;
                case "3":
                    result = "Voiturette";
                    break;
                case "7":
                    result = "VL Seul";
                    break;
                case "10":
                    result = "VU seul 1.5T";
                    break;
                case "13": 
                    result = "PL seul 3.5T";
                    break;
                case "14":
                    result = "PL seul > 7.5T";
                    break;
                case "15":
                    result = "PL > 3.5T + remorque";
                    break;
                case "16":
                    result = "Tracteur routier seul";
                    break;
                case "17":
                    result = "Tracteur routier + semi remorque";
                    break;
                case "20":
                    result = "Engin Spécial";
                    break;
                case "21":
                    result = "Tracteur agricole";
                    break;
                case "30":
                    result = "Scooter <50cm3";
                    break;
                case "31":
                    result = "Motocyclette > 50cm3 et <= 125 cm3";
                    break;
                case "32":
                    result = "Scooter > 50cm3 et <= 125 cm3";
                    break;
                case "33":
                    result = "Motocyclette > 125 cm3";
                    break;
                case "34":
                    result = "Scooter > 125 cm3 ";
                    break;
                case "35":
                    result = "Quad lourd <= 50 cm3 ";
                    break;
                case "36":
                    result = "Quad lourd > 50 cm3 ";
                    break;
                case "37":
                    result = "Autobus";
                    break;
                case "38":
                    result = "Autocar";
                    break;
                case "39":
                    result = "Train";
                    break;
                case "40":
                    result = "Tramway";
                    break;
                default:
                    result = "autre";
                    break;
            }

            return result;
        }

        public static NbCategVoiture ReqCategVoiture(string annee)
        {
            string messErreur = "";
            NbCategVoiture nbCategVoiture = new NbCategVoiture(annee);

            messErreur = ConnexionToDataBase();

            if (messErreur == "")
            {
                Command = GetConnexion().CreateCommand();
                Command.CommandText = "SELECT count(*) as nbAcc, Catv as CategVehic " +
                                      "FROM vehicule " +
                                      "WHERE Num_Acc like '" + annee + "%' " +
                                      "GROUP BY Catv; ";
                DataReader = Command.ExecuteReader();
                while (DataReader.Read())
                {
                    nbCategVoiture.GetlistCategVoiture().Add(new CategVoiture(DataReader[0].ToString(), GetCatv(DataReader[1].ToString())));
                }
                DataReader.Close();
            }

            DeConnexion(Connexion);

            return nbCategVoiture;
        }
    }
}