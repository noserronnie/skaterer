using Skaterer.Services.Products.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skaterer.Models
{
    public class TrucksProduct : Product
    {

        public long Id { get; set; }

        [Required]
        public float AxleWidth { get; set; }

        [Required]
        public float HangerWidth { get; set; }

        [Required]
        public float Height { get; set; }

        public float Weight { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}
