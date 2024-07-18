using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TarkhinehDbContext : DbContext
    {
        public TarkhinehDbContext()
        {

        }

        public TarkhinehDbContext(DbContextOptions<TarkhinehDbContext> options)
              : base(options)
        {
           
        }
        public virtual DbSet<TblAddress> TblAddress { get; set; }
        public virtual DbSet<TblAgent> TblAgent { get; set; }
        public virtual DbSet<TblBranch> TblBranch { get; set; }
        public virtual DbSet<TblCart> TblCart { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblDelivery> TblDelivery { get; set; }
        public virtual DbSet<TblFood> TblFood { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblPayment> TblPayment { get; set; }
    }
}
