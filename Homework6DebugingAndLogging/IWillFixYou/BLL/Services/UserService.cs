using BLL.Abstractions.Interfaces;
using BLL.ModelsDTO;
using Core.Models;
using DAL.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly ILogger<UserService> logger;

        public UserService(IRepository<User> userRepository, ILogger<UserService> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public IServiceResult CreateUser(IDTOModel newUser)
        {
            try
            {
                var user = new User
                {
                    Id = ((UserDTO)newUser).Id,
                    FirstName = ((UserDTO)newUser).FirstName,
                    LastName = ((UserDTO)newUser).LastName,
                    Age = ((UserDTO)newUser).Age
                };

                this.userRepository.Create(user);

                return ServiceResult.FromResult(true, "User was created");
            }
            catch (Exception)
            {
                this.logger.LogError($"Exception create user {((UserDTO)newUser).FirstName}", newUser);

                return ServiceResult.FromResult(false, "User wasn`t created");
            }
        }

        public IServiceResult<IDTOModel> GetUser(Func<User, bool> condition)
        {
            try
            {
                var user = this.userRepository.GetEntity(condition);

                var userDTO = new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age
                };

                return ServiceResult<IDTOModel>.FromResult(true, userDTO, "User");
            }
            catch (Exception)
            {
                this.logger.LogError($"User was not found");

                return ServiceResult<IDTOModel>.FromResult(false, null, "User not found");
            }
        }
    }
}
