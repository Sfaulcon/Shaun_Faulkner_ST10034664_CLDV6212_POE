namespace Shaun_Faulkner_ST10034664_CLDV6212_POE.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
