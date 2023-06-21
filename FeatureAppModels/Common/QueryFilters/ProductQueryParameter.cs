using Models.Common;

namespace Entities.QueryFilters
{
    public class ProductQueryParameter : BaseQueryParameters
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string SortBy { get; set; } = "Id";

        private string _sortOrder = "asc";

        public string SortOrder
        {
            get
            {
                return _sortOrder;
            }

            set
            {
                if (value == "asc" || value == "desc")
                {
                    _sortOrder = value;
                }
            }
        }

        public string SearchTerm { get; set; } = string.Empty;
    }
}
