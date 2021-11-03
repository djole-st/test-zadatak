using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test_Zadatak.DAL.Interfaces;
using Test_Zadatak.Models;
using Test_Zadatak.Helpers;

namespace Test_Zadatak.DAL
{
    public class RadnikDAL : IRadnikDAL
    {
        string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public string getCon()
        {
            return connection;
        }

        public List<Radnik> getAll()
        {
            List<Radnik> radnici = new List<Radnik>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = $"SELECT * FROM radnik";

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        radnici.Add(new Radnik()
                        {
                            Id = Int32.Parse(reader[0].ToString()),
                            Ime = reader[1].ToString(),
                            Prezime = reader[2].ToString(),
                            Adresa = reader[3].ToString(),
                            NetoPlata = Int32.Parse(reader[4].ToString()),
                            UmanjenjePoreskeOsnovice = Convert.ToDouble(reader[5].ToString()),
                            BrutoIznos = Convert.ToDouble(reader[6].ToString())
                        });
                    }
                    reader.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return radnici;

        }

        public void insert(Radnik radnik)
        {
            //(Neto zarada – (18.300 x 10%)) / 0,701
            radnik.BrutoIznos = (radnik.NetoPlata - (Constants.UMANJENJE_PORESKE_OSNOVICE * 0.1)) / Constants.KOEFICIJENT_PRERACUNA;
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = $"INSERT INTO radnik VALUES (@ime,@prezime,@adresa,@neto_plata,@umanjenje_poreske_osnovice,@bruto_iznos)";

                    SqlParameter parameter = command.CreateParameter();
                    parameter = command.CreateParameter();
                    parameter.DbType = System.Data.DbType.String;
                    parameter.ParameterName = "@ime";
                    parameter.Value = radnik.Ime;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.DbType = System.Data.DbType.String;
                    parameter.ParameterName = "@prezime";
                    parameter.Value = radnik.Prezime;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.DbType = System.Data.DbType.String;
                    parameter.ParameterName = "@adresa";
                    parameter.Value = radnik.Adresa;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.DbType = System.Data.DbType.Int32;
                    parameter.ParameterName = "@neto_plata";
                    parameter.Value = radnik.NetoPlata;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.DbType = System.Data.DbType.Double;
                    parameter.ParameterName = "@umanjenje_poreske_osnovice";
                    parameter.Value = Constants.UMANJENJE_PORESKE_OSNOVICE;
                    command.Parameters.Add(parameter);

                    parameter = command.CreateParameter();
                    parameter.DbType = System.Data.DbType.Double;
                    parameter.ParameterName = "@bruto_iznos";
                    parameter.Value = radnik.BrutoIznos;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}