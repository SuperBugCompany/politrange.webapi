using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonPageRank>().HasOptional(x=>x.Person).WithOptionalDependent().WillCascadeOnDelete(true);
            modelBuilder.Entity<PersonPageRank>().HasOptional(x => x.Page).WithOptionalDependent().WillCascadeOnDelete(true);
            modelBuilder.Entity<Keyword>().HasOptional(x => x.Person).WithOptionalDependent().WillCascadeOnDelete(true);
            modelBuilder.Entity<Page>().HasOptional(x => x.Site).WithOptionalDependent().WillCascadeOnDelete(true);
        }
    }
}