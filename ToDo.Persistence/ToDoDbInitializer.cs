using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;

namespace ToDo.Persistence
{
    public class ToDoDbInitializer
    {
        private readonly Dictionary<int, ToDoCategory> ToDoCategories = new Dictionary<int, ToDoCategory>();
        private readonly Dictionary<int, ToDoItem> ToDoItems = new Dictionary<int, ToDoItem>();

        public static void Initialize(ToDoDbContext context)
        {
            var initializer = new ToDoDbInitializer();
            initializer.SeedAll(context);
        }

        public void SeedAll(ToDoDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if Db has been seeded already
            if (context.ToDoItems.Any())
            {
                return;
            }

            SeedCategories(context);

            SeedToDos(context);
        }

        public void SeedCategories(ToDoDbContext context)
        {
            ToDoCategories.Add(1, new ToDoCategory
            {
                Name = "Home",
                Description = "Home ToDo",
            });

            ToDoCategories.Add(2, new ToDoCategory
            {
                Name = "Work",
                Description = "Work ToDo",
            });

            foreach (var category in ToDoCategories.Values)
            {
                context.ToDoCategories.Add(category);
            }

            context.SaveChanges();
        }

        public void SeedToDos(ToDoDbContext context)
        {
            ToDoItems.Add(1, new ToDoItem
            {
                Name = "Workspace",
                Description = "Clean Workspace",
                Time = DateTime.UtcNow,
                Done = false,
                Category = ToDoCategories[1]
            });

            foreach (var toDoItem in ToDoItems.Values)
            {
                context.ToDoItems.Add(toDoItem);
            }

            context.SaveChanges();
        }

    }
}