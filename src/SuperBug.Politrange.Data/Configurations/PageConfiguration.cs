using System.Data.Entity.ModelConfiguration;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Configurations
{
    public class PageConfiguration: EntityTypeConfiguration<Page>
    {
        public PageConfiguration()
        {
            HasRequired(s => s.Site)
                .WithMany(s => s.Pages)
                .HasForeignKey(s => s.SiteId);

            Property(p => p.FoundDate)
                .IsOptional();
            Property(p => p.LastScanDate)
                .IsOptional();
        }
    }
}