using BuildingBlocks.CQRS;
using Catalog.API.Models;


namespace Catalog.API.Products.CreateProduct;
//CQRS -Command Query Responsibility Segregation
// create Record type  commmand need to be created for CreateProductCommand and it should have the same properties as Products class

public record CreateProductCommand
(
       string Name,
          List<string> Category,
             string Description,
                string ImageFile,
                   decimal Price
    ):ICommand<CreateProductResult>;

// we additional createProductResult record type to return the result of the command
public record CreateProductResult(Guid Id);
// we need to implement the IRequestHandler interface to handle the CreateProductCommand and return a CreateProductResult
internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult> 
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {            
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        return new CreateProductResult(Guid.NewGuid());
    }
}
