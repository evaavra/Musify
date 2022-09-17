using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Musify.Interfaces;

namespace Musify.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users;
        }

        public IEnumerable<ApplicationUser> GetPremiumUsers()
        {
            var users = GetAll().ToList();

            return users.Where(u => u.HasPaid == true);
        }

        public IEnumerable<ApplicationUser> GetNotPremiumUsers()
        {
            var users = GetAll().ToList();

            return users.Where(u => u.HasPaid == false);
        }
    }
}