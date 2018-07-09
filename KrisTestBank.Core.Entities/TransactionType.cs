using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Entities
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public bool IsDeleted { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}
