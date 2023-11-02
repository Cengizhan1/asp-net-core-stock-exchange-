using Data.Context;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Data.Repositories.Abstraction;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity , new()
    {
        private readonly AppDbContext dbContext;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<List<T>> GetAll(Expression<Func<T,bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties )
        {
            IQueryable<T> query = Table;
            if ( predicate != null )
                query = query.Where( predicate );
            if ( includeProperties.Any())
            {
                foreach ( var item in includeProperties)
                {
                    query = query.Include( item );
                }
            }
            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await dbContext.SaveChangesAsync(); 

        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where( predicate );

            if( includeProperties.Any())
            {
                foreach( var item in includeProperties)
                 query = query.Include( item ); 
            }
            return await query.SingleAsync();
        }

        public async Task<T> GetByGuid(Guid guid)
        {
            return await Table.FindAsync(guid);
        }

        public async Task<T> Update(T entity)
        {
            await Task.Run(()=>Table.Update(entity));
            return entity;  
        }

        public async Task Delete(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
