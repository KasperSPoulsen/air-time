using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class AirTimeContext : DbContext
    {
        public AirTimeContext() : base("AirTimeContext")
        {
            
        }

        public DbSet<Bil> Biler { get; set; }
        public DbSet<Konkurrence> Konkurrencer { get; set; }
        public DbSet<Hold> Hold { get; set; }
        public DbSet<KontaktPerson> KontaktPersoner { get; set; }
        public DbSet<Springer> Springere { get; set; }
        public DbSet<Traening> Traeninger { get; set; }
        public DbSet<Fremmoederegistrering> Fremmoederegistreringer { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
