using System;

namespace ProductsAPI.Models.Entities
{
    [Serializable]
    public record ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeInsured { get; set; }
    }
}
