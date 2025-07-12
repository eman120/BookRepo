using MediatR;

namespace Base.Application.UpdateBook;

public record UpdateBookCommand(int Id, string Title, string Author) : IRequest;
