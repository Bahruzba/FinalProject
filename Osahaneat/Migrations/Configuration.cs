<<<<<<< HEAD
namespace Osahaneat.Migrations
=======
﻿namespace Osahaneat.Migrations
>>>>>>> change reviews structure
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Osahaneat.Data.RestaurantsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Osahaneat.Data.RestaurantsContext context)
        {
            //  This method will be called after migrating to the latest version.

<<<<<<< HEAD
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
=======
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
>>>>>>> change reviews structure
            //  to avoid creating duplicate seed data.
        }
    }
}
