using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblDelivery
    {
        [Key]
        public int DeliveryId { get; set; }

        [ForeignKey("TblCustomer")]
        public int CustomerID { get; set; }

        [ForeignKey("TblAddress")]
        public int AddressID { get; set; }

        [ForeignKey("TblAgent")]
        public int AgentID { get; set; }

        public string StartDate { get; set; }

        public string FinishDate { get; set; }

        public string SendType { get; set; }

        public string SendPrice { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string GuesDate { get; set; }

        public string CreatedDate { get; set; }
    }
}
