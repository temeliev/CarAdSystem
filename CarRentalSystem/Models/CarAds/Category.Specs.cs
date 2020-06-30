using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAdAggregates;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            //Act
            Action act = () => new Category("Valid name", "Valid description text");

            //Assert
            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            //Act
            Action act = () => new Category("", "Valid description text");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidDescriptionShouldThrowException()
        {
            //Act
            Action act = () => new Category("valid name", "");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidNameAndDescriptionShouldThrowException()
        {
            //Act
            Action act = () => new Category("", "");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }
    }
}
