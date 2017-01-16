using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;
using Repositories1;

namespace usersWebService
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private UserdbEntities context;

        public UserRepository(UserdbEntities context)
        {
            this.context = context;
           
        }

        public UserRepository(IUserRepository @object)
        {
            this.@object = @object;
        }

        public List<DTOs.User> GetAll() 
        {
            var data = context.User.ToList();
            List<DTOs.User> user = data.Select(u => new DTOs.User
            (
                ID : u.ID,
                Name : u.Name,
                Email : u.Email
            )).ToList();
            return user;
        }

        public DTOs.User GetById(int id)
        {
            var data = context.User.ToList();
            DTOs.User user = data.Where(u => u.ID == id).Select(u => new DTOs.User
            (
                ID : u.ID,
                Name : u.Name,
                Email : u.Email
            )).FirstOrDefault();
            return user;
        }

        public void CreateNewUser(DTOs.User user)
        {
            usersWebService.User us = new usersWebService.User();
            us.ID = (int)user.ID;
            us.Name = user.Name;
            us.Email = user.Email;
            context.User.Add(us);
        }

        public void UpdateUser(DTOs.User user, int ID)
        {
            DTOs.User use = GetById(ID);
            usersWebService.User us = new usersWebService.User();
            us.ID = (int)use.ID;
            context.User.Remove(us);
            us.ID = user.ID;
            us.Name = user.Name;
            us.Email = user.Email;
            context.User.Add(us);
            // context.Entry(user).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        private IUserRepository @object;

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
            var data = context.User.ToList();
            DTOs.User user = data.Where(u => u.Email == email).Select(u => new DTOs.User
            (
                ID : u.ID,
                Name : u.Name,
                Email : u.Email
            )).FirstOrDefault();
            return user;
        }
    }
}