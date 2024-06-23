using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Core.Services
{
    public interface ITransactionServices
    {
        Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
        Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
        Task<Response<PagedResponse<List<Transaction>?>>> GetAllAsync(GetTransactionsByPeriodsRequests request);
    }
}
