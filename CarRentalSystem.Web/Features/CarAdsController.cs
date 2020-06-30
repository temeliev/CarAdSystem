using CarRentalSystem.Application;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ControllerBase
    {
        private readonly IRepository<CarAd> carAds;
        private readonly IOptions<ApplicationSettings> settings;

        public CarAdsController(
            IRepository<CarAd> carAds,
            IOptions<ApplicationSettings> settings)
        {
            this.carAds = carAds;
            this.settings = settings;
        }

        [HttpGet]
        public object Get() => new
        {
            Settings = this.settings,
            CarAds = this.carAds
                .All()
                .Where(x => x.IsAvailable)
                .ToList()
        };
    }
}
