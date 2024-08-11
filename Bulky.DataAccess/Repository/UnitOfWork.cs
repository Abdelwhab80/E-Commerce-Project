using Bulky.DataAccess.Repository.IRepository;
using E_Commerce_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository categoryRepository { get; private set; }

        public IProductRepository ProductRepository {  get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            categoryRepository = new CategoryRepository(_db);
            ProductRepository = new ProductRepository(_db);
            CompanyRepository = new CompanyRepository(_db);
        }

        public void Save()
        {
             _db.SaveChanges();

        }
    }
}
