using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Parsing;
using TravelApi.Services.Interfaces.Interfaces;
using System.Net.Http;

namespace TravelAPI.Controllers
{
    [Route("api/parsing")]
    [ApiController]
    public class ParsingController : ControllerBase
    {
        private readonly IParsingService _parsingService;
        public ParsingController(IParsingService parsingService)
        {
            _parsingService = parsingService;
        }

        [HttpPost("parseFlights")]
        public Task<OperationResult<IEnumerable<Flight>>> GetFlightsYandex(ParamsAviaTickets request)
        {
            var response = _parsingService.ParseFlightsYandexAsync(request);
            return response;
        }

        [HttpPost("parseHotels")]
        public Task<OperationResult<IEnumerable<Hotel>>> GetTicketsYandex(ParamsHotels request)
        {
            var response = _parsingService.ParseHotelsYandexAsync(request);
            return response;
        }
    }
}
