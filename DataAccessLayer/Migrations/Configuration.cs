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

            var kontakt2 = new KontaktPerson
            {
                Navn = "Clemen Dalgaard",
                TlfNr = "4567890",
                Mail = "clemen.dalgaard@gmail.com"
            };

            // Only add if it doesn't already exist
            if (!context.KontaktPersoner.Any(k => k.Mail == kontakt.Mail))
            {
                context.KontaktPersoner.Add(kontakt);
                context.KontaktPersoner.Add(kontakt2);
                context.SaveChanges();
            }

            // Tilføj hold hvis de ikke allerede findes
            string[] holdNavne = {
                "Tirsdag hold 1",
                "Tirsdag hold 2",
                "Torsdag hold 1",
                "Torsdag hold 2"
};

            foreach (var navn in holdNavne)
            {
                if (!context.Hold.Any(h => h.HoldNavn == navn))
                {
                    context.Hold.Add(new Hold { HoldNavn = navn });
                }
            }

            context.SaveChanges();

        }

    }
}
