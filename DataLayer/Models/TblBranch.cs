using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TblBranch
    {
        [Key]
        [Required]
        public int BranchId { get; set; }

        [Required]
        public string OwnerFullName { get; set; }

        [Required]
        public string OwnerNatCode { get; set; }

        [Required]
        public string OwnerPhone { get; set; }

        [Required]
        public string OwnerState { get; set; }

        [Required]
        public string OwnerCity { get; set; }

        [Required]
        public string OwnerRegion { get; set; }

        [Required]
        public string OwnerAddress { get; set; }

        // نوع مالکیت
        [Required]
        public string OwnerType { get; set; }

        [Required]
        public string PlaceArea { get; set; }

        [Required]
        public int PalceAge { get; set; }

        [Required]
        public bool Verification { get; set; }

        [Required]
        public bool Kitchen { get; set; }

        [Required]
        public bool Parking { get; set; }

        [Required]
        public bool Store { get; set; }

        [Required]
        public string WorkingTime { get; set; }

        [Required]
        public string Tel1 { get; set; }

        public string Tel2 { get; set; }

        public string CreatedDate { get; set; }
    }
}
