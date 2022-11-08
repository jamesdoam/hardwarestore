using HardwareStore.DataAccess.Repository.IRepository;
using HardwareStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            //do the following if you want to update a certain properties (not all)
            var objFromDb = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Price = obj.Price;
                objFromDb.SalePrice = obj.SalePrice;
                objFromDb.Description = obj.Description;
                objFromDb.Sku = obj.Sku;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.FinishId = obj.FinishId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
                objFromDb.CreatedDateTime = DateTime.Now;
            }
            //_db.Products.Update(obj);
        }
    }
}
