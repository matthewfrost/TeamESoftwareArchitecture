using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Repositories1
{
    public interface IBoxRepository : IDisposable
    {
        List<Box> GetAll();
        Box GetById(int ID);
        bool CreateBox(Box box);
        void UpdateBox(Box box, int id);
        void Save();

    }

}
