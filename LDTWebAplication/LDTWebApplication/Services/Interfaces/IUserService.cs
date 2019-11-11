using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(RegisterViewModel user);
        UserViewModel LogInUser(LogInViewModel user);
        UserViewModel GetCurrentUser(string username);
        void LogOutUser();
        IEnumerable<UserViewModel> GetAllUsers();
    }
}
