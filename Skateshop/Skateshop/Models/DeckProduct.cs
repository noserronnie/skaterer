using Skateshop.Composite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skateshop.Models
{
    public class DeckProduct : Product
    {

        public long Id { get; set; }

        [Required]
        public float Width { get; set; }

        [Required]
        public float Length { get; set; }

        public float Wheelbase { get; set; }

        public float Nose { get; set; }

        public float Tail { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}
