using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cheap.Awesome.API.Models;
using Newtonsoft.Json;

namespace Cheap.Awesome.API.Services
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
