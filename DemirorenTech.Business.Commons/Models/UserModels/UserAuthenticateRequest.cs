using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.UserModels
{
    public class UserAuthenticateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
