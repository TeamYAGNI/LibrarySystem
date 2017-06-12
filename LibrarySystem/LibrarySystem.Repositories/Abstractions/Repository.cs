// <copyright file="Repository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Repository{TEntity} abstract class.</summary>

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using Bytes2you.Validation;

using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Abstractions
{
    /// <summary>
    /// Represent a <see cref="Repository"/> class implementator of <see cref="IRepository"/> interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of entities provided by the instance of the <see cref="Repository"/> class heir.</typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Context providing connection to the database.
        /// </summary>
        private DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class heir.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        protected Repository(DbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets the Context of the <see cref="Repository"/> class.
        /// </summary>
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

        /// <summary>
        /// Adds a given entity to the context.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Adds a given collection of entities to the context.
        /// </summary>
        /// <param name="entities">Collection of entities to be added.</param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Find entities by a given predicate expression.
        /// </summary>
        /// <param name="predicate">Expression by witch entities to be find.</param>
        /// <returns>Collection of entities filtered by the predicate.</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate).ToList();
        }

        /// <summary>
        /// Find entity by a given id.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>The entity with the provided id if exist. Otherwise <see cref="null"/>.</returns>
        public TEntity Get(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Provide all the entities.
        /// </summary>
        /// <returns>All the entities</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Remove a given entity.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Remove given collection of entities.
        /// </summary>
        /// <param name="entities">Collection of entities to remove.</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
