using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ServiceRegistration
{
    public class Config : IEntityTypeConfiguration<ObjectModel>
    {
        public void Configure(EntityTypeBuilder<ObjectModel> builder)
        {
            builder.Property(name => name.ObjectName).IsRequired();
        }
    }
}
