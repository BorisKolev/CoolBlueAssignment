using Moq;
using ProductsAPI.Functionalities;
using ProductsAPI.Interfaces.IRepository;
using ProductsAPI.Models.Entities;
using ProductsAPI.Models.Enums;
using Xunit;

namespace ProductAPI.Tests.FunctionalitiesTests
{
    public class InsuranceLookUpsTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new();
        private readonly Mock<IProductTypeRepository> _productTypeRepositoryMock = new();

        // IsProductTypeInsurable
        [Fact]
        public void IsProductTypeInsurable_WithInsurableProductType()
        {
            var product = CreateProduct();
            var productType = CreateProductType();

            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(product);
            _productTypeRepositoryMock.Setup(repo => repo.GetProductType(It.IsAny<int>()))
                .Returns(productType);

            var insuranceLookUps = new InsuranceLookUps(_productRepositoryMock.Object, _productTypeRepositoryMock.Object);
            var result = insuranceLookUps.IsProductTypeInsurable(It.IsAny<int>());

            Assert.Equal(productType.CanBeInsured, result);
        }

        [Fact]
        public void IsProductTypeInsurable_WithNonInsurableProductType()
        {
            var product = CreateProduct();
            var productType = CreateProductType();
            productType.CanBeInsured = false;

            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(product);
            _productTypeRepositoryMock.Setup(repo => repo.GetProductType(It.IsAny<int>()))
                .Returns(productType);

            var insuranceLookUps = new InsuranceLookUps(_productRepositoryMock.Object, _productTypeRepositoryMock.Object);
            var result = insuranceLookUps.IsProductTypeInsurable(It.IsAny<int>());

            Assert.Equal(productType.CanBeInsured, result);
        }

        // GetProductTypeName
        [Fact]
        public void GetProductTypeName_ReturnsTypeName()
        {
            var product = CreateProduct();
            var productType = CreateProductType();

            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(product);
            _productTypeRepositoryMock.Setup(repo => repo.GetProductType(It.IsAny<int>()))
                .Returns(productType);

            var insuranceLookUps = new InsuranceLookUps(_productRepositoryMock.Object, _productTypeRepositoryMock.Object);
            var result = insuranceLookUps.GetProductTypeName(It.IsAny<int>());

            Assert.Equal(productType.Name, result);
        }

        // GetProductPrice
        [Fact]
        public void GetProductPrice_ReturnsProductPrice()
        {
            var product = CreateProduct();

            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(product);

            var insuranceLookUps = new InsuranceLookUps(_productRepositoryMock.Object, _productTypeRepositoryMock.Object);
            var result = insuranceLookUps.GetProductPrice(It.IsAny<int>());

            Assert.Equal(product.SalesPrice, result);
        }

        // GetProductName
        [Fact]
        public void GetProductName_ReturnsProductName()
        {
            var product = CreateProduct();

            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(product);

            var insuranceLookUps = new InsuranceLookUps(_productRepositoryMock.Object, _productTypeRepositoryMock.Object);
            var result = insuranceLookUps.GetProductName(It.IsAny<int>());

            Assert.Equal(product.Name, result);
        }

        // GetInsuranceType
        [Fact]
        public void GetInsuranceType_WithLessThan500_ReturnsInsuranceNotRequired()
        {

            var insuranceLookUps = new InsuranceLookUps(_productRepositoryMock.Object, _productTypeRepositoryMock.Object);
            var result = insuranceLookUps.GetInsuranceType(499);

            Assert.Equal(InsuranceTypes.InsuranceNotRequired, result);
        }

        [Fact]
        public void GetInsuranceType_WithMoreThanOr500_ReturnsInsuranceNotRequired()
        {

            var insuranceLookUps = new InsuranceLookUps(_productRepositoryMock.Object, _productTypeRepositoryMock.Object);
            var result1 = insuranceLookUps.GetInsuranceType(500);
            var result2 = insuranceLookUps.GetInsuranceType(500);

            Assert.Equal(InsuranceTypes.InsuranceRequired, result1);
            Assert.Equal(InsuranceTypes.InsuranceRequired, result2);
        }

        private static Product CreateProduct()
        {
            return new()
            {
                Id = 1,
                Name = "Bobby",
                ProductTypeId = 1,
                SalesPrice = 1,
            };
        }

        private static ProductType CreateProductType()
        {
            return new()
            {
                Id = 1,
                Name = "Bobby",
                CanBeInsured = true,
            };
        }
    }
}
