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


           
            var O1 = new Operator { name = "VodafoneEG", country = "Egypt", Merchants = new List<Merchant>() };
            var O2 = new Operator { name = "EtisalatEG", country = "Egypt", Merchants = new List<Merchant>() };
            var O3 = new Operator { name = "OrangeEG", country = "Egypt", Merchants = new List<Merchant>() };
            var O4 = new Operator { name = "WE", country = "Egypt", Merchants = new List<Merchant>() };

            var M1 = new Merchant { name = "Anghamy", country = "Egypt", Operators = new List<Operator>() { O1} };
            var M2 = new Merchant { name = "Shahed", country = "KSA", Operators = new List<Operator>() { O1,O2,O3 } };
            var M3 = new Merchant { name = "SoundCloud", country = "UK", Operators = new List<Operator>() { O1 } };
            var M4 = new Merchant { name = "Spotify", country = "USA", description = "Yet another music application", Operators = new List<Operator>() { O2,O4} };




            //context.Operators.AddOrUpdate(r => r.name, O1);
            //context.Operators.AddOrUpdate(r => r.name, O2);
            //context.Operators.AddOrUpdate(r => r.name, O3);
            //context.Operators.AddOrUpdate(r => r.name, O4);

           

            context.Merchants.AddOrUpdate(r => r.name, M1);
            context.Merchants.AddOrUpdate(r => r.name, M2);
            context.Merchants.AddOrUpdate(r => r.name, M3);
            context.Merchants.AddOrUpdate(r => r.name, M4);
        }

    }
}
