using Fina.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Models
{
    internal class Transaction
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaidOrReceivedAt { get; set; }

        public EtransactionType Type { get; set; } = EtransactionType.WithDaw;

        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public string? UserId { get; set; }

    }
}
