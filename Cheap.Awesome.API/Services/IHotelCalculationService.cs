using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cheap.Awesome.API.Models;

namespace Cheap.Awesome.API.Services
{
    public interface IHotelCalculationService
    {
        public List<Result> GetResultsCalculation(List<Result> results, int nights);
    }
}
