using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Repository
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Request(Expression<Func<TEntity, bool>>? filter = null, int pageNumber = 1, int pageSize = 10);
        IEnumerable<TEntity> GetAll(int pageNumber = 1, int pageSize = 10);
        TEntity Get(int id);
        void Add(TEntity data);
        void Delete(int Id);
        void Update(TEntity data);
        void Save();

    }
}
