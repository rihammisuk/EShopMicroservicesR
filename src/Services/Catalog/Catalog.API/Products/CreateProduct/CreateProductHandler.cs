namespace Catalog.API.Products.CreateProduct;
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IDocumentSession _session;
    //private readonly ILogger<CreateProductCommandHandler> _logger;
    //public CreateProductCommandHandler(IDocumentSession ses sion, ILogger<CreateProductCommandHandler> logger)
    public CreateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
        //_logger = logger;
    }
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //_logger.LogInformation("Handling CreateProductCommand: {@Command}", command);
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);
        //return result
        return new CreateProductResult(product.Id);
    }
}