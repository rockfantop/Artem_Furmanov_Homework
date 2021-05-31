using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : DbEntity
    {
        void Create(TEntity entity);

        TEntity GetEntity(Func<TEntity, bool> condition);
    }
}
