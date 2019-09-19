using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ToDo.Application.ToDoItems.Queries.GetToDoItemsList
{
    public class GetToDoItemsListQueryHandler : IRequestHandler<GetToDoItemsListQuery, string>
    {
        public async Task<string> Handle(GetToDoItemsListQuery request, CancellationToken cancellationToken)
        {
            return "Hello world!";
        }
    }
}
