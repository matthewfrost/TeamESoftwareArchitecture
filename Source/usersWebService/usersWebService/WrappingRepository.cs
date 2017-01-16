using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories1;
using DTOs;

namespace usersWebService
{
    public class WrappingRepository : IWrapperRepository, IDisposable
    {
        private WrappingdbEntities context;

        public WrappingRepository(WrappingdbEntities context)
        {
            this.context = context;
        }

        public List<DTOs.Wrapping> GetAll()
        {
            var data = context.Wrapping.ToList();
            List<DTOs.Wrapping> wrapping = data.Select(w => new DTOs.Wrapping
            (
                ID : w.ID,
                TypeID : w.TypeID,
                TypeName : w.TypeName,
                RangeID : w.RangeID,
                RangeName : w.RangeName,
                Price : w.Price,
                Size : w.Size
            )).ToList();
            return wrapping;
        }

        public DTOs.Wrapping GetById(int id)

        {
            var data = context.Wrapping.ToList();
            DTOs.Wrapping wrapping = data.Where(w => w.ID == id).Select(w => new DTOs.Wrapping
            (
                ID : w.ID,
                TypeID : w.TypeID,
                TypeName : w.TypeName,
                RangeID : w.RangeID,
                RangeName : w.RangeName,
                Price : w.Price,
                Size : w.Size
            )).FirstOrDefault();
            return wrapping;
        }

        public void CreateWrapping(DTOs.Wrapping wrappings)
        {
            usersWebService.Wrapping wrapping = new usersWebService.Wrapping();
            wrapping.ID = (int)wrappings.ID;
            wrapping.TypeID = wrappings.TypeID;
            wrapping.TypeName = wrappings.TypeName;
            wrapping.RangeID = wrappings.RangeID;
            wrapping.RangeName = wrappings.RangeName;
            wrapping.Price = wrappings.Price;
            wrapping.Size = wrappings.Size;
            context.Wrapping.Add(wrapping);
        }

        public void UpdateWrapping(DTOs.Wrapping wrappings, int id)
        {
            DTOs.Wrapping wrapping = GetById(id);
            usersWebService.Wrapping wrappin = new usersWebService.Wrapping();
            wrappin.ID = (int)wrapping.ID;
            context.Wrapping.Remove(wrappin);
            wrappin.ID = (int)wrappings.ID;
            wrappin.TypeID = wrappings.TypeID;
            wrappin.TypeName = wrappings.TypeName;
            wrappin.RangeID = wrappings.RangeID;
            wrappin.RangeName = wrappings.RangeName;
            wrappin.Price = wrappings.Price;
            wrappin.Size = wrappings.Size;
            context.Wrapping.Add(wrappin);
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
    }
}