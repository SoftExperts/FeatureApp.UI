using Models.Product;

namespace Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task AddProductAsync(ProductModel product);
    }
}
