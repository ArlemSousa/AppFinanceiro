using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;

namespace Fina.App.Services
{
    public class CategoryServices(IHttpClientFactory httpClientFactory) : ICategoryServices
    {
        //criar o client
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

        public Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> DeleteAsync(DeleteCategororyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PagedResponse<List<Category>?>>> GetAllAsync(GetAllCategororyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> GetByIdAsync(GetCategororyByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> UpdateAsync(UpdateCategororyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
