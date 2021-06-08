using Placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetNewGamesAPI.Controllers
{

    [Route("api/Apuesta/{action}")]
    public class UserController : ApiController
    {
        // GET api/<controller>

        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<User> Get()
        {
            return new UserRepositorio().Retrive();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}