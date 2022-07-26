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
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(75);

            builder.Property(x => x.ReleaseDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            

            builder.HasOne(x => x.Company)
                .WithMany(y => y.Games)
                .HasForeignKey(x => x.DistributorId)
                .HasForeignKey(x => x.DeveloperId);
        }
    }
}
