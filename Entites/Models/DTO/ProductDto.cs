using System.Text.Json.Serialization;

namespace Entities.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        [JsonIgnore]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Brand { get; set; }
        public decimal RetailPrice { get; set; }
        public int Status { get; set; }
        [JsonIgnore]
        public List<CategoryDto>? Categories { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        
    }
}
