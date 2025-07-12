using MediatR;

namespace Base.Application.GetBookById;

public record GetBookByIdQuery(int Id) : IRequest<BookDto>;
