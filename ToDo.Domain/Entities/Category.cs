using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Entities
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; private set; }

        public Category()
        {
            ToDoItems = new HashSet<ToDoItem>();
        }
    }
}
