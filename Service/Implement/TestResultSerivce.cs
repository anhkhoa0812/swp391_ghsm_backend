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
    public class TestResultSerivce(TestResultRepository _repository) : ITestResultService
    {
        public async Task<bool> CreateTestResult(CreateTestResult request)
        {
            return await _repository.CreateTestResult(request);
        }

        public async Task<TestResultResponse> GetTestResultByUserBooking(Guid bookingId)
        {
            return await _repository.GetTestResultByUserBooking(bookingId);
        }

        public async Task<List<UserTestResultResponse>> GetUserTestResultByConsulTant(Guid userId)
        {
            return await _repository.GetUserTestResultByCansulTant(userId);
        }

        public async Task<bool> UpdateTestResult(Guid resultId, CreateTestResult response)
        {
            return await _repository.EditTestResult(resultId, response);
        }
    }
}
