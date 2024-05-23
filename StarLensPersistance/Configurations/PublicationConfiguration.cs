using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarLens.Persistance.Postgres.Configurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Publications);
            builder
                .HasMany(p => p.Likes);
            builder
                .HasMany(p => p.Likes);
            builder
                .HasOne(p => p.TechInfo);
            builder
                .HasMany(p => p.Comments);
        }
    }
}
