

namespace KASHOP.DAL.DTO.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public double Rate { get; set; }
        public string MainImageUrl { get; set; }
        public string CategoryName { get; set; }
    }
}
