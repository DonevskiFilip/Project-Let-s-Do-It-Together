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

        public UserViewModel LogInUser(LogInViewModel user)
        {
            var LogInUser = _userRepo.GetByUsername(user.Username);
            if(LogInUser == null || LogInUser.Password != user.Password)
            {
                throw new Exception("Check Your username or password");
            }
                return _mapper.Map<UserViewModel>(LogInUser);
        }

        public void LogOutUser()
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterViewModel registerUser)
        {
            if(_userRepo.GetByUsername(registerUser.Username) != null)
            {
                throw new Exception("We have account with this username");
            }
            if(registerUser.Password != registerUser.ConfirmePassword)
            {
                throw new Exception("Your password does not match!");
            }

            User newUser = _mapper.Map<User>(registerUser);
            _userRepo.Create(newUser);
        }
    }
}
