using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsAPI.Controllers;
using ProductsAPI.Interfaces.IRepository;
using ProductsAPI.Models.DTos;
using ProductsAPI.Models.Entities;
using Xunit;

namespace ProductAPI.Tests.ControllerTests
{
    public class ProductTypeControllerTests
    {
        private readonly Mock<IProductTypeRepository> _productTypeRepositoryMock = new();

        [Fact]
        public void GetProductType_WithExistingProductType_ReturnsProductType()
        {
            var productType = CreateProductType();
            var productTypeDto = CreateProductTypeDto();

            _productTypeRepositoryMock.Setup(repo => repo.GetProductType(It.IsAny<int>()))
                .Returns(productType);

            var controller = new ProductTypesController(_productTypeRepositoryMock.Object);
            var result = controller.GetProductType(666);

            result.Value.Should().BeEquivalentTo(
                productTypeDto,
                options => options.ComparingByMembers<ProductTypeDto>());
        }

        [Fact]
        public void GetProductType_WithUnexistingProduct_ReturnsNotFound()
        {
            _productTypeRepositoryMock.Setup(repo => repo.GetProductType(It.IsAny<int>()));

            var controller = new ProductTypesController(_productTypeRepositoryMock.Object);

            var result = controller.GetProductType(It.IsAny<int>());

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetProductTypes_WithExistingProducts_ReturnsProductTypes()
        {
            var productTypes = new[] { CreateProductType(), CreateProductType(), CreateProductType() };
            var expectedProductTypes = new[] { CreateProductType(), CreateProductType(), CreateProductType() };

            _productTypeRepositoryMock.Setup(repo => repo.GetProductTypes())
                .Returns(productTypes);

            var controller = new ProductTypesController(_productTypeRepositoryMock.Object);
            var result = controller.GetProductTypes();

            result.Should().BeEquivalentTo(
                expectedProductTypes,
                options => options.ComparingByMembers<ProductTypeDto>());
        }

        private static ProductType CreateProductType()
        {
            return new()
            {
                Id = 1,
                Name = "I am 23 years old and I watch Naruto"
            };
        }

        private static ProductTypeDto CreateProductTypeDto()
        {
            return new()
            {
                Id = 1,
                Name = "I am 23 years old and I watch Naruto"
            };
        }
    }
}
