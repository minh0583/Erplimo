using System;
using System.Collections.Generic;
using System.Text;

namespace Erplimo.Business.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
    }
}
