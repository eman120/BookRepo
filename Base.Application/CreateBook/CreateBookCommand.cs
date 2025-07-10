using Base.Domain;
using MediatR;

namespace Base.Application.CreateBook;

public record CreateBookCommand(string Title, string Author) : IRequest<BookDto>;
