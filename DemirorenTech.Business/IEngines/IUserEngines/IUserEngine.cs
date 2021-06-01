using DemirorenTech.Business.Commons.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.IEngines.IUserEngines
{
    public interface IUserEngine
    {
        UserResponse InsertUser(InsertUserRequest request);
        UserResponse Login(string username, string password);
    }
}
