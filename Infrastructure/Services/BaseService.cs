using System;
using AutoMapper;
using Core.Repository;
using Core.Services;

namespace Infrastructure.Services
{
    public class BaseService<DtoType, AddDtoType, ModelType, TRepository> : IBaseService<DtoType, AddDtoType, ModelType, TRepository>
        where DtoType : class
        where AddDtoType : class
        where ModelType : class
        where TRepository : IBaseRepository<ModelType>
    {
        protected readonly IMapper _mapper;
        protected TRepository repository;

        public BaseService(TRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Count()
        {
            var count = await repository.Count();

            return count;
        }

        public virtual async Task<DtoType> CreateAsync(AddDtoType obj)
        {
            var addobject = _mapper.Map<ModelType>(obj);

            if (addobject != null)
            {
                var incomeCreated = await repository.CreateAsync(addobject);

                return _mapper.Map<DtoType>(incomeCreated);
            }
            return null;
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            return await repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<DtoType>> GetAllAsync()
        {
            var objects = await repository.GetAllAsync();

            return _mapper.Map<IEnumerable<DtoType>>(objects);
        }

        public virtual async Task<DtoType> GetByIdAsync(string id)
        {
            var obj = await repository.GetByIdAsync(id);

            return _mapper.Map<DtoType>(obj);
        }

        public virtual async Task<DtoType> UpdateAsync(string id, DtoType obj)
        {
            var objectFromDatabase = await this.repository.GetByIdAsync(id);

            if (objectFromDatabase != null)
            {
                _mapper.Map(obj, objectFromDatabase);

                var updatedObj = await this.repository.UpdateAsync(objectFromDatabase);

                return _mapper.Map<DtoType>(updatedObj);
            }

            return null;
        }
    }
}
