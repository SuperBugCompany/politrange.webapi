using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;
using SuperBug.Politrange.Data.Configurations;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Contexts
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PolitrangeContext: DbContext
    {
        public PolitrangeContext()
            : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PolitrangeContext>());
        }

        public PolitrangeContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonPageRank> PersonPageRanks { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new PersonPageRankConfiguration());
            modelBuilder.Configurations.Add(new KeywordConfiguration());
            modelBuilder.Configurations.Add(new PageConfiguration());
        }
    }
}