namespace TPaySaleChannelSimulator.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TPaySaleChannelSimulator.Models.TPayDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TPaySaleChannelSimulator.Models.TPayDb";
        }

        protected override void Seed(TPaySaleChannelSimulator.Models.TPayDb context)
        {


            var M1 = new Merchant { name = "Anghamy", country = "Egypt" };
            var M2 = new Merchant { name = "Shahed", country = "KSA" };
            var M3 = new Merchant { name = "SoundCloud", country = "UK" };
            var M4 = new Merchant { name = "Spotify", country = "USA", description = "Yet another music application" };


            var O1 = new Operator { name = "VodafoneEG", country = "Egypt" };
            var O2 = new Operator { name = "EtisalatEG", country = "Egypt" };
            var O3 = new Operator { name = "OrangeEG", country = "Egypt" };
            var O4 = new Operator { name = "WE", country = "Egypt" };

            context.Operators.AddOrUpdate(r=>r.name,O1);
            context.Operators.AddOrUpdate(r => r.name,O2);
            context.Operators.AddOrUpdate(r => r.name, O3);
            context.Operators.AddOrUpdate(r => r.name, O4);

            M1.Operators.Add(O1);
            M2.Operators.Add(O1);
            M3.Operators.Add(O1);

            M2.Operators.Add(O2);
            M2.Operators.Add(O3);
            M4.Operators.Add(O3);

            context.Merchants.AddOrUpdate(M1);
            context.Merchants.AddOrUpdate(M2);
            context.Merchants.AddOrUpdate(M3);
            context.Merchants.AddOrUpdate(M4);
        }
        
    }
}
