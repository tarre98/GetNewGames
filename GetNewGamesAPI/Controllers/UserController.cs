
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

        //get all
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<User> Get()
        {
            return new UserRepositorio().Retrive();
        }

        //get games desde aqui, porq borre el enablecors de game (no funcionaba la api), y lo he puesto aaqui
        [HttpGet]
        [ActionName("Getgame")]
        public IEnumerable<Game> GetGame()
        {
            return new GameRepositorio().Retrive();
        }

        //get games de id
        [HttpGet]
        [Route("api/Games/Get/{id}")]
        public IEnumerable<Game> Get(int id)
        {
            return new GameRepositorio().Retrive2(id);
        }

        //get game de plataforma de games
        [HttpGet]
        [Route("api/GamesPlataform/Get/{id}")]
        public IEnumerable<Game> GetPlataform(string id)
        {
            return new GameRepositorio().Retrive3(id);
        }

        //get de nombre juegos
        [HttpGet]
        [Route("api/GamesName/Get/{id}")]
        public IEnumerable<Game> GetName(string id)
        {
            return new GameRepositorio().Retrive4(id);
        }

        // comprueba si es true o false el login
        [HttpGet]
        [Route("api/User/Log/{user}/{pass}")]
  
        public bool log(string user,string pass)
        {
            return new UserRepositorio().log(user, pass);
        }

        // actualiza dinero total
        [HttpGet]
        [Route("api/User/Put/{dinero}/{id}")]

        public void put(decimal dinero, int id)
        {
             new UserRepositorio().update(id, dinero);
        }

        // filtro por id user
        [HttpGet]
        [Route("api/User/Get/{id}")]
        public IEnumerable<User> Get(string id)
        {
            return new UserRepositorio().Retrive2(id);
        }

        // post de user
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