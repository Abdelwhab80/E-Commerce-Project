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
    public class CompanyRepository : Repository<Company> ,ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
    

        

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);    
        }
    }
}
