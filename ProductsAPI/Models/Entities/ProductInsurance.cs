using ProductsAPI.Models.Enums;

namespace ProductsAPI.Models.Entities
{
    public record ProductInsurance
    {
        public string ProductName { get; set; } = string.Empty;
        public int InsuranceAmount { get; set; } = 0;
        public InsuranceTypes InsuranceType { get; set; }
    }
}
