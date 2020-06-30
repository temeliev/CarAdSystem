using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models;
using CarRentalSystem.Domain.Models.CarAdAggregates;
using CarRentalSystem.Domain.Models.CarAds;

namespace CarRentalSystem.Domain.Factories.CarAds
{
    internal class CarAdFactory : ICarAdFactory
    {
        private string imageUrl = default!;
        private string model = default!;
        private decimal pricePerDay = default!;
        private Manufacturer manufacturer = default!;
        private Category category = default!;
        private Options options = default!;

        private bool optionsIsSet = false;
        private bool categoryIsSet = false;
        private bool manufacturerIsSet = false;

        public CarAd Buid()
        {
            if (!categoryIsSet || !manufacturerIsSet || !optionsIsSet)
            {
                throw new InvalidCarAdException("Manufacturer, category and options must have a value.");
            }

            return new CarAd(
                manufacturer,
                model,
                category,
                pricePerDay,
                imageUrl,
                options,
                true);
        }

        public ICarAdFactory WithCategory(string name, string description)
        {
            WithCategory(new Category(name, description));
            return this;
        }

        public ICarAdFactory WithCategory(Category category)
        {
            this.category = category;
            categoryIsSet = true;
            return this;
        }

        public ICarAdFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            return this;
        }

        public ICarAdFactory WithManufacturer(string name)
        {
            WithManufacturer(new Manufacturer(name));
            return this;
        }

        public ICarAdFactory WithManufacturer(Manufacturer manufacturer)
        {
            this.manufacturer = manufacturer;
            manufacturerIsSet = true;
            return this;
        }

        public ICarAdFactory WithModel(string model)
        {
            this.model = model;
            return this;
        }

        public ICarAdFactory WithOptions(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType)
        {
            WithOptions(new Options(hasClimateControl, numberOfSeats, transmissionType));
            return this;
        }

        public ICarAdFactory WithOptions(Options options)
        {
            this.options = options;
            optionsIsSet = true;
            return this;
        }

        public ICarAdFactory WithPricePerDay(decimal pricePerDay)
        {
            this.pricePerDay = pricePerDay;
            return this;
        }
    }
}
