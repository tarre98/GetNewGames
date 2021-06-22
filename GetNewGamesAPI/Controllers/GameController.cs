using GetNewGamesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GetNewGamesAPI.Controllers
{
    
    //generamos rutas que establecer
    [Route("api/Game/{action}")]
    public class GameController : ApiController
    {
        //ruta general para leer todo
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Game> Get()
        {
            //se usa en el metodo de retrive
            return new GameRepositorio().Retrive();
        }

        //filtro para buscar por id
        [HttpGet]
        [Route("api/Game/Get/{id}")]
        public IEnumerable<Game> Get(int id)
        {
            //se usa en el metodo de retrive2
            return new GameRepositorio().Retrive2(id);
        }

        public void Post([FromBody] string value)
        {
        }


        public void Put(int id, [FromBody] string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
