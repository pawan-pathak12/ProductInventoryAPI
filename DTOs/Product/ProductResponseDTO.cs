using System.ComponentModel.DataAnnotations;

namespace ProductInventoryAPI.DTOs.Product
{
    public class ProductResponseDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

    }
}
