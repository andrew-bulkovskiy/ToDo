using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Persistence.Configurations;

namespace ToDo.Persistence
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        // Can use since EF Core 2.2
        // Applaying all configurations from Configurations folder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoDbContext).Assembly);
        }
    }
}