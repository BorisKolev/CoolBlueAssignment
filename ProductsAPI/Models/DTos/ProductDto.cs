namespace ProductsAPI.Models.DTos
{
    public record ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SalesPrice { get; set; }
        public int ProductTypeId { get; set; }
    }
}
