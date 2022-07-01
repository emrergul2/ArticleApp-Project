using ArticleApp.Core.DTOs;
using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;
using AutoMapper;

namespace ArticleApp.Service.Services
{
    public class ArticleServiceWithNoCaching : GenericService<Article>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public ArticleServiceWithNoCaching(IGenericRepository<Article> repository, IUnitOfWork unitOfWork, IMapper mapper, IArticleRepository articleRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }
        public async Task<CustomResponseDto<List<ArticleWithAuthorAndCategoryDto>>> GetArticleWithAuthorAndCategoryAsync()
        {
            var articles = await _articleRepository.GetAllAsync();
            var articleDto = _mapper.Map<List<ArticleWithAuthorAndCategoryDto>>(articles);
            return CustomResponseDto<List<ArticleWithAuthorAndCategoryDto>>.Success(200, articleDto);
        }
    }
}