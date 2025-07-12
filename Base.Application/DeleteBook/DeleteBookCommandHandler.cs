using Base.Domain;
using MediatR;

namespace Base.Application.DeleteBook;

public class DeleteBookCommandHandler(IBookRepository repository) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
    }
}
