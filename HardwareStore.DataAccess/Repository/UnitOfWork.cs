using HardwareStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Finish = new FinishRepository(_db);
        }
    
        public ICategoryRepository Category {get;private set;}
        public IFinishRepository Finish { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
