using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;
using System.Net.Http.Json;

namespace Fina.App.Services
{
    public class CategoryServices(IHttpClientFactory httpClientFactory) : ICategoryServices
    {
        //criar o client
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var result = await _client.PostAsJsonAsync("v1/categories", request);

                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadFromJsonAsync<Response<Category?>>();
                }
                else
                {
                    var errorResponse = await result.Content.ReadAsStringAsync();
                    return new Response<Category?>(null, (int)result.StatusCode, $"Erro na requisição: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                // Capture and log the exception details for debugging
                // You can use a logging framework (e.g., Serilog, NLog) or write to a file
                Console.WriteLine($"Exceção ao criar categoria: {ex.Message}");

                // Return a generic error response to the user
                return new Response<Category?>(null, 500, "Erro interno ao processar a requisição");
            }

        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategororyRequest request)
        {
            var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                   ?? new Response<Category?>(null, 400, "Falha ao excluir a categoria");
        }

        public async Task<Response<PagedResponse<List<Category>?>>> GetAllAsync(GetAllCategororyRequest request)
        {
            var pagedResponse = await _client.GetFromJsonAsync<PagedResponse<List<Category>?>>("v1/categories")
                              ?? new PagedResponse<List<Category>?>(null, 400, "Não foi possível obter as categorias");
            return new Response<PagedResponse<List<Category>?>>(pagedResponse, 200, "Categorias obtidas com sucesso"); 
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategororyByIdRequest request)
       => await _client.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
          ?? new Response<Category?>(null, 400, "Não foi possível obter a categoria");

        public async Task<Response<Category?>> UpdateAsync(UpdateCategororyRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                   ?? new Response<Category?>(null, 400, "Falha ao atualizar a categoria");
        }

    }
}
