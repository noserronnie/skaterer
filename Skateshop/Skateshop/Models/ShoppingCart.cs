using System.Collections.Generic;

namespace Skaterer.Models
{
    public class ShoppingCart
    {

        public long Id { get; set; }

        public ICollection<DeckProduct> DeckProducts { get; set; }

        public ICollection<TrucksProduct> TrucksProducts { get; set; }

        public ICollection<WheelsProduct> WheelsProducts { get; set; }

        public ICollection<GriptapeProduct> GriptapeProducts { get; set; }

    }
}
