using Base.Domain;
using MediatR;

namespace Base.Application.GetAllBooks;

public record GetBooksQuery: IRequest<List<BookDto>>;
