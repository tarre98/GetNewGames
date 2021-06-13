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
    

    [Route("api/Game/{action}")]
    public class GameController : ApiController
    {

        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Game> Get()
        {
            return new GameRepositorio().Retrive();
        }

        [HttpGet]
        [Route("api/Game/Get/{id}")]
        public IEnumerable<Game> Get(int id)
        {
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
