using DataAccess;
using DomainModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels;
using AutoMapper;

namespace Services
{
    public class UserService : IUserService
    {
   
        private readonly IUserRepository<User> _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository<User> userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            IEnumerable<User> allUsers = _userRepo.GetAll();
            return _mapper.Map<IEnumerable<UserViewModel>>(allUsers);
        }

        public UserViewModel GetCurrentUser(string username)
        {
            var user = _userRepo.GetByUsername(username);
            return _mapper.Map<UserViewModel>(user);
        }

        public void LogInUser(LogInViewModel user)
        {
            throw new NotImplementedException();
        }

        public void LogOutUser()
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
