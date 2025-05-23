﻿using DataAccessLayer.Mappers;
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
            // Check if the KontaktPersoner already exist before adding
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

            if (!context.KontaktPersoner.Any(k => k.Mail == kontakt.Mail) && !context.KontaktPersoner.Any(k => k.Mail == kontakt2.Mail))
            {
                context.KontaktPersoner.Add(kontakt);
                context.KontaktPersoner.Add(kontakt2);
                context.SaveChanges();
            }

            // Check if any Hold data already exists before adding new hold names
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

            HoldMap = context.Hold
                .Where(h => holdNavne.Contains(h.HoldNavn))
                .ToDictionary(h => h.HoldNavn, h => h.Id);

            // Find holdet "Tirsdag hold 1"
            var tirsdagHold1 = context.Hold.FirstOrDefault(h => h.HoldNavn == "Tirsdag hold 1");

            Springer springer1 = null;

            // Sørg for at holdet findes
            if (tirsdagHold1 != null)
            {
                springer1 = new Springer("William Jensen", new DateTime(2010, 5, 15), kontakt, new List<Hold> { tirsdagHold1 });
                springer1.TraeningsMaal = "TripleBack, TripleFront";

                var springer2 = new Springer("Emil Sørensen", new DateTime(2011, 3, 20), kontakt, new List<Hold> { tirsdagHold1 });

                var springer3 = new Springer("Laura Nielsen", new DateTime(2009, 11, 2), kontakt2, new List<Hold> { tirsdagHold1 });
                springer3.TraeningsMaal = "TripleBack, TripleFront";

                var springer4 = new Springer("Frederik Madsen", new DateTime(2012, 7, 8), kontakt2, new List<Hold> { tirsdagHold1 });

                var springer5 = new Springer("Sofie Kristensen", new DateTime(2010, 1, 25), kontakt, new List<Hold> { tirsdagHold1 });

                var springere = new List<Springer>
                {
                    springer1,
                    springer2,
                    springer3,
                    springer4,
                    springer5
                };

                context.Springere.AddRange(springere);

            }

            context.SaveChanges();


            var konkurrence = new Konkurrence("Hovedgaden 12", "Forårskonkurrence", new DateTime(2026, 5, 10));
            konkurrence.Springere.Add(springer1);
            Bil bil = new Bil(kontakt2);
            konkurrence.Biler.Add(bil);

            bil.Springere.Add(springer1);

            context.Konkurrencer.Add(konkurrence);


            context.SaveChanges();



        }

    }
}
