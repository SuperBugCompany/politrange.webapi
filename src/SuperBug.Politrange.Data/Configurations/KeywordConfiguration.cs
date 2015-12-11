using System.Data.Entity.ModelConfiguration;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Configurations
{
    public class KeywordConfiguration: EntityTypeConfiguration<Keyword>
    {
        public KeywordConfiguration()
        {
            HasRequired(p => p.Person)
                .WithMany(p => p.Keywords)
                .HasForeignKey(p => p.PersonId);
        }
    }
}