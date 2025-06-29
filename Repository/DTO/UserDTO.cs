﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string FullName {  get; set; }
        public string Email { get; set; }
        public string PhoneNumber {  get; set; }
        public string Address {  get; set; }
        public string Gender {  get; set; }
        public DateTime? CreateAt { get; set; }
        public string Avatar {  get; set; }
    }
}
