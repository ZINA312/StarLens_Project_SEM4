using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StarLens.Persistance.Postgres.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(u => u.Publications)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            builder.HasMany(u => u.Topics)
                .WithOne(t => t.Creator)
                .HasForeignKey(t => t.CreatorId);
            builder.HasMany(u => u.Subscriptions);
        }

    }
}
