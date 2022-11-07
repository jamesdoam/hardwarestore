using HardwareStore.DataAccess.Repository.IRepository;
using HardwareStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.DataAccess.Repository
{
    public class FinishRepository : Repository<Finish>, IFinishRepository
    {
        private ApplicationDbContext _db;
        public FinishRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Finish obj)
        {
            _db.Finishes.Update(obj);
        }
    }
}
