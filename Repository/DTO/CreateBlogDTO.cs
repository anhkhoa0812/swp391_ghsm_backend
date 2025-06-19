using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Repository.DTO
{
    public class CreateBlogDTO
    {
        public string Title { get; set; }
        public string Content {  get; set; }
        public IFormFile Image {  get; set; }
    }
}
