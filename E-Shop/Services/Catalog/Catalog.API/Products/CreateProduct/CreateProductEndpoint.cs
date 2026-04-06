namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest
(
  string Name,
  List<string> Category,
  string Description,
  string ImageFile,
  decimal Price
);

public record CreateProductResponse(Guid Id);
public class CreateProductEndpoint : ICarterModule
{
    // add the route to the endpoint is nothing but a POST request to the endpoint with the request body as CreateProductRequest and the response body as CreateProductResponse a minimal Api
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
       {
           var command = request.Adapt<CreateProductCommand>();
           var result = await sender.Send(command); // this mediatr call will go to the CreateProductCommandHandler and return the result which is the created product's ID
           var response = result.Adapt<CreateProductResponse>();
           return Results.Created($"/products/{response.Id}", response);
       }).WithName("CreateProduct")
       .Produces<CreateProductResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Creates a new product")
       .WithDescription("Creates a new product with the given details and returns the created product's ID.");

    }
}
