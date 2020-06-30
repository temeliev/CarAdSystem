using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class Manufacturer : Entity<int>
    {
        public string Name { get; }

        public Manufacturer(string name)
        {
            Validate(name);

            Name = name;
        }

        private void Validate(string name)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                name,
                ModelConstants.Common.MinNameLength,
                ModelConstants.Common.MaxNameLength,
                nameof(this.Name));
        }
    }
}
