using Repositories.Entities;
using Repositories.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Staff> LoginAsync(string username, string password)
        {
            return await _userRepository.ValidateUserAsync(username, password);
        }
        public void AddStaff(Staff staff)
        {
            _userRepository.Add(staff);
        }
    }
}
