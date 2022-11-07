using HardwareStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.DataAccess.Repository.IRepository
{
    public interface IFinishRepository : IRepository<Finish>
    {
        void Update(Finish obj);
    }
}
