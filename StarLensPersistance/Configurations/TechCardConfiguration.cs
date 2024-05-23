
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarLens.Persistance.Postgres.Configurations
{
    public class TechCardConfiguration : IEntityTypeConfiguration<TechCard>
    {
        public void Configure(EntityTypeBuilder<TechCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(t => t.Equipment);
            builder
                .HasMany(t => t.Sessions);
        }
    }
}
