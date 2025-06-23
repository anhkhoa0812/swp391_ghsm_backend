using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DTO;
using Repository.Repository;
using Service.Interface;

namespace Service.Implement
{
    public class ConsultantUserScheduleService(ConsultantUserScheduleRepository _repository) : IConsultantUserScheduleService
    {
        //public async Task<bool> Create(CreateConsultantUserSchedule request)
        //{
        //    return await _repository.Create(request);
        //}
    }
}
