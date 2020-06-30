using CarRentalSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Dealer)
                .WithOne()
                .HasForeignKey<User>("DealerId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
