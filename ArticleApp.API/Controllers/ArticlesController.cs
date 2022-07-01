using ArticleApp.Core.DTOs;
using ArticleApp.Core.Models;
using ArticleApp.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApp.API.Controllers
{
    public class ArticlesController : CustomBaseController
    {
        private readonly IArticleService _service;
        private readonly IMapper _mapper;

        public ArticlesController(IMapper mapper, IArticleService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _service.GetAllAsync();
            var articlesDto = _mapper.Map<List<ArticleDto>>(articles);
            return CreateActionResult<List<ArticleDto>>(CustomResponseDto<List<ArticleDto>>.Success(200, articlesDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _service.GetByIdAsync(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return CreateActionResult<ArticleDto>(CustomResponseDto<ArticleDto>.Success(200, articleDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ArticleInsertDto articleDto)
        {
            var article = await _service.AddAsync(_mapper.Map<Article>(articleDto));
            var articlesDto = _mapper.Map<ArticleDto>(article);
            return CreateActionResult<ArticleDto>(CustomResponseDto<ArticleDto>.Success(201, articlesDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ArticleDto articleDto)
        {
            await _service.UpdateAsync(_mapper.Map<Article>(articleDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var article = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(article);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetArticleWithAuthorAndCategory()
        {
            var articles = await _service.GetArticleWithAuthorAndCategoryAsync();
            return CreateActionResult(articles);
        }
    }
}