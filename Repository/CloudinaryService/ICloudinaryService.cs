using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OhBau.Service.CloudinaryService
{
    public interface ICloudinaryService
    {
        Task<string> Upload(IFormFile file);
    }
}
