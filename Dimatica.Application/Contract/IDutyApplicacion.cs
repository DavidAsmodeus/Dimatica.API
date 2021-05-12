using Dimatica.Application.Model;
using System.Collections.Generic;

namespace Dimatica.Application.Contract
{
    public interface IDutyApplicacion
    {
        Duty GetDutyById(string id);
        List<Duty> GetDuties();
        Duty AddDuty(Duty duty);
        Duty UpdateDuty(Duty duty);
        void DeleteDuty(string id);
    }
}
