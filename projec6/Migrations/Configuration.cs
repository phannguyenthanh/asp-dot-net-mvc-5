namespace projec6.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<project5.Models.footwear_db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "project5.Models.footwear_db";
        }

        protected override void Seed(project5.Models.footwear_db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
