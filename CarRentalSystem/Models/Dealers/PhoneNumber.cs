using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

namespace CarRentalSystem.Domain.Models.DealerAggregates
{
    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            if (!number.StartsWith(ModelConstants.PhoneNumber.PhoneNumberFirstSymbol))
            {
                throw new InvalidPhoneNumberException
                    ($"Phone number must start with a '{ModelConstants.PhoneNumber.PhoneNumberFirstSymbol}'.");
            }

            this.Number = number;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number) => number.Number;

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

        private void Validate(string phoneNumber)
            => Guard.ForStringLength<InvalidPhoneNumberException>(
                phoneNumber,
                ModelConstants.PhoneNumber.MinPhoneNumberLength,
                ModelConstants.PhoneNumber.MaxPhoneNumberLength,
                nameof(PhoneNumber));
    }
}
