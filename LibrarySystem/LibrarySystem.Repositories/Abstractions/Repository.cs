using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Bytes2you.Validation;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Data;

namespace LibrarySystem.Repositories.Abstractions
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DbContext context;

        protected Repository(DbContext context)
        {
            this.Context = context;
        }

        protected DbContext Context
        {
            get
            {
                return this.context;
            }

            private set
            {
                Guard.WhenArgument(value, "Context").IsNull().Throw();

                this.context = value;
            }
        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
