using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ToDo.Application.ToDoItems.Queries.GetToDoItemsList
{
    public class GetToDoItemsListQueryHandler : IRequestHandler<GetToDoItemsListQuery, ToDoItemListViewModel>
    {
        public async Task<ToDoItemListViewModel> Handle(GetToDoItemsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new ToDoItemListViewModel
            {
                 
            };

            return vm;
        }
    }
}
