using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories1
{
    class UserRepository
    {
        public class UserRepository : IUserRepository, IDisposable
        {
            private UserDBContext context;

            public UserRepository(UserDBContext context)
            {
                this.context = context;
            }

            public IEnumerable<User> GetUser()
            {
                return context.User.ToList();
            }

            public User GetById(int id)
            {
                return context.User.Find(id);
            }

            public void CreateNewUser(User user)
            {
                context.User.Add(user);
            }

            public void UpdateUser(User user)
            {
                context.Entry(user).State = EntityState.Modified;
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
        }
    }
}
