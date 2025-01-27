using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Insurance.Infrastructure.Data.Configurations;

public class RequestEntityConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(t => t.Title)
            .HasMaxLength(200)
        .IsRequired();

        builder.Property(r => r.TotalPremium)
            .IsRequired();

        builder.OwnsMany(r => r.Coverages, a =>
        {
            a.WithOwner().HasForeignKey(rc=>rc.RequestId);
            a.HasKey(rc=>rc.Id);
            a.Property(c => c.CoverageType)
            .IsRequired();

            a.Property(c => c.Amount)
            .IsRequired();
        });
    }
}
