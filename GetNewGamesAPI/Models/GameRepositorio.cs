using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetNewGamesAPI.Models
{
    public class GameRepositorio
    {

        //CONEXION BASE DE DATOS
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

        // RECOGE TODA LA INFO DE LA BASE DE DATOS (GET)
        internal List<Game> Retrive()
        {
            //RECOGE TODA LA INFO DE GAMES
            List<Game> mercados = new List<Game>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM games";
            //DECLARAMOS UN GAME VACIO, QUE VAMOS A IR RELLENANDO CON LA BASE DE DATOS
            Game ap = null;
            try
            {
                // EJECUTAS COMANDO DE ARRIBA
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                //MIENTRAS QUE LA RESPUESTA SIGA LEYENDO :
                while (res.Read())
                {
                    //RELLENAMOS LA VARIABLE CON LOS DATOS DE LA BASE DE DATOS HASTA LEER TODOS
                    ap = new Game(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(4), res.GetString(3), res.GetDecimal(5), res.GetDecimal(6), res.GetDecimal(7));
                    //RELLENAMOS LA LISTA DE MERCADOS
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {


            }

            con.Close();
            //DEVUELVE LISTA MERCADOS
            return mercados;
        }





        //filtro para buscar solo por el id del juego
        internal List<Game> Retrive2(int id)
        {
            List<Game> mercados = new List<Game>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `games` WHERE `idGames` = '" + id + "'";
            Game ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new Game(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetDecimal(5), res.GetDecimal(6), res.GetDecimal(7));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }

        // filtro para buscar por plataforma
        internal List<Game> Retrive3(string id)
        {
            List<Game> mercados = new List<Game>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `games` WHERE `plataforma` LIKE '" + id + "'";
            Game ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new Game(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetDecimal(5), res.GetDecimal(6), res.GetDecimal(7));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }

        // filtro para buscar por nombre
        internal List<Game> Retrive4(string id)
        {
            List<Game> mercados = new List<Game>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `games` WHERE `nombre` LIKE '" + id + "'";
            Game ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    ap = new Game(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetDecimal(5), res.GetDecimal(6), res.GetDecimal(7));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
            }

            con.Close();
            return mercados;
        }

    }
}