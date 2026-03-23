using AttandanceTracker.Application.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.TokenService
{
    public class AuthService
    {
        private readonly ITokenService tokenService;

        public AuthService(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        public string Login(string username, string password)
        {
            // Replace with DB validation
            if (username == "admin" && password == "123")
            {
                return tokenService.GenerateToken(username);
            }

            throw new Exception("Invalid credentials");
        }
    }
}
