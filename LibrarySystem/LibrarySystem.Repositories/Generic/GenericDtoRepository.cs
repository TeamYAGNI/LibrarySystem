using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LibrarySystem.Repositories.Contracts;
using Bytes2you.Validation;

namespace LibrarySystem.Repositories.Generic
{
    public class GenericDtoRepository<TypeDto> : IRepository<TypeDto>
        where TypeDto : class
    {
        private ICollection<TypeDto> dtoData;

        public GenericDtoRepository(ICollection<TypeDto> dtoData)
        {
            Guard.WhenArgument(dtoData, "GenericDtoRepository").IsNull().Throw();

            this.dtoData = dtoData;
        }

        public void Add(TypeDto entity)
        {
            this.dtoData.Add(entity);
        }

        public void AddRange(IEnumerable<TypeDto> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public IEnumerable<TypeDto> Find(Expression<Func<TypeDto, bool>> predicate)
        {
            return this.dtoData.Where(predicate.Compile());
        }

        public TypeDto Get(int id)
        {
            return this.dtoData.ElementAt(id);
        }

        public IEnumerable<TypeDto> GetAll()
        {
            return this.dtoData;
        }

        public void Remove(TypeDto entity)
        {
            this.dtoData.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TypeDto> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }
    }
}
