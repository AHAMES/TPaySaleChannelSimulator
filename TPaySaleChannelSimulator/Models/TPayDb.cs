using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPaySaleChannelSimulator.Models
{
    public class TPayDb:DbContext
    {
        public TPayDb() : base("name=DefaultConnection")
        {

        }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<SaleChannel> SaleChannel { get; set; }
    }
}