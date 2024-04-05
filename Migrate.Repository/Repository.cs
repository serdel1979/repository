using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Migrate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private DbSet<TEntity> _dbSet;
        public Repository(Context context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();
        }

        async public void Save()
        {
            await _context.SaveChangesAsync();
        }

        void IRepository<TEntity>.Add(TEntity data) => _dbSet.Add(data);

        void IRepository<TEntity>.Delete(int Id)
        {
            var entity = _dbSet.Find(Id);
            _dbSet.Remove(entity);
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll(int pageNumber = 1, int pageSize = 10)
        {
            return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }


        TEntity IRepository<TEntity>.Get(int id)
        {
            return _dbSet.Find(id);
        }



        void IRepository<TEntity>.Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Request(Expression<Func<TEntity, bool>>? filter = null, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<TEntity> request = filter == null ? _dbSet : _dbSet.Where(filter);
            return request.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable();
        }


    }
}
