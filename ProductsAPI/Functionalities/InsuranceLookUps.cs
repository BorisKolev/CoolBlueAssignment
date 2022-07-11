using ProductsAPI.Factories;
using ProductsAPI.Functionalities.Extensions;
using ProductsAPI.Interfaces.IFunctionalities;
using ProductsAPI.Interfaces.IRepository;
using ProductsAPI.Models.Entities;
using ProductsAPI.Models.Enums;

namespace ProductsAPI.Functionalities
{
    public class InsuranceLookUps : IInsuranceLookUps
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public InsuranceLookUps(IProductRepository productRepository,
                                IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public bool IsProductTypeInsurable(int productId)
        {
            var productTypeId = _productRepository.GetProduct(productId).ProductTypeId;
            return _productTypeRepository.GetProductType(productTypeId).CanBeInsured;
        }

        public string GetProductTypeName(int productId)
        {
            var productTypeId = _productRepository.GetProduct(productId).ProductTypeId;
            return _productTypeRepository.GetProductType(productTypeId).Name;
        }

        public double GetProductPrice(int productId)
        {
            return _productRepository.GetProduct(productId).SalesPrice;
        }

        public string GetProductName(int productId)
        {
            return _productRepository.GetProduct(productId).Name;
        }

        public InsuranceTypes GetInsuranceType(double productPrice) 
            => productPrice < 500 ? InsuranceTypes.InsuranceNotRequired :
                                    InsuranceTypes.InsuranceRequired;

        public ProductInsurance CreateInsurance(int productId)
        {
            double productPrice = GetProductPrice(productId);

            int insuranceAmount = CalculateInsurance.CalculateInsuranceCost(productPrice,
                                                                    GetProductTypeName(productId));

            return InsuranceFactory.CreateInsurance(GetProductName(productId),
                                                    GetInsuranceType(productPrice),
                                                    insuranceAmount);
        }
    }
}
