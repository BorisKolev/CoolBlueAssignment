using ProductsAPI.Models.Entities;
using ProductsAPI.Models.Enums;

namespace ProductsAPI.Factories
{
    public static class InsuranceFactory
    {
        public static ProductInsurance CreateInsurance(string productName,
                                                       InsuranceTypes insuranceType,
                                                       int insuranceAmount)
        {

            return new()
            {
                ProductName = productName,
                InsuranceType = insuranceType,
                InsuranceAmount = insuranceAmount,
            };

        }
    }
}
