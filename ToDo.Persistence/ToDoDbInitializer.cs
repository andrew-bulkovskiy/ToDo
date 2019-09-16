using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;

namespace ToDo.Persistence
{
    public class ToDoDbInitializer
    {
        private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();
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
            Categories.Add(1, new Category
            {
                Name = "Home",
                Description = "Home ToDo",
            });

            Categories.Add(2, new Category
            {
                Name = "Work",
                Description = "Work ToDo",
            });

            foreach (var category in Categories.Values)
            {
                context.Categories.Add(category);
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
                Category = Categories[1]
            });

            foreach (var toDoItem in ToDoItems.Values)
            {
                context.ToDoItems.Add(toDoItem);
            }

            context.SaveChanges();
        }

    }
}