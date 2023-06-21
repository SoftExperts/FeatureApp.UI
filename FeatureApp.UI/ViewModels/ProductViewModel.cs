using Entities.QueryFilters;
using Models.Product;

namespace FeatureApp.UI.ViewModels
{
    public class ProductViewModel : ProductQueryParameter
    {
        public IEnumerable<ProductModel>? Products { get; set; }
    }
}
