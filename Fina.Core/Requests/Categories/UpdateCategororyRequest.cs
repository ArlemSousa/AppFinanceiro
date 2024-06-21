using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories
{
    public class UpdateCategororyRequest : Request
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Título Inválido")]
        [MaxLength(80, ErrorMessage = "Até 80 caracteres por favor!")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição Inválida")]
        public string Description { get; set; } = string.Empty;
    }
}
