using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.ModelConfigurations
{
    public class ImageCategoryConfiguration : IEntityTypeConfiguration<ImageCategory>
    {
        public void Configure(EntityTypeBuilder<ImageCategory> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.HasMany(x=>x.GameImages)
                   .WithOne(x=>x.Category)
                   .HasForeignKey(x=>x.CategoryId);
        }
    }
}
