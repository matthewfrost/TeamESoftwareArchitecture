using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Repositories1
{
    public interface IWrapperRepository : IDisposable
    {
        List<Wrapping> GetAll();
        Wrapping GetById(int ID);
        void CreateWrapping(Wrapping wrapping);
        void UpdateWrapping(Wrapping wrapping, int id);
        void Save();
    }
}
