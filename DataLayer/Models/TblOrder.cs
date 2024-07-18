using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblOrder
    {
        [Key]
        public int OrderId { get; set; }

        public string CreatedDate { get; set; }

        [ForeignKey("TblDelivery")]
        public int DeliveryID { get; set; }
    }
}
