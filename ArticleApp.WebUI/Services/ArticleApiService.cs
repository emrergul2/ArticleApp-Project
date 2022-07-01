
using ArticleApp.Core.DTOs;

namespace ArticleApp.WebUI.Services
{
    public class ArticleApiService
    {
        private readonly HttpClient _httpClient;
        public ArticleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ArticleDto> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ArticleDto>>($"Articles/{id}");
            return response.Data;
        }
        public async Task<List<ArticleDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ArticleDto>>>("Articles");
            return response.Data;
        }
        public async Task<ArticleDto> SaveAsync(ArticleDto articleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Articles", articleDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ArticleDto>>();
            return responseBody.Data;
        }
        public async Task<bool> UpdateAsync(ArticleDto articleDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Articles", articleDto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Articles/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<List<ArticleWithAuthorAndCategoryDto>> GetArticleWithAuthorAndCategory()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ArticleWithAuthorAndCategoryDto>>>("Articles/GetArticleWithAuthorAndCategory");
            return response.Data;
        }
    }
}