using System.Collections.Generic;
using Cheap.Awesome.BusinessLayer.Models;
using Cheap.Awesome.Infrastructure.Interfaces;

namespace Cheap.Awesome.Infrastructure.Services
{
    public class HotelCalculationService : IHotelCalculationService
    {
        public List<Result> GetResultsCalculation(List<Result> results, int nights)
        {
            if (results != null && results.Count != 0)
            {
                foreach (var result in results)
                {
                    foreach (var rate in result.rates)
                    {
                        if (rate.rateType.Equals("PerNight"))
                        {
                            rate.value = rate.value * nights;
                        }
                    }
                }
            }

            return results;
        }
    }
}
