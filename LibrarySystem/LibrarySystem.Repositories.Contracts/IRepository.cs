// <copyright file = "IRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IRepository implementators.</summary>

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LibrarySystem.Repositories.Contracts
{
    /// <summary>
    /// Represent a <see cref="IRepository{TEntity}"/> interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of entities provided by the <see cref="Repository"/> class.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Find entity by a given id.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>The entity with the provided id if exist. Otherwise <see cref="null"/>.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Provide all the entities.
        /// </summary>
        /// <returns>All the entities</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Find entities by a given predicate expression.
        /// </summary>
        /// <param name="predicate">Expression by witch entities to be find.</param>
        /// <returns>Collection of entities filtered by the predicate.</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds a given entity to the context.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds a given collection of entities to the context.
        /// </summary>
        /// <param name="entities">Collection of entities to be added.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Remove a given entity.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove given collection of entities.
        /// </summary>
        /// <param name="entities">Collection of entities to remove.</param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
