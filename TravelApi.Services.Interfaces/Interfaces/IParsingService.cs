using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Parsing;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IParsingService
    {
        Task<OperationResult<IEnumerable<Flight>>> ParseFlightsYandexAsync(ParamsAviaTickets request);
        Task<OperationResult<IEnumerable<Hotel>>> ParseHotelsYandexAsync(ParamsHotels request);
    }
}
