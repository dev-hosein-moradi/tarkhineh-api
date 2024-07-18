using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblCustomer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string BirthDate { get; set; }

        public string NickName { get; set; }

        [Required]
        public string Role { get; set; }

        public string CreatedDate { get; set; }
    }
}
