using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.ModelConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(x => x.CategoryId)
                   .IsRequired();

            builder.Property(x => x.DeveloperId)
                   .IsRequired();

            builder.Property(x => x.DistributorId)
                   .IsRequired();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(75);

            builder.Property(x => x.Price)
                   .IsRequired();

            builder.Property(x => x.ReleaseDate)
                   .IsRequired()
                   .HasColumnType("date");

            builder.Property(x => x.Description)
                .HasMaxLength(500);


            builder.HasMany(x=>x.GameImages)
                   .WithOne(x=>x.Game)
                   .HasForeignKey(x=>x.GameId);
            
        }
    }
}
