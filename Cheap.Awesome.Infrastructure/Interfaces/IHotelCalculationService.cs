using System.Collections.Generic;
using Cheap.Awesome.BusinessLayer.Models;

namespace Cheap.Awesome.Infrastructure.Interfaces
{
    public interface IHotelCalculationService
    {
        public List<Result> GetResultsCalculation(List<Result> results, int nights);
    }
}
