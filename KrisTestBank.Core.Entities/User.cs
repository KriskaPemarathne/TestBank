using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Entities
{
    public class User
    {
        [Key]

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string PassPortNo { get; set; }
        public string DriverLicenceNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Account> Account { get; set; }
    }
}
