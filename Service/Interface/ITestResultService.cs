using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DTO;

namespace Service.Interface
{
    public interface ITestResultService
    {
        Task<bool> CreateTestResult(CreateTestResult request);
        Task<bool> UpdateTestResult(Guid resultId, CreateTestResult response);
        Task<TestResultResponse> GetTestResultByUserBooking(Guid bookingId);
        Task<List<UserTestResultResponse>> GetUserTestResultByConsulTant(Guid userId);
    }
}
