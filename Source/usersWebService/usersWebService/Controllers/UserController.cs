using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace usersWebService.Controllers
{
    public class UserController : ApiController
    {
        UserRepository userrepository;

        public UserController()
        {
            this.userrepository = new UserRepository(new UserdbEntities());
        }
        // GET: api/User
        public List<DTOs.User>Get()
        {
            return userrepository.GetAll();
        }

        // GET: api/User/5
        public DTOs.User GetById(int id)
        {
            return userrepository.GetById(id);
        }

        // POST: api/User
        public void Post([FromBody]DTOs.User user)
        {
            userrepository.CreateNewUser(user);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]DTOs.User user)
        {
            userrepository.UpdateUser(user, id);
        }

        //GET: api/User/ByEmail/5
        public DTOs.User GetByEmail(String email)
        {
            return userrepository.GetByEmail(email);
        }
    }
}
