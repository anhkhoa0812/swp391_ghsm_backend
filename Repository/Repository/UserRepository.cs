﻿using Repository.Base;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }
        public UserRepository(Swp391ghsmContext context) => _context = context;
        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
