using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommand :ICommand<Unit> // emplicitly implement the ICommand interface with a Unit response type, which indicates that the command does not return any data. This allows us to use the ICommand interface for commands that do not need to return a response, while still providing a consistent interface for all commands.
{
    
}
public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
