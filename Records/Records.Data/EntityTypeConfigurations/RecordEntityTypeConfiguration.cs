using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileParkTask.Records.Domain.Models;

namespace MobileParkTask.Records.Data.EntityTypeConfigurations;

public class RecordEntityTypeConfiguration : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.Keyword);

        builder
            .Property(x => x.FragmentName)
            .IsRequired();

        builder
            .Property(x => x.Language)
            .IsRequired();

        builder
            .HasMany(x => x.Results)
            .WithOne(x => x.Record)
            .HasForeignKey(x => x.RecordId);

        builder
            .HasKey(x => x.Id);
    }
}