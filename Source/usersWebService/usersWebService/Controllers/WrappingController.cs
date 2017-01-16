using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace usersWebService.Controllers
{
    public class WrappingController : ApiController
    {
        WrappingRepository wrappingrepository;

        public WrappingController()
        {
            this.wrappingrepository = new WrappingRepository(new WrappingdbEntities());
        }
        // GET: api/Wrapping
        public List<DTOs.Wrapping> Get()
        {
            return wrappingrepository.GetAll();
        }

        // GET: api/Wrapping/5
        public DTOs.Wrapping GetById(int id)
        {
            return wrappingrepository.GetById(id);        }

        // POST: api/Wrapping
        public void Post([FromBody]DTOs.Wrapping wrapping)
        {
            wrappingrepository.CreateWrapping(wrapping);
        }

        // PUT: api/Wrapping/5
        public void Put(int id, [FromBody]DTOs.Wrapping wrapping)
        {
            wrappingrepository.UpdateWrapping(wrapping, id);
        }
    }
}
