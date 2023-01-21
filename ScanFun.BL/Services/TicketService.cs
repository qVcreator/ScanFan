using ScanFun.BL.Interfaces;
using ScanFun.BL.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace ScanFun.BL.Services
{
    public class TicketService : ITicketService
    {
        private JsonSerializerOptions _jsonOptions;

        public TicketService()
        {
            _jsonOptions = new JsonSerializerOptions();
            _jsonOptions.PropertyNameCaseInsensitive = true;
        }

        public List<TypesResponse> GetTicketTypes()
        {
            //server query
            var response = @" [ {""id"": ""14"", ""caption"": ""Детский платный""}, 
    {""id"": ""15"", ""caption"": ""Детский бесплатный""} ]";

            return JsonSerializer.Deserialize<List<TypesResponse>>(response, _jsonOptions);
        }

        public TicketResponse SendTicket(TicketRequest ticket)
        {
            //server query
            var response = @"{""mess"": ""Билет зарегестрирован"", ""type"": ""OK""}";

            return JsonSerializer.Deserialize<TicketResponse>(response, _jsonOptions);
        }
    }
}
