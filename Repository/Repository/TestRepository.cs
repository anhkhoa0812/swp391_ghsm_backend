using Repository.Base;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TestRepository : GenericRepository<Test>
    {
        public TestRepository() { }
        public TestRepository(Swp391ghsmContext context) => _context = context;

        public async Task<bool> CreateTest(TestDTO request)
        {
            try
            {
                var createNewTest = new Test
                {
                    TestId = Guid.NewGuid(),
                    Name = request.TestName,
                    Description = request.Description,
                    Price = request.Price
                };

                await _context.Tests.AddAsync(createNewTest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) {

                throw new Exception(ex.ToString());
            }
        }
    }
}
