using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;
using System.Net.Http.Json;

namespace Fina.App.Services
{
    public class CategoryServices(IHttpClientFactory httpClientFactory) : ICategoryServices
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/categories", request);
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, "Falha ao criar categoria");
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategororyRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                   ?? new Response<Category?>(null, 400, "Falha ao atualizar a categoria");
        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategororyRequest request)
        {
            var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                   ?? new Response<Category?>(null, 400, "Falha ao excluir a categoria");
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategororyByIdRequest request)
            => await _client.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
               ?? new Response<Category?>(null, 400, "Não foi possível obter a categoria");

        public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategororyRequest request)
            => await _client.GetFromJsonAsync<PagedResponse<List<Category>?>>("v1/categories")
               ?? new PagedResponse<List<Category>?>(null, 400, "Não foi possível obter as categorias");
    }
}
