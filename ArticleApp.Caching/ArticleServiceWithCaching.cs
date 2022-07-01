using ArticleApp.Core.DTOs;
using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;
using ArticleApp.Service.Exceptions;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace ArticleApp.Caching
{
    public class ArticleServiceWithCaching : IArticleService
    {
        private const string CacheArticleKey = "articleKey";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IArticleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleServiceWithCaching(IUnitOfWork unitOfWork, IArticleRepository repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;
            if (!_memoryCache.TryGetValue(CacheArticleKey, out _))
            {
                _memoryCache.Set(CacheArticleKey, _repository.GetArticleWithAuthorAndCategoryAsync().Result);
            }
        }
        public async Task CacheAllArticlesAsync()
        {
            _memoryCache.Set(CacheArticleKey, await _repository.GetArticleWithAuthorAndCategoryAsync());
        }
        public async Task<Article> AddAsync(Article entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllArticlesAsync();
            return entity;
        }
        public Task<IEnumerable<Article>> GetAllAsync()
        {
            var articles = _memoryCache.Get<IEnumerable<Article>>(CacheArticleKey);
            return Task.FromResult(articles);
        }
        public Task<Article> GetByIdAsync(int id)
        {
            var article = _memoryCache.Get<List<Article>>(CacheArticleKey).FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                throw new NotFoundException($"{typeof(Article).Name}({id}) not found");
            }
            return Task.FromResult(article);
        }
        public async Task RemoveAsync(Article entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllArticlesAsync();
        }
        public async Task UpdateAsync(Article entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllArticlesAsync();
        }

        public async Task<CustomResponseDto<List<ArticleWithAuthorAndCategoryDto>>> GetArticleWithAuthorAndCategoryAsync()
        {
            var articles = await _repository.GetArticleWithAuthorAndCategoryAsync();
            var articleWithAuthorAndCategoryDto = _mapper.Map<List<ArticleWithAuthorAndCategoryDto>>(articles);
            return await Task.FromResult(CustomResponseDto<List<ArticleWithAuthorAndCategoryDto>>.Success(200, articleWithAuthorAndCategoryDto));
        }
    }
}