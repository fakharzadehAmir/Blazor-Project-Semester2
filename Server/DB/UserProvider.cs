using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P8.Server.Controllers;
using P8.Shared;
using System.Linq;

namespace P8.Server.DB
{
    public class UserProvider
    {
        private readonly UserDbContext _context;
        private readonly ILogger _logger;
        public UserProvider(UserDbContext context, ILoggerFactory LoggerFactory)
        {
            this._context = context;
            this._logger = LoggerFactory.CreateLogger("UserProvider");
        }
        public void AddUser(User user)
        {
            if(this._context.Users == null)
                user.Id = 1;
            if(this._context.Users != null)
                user.Id = this._context.Users.Select(a => a.Id).Max() + 1;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            if(this._context.Users != null)
                this._context.Users.Update(user);
            _context.SaveChanges();
        }
        public void RemoveUser(User user)
        {
            if(this._context.Users != null)
                this._context.Users.Remove(user);
            _context.SaveChanges();
        }
        public List<User> GetAllUser() =>
            this._context.Users.OrderBy(ins => ins.Id).ToList();
    }
}