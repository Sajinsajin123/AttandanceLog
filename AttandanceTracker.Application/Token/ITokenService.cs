using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.Token
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
