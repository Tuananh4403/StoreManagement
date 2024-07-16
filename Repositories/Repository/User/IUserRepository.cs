using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.User
{
    public interface IUserRepository
    {
        Task<Staff> ValidateUserAsync(string username, string password);
        void Add(Staff staff);
    }
}
