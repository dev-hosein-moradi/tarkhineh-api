using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblCart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("TblFood")]
        public int FoodID { get; set; }
        
        [ForeignKey("TblDelivery")]
        public int DeliveryID { get; set; }

        public string Status { get; set; }

        public string CreatedDate { get; set; }

    }
}
