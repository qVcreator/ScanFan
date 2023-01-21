using ScanFun.BL.Models;
using System.Collections.Generic;

namespace ScanFun.BL.Interfaces
{
    public interface ITicketService
    {
        List<TypesResponse> GetTicketTypes();

        TicketResponse SendTicket(TicketRequest ticket);
    }
}
