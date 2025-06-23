using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository.Models;
#pragma warning disable
namespace Repository.Repository
{
    public class TestResultRepository(Swp391ghsmContext _context)
    {
        public async Task<bool> CreateTestResult(CreateTestResult request)
        {
            try
            {
                var getBooking = await _context.TestBookings.FirstOrDefaultAsync(x => x.TestBookingId == request.BookingID);
                var createNewTestResult = new TestResult
                {
                    ResultId = Guid.NewGuid(),
                    UserId = getBooking.UserId,
                    TestId = getBooking.TestId,
                    TypeStis = request.typeSTIs ?? null,
                    TestSample = request.testSample ?? null,
                    TestBlood = request.testBlood ?? null,
                    TestUrine = request.testUrine ?? null,
                    DiagnosticResults = request.diagnosticResults ?? null,
                };

                await _context.TestResults.AddAsync(createNewTestResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
          
        }

        public async Task<bool>EditTestResult(Guid resultId, CreateTestResult request)
        {
            try
            {
                var getTestResult = await _context.TestResults.FirstOrDefaultAsync(x => x.ResultId == resultId);
                if (getTestResult == null)
                {
                    return false;
                }

                getTestResult.TypeStis = request.typeSTIs ?? getTestResult.TypeStis;
                getTestResult.TestSample = request.testSample ?? getTestResult.TestSample;
                getTestResult.TestBlood = request.testBlood ?? getTestResult.TestBlood;
                getTestResult.TestUrine = request.testUrine ?? getTestResult.TestUrine;
                getTestResult.DiagnosticResults = request.diagnosticResults ?? getTestResult.DiagnosticResults;
                _context.TestResults.Update(getTestResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public async Task<TestResultResponse>GetTestResultByUserBooking(Guid bookingId)
        {
            var getBooking = await _context.TestBookings.FirstOrDefaultAsync(x => x.TestBookingId == bookingId);
            var getTestResultByUserBooking = await _context.TestResults.FirstOrDefaultAsync(x => x.UserId == getBooking.UserId);

            var response = new TestResultResponse
            {
                ResultId = getTestResultByUserBooking.ResultId,
                TypeSTIs = getTestResultByUserBooking.TypeStis,
                TestBlood = getTestResultByUserBooking.TestBlood,
                DiagnosticResults = getTestResultByUserBooking.DiagnosticResults,
                TestSample = getTestResultByUserBooking.TestSample,
                TestUrine = getTestResultByUserBooking.TestUrine
            };

            return response;
        }

        public async Task<List<UserTestResultResponse>> GetUserTestResultByCansulTant(Guid userId)
        {
            var getConsuttant = await _context.Consultants.FirstOrDefaultAsync(x => x.UserId == userId);
            var bookings = await _context.TestBookings
                .Include(x => x.Test)
                .Where(x => x.Test.ConsutantId == getConsuttant.ConsultantId)
                .ToListAsync();

            var userIds = bookings.Select(b => b.UserId).Distinct().ToList();

            var users = await _context.Users
                .Where(u => userIds.Contains(u.UserId))
                .ToListAsync();

            var testResults = await _context.TestResults
                .Where(tr => userIds.Contains(tr.UserId))
                .ToListAsync();

            var result = (from booking in bookings
                          join user in users on booking.UserId equals user.UserId
                          join testResult in testResults on booking.UserId equals testResult.UserId into trGroup
                          from tr in trGroup.DefaultIfEmpty()
                          select new UserTestResultResponse
                          {
                              UserResponse = new UserResponse
                              {
                                  UserId = user.UserId,
                                  FullName = user.FullName,
                                  Email = user.Email,
                                  Gender = user.Gender,
                                  Address = user.Address
                              },
                              TestResultResponse = tr != null ? new TestResultResponse
                              {
                                  ResultId = tr.UserId,
                                  TypeSTIs = tr.TypeStis,
                                  TestSample = tr.TestSample,
                                  TestBlood = tr.TestBlood,
                                  TestUrine = tr.TestUrine,
                                  DiagnosticResults = tr.DiagnosticResults
                              } : null
                          }).ToList();

            return result;
        }
    }
}
