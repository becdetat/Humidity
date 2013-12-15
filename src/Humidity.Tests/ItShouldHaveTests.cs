using Shouldly;
using Xunit;

namespace Humidity.Tests
{
    public class ItShouldHaveTests
    {
        [Fact]
        public void BecauseTestsAreTehBomb()
        {
            true.ShouldNotBe(false);
        }
    }
}