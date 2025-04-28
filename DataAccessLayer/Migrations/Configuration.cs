namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Context.AirTimeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.Context.AirTimeContext context)
        {
            var kontakt = new KontaktPerson
            {
                Navn = "Anders Andersen",
                TlfNr = "12345678",
                Mail = "anders@example.com"
            };

            // Only add if it doesn't already exist
            if (!context.KontaktPersoner.Any(k => k.Mail == kontakt.Mail))
            {
                context.KontaktPersoner.Add(kontakt);
                context.SaveChanges();
            }
        }

    }
}
