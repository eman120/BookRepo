using MediatR;

namespace Base.Application.DeleteBook;

public record DeleteBookCommand(int Id) : IRequest;
