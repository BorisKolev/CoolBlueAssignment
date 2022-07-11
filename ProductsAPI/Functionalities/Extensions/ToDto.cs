using ProductsAPI.Models.DTos;
using ProductsAPI.Models.Entities;

namespace ProductsAPI.Functionalities.ExtensionTests
{
    public static class ToDto
    {
        public static ProductDto AsProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                SalesPrice = product.SalesPrice,
                ProductTypeId = product.ProductTypeId
            };
        }

        public static ProductTypeDto AsProductTypeDto(this ProductType productType)
        {
            return new ProductTypeDto
            {
                Id = productType.Id,
                Name = productType.Name,
                CanBeInsured = productType.CanBeInsured,
            };
        }

        public static ProductInsuranceDto AsProductInsuranceDto(this ProductInsurance productInsurance)
        {
            return new ProductInsuranceDto
            {
                ProductName = productInsurance.ProductName,
                InsuranceAmount = productInsurance.InsuranceAmount,
                InsuranceType = productInsurance.InsuranceType.ToString(),
            };
        }
    }
}
