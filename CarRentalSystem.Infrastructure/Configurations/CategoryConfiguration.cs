using CarRentalSystem.Domain.Models;
using CarRentalSystem.Domain.Models.CarAdAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasMaxLength(ModelConstants.Category.MaxDescriptionLength);
        }
    }
}
