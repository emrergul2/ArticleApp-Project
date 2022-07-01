using ArticleApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApp.WebUI.Controllers
{
    // [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly ArticleApiService _articleApiService;

        public ArticleController(ArticleApiService articleApiService)
        {
            _articleApiService = articleApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _articleApiService.GetArticleWithAuthorAndCategory());
        }
    }
}