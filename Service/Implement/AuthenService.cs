﻿using Repository.Models;
using Repository.Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DTO;

namespace Service.Implement
{
    public class AuthenService : IAuthenService
    {
        private readonly AuthenRepository _authenRepository;

        public AuthenService(AuthenRepository authenRepository)
        {
            _authenRepository = authenRepository;
        }

        public async Task<LoginResponseDto> LoginWithToken(string email, string password)
        {
            var (token, user) = await _authenRepository.LoginWithToken(email, password);
            var response = new LoginResponseDto
            {
                Token = token,
                UserId = user.UserId,
                Avatar = user.Avatar,
            };
            return response;
        }

        public async Task<User> RegisterAsync(string fullName, string email, string password, Guid roleId, string phoneNumber, string gender)
        {
            return await _authenRepository.RegisterAsync(fullName, email, password, roleId, phoneNumber, gender);
        }
    }
}
