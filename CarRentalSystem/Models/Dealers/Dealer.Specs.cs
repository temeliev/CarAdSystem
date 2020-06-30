using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace CarRentalSystem.Domain.Models.Dealers
{
    public class DealerSpecs
    {
		[Fact]
		public void AddingCarAdShouldIncreaseCarAdsCount()
		{
			// Arrange
			var carAd = A.Dummy<CarAd>();
			var dealer = new Dealer("valid name", new DealerAggregates.PhoneNumber("+35955"));

			// Act
			dealer.AddCarAd(carAd);

			// Assert
			dealer.CarAds.Should().NotBeEmpty().And.HaveCount(1);
		}
	}
}
