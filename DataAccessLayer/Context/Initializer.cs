using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    internal class Initializer : CreateDatabaseIfNotExists<AirTimeContext>
    {
        public static Dictionary<string, int> HoldMap { get; set; } = new Dictionary<string, int>();

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



            if (!context.KontaktPersoner.Any(k => k.Mail == kontakt.Mail))
            {
                context.KontaktPersoner.Add(kontakt);
                context.KontaktPersoner.Add(kontakt2);
                context.SaveChanges();
            }

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

            var hoppePeter = new Springer
            {
                Navn = "Hoppe peter",
                Foedselsdato = new DateTime(1990, 1, 1),
                KontaktPerson = kontakt,
                Hold = new List<Hold>
                {
                    context.Hold.FirstOrDefault(h => h.HoldNavn == "Tirsdag hold 1"),
                    context.Hold.FirstOrDefault(h => h.HoldNavn == "Torsdag hold 1")
                }
            };

            context.Springere.Add(hoppePeter);

            context.SaveChanges();

            HoldMap = context.Hold
                .Where(h => holdNavne.Contains(h.HoldNavn))
                .ToDictionary(h => h.HoldNavn, h => h.Id);
        }
    }
}
