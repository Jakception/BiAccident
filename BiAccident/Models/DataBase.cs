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
            string result;

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
                    nbAccidentLieux.ListAccidentLieux.Add(new AccidentLieux(DataReader[0].ToString(), GetCatrt(DataReader[1].ToString())));
                }
                DataReader.Close();
            }

            return nbAccidentLieux;
        }
    }
}