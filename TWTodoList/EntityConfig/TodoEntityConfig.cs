using Microsoft.EntityFrameworkCore;
using TWTodoList.Models;

namespace TWTodoList.EntityConfig;

public class TodoEntityConfig : IEntityTypeConfiguration<Todo>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("todo");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("Id");
        builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("nvarchar(100)").IsRequired();
        builder.Property(x => x.Date).HasColumnName("date").HasColumnType("date").IsRequired();
        builder.Property(x => x.IsCompleted).HasColumnName("is_completed").HasColumnType("bit").IsRequired();
        
    }
}
