using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DTO;

namespace Service.Interface
{
    public interface IAuthenService
    {
        Task<LoginResponseDto> LoginWithToken(string email, string password);
        Task<User> RegisterAsync(string fullName, string email, string password, Guid roleId, string phoneNumber, string gender);
    }
}
