using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Models.CarAds
{
    public class CarAdFakes
    {
        public class CarAdDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => true;
             

            public object? Create(Type type)
            {
                var carAd = new CarAd(new Manufacturer("Valid Manufacturer"),
                "valid model",
                new CarAdAggregates.Category("valid category", "valid description is set"),
                10,
                "https://valid.test",
                new Options(true, 4, TransmissionType.Automatic),
                true);

                return carAd;
            }
        }
    }
}
