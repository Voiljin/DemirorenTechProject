using DemirorenTech.Business.Commons.Models.UserModels;
using DemirorenTech.Business.IEngines.IUserEngines;
using DemirorenTech.Business.Mapping;
using DemirorenTech.Mongo.Data.Entities;
using DemirorenTech.Mongo.Data.IRepositories.IUserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemirorenTech.Business.Engines.UserEngines
{
    public class UserEngine : AutoMapperService, IUserEngine
    {
        private readonly IUserRepository _userRepository;

        public UserEngine(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserResponse Login(string username, string password)
        {
            var getUser = _userRepository.GetFilterBy(x => x.UserName == username && x.Password == password).FirstOrDefault();

            if (getUser == null) throw new Exception("Username or password is wrong");

            return Mapper.Map<UserResponse>(getUser);
        }

        public UserResponse InsertUser(InsertUserRequest request)
        {
            var insertUser = _userRepository.Insert(Mapper.Map<User>(request));

            return Mapper.Map<UserResponse>(insertUser);
        }
    }
}
