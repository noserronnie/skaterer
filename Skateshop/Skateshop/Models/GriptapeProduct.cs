using Skaterer.Services.Products.Models;
using System.Collections.Generic;

namespace Skaterer.Models
{
    public class GriptapeProduct : Product
    {

        public long Id { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }


    }
}
