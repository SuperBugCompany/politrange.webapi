using System.Data.Entity.ModelConfiguration;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Configurations
{
    public class PersonConfiguration: EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("Persons");
        }
    }
}