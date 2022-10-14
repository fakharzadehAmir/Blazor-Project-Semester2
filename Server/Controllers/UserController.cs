using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P8.Server.DB;
using P8.Shared;

namespace P8.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserProvider _provider;
        public UserController(UserProvider provider)
        {
            this._provider = provider;
        }
        [HttpPost]
        [Route("addNewUserToDb")]
        public User AddNewUserToDB(User newUser)
        {
            this._provider.AddUser(newUser);
            return newUser;
        }
        [HttpPut]
        [Route("updateUserInDB")]
        public User UpdateUserinDB(User newUser)
        {
            this._provider.UpdateUser(newUser);
            return newUser;
        }
        [HttpDelete]
        [Route("removeUserFromDB")]
        public User RemoveUserinDB(string email)
        {
            var DeletedUser = this._provider.GetAllUser().Where(user => user.Email == email).First();
            this._provider.RemoveUser(DeletedUser);
            return DeletedUser;
        }
        [HttpGet]
        [Route("GetAllUserFromDb")]
        public List<User> GetAllUserFromDb() =>
            this._provider.GetAllUser();
    }
}