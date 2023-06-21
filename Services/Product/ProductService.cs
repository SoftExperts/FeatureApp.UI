using Entities.QueryFilters;
using Models.Common;
using Models.Product;
using Services.Http;

namespace Services.Product
{
    public class ProductService : IProductService
    {
		private readonly IHttpClientService httpClient;
		public ProductService(IHttpClientService httpClient)
		{
			this.httpClient = httpClient;
		}

        public async Task AddAsync(ProductModel product)
        {
			try
			{
                await httpClient.PostAsync<ProductModel>(product, ApiUrls.AddProduct);
            }
			catch (Exception)
			{

				throw;
			}
        }

        public async Task DeleteAsync(Guid Id)
        {
			try
			{
				await httpClient.DeleteAsync($"{ApiUrls.DeleteProduct}{Id}");
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            try
            {
                var products = await httpClient.GetAsync<ProductModel>(ApiUrls.GetFilteredProducts);

                return (IEnumerable<ProductModel>)products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductModel>> GetFilteredProducts(ProductQueryParameter productQuery)
        {
			try
			{
			   var products = await httpClient.PostAsync<ProductModel, ProductQueryParameter>(productQuery, ApiUrls.GetFilteredProducts);

			   return (IEnumerable<ProductModel>)products;
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<ProductModel> GetById(Guid Id)
        {
			try
			{
				return await httpClient.GetByIdAsync<ProductModel>($"{ApiUrls.GetById}{Id}");
            }
            catch (Exception)
			{

				throw;
			}
        }

        public async Task UpdateAsync(ProductModel product)
        {
			try
			{
                await httpClient.PutAsync<ProductModel>(product, ApiUrls.UpdateProduct);
            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}
