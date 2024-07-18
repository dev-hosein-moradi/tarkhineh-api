using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblPayment
    {
        [Key]
        public int PaymentId { get; set; }

        public string DiscountCode { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string PaymentAgent { get; set; }

        [Required]
        public string Price { get; set; }

        public string Status { get; set; }

        public string CreatedDate { get; set; }
    }
}
