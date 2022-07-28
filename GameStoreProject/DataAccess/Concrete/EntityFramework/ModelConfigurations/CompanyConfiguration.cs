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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x=>x.WebSite)
                   .HasMaxLength(100);

            builder.HasMany(x => x.Games)
                   .WithOne(x => x.Company)
                   .HasForeignKey(x => x.DistributorId)
                   .HasForeignKey(x => x.DeveloperId);
        }
    }
}
