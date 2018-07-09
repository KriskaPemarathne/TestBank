using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Entities
{
    public class Transaction
    {
        [Key]
                
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public string TransactionNote { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }        
        public int TransactionTypeId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Account Account { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
