using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsAPI.Controllers;
using ProductsAPI.Interfaces.IFunctionalities;
using ProductsAPI.Interfaces.IRepository;
using ProductsAPI.Models.DTos;
using ProductsAPI.Models.Entities;
using ProductsAPI.Models.Enums;
using Xunit;

namespace ProductAPI.Tests.ControllerTests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new();
        private readonly Mock<IInsuranceLookUps> _insuranceLookUpsMock = new();

        // GET PRODUCTS
        [Fact]
        public void GetProducts_WithExistingProducts_ReturnsProducts()
        {
            var Products = new[] { CreateProduct(), CreateProduct(), CreateProduct() };
            var expectedProducts = new[] {CreateProductDto(), CreateProductDto(), CreateProductDto() };

            _productRepositoryMock.Setup(repo => repo.GetProducts())
                .Returns(Products);

            var controller = new ProductsController(_productRepositoryMock.Object, _insuranceLookUpsMock.Object);
            var actualProducts = controller.GetProducts();

            actualProducts.Should().BeEquivalentTo(
                expectedProducts,
                options => options.ComparingByMembers<ProductDto>());
        }

        // GET PRODUCT
        [Fact]
        public void GetProduct_WithExistingProduct_ReturnsProduct()
        {
            var product = CreateProduct();
            var expectedProductDto = CreateProductDto();

            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(product);

            var controller = new ProductsController(_productRepositoryMock.Object, _insuranceLookUpsMock.Object);
            var result = controller.GetProduct(666);

            result.Value.Should().BeEquivalentTo(
                expectedProductDto,
                options => options.ComparingByMembers<ProductDto>());
        }

        [Fact]
        public void GetProduct_WithUnexistingProduct_ReturnsNotFound()
        {
            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()));

            var controller = new ProductsController(_productRepositoryMock.Object, _insuranceLookUpsMock.Object);

            var result = controller.GetProduct(It.IsAny<int>());

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        // GET INSURANCE
        [Fact]
        public void GetProductInsurance_WithUnexistingProduct_ReturnsNotFound()
        {
            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()));

            var controller = new ProductsController(_productRepositoryMock.Object, _insuranceLookUpsMock.Object);

            var result = controller.GetProductInsurance(It.IsAny<int>());

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetProductInsurance_WithNonInsurableType_ReturnsNull()
        {
            var expectedItem = CreateProduct();
            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(expectedItem);
            _insuranceLookUpsMock.Setup( lookup => lookup.IsProductTypeInsurable(666))
                .Returns(false);

            var controller = new ProductsController(_productRepositoryMock.Object, _insuranceLookUpsMock.Object);
            var result = controller.GetProductInsurance(666);

            result.Value.Should().Be(null);
        }

        [Fact]
        public void GetProductInsurance_WithNotNonInsurableTypeAndExistingProduct_ReturnsInsurance()
        {
            var Product = CreateProduct();
            var ProductInsurance = CreateProductInsurance();
            var expectedProductInsuranceDto = CreateProductInsuranceDto();

            _productRepositoryMock.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .Returns(Product);
            _insuranceLookUpsMock.Setup(lookup => lookup.IsProductTypeInsurable(666))
                .Returns(true);
            _insuranceLookUpsMock.Setup(lookup => lookup.CreateInsurance(666))
                .Returns(ProductInsurance);
            
            var controller = new ProductsController(_productRepositoryMock.Object, _insuranceLookUpsMock.Object);
            var result = controller.GetProductInsurance(666);

            result.Value.Should().BeEquivalentTo(
                expectedProductInsuranceDto,
                options => options.ComparingByMembers<ProductInsuranceDto>());
        }

        private static ProductInsurance CreateProductInsurance()
        {
            return new()
            {
                InsuranceAmount = 20,
                InsuranceType = InsuranceTypes.InsuranceRequired,
                ProductName = "Hey there",
            };
        }

        private static ProductInsuranceDto CreateProductInsuranceDto()
        {
            return new()
            {
                InsuranceAmount = 20,
                InsuranceType = "InsuranceRequired",
                ProductName = "Hey there",
            };
        }

        private static Product CreateProduct()
        {
            return new()
            {
                Id = 1,
                Name = "It is 2AM",
                ProductTypeId = 1,
                SalesPrice = 1.1,
            };
        }

        private static ProductDto CreateProductDto()
        {
            return new()
            {
                Id = 1,
                Name = "It is 2AM",
                ProductTypeId = 1,
                SalesPrice = 1.1,
            };
        }
    }
}
