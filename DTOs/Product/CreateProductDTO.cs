using System.ComponentModel.DataAnnotations;

namespace ProductInventoryAPI.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public decimal Discount { get; set; }

    }
}
