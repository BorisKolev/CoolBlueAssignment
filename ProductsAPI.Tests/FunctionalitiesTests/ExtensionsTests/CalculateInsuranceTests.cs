using ProductsAPI.Functionalities.Extensions;
using Xunit;

namespace ProductAPI.Tests.FunctionalitiesTests.ExtensionsTests
{
    public class CalculateInsuranceTests
    {
        [Theory]

        [InlineData(499.00, "LAPTOPS", 500)]
        [InlineData(500.00, "LAPTOPS", 1500)]
        [InlineData(1999.00, "LAPTOPS", 1500)]
        [InlineData(2000.00, "LAPTOPS", 2500)]
        [InlineData(3000.00, "LAPTOPS", 2500)]

        [InlineData(499.00, "SMARTPHONES", 500)]
        [InlineData(500.00, "SMARTPHONES", 1500)]
        [InlineData(1999.00, "SMARTPHONES", 1500)]
        [InlineData(2000.00, "SMARTPHONES", 2500)]
        [InlineData(3000.00, "SMARTPHONES", 2500)]

        [InlineData(499.00, "DIGITAL CAMERAS", 0)]
        [InlineData(500.00, "DIGITAL CAMERAS", 1000)]
        [InlineData(1999.00, "DIGITAL CAMERAS", 1000)]
        [InlineData(2000.00, "DIGITAL CAMERAS", 2000)]
        [InlineData(3000.00, "DIGITAL CAMERAS", 2000)]

        [InlineData(499.00, "SLR CAMERAS", 0)]
        [InlineData(500.00, "SLR CAMERAS", 1000)]
        [InlineData(1999.00, "SLR CAMERAS", 1000)]
        [InlineData(2000.00, "SLR CAMERAS", 2000)]
        [InlineData(3000.00, "SLR CAMERAS", 2000)]

        [InlineData(499.00, "MP3 PLAYERS", 0)]
        [InlineData(500.00, "MP3 PLAYERS", 1000)]
        [InlineData(1999.00, "MP3 PLAYERS", 1000)]
        [InlineData(2000.00, "MP3 PLAYERS", 2000)]
        [InlineData(3000.00, "MP3 PLAYERS", 2000)]

        [InlineData(499.00, "WASHING MACHINES", 0)]
        [InlineData(500.00, "WASHING MACHINES", 1000)]
        [InlineData(1999.00, "WASHING MACHINES", 1000)]
        [InlineData(2000.00, "WASHING MACHINES", 2000)]
        [InlineData(3000.00, "WASHING MACHINES", 2000)]
        public void Test_CalculateInsurance(double productPrice, string productType, int expectedInsurance)
        {
            var result = CalculateInsurance.CalculateInsuranceCost(productPrice, productType);

            Assert.Equal(expectedInsurance, result);
        }
    }
}
