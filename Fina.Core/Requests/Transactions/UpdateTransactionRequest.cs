using Fina.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Transactions
{
    public class UpdateTransactionRequest : Request
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Titulo Inválido")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Tipo Inválido")]
        public EtransactionType Type { get; set; } = EtransactionType.WithDaw;

        [Required(ErrorMessage = "Valor Invalido")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "categoria Invalido")]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = "Data Invalido")]
        public DateTime? PaidOrReceivedAt { get; set; }
    }
}
