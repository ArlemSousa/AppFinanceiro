using Fina.Api.Data;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Services
{
    public class CategoryServices(AppDbContext context) : ICategoryServices
    {
        private readonly AppDbContext _context = context;

        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description
            };

            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return new Response<Category?>(category, 201, "Categoria criada com sucesso!");
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível criar a categoria");
            }
        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategororyRequest request)
        {
            //primeiro procurar a categoria
            var category = await _context.Categories.FindAsync(request.Id);
            if (category == null) //se a categoria não existir retorna mensagem de erro.
            {
                return new Response<Category?>(data: null, code: 404, message: "Categoria não encontrada.");
            }

            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return new Response<Category?>(data: null, code: 204, message: "Categoria excluída com sucesso.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao excluir a categoria: {ex.Message}");
                return new Response<Category?>(data: null, code: 500, message: "Erro ao excluir a categoria.");
            }
        }
        
        public async Task<Response<Category?>> UpdateAsync(UpdateCategororyRequest request)
        {
            try
            {
                //assim como o delete, tem que verificar se existe no banco primeiro
                var existingCategory = await _context.Categories.FindAsync(request.Id);

                if (existingCategory == null)
                {
                    return new Response<Category?>(data: null, code: 404, message: "Categoria não encontrada.");
                }

                // atualizar a categoria
                existingCategory.Title = request.Title;
                existingCategory.Description = request.Description;

                await _context.SaveChangesAsync();

                return new Response<Category?>(data: existingCategory, code: default, message: "Categoria atualizada com sucesso.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error updating category: {ex.Message}");
                return new Response<Category?>(data: null, code: 500, message: "Erro ao atualizar a categoria.");
            }
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategororyByIdRequest request)
        {
            try
            {
                //Usar AsNoTracking() para operações somente leitura, pois a busca fica mais performática.
                //nesse cenário, nao se usa o FindAsync, mas sim o FirstOrDefault.
                var category = await _context.Categories.AsNoTracking()
                                              .FirstOrDefaultAsync(c => c.Id == request.Id);

                if (category == null)
                {
                    return new Response<Category?>(data: null, code: 404, message: "Categoria não encontrada.");
                }

                return new Response<Category?>(data: category, code: 200, message: "Categoria obtida com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter a categoria: {ex.Message}");
                return new Response<Category?>(data: null, code: 500, message: "Erro ao obter a categoria.");
            }
        }

        public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategororyRequest request)
        {
             try
            {
                var query = context
                    .Categories
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.Title);

                var categories = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Category>?>(
                    categories,
                    count,
                    request.PageNumber,
                    request.PageSize);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error getting categories: {ex.Message}");
                return new PagedResponse<List<Category>?>(null, 500, "Não foi possível consultar as categorias");
            }
        }
    }
}
