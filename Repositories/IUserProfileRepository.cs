using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfile>> GetAll();
        void AddUserProfile(UserProfile userProfile);
        void UpdateUserProfile(UserProfile userProfile);
        void DeleteUserProfile(int id);
        Task<UserProfile> GetUserProfileById(int id);
        bool UserProfileExists(int id);
        UserProfile Login(UserProfile userProfile);
    }

}
