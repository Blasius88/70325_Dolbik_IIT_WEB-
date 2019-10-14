namespace ClassLibrary170325_Dolbik_Vorobei.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_70325_Dolbik_Vorobei.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_70325_Dolbik_Vorobei.DAL.ApplicationDbContext";
        }

        protected override void Seed(_70325_Dolbik_Vorobei.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
