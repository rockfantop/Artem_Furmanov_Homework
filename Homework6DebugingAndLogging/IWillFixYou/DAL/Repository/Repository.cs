using Core.Models;
using DAL.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : DbEntity
    {
        private readonly IJsonHandler<TEntity> jsonHandler;

        public Repository(IJsonHandler<TEntity> jsonHandler)
        {
            this.jsonHandler = jsonHandler;
        }

        public void Create(TEntity entity)
        {
            this.jsonHandler.Create(entity);
        }

        public TEntity GetEntity(Func<TEntity, bool> condition)
        {
            return this.jsonHandler.GetEntity(condition);
        }
    }
}
