using System;

namespace ProductsAPI.Models.Entities
{
    [Serializable]
    public record Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double SalesPrice { get; set; }
        public int ProductTypeId { get; set; }
    }
}
