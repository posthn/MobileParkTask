using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileParkTask.Records.Domain.Models;

namespace MobileParkTask.Records.Data.EntityTypeConfigurations;

public class RecordItemEntityTypeConfiguration : IEntityTypeConfiguration<RecordItem>
{
    public void Configure(EntityTypeBuilder<RecordItem> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.RecordId)
            .IsRequired();

        builder
            .Property(x => x.Content)
            .IsRequired();

        builder
            .Property(x => x.VowelsCount)
            .IsRequired();

        builder
            .HasOne(x => x.Record)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.RecordId);

        builder
            .HasKey(x => x.Id);
    }
}