using FluentAssertions;
using ProductsAPI.Factories;
using ProductsAPI.Models.Entities;
using ProductsAPI.Models.Enums;
using Xunit;

namespace ProductAPI.Tests.FactoriesTests
{
    public class InsuranceFactoryTests
    {
        [Fact]
        public void CreateInsurance_ReturnsInsurance()
        {
            ProductInsurance expectedInsurance = new()
            {
                ProductName = "Bobby",
                InsuranceAmount = 1,
                InsuranceType = InsuranceTypes.InsuranceRequired
            };

            var actualInsurance = InsuranceFactory.CreateInsurance("Bobby", InsuranceTypes.InsuranceRequired, 1);

            actualInsurance.Should().BeEquivalentTo(
                expectedInsurance,
                options => options.ComparingByMembers<ProductInsurance>());

        }
    }
}
