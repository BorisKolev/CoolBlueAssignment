namespace ProductsAPI.Models.DTos
{
    public record ProductInsuranceDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int InsuranceAmount { get; set; } = 0;
        public string InsuranceType { get; set; } = string.Empty;
    }
}
