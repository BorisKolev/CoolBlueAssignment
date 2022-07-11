using ProductsAPI.Models.DTos;
using Xunit;
using ProductsAPI.Models.Entities;
using ProductsAPI.Functionalities.ExtensionTests;
using FluentAssertions;
using ProductsAPI.Models.Enums;

namespace ProductAPI.Tests.FunctionalitiesTests.ExtensionsTests
{
    public class ToDtoTests
    {
        [Fact]
        public void PassProduct_ReturnsProductDto()
        {
            Product product = new()
            {
                Id = 1,
                Name = "Bobby",
                SalesPrice = 123,
                ProductTypeId = 1,
            };

            ProductDto expectedProductDto = new()
            {
                Id = 1,
                Name = "Bobby",
                SalesPrice = 123,
                ProductTypeId = 1,
            };

            var actualDtoInsurance = ToDto.AsProductDto(product);

            actualDtoInsurance.Should().BeEquivalentTo(
                expectedProductDto,
                options => options.ComparingByMembers<ProductDto>());
        }

        [Fact]
        public void PassProductType_ReturnsProductTypeDto()
        {
            ProductType productType = new()
            {
                Id = 1,
                Name = "Bobby",
                CanBeInsured = true,
            };

            ProductTypeDto expectedProductTypeDto = new()
            {
                Id = 1,
                Name = "Bobby",
                CanBeInsured = true,
            };

            var actualDtoInsurance = ToDto.AsProductTypeDto(productType);

            actualDtoInsurance.Should().BeEquivalentTo(
                expectedProductTypeDto,
                options => options.ComparingByMembers<ProductTypeDto>());
        }

        [Fact]
        public void PassProductInsurance_ReturnsProductInsuranceDto()
        {
            ProductInsurance productInsurance = new()
            {
                ProductName = "Bobby",
                InsuranceAmount = 1,
                InsuranceType = InsuranceTypes.InsuranceRequired,
            };

            ProductInsuranceDto expectedProductDto = new()
            {
                ProductName = "Bobby",
                InsuranceAmount = 1,
                InsuranceType = "InsuranceRequired",
            };

            var actualProductInsuranceDto = ToDto.AsProductInsuranceDto(productInsurance);

            actualProductInsuranceDto.Should().BeEquivalentTo(
                expectedProductDto,
                options => options.ComparingByMembers<ProductInsuranceDto>());
        }

    }
}
