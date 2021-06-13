
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [Route("api/User/{action}")]
    public class UserController : ApiController
    {


        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<User> Get()
        {
            return new UserRepositorio().Retrive();
        }

        [HttpGet]
        [ActionName("Getgame")]
        public IEnumerable<Game> GetGame()
        {
            return new GameRepositorio().Retrive();
        }

        [HttpGet]
        [Route("api/Games/Get/{id}")]
        public IEnumerable<Game> Get(int id)
        {
            return new GameRepositorio().Retrive2(id);
        }

        [HttpGet]
        [Route("api/User/Log/{user}/{pass}")]
  
        public bool log(string user,string pass)
        {
            return new UserRepositorio().log(user, pass);
        }

        [HttpGet]
        [Route("api/User/Get/{id}")]
        public IEnumerable<User> Get(string id)
        {
            return new UserRepositorio().Retrive2(id);
        }


        [HttpPost]
        [ActionName("post")]



        public void Post([FromBody] User value)
        {
            var repo = new UserRepositorio();
            repo.Save(value);
        }


        public void Put(int id, [FromBody]string value)
        {
        }


        public void Delete(int id)
        {
        }
    }
}