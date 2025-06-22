using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DTO;

namespace Service.Interface
{
    public interface IConsultantUserScheduleService
    {
        Task<bool> Create(CreateConsultantUserSchedule request);
    }
}
