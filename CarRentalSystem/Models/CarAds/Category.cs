using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

namespace CarRentalSystem.Domain.Models.CarAdAggregates
{
    public class Category : Entity<int>
    {
        public string Name { get; }

        public string Description { get; }

        internal Category(string name, string description)
        {
            Validate(name, description);

            Name = name;
            Description = description;
        }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                name,
                ModelConstants.Common.MinNameLength,
                ModelConstants.Common.MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidCarAdException>(
                description,
                ModelConstants.Category.MinDescriptionLength,
                ModelConstants.Category.MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
