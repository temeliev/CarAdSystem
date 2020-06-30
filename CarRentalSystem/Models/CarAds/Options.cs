using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class Options : ValueObject
    {
        private Options(bool hasClimateControl, int numberOfSeats)
        {
            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;
            TransmissionType = default!;
        }

        internal Options(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType)
        {
            this.Validate(numberOfSeats);

            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;
            this.TransmissionType = transmissionType;
        }

        public bool HasClimateControl { get; }

        public int NumberOfSeats { get; }

        public TransmissionType TransmissionType { get; }

        private void Validate(int numberOfSeats)
            => Guard.AgainstOutOfRange<InvalidOptionsException>(
                numberOfSeats,
                ModelConstants.Options.MinNumberOfSeats,
                ModelConstants.Options.MaxNumberOfSeats,
                nameof(this.NumberOfSeats));
    }
}
