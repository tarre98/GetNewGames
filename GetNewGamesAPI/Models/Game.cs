using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// MOLDE DE GAME 
namespace GetNewGamesAPI.Models
{
    public class Game
    {

        public int idgames { get; set; }
        public string nombre { get; set; }
        public string plataforma { get; set; }
        public string fechaSalida { get; set; }
        public string descripcion { get; set; }
        public decimal gastosEnvio { get; set; }
        public decimal gastosEnvioInternacional { get; set; }
        public decimal precio { get; set; }


        public Game(int Idgames, string Nombre, string Plataforma, string Descripcion, string FechaSalida, decimal GastosEnvio, decimal Precio, decimal GastosEnvioInternacional)
        {
            idgames = Idgames;
            nombre = Nombre;
            plataforma = Plataforma;
            descripcion = Descripcion;
            fechaSalida = FechaSalida;
            gastosEnvio = GastosEnvio;
            precio = Precio;
            gastosEnvioInternacional = GastosEnvioInternacional;

        }

    }
}