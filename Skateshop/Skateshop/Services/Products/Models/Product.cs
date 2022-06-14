using System.ComponentModel.DataAnnotations;
using Skaterer.Models;

namespace Skaterer.Services.Products.Models
{
    public class Product
    {

        [Required]
        public string Name { get; set; }

        public Brand Brand { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string ImagePath { get; set; }

    }
}
