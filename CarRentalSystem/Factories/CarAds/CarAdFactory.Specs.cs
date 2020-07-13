using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarRentalSystem.Domain.Factories.CarAds
{
    public class CarAdFactorySpecs
    {
        [Fact]
        public void BuildShouldFailIfManufacturerIsNotSet()
        {
            //Arrange
            CarAdFactory factory = new CarAdFactory();

            //Act
            Action act = () => factory.WithCategory("Test Category", "Test description sadsd")
                                      .WithOptions(true, 4, TransmissionType.Automatic)
                                      .Buid();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldFailIfCategoryIsNotSet()
        {
            //Arrange
            CarAdFactory factory = new CarAdFactory();

            //Act
            Action act = () => factory.WithManufacturer("Test manufacturer")
                                      .WithOptions(true, 4, TransmissionType.Automatic)
                                      .Buid();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldFailIfOptionsAreNotSet()
        {
            //Arrange
            CarAdFactory factory = new CarAdFactory();

            //Act
            Action act = () => factory
                                .WithCategory("Test Category", "Test description sadsd")
                                .WithManufacturer("Test manufacturer")
                                .Buid();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldCreateCarAdIfEveryPropertyIsSet()
        {
            //Arrange
            CarAdFactory factory = new CarAdFactory();

            //Act
            Action act = () => factory
                                .WithCategory("Test Category", "Test description sadsd")
                                .WithManufacturer("Test manufacturer")
                                .WithOptions(true, 4, TransmissionType.Automatic)
                                .WithImageUrl("http://test.image.url")
                                .WithModel("test model")
                                .WithPricePerDay(100)
                                .Buid();

            //Assert
            act.Should().NotBeNull();
        }
    }
}
