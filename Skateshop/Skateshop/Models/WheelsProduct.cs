using Skateshop.Composite;
using System.Collections.Generic;

namespace Skateshop.Models
{
    public class WheelsProduct : Product
    {

        public long Id { get; set; }

        public float Diameter { get; set; }

        public float Width { get; set; }

        public float Hardness { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }


    }
}
