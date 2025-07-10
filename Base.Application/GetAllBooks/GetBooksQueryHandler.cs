using Base.Domain;
using MediatR;

namespace Base.Application.GetAllBooks;

public class GetBooksQueryHandler(IBookRepository repository) : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await repository.GetAllAsync();
        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author
        }).ToList();
    }
}