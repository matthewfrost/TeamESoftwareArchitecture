using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usersWebService;
using Repositories1;
using DTOs;

namespace Repositories2
{

    public class UserRepository : IUserRepository, IDisposable
    {
        private AdminEntities context;

        public UserRepository(AdminEntities context)
        {
            this.context = context;
        }

        public List<DTOs.User> GetAll()
        {
            var data = context.Admin.ToList();
            List<DTOs.User> user = data.Select(u => new DTOs.User
            {
                ID = u.ID,
                Name = u.Name,
                Email = u.Email
            });
            return user;
        }

        public DTOs.User GetById(int id)
        {
            var data = context.Admin.ToList();
            DTOs.User user = data.Where(u => u.ID == id).Select(u => new DTOs.User
            {
                ID = u.ID,
                Name = u.Name,
                Email = u.Email
            }).FirstOrDefault();
            return user;
        }

        public void CreateNewUser(DTOs.User user)
        {
            usersWebService.Admin us = new usersWebService.Admin();
            us.ID = (int)user.ID;
            us.User = user.Name;
            us.Email = user.Email;
            context.Admin.Add(us);
        }

        public void UpdateUser(DTOs.User user, int ID)
        {
            DTOs.User use = GetById(ID);
            usersWebService.Admin us = new usersWebService.Admin();
            us.ID = (int)use.ID;
            context.Admin.Remove(us);
            us.ID = user.ID;
            us.User = user.Name;
            us.Email = user.Email;
            context.Admin.Add(us);
            // context.Entry(user).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DTOs.User GetByEmail(string email)
        {
            var data = context.Admin.ToList();
            DTOs.User user = data.Where(u => u.Email == email).Select(u => new DTOs.User
            {
                ID = u.ID,
                Name = u.Name,
                Email = u.Email
            }).FirstOrDefault();
            return user;
        }
    }
}
