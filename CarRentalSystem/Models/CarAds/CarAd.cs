using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAdAggregates;
using CarRentalSystem.Domain.Models.CarAds;
using System.Runtime.CompilerServices;

namespace CarRentalSystem.Domain.Models
{
    public class CarAd : Entity<int>, IAggregateRoot
    {
        public string Model { get; }
        public decimal PricePerDay { get; }
        public string ImageUrl { get; }
        public bool IsAvailable { get; private set; }
        public Manufacturer Manufacturer { get; }
        public Category Category { get; }

        public Options Options { get; }

        private CarAd(
            string model,
            string imageUrl,
            decimal pricePerDay,
            bool isAvailable)
        {
            this.Model = model;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.IsAvailable = isAvailable;

            this.Manufacturer = default!;
            this.Category = default!;
            this.Options = default!;
        }

        public CarAd(
            Manufacturer manufacturer, 
            string model, 
            Category category,
            decimal pricePerDay, 
            string imageUrl,
            Options options,
            bool isAvailable) 
        {
            this.Validate(model, imageUrl, pricePerDay);

            Model = model;
            PricePerDay = pricePerDay;
            ImageUrl = imageUrl;
            Category = category;
            Options = options;
            Manufacturer = manufacturer;
            IsAvailable = isAvailable;
        }

        public void ChangeAvailability()
            => this.IsAvailable = !this.IsAvailable;

        private void Validate(string model, string imageUrl, decimal pricePerDay)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                model,
                ModelConstants.CarAd.MinModelLength,
                ModelConstants.CarAd.MaxModelLength,
                nameof(this.Model));

            Guard.ForValidUrl<InvalidCarAdException>(
                imageUrl,
                nameof(this.ImageUrl));

            Guard.AgainstOutOfRange<InvalidCarAdException>(
                pricePerDay,
                ModelConstants.Common.Zero,
                decimal.MaxValue,
                nameof(this.PricePerDay));
        }
    }
}
