using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.ModelConfigurations
{
    public class UserRoleClaimConfiguration : IEntityTypeConfiguration<UserRoleClaim>
    {
        public void Configure(EntityTypeBuilder<UserRoleClaim> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.RoleClaimId).IsRequired();
        }
    }
}
