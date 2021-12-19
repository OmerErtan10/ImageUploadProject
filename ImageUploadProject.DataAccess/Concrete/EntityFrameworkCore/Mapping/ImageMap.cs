using ImageUploadProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageUploadProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ImageMap : IEntityTypeConfiguration<Entities.Concrete.Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(100).IsRequired();

        }
    }
}
