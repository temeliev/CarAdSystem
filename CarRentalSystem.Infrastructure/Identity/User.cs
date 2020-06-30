using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRentalSystem.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Dealer? Dealer { get; set; }

        public void BecomeDealer(Dealer dealer)
        {
            if(this.Dealer != null)
            {
                throw new InvalidDealerException(
                    $"User '{this.UserName}' is already a dealer.");
            }

            this.Dealer = dealer;
        }
    }
}
