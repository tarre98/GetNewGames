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


        public User(int Iduser, string Name, string Pasword, int Admin)
        {
            iduser = Iduser;
            name = Name;
            pasword = Pasword;
            admin = Admin;

        }





    }
}



