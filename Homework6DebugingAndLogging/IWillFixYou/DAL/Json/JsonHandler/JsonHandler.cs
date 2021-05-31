using Core.Models;
using DAL.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Json.JsonHandler
{
    public class JsonHandler<TEntity> : IJsonHandler<TEntity>
        where TEntity : DbEntity
    {
        private readonly ILogger<JsonHandler<TEntity>> logger;

        public JsonHandler(ILogger<JsonHandler<TEntity>> logger)
        {
            this.logger = logger;
        }

        public void Create(TEntity entity)
        {
            try
            {
                using (StreamWriter file = File.CreateText($"..//..//..//..//{typeof(TEntity).Name}.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.NullValueHandling = NullValueHandling.Include;
                    serializer.Serialize(file, entity);
                }
            }
            catch (Exception)
            {
                this.logger.LogError($"User {entity} wasn`t added to file", entity);
            }
        }

        public TEntity GetEntity(Func<TEntity, bool> condition)
        {
            try
            {
                using (StreamReader file = File.OpenText($"..//..//..//..//{typeof(TEntity).Name}.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    var item = (TEntity)serializer.Deserialize(file, typeof(TEntity));

                    if (item == null)
                    {
                        return null;
                    }

                    return item;
                }
            }
            catch (Exception)
            {
                this.logger.LogError($"User wasn`t found by the condition {condition.Method}", condition);

                return null;
            }
        }
    }
}
