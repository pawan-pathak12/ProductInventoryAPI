using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductInventoryAPI.DTOs.Product
{
    public class UpdateProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        
    }
}
