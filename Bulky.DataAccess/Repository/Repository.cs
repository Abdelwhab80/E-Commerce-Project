using Bulky.DataAccess.Repository.IRepository;
using E_Commerce_Project.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public Repository( ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
            _db.products.Include(u => u.category).Include(u => u.CategoryID);
        }
        public void Add(T entity)
        {
            dbset.Add(entity);

        }
        public T Get(Expression<Func<T, bool>> filter, string? incprop = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(incprop))
            {
                foreach (var item in incprop.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incprop);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? incprop = null)
        {
            IQueryable<T> query = dbset;
            if (!string.IsNullOrEmpty(incprop))
            {
                foreach (var item in incprop.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incprop);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
