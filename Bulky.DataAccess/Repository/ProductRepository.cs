using bulky.Models.Models;
using Bulky.DataAccess.Repository.IRepository;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
    

        

        public void Update(Product obj)
        {
            _db.products.Update(obj);    
        }
    }
}
