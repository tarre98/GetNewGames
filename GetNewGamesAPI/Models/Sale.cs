﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// MOLDE DE SALE 
namespace GetNewGamesAPI.Models
{
    public class Sale
    {

        public int idsale { get; set; }
        public int iduser { get; set; }
        public int idgame { get; set; }
        public decimal precio { get; set; }
        public string envio { get; set; }
        public int cantidad { get; set; }


        public Sale(int Idsale, int Iduser, int Idgame, decimal Precio, string Envio, int Cantidad)
        {

            idsale = Idsale;
            iduser = Iduser;
            idgame = Idgame;
            precio = Precio;
            envio = Envio;
            cantidad = Cantidad;


        }

    }
}