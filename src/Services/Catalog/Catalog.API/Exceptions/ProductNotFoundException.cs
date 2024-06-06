namespace Catalog.API.Exceptions;

//public class ProductNotFoundException : NotFoundException
public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(Guid Id) : base("Product not found!")
    //public ProductNotFoundException(Guid Id) : base("Product", Id)
    {
    }
}