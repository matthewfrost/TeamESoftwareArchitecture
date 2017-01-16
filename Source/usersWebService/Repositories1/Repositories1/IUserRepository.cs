using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;


namespace Repositories1
{
    public interface IUserRepository :IDisposable
    {
        List<User> GetAll();
        User GetById(int userID);
        void CreateNewUser(User user);
        void UpdateUser(User user, int ID);
        void Save();
        User GetByEmail(string email);
    }
}
