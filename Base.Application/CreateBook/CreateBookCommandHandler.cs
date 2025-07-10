using Base.Domain;
using MediatR;

namespace Base.Application.CreateBook;

public class CreateBookCommandHandler(IBookRepository repository) : IRequestHandler<CreateBookCommand, BookDto>
{
    public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author
        };
        await repository.AddAsync(book);
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author
        };
    }
}