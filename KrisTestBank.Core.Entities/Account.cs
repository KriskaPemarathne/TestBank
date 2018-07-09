using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }        
        public DateTime CreatedDate { get; set; }
        public double AccountBalance { get; set; }
        public int UserId { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }
        public List<Transaction> Transaction { get; set; }

    }
}
