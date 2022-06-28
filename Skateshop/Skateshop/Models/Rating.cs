using Skaterer.Services.Products.Models;
using System.ComponentModel.DataAnnotations;

namespace Skaterer.Models
{
    public class Rating
    {
        public long Id { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        public long UserId { get; set; }

        [Range(1, 5)]
        [Required]
        public double Stars { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        public string Text { get; set; }

    }
}
