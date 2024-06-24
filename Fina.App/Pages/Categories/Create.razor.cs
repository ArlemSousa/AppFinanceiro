using Fina.Core.Services;
using Fina.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.App.Pages.Categories
{
    public partial class CreateCategoryPage : ComponentBase // Define a página como um componente Blazor.
    {


        // Indica se a página está processando alguma requisição.
        public bool IsBusy { get; set; } = false;

        // Modelo de dados para a requisição de criação de categoria.
        public CreateCategoryRequest InputModel { get; set; } = new();



        #region Services // Região para injeção de dependências de serviços.

        // Injeta o serviço de categorias.
        [Inject]
        public ICategoryServices Services { get; set; } = null!;

        // Injeta o serviço de navegação entre páginas.
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        // Injeta o serviço de Snackbar para exibir mensagens.
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods // Região para métodos da página.

        // Método executado quando o formulário é submetido com sucesso.
        public async Task OnValidSubmitAsync()
        {
            // Indica que a página está ocupada processando.
            IsBusy = true;

            try
            {
                // Chama o serviço para criar a categoria.
                var result = await Services.CreateAsync(InputModel);

                // Verifica se a criação foi bem-sucedida.
                if (result.IsSuccess)
                {
                    // Exibe mensagem de sucesso e redireciona para a página de categorias.
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/categorias");
                }
                else
                {
                    // Exibe mensagem de erro caso ocorra algum problema na criação.
                    Snackbar.Add(result.Message, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura e exibe mensagens de exceções.
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                // Garante que a flag IsBusy seja definida como false ao final do processo.
                IsBusy = false;
            }
        }

        #endregion
    }
}