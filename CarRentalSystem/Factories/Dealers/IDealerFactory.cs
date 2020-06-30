using CarRentalSystem.Domain.Models;

namespace CarRentalSystem.Domain.Factories.Dealers
{
    public interface IDealerFactory : IFactory<Dealer>
    {
        IDealerFactory WithName(string name);

        IDealerFactory WithPhoneNumber(string phoneNumber);
    }
}
