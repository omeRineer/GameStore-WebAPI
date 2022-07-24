using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, Context> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where Context : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (Context context = new Context())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (Context context = new Context())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (Context context = new Context())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                return filter != null
                       ? context.Set<TEntity>().Where(filter).ToList()
                       : context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (Context context = new Context())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
