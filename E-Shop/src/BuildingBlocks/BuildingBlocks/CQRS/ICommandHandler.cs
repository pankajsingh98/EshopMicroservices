using MediatR;

namespace BuildingBlocks.CQRS;

// below ICommandHandler interface is used for handling commands that do not return any data, while the ICommandHandler<TCommand, IResponse> interface is used for handling commands that return a response of type IResponse. By using these interfaces, we can create a consistent and flexible way to handle commands in our application, regardless of whether they return data or not.
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand<Unit>
{
}

// below ICommandHandler interface is used for handling commands that return a response of type IResponse. By using this interface, we can create a consistent and flexible way to handle commands in our application, regardless of whether they return data or not.
public interface ICommandHandler<in TCommand, IResponse> : IRequestHandler<TCommand, IResponse> where TCommand : ICommand<IResponse>
{
}
