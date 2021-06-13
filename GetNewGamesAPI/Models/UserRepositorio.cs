using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Org.BouncyCastle.Asn1;


// UPDATE `users` SET `dineroGastado` = '1525' WHERE `users`.`iduser` = 5;


namespace GetNewGamesAPI.Models
{
    public class UserRepositorio
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
        internal List<User> Retrive()
        {
            List<User> mercados = new List<User>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `users`";
            User ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new User(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetString(4), res.GetString(5), res.GetInt32(6), res.GetInt32(7), res.GetDecimal(8));
                    mercados.Add(ap);
                }
            
            }
            catch (Exception e)
            {

             
            }
            
            con.Close();
            return mercados;
        }

        internal void update(int id , decimal dinero)
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = " UPDATE `users` SET `dineroGastado` = '"+dinero+"' WHERE `users`.`iduser` = "+id+";";
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();


            }
            catch (Exception e)
            {

               

            }

            con.Close();

        }


        internal bool log(string usu, string pass)
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = " SELECT* FROM `users` WHERE `name` LIKE '" + usu + "' AND `pasword` LIKE '" + pass + "'";
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {

                return false;

            }

            con.Close();

        }



        internal List<User> Retrive2(string id)
        {
            List<User> mercados = new List<User>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();        
             comand.CommandText = "SELECT * FROM `users` WHERE `name` LIKE '"+id+"'";
            User ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new User(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetString(4), res.GetString(5), res.GetInt32(6), res.GetInt32(7), res.GetDecimal(8));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }

        

     
        internal void Save(User a)
        {
            //User a = new User(23, "2020-11-05 12:22:54", 1, 23, "123", "123");
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO `users` (`iduser`, `name`, `pasword`, `admin`,`apellido`,`email`,`edad`,`numCuenta`,`dineroGastado`) VALUES ('" + a.iduser + "' , '" + a.name + "' ,'" + a.pasword + "' ,'" + a.admin + "','" + a.apellido + "' ,'" + a.email + "' ,'" + a.edad + "' ,'" + a.numCuenta + "' ,'" + a.dineroGastado + "');";
          
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Insert User");
            }
        }


       




    }

}