using Skaterer.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skaterer.Services.Ratings.Models
{
    public class RatingViewModel
    {
        [Required]
        public bool Star1 { get; set; }

        [Required]
        public int Stars { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        public string Text { get; set; }
    }
}
