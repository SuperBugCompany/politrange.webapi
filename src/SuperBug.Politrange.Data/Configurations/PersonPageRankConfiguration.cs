using System.Data.Entity.ModelConfiguration;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Configurations
{
    public class PersonPageRankConfiguration: EntityTypeConfiguration<PersonPageRank>
    {
        public PersonPageRankConfiguration()
        {
            HasRequired(p => p.Person)
                .WithMany(p => p.PersonPageRanks)
                .HasForeignKey(p => p.PersonId);

            HasRequired(p => p.Page)
                .WithMany(p => p.PersonPageRanks)
                .HasForeignKey(p => p.PageId);

        }
    }
}