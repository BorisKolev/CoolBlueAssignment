namespace ProductsAPI.Models.DTos
{
    public record ProductInsuranceDto
    {
        public string ProductName { get; set; }
        public int InsuranceAmount { get; set; } = 0;
        public string InsuranceType { get; set; }
    }
}
