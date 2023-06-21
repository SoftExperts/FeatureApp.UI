using System.ComponentModel.DataAnnotations;
using Entities.QueryFilters;
using Models.Common;

namespace Models.Product
{
    public class ProductModel : BaseModel
    {
        [Required]
        public string Sku { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}