using Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories.Repository.User
{
    public class UserRepository :IUserRepository
    {
        private readonly MyStoreDBContext _context;

        public UserRepository(MyStoreDBContext context)
        {
            _context = context;
        }

        public async Task<Staff> ValidateUserAsync(string username, string password)
        {
            return await _context.Staffs.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
        public void Add(Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
        }
    }
}
