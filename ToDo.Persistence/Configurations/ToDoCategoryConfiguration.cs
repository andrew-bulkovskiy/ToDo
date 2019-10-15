using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Persistence.Configurations
{
    class ToDoCategoryConfiguration: IEntityTypeConfiguration<ToDoCategory>
    {
        public void Configure(EntityTypeBuilder<ToDoCategory> builder)
        {
            builder.HasKey(e => e.ToDoCategoryId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(16);
        }
    }
}
