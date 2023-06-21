using Entities.QueryFilters;
using Models.Product;

namespace Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<IEnumerable<ProductModel>> GetFilteredProducts(ProductQueryParameter productQuery);
        Task<ProductModel> GetById(Guid Id);
        Task AddAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
        Task DeleteAsync(Guid Id);
    }
}