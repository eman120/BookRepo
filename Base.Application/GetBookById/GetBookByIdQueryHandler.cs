using Base.Domain;
using MediatR;
using System.Threading.Tasks;

namespace Base.Application.GetBookById;

public class GetBookByIdQueryHandler(IBookRepository repository) : IRequestHandler<GetBookByIdQuery, BookDto>
{
    public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.Id);
        if (book == null)
            return null;

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author
        };
    }
}
