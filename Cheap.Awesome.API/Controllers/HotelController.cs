using System;
using System.Collections.Generic;
using Cheap.Awesome.API.Models;
using Cheap.Awesome.API.Services;
using Cheap.Awesome.API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Cheap.Awesome.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelCalculationService _hotelCalculationService;
        public HotelController(ILogger<HotelController> logger, IHotelCalculationService hotelCalculationService)
        {
            _logger = logger;
            _hotelCalculationService = hotelCalculationService;
        }

        [HttpGet("{destinationId}/{nights}")]
        public IEnumerable<Result> GetResult(int destinationId, int nights)
        {
            object resultCall = null;
            _logger.LogInformation($"Call GetResult from HotelController with destinationId={destinationId} and nights={nights}");

            try
            {
                string urlAPI = $"https://webbedsdevtest.azurewebsites.net/api/findBargain?code=aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==&nights={nights}&destinationId={destinationId}";
                var client = new RestClient(urlAPI);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                // at first call will save the result with all calculation in cache
                // the cache key will in fallowing format destinationId{integer}-nights{integer} 
                // at next calls if we alredy have the result in cache, then will take result from cache 
                // and will not call again external api from https://webbedsdevtest.azurewebsites.net  
                if (!MemoryCacher.TryGetValue($"destinationId{destinationId}-nights{nights}", out resultCall))
                {
                    var results = JsonConvert.DeserializeObject<List<Result>>(response.Content);
                    resultCall = _hotelCalculationService.GetResultsCalculation(results, nights);

                    MemoryCacher.Add($"destinationId{destinationId}-nights{nights}", results, DateTimeOffset.UtcNow.AddMinutes(60));
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Call Exception for GetResult from HotelController with destinationId={destinationId} and nights={nights}");
            }

            _logger.LogInformation("Successfully Call GetResult from HotelController");

            if (resultCall != null)
                return (IEnumerable<Result>)resultCall;
            else
                return new List<Result>();
        }
    }
}
