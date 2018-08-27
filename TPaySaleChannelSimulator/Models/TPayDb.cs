using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPaySaleChannelSimulator.Models
{
    public class TPayDb : DbContext
    {
        public TPayDb() : base("name=DefaultConnection")
        {

        }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<SaleChannel> saleChannel { get; set; }
        //public object Merchant { get; internal set; }
    }
}