using ProductsAPI.Models.Entities;
using ProductsAPI.Models.Enums;

namespace ProductsAPI.Interfaces.IFunctionalities
{
    public interface IInsuranceLookUps
    {
        public bool IsProductTypeInsurable(int productId);
        public string GetProductTypeName(int productId);
        public double GetProductPrice(int productId);
        public string GetProductName(int productId);
        public InsuranceTypes GetInsuranceType(double productPrice);
        public ProductInsurance CreateInsurance(int productId);
    }
}
