using Skateshop.Models;
using System.ComponentModel.DataAnnotations;

namespace Skateshop.Composite
{
    public class Product
    {

        public string Name { get; set; }

        public Brand Brand { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string ImagePath { get; set; }

        [Range(1, 5)]
        public float Rating { get; set; }

    }
}
