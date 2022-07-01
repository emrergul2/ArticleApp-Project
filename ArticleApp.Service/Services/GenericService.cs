using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;
using ArticleApp.Service.Exceptions;

namespace ArticleApp.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class, IEntity, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasArticle = await _repository.GetByIdAsync(id);
            if (hasArticle == null)
            {
                throw new NotFoundException($"{typeof(T).Name} not found.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}