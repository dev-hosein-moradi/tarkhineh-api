using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblFood
    {
        [Key]
        public int FoodId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int RateStar { get; set; }

        [Required]
        public string MainPrice { get; set; }

        public string DiscountPrice { get; set; }

        public int DiscountPercent { get; set; }

        public bool Favorite { get; set; }

        public string Score { get; set; }

        public string Type { get; set; }

        public string Reagion { get; set; }

        public string Tags { get; set; }

        public string CreatedDate { get; set; }

        [ForeignKey("TblBranch")]
        public int BranchID { get; set; }
    }
}
