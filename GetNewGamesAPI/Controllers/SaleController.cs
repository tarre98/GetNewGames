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

    [Route("api/Sale/{action}")]


    
    public class SaleController : ApiController
    {
        //GET TOTAL
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Sale> Get()
        {
            return new SaleRepositorio().Retrive();
        }

        // GET ENVIO NACIONAL
        [HttpGet]
        [ActionName("GetN")]
        public IEnumerable<Sale> GetN()
        {
            return new SaleRepositorio().RetriveN();

        }

        // GET ENVIO INTERNACIONAL
        [HttpGet]
        [ActionName("GetI")]
        public IEnumerable<Sale> GetI()
        {
            return new SaleRepositorio().RetriveI();
        }

        // FILTRO POR ID 
        [HttpGet]
        [Route("api/Sale/Get/{id}")]
        public IEnumerable<Sale> Get(int id)
        {
            return new SaleRepositorio().Retrive2(id);
        }

        // FILTRO POR GAME
        [HttpGet]
        [Route("api/Sale/Get/Game/{id}")]
        public IEnumerable<Sale> GetG(int id)
        {
            return new SaleRepositorio().RetriveByG(id);
        }

        // FILTRO POR USUARIO
        [HttpGet]
        [Route("api/Sale/Get/User/{id}")]
        public IEnumerable<Sale> GetU(int id)
        {
            return new SaleRepositorio().RetriveByU(id);
        }

        // FILTRO BETWEEN PRECIOS
        [HttpGet]
        [Route("api/Sale/Get/Precio/{p1}/{p2}")]
        public IEnumerable<Sale> GetP(int p1, int p2)
        {
            return new SaleRepositorio().RetriveP(p1, p2);
        }

        // POST DE LA BASE DE DATOS
        [HttpPost]
        [ActionName("post")]
          
        public void Post([FromBody] Sale value)
        {
            var repo = new SaleRepositorio();
            repo.Save(value);
        }



        public void Put(int id, [FromBody] string value)
        {
        }


        public void Delete(int id)
        {
        }
    }
}