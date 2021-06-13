using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetNewGamesAPI.Models
{
    public class User
    {
        public int iduser { get; set; }
        public string name { get; set; }
        public string pasword { get; set; }
        public int admin { get; set; }

        public string apellido { get; set; }

        public string email { get; set; }

        public int edad { get; set; }

        public int numCuenta { get; set; }

        public decimal dineroGastado { get; set; }




        public User(int Iduser, string Name, string Pasword, int Admin, string Apellido, string Email, int Edad, int NumCuenta, decimal DineroGastado)
        {
            iduser = Iduser;
            name = Name;
            pasword = Pasword;
            admin = Admin;
            apellido = Apellido;
            email = Email;
            edad = Edad;
            numCuenta = NumCuenta;
            dineroGastado = DineroGastado;



        }





    }
}



