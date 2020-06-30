using CarRentalSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Infrastructure.Configurations
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder.OwnsOne(c => c.PhoneNumber, o =>
            {
                o.WithOwner();

                o.Property(op => op.Number)
                 .HasMaxLength(ModelConstants.PhoneNumber.MaxPhoneNumberLength);
            });

            builder
                .HasMany(pr => pr.CarAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("carAds");
        }
    }
}
