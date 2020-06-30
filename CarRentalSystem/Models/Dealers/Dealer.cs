using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.DealerAggregates;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Domain.Models
{
    public class Dealer : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<CarAd> carAds;

        public string Name { get; }

        public PhoneNumber PhoneNumber { get; }

        public IReadOnlyCollection<CarAd> CarAds => this.carAds.ToList().AsReadOnly();

        private Dealer(string name)
        {
            Name = name;
            PhoneNumber = default!;
            carAds = new HashSet<CarAd>();
        }

        public Dealer(string name, PhoneNumber number)
        {
            Validate(name);

            Name = name;
            PhoneNumber = number;
            carAds = new HashSet<CarAd>();
        }

        public void AddCarAd(CarAd carAd) 
            => carAds.Add(carAd);

        private void Validate(string name)
            => Guard.ForStringLength<InvalidCarAdException>
                (name, 
                ModelConstants.Common.MinNameLength, 
                ModelConstants.Common.MaxNameLength, 
                nameof(this.Name));
    }
}
