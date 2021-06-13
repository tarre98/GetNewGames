using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetNewGamesAPI.Models
{
    public class SaleRepositorio
    {


        private MySqlConnection Connect()
        {
            string server = "server=127.0.0.1;";
            string port = "port=3306;";
            string database = "database=gngames;";
            string usuario = "uid=root;";
            string password = "pwd=;";

            string connString = server + port + database + usuario + password;
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Sale> Retrive()
        {
            List<Sale> mercados = new List<Sale>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `Sales`";
            Sale ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new Sale(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {


            }

            con.Close();
            return mercados;
        }
        internal List<Sale> RetriveByU(int id)
        {
            List<Sale> mercados = new List<Sale>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM sales WHERE Users_iduser = '" + id + "'";
            Sale ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new Sale(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }
        internal List<Sale> RetriveN()
        {
            List<Sale> mercados = new List<Sale>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `sales` WHERE `tipoEnvio` LIKE 'nacional'";
            Sale ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new Sale(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {


            }

            con.Close();
            return mercados;
        }

        internal List<Sale> RetriveI()
        {
            List<Sale> mercados = new List<Sale>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `sales` WHERE `tipoEnvio` LIKE 'internacional'";
            Sale ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new Sale(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {


            }

            con.Close();
            return mercados;
        }

        //SELECT * FROM sales WHERE Games_idGames = 1


        internal List<Sale> RetriveByG(int id)
        {
            List<Sale> mercados = new List<Sale>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `sales` WHERE `Games_idGames` = '" + id + "'";
            Sale ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new Sale(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }


        internal List<Sale> Retrive2(int id)
        {
            List<Sale> mercados = new List<Sale>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT* FROM `Sale` WHERE `USUARIO_EMAIL` = '" + id + "'";
            Sale ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new Sale(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }

        internal List<Sale> RetriveP(int p1, int p2)
        {
            List<Sale> mercados = new List<Sale>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `sales` WHERE `precioTotal` BETWEEN " + p1 + " AND " + p2;
            Sale ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new Sale(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }


        internal void Save(Sale a)
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO `sales` (`idSales`, `Users_iduser`, `Games_idGames`, `precioTotal`, `tipoEnvio` , `cantidad` ) VALUES ('NULL', '" + a.iduser + "', '" + a.idgame + "', '" + a.precio + "', '" + a.envio + "', '" + a.cantidad + "');";

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }




    }
}