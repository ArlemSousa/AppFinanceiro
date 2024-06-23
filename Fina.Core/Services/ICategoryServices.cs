using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Services
{
    public interface ICategoryServices
    {
        
        Task<Response<Category?>> DeleteAsync(DeleteCategororyRequest request);
        Task<Response<Category?>> GetByIdAsync(GetCategororyByIdRequest request);
        Task<Response<Category?>> UpdateAsync(UpdateCategororyRequest request);
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
        Task<Response<PagedResponse<List<Category>?>>> GetAllAsync(GetAllCategororyRequest request);
    }
}
