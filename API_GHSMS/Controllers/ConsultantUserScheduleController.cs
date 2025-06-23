using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Repository.DTO;
using Repository.Util;
using Service.Interface;

namespace API_GHSMS.Controllers
{
    [ApiController]
    [Route("api/v1/consultant-user-schedule")]
    public class ConsultantUserScheduleController(IConsultantUserScheduleService _service) : Controller
    {

        //[HttpPost("create")]
        //[Authorize]
        //public async Task<IActionResult>Create(CreateConsultantUserSchedule request)
        //{
        //    var userId = UserUtil.GetUserId(User);
        //    request.userId = userId;
        //    var response = await _service.Create(request);
        //    return StatusCode(200, new { Message = "Create success" });
        //}
    }
}
