using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Persistence.EntityConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnType("nvarchar(100)").IsRequired(true);
            builder.Property(x => x.Password).HasColumnType("nvarchar(100)").IsRequired(true);
            builder.Property(x => x.PasswordSalt).HasColumnType("nvarchar(100)").IsRequired(true);
            builder.Property(x => x.FullName).HasColumnType("nvarchar(100)").IsRequired(false);

            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
        }
    }
}
