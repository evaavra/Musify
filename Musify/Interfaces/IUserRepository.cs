using Musify.Models;
using System.Collections.Generic;

namespace Musify.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();
        IEnumerable<ApplicationUser> GetPremiumUsers();
        IEnumerable<ApplicationUser> GetNotPremiumUsers();
    }
}