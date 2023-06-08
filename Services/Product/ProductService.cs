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

        public async Task AddProductAsync(ProductModel product)
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

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
			try
			{
			   var products = await httpClient.GetAsync<ProductModel>(ApiUrls.GetAllProducts);

			   return (IEnumerable<ProductModel>)products;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
