using Base.Domain;
using MediatR;

namespace Base.Application.UpdateBook;

public class UpdateBookCommandHandler(IBookRepository repository) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.Id);
        if (book is null)
            return;

        book.Title = request.Title;
        book.Author = request.Author;
        await repository.UpdateAsync(book);
    }
}
