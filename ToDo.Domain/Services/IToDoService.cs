using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Services
{
    public interface IToDoService
    {
        IEnumerable<ToDoItem> GetToDoItemsAsync();
    }
}
