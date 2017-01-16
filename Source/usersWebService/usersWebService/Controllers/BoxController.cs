using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace usersWebService.Controllers
{
    public class BoxController : ApiController
    {
        BoxRepository boxrepository;

        public BoxController()
        {
            this.boxrepository = new BoxRepository(new BoxdbEntities(), new ProductdbEntities());
        }
        // GET: api/Box
        public List <DTOs.Box> Get()
        {
            return boxrepository.GetAll();
        }

        // GET: api/Box/5
        public DTOs.Box GetById(int id)
        {
            return boxrepository.GetById(id);
        }

        // POST: api/Box
        public void Post([FromBody]DTOs.Box box)
        {
            boxrepository.CreateBox(box);
        }

        // PUT: api/Box/5
        public void Put(int id, [FromBody]DTOs.Box box)
        {
            boxrepository.UpdateBox(box, id);
        }
    }
}
