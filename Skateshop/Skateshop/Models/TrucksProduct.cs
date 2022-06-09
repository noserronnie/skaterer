using Skateshop.Composite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skateshop.Models
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
