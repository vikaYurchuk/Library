using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Author).IsRequired();

            builder.HasOne(b => b.Sequel)
            .WithOne(b => b.Previous)
            .HasForeignKey<Book>(b => b.SequelTo) 
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}