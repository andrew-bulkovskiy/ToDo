using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Application.ToDoItems.Queries.GetToDoItemsList
{
    public class GetToDoItemsListQuery : IRequest<ToDoItemListViewModel> { }
}
