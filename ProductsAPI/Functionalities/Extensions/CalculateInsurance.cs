using ProductsAPI.Constants;

namespace ProductsAPI.Functionalities.Extensions
{
    public static class CalculateInsurance
    {
        public static int CalculateInsuranceCost(double productPrice, string productType)
        {

            int insuranceCost = 0;

            if (productType.ToUpper() == ProductTypeNames.LAPTOPS ||
                productType.ToUpper() == ProductTypeNames.SMARTPHONES)
            {
                insuranceCost += 500;
            }

            if (productPrice < 500)
            {
                return insuranceCost;
            }

            else
            {
                if (productPrice < 2000)
                {
                    return insuranceCost += 1000;
                }
                else
                {
                    return insuranceCost += 2000;
                }
            }

        }
    }
}
