using Microsoft.EntityFrameworkCore;

namespace ToDo.Persistence
{

    public class ToDoDbContextFactory : DesignTimeDbContextFactoryBase<ToDoDbContext>
    {
        protected override ToDoDbContext CreateNewInstance(DbContextOptions<ToDoDbContext> options)
        {
            return new ToDoDbContext(options);
        }
    }
}
