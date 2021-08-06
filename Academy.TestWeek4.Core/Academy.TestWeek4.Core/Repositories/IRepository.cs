using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.TestWeek4.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Fetch();
        TEntity GetById(int id);
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}
