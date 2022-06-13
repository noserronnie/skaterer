namespace Skaterer.Services.Products.Models
{
    public class DeleteProductViewModel
    {

        public long Id { get; set; }

        public ProductType Type { get; set; }

        public DeleteProductViewModel(long id, ProductType type)
        {
            Id = id;
            Type = type;
        }

    }
}
