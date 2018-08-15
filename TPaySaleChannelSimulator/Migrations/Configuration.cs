namespace TPaySaleChannelSimulator.Migrations
{
    using Models;
    using System;
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
            context.Merchants.AddOrUpdate(
                 r => r.name,
                 new Merchant { name = "Anghamy", country = "Egypt" },
                 new Merchant { name = "Shahed", country = "KSA" },
                 new Merchant { name = "SoundCloud", country = "UK" },
                 new Merchant { name = "Spotify", country = "USA", description = "Yet another music application" });

            context.Operators.AddOrUpdate(
                 r => r.name,
                 new Operator { name = "VodafoneEG", country = "Egypt" },
                 new Operator { name = "EtisalatEG", country = "Egypt" },
                 new Operator { name = "OrangeEG", country = "Egypt" },
                 new Operator { name = "WE", country = "Egypt" });
            context.SaleChannel.AddOrUpdate(

                new SaleChannel { OperatorID = 1, MerchantID = 2 },
                new SaleChannel { OperatorID = 1, MerchantID = 1 },
                new SaleChannel { OperatorID = 1, MerchantID = 3 },

                new SaleChannel { OperatorID = 2, MerchantID = 1 },

                new SaleChannel { OperatorID = 3, MerchantID = 4 }
                );

        }
    }
}
