using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly HostelDBContext _context;
        public UserProfileRepository(HostelDBContext context)
        {
            _context = context;
        }
        public async void AddUserProfile(UserProfile userProfile)
        {
            try
            {
                userProfile.IsActive = true;
                userProfile.Created = DateTime.Now;
                _context.UserProfiles.Add(userProfile);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void DeleteUserProfile(int id)
        {
            try
            {
                UserProfile userProfile = await GetUserProfileById(id);
                userProfile.IsActive = false;
                userProfile.Modified = DateTime.Now;
                _context.UserProfiles.Update(userProfile);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserProfile>> GetAll()
        {
            return await _context.UserProfiles.Include(u => u.Fkrole).ToListAsync();
        }
        public async Task<UserProfile> GetUserProfileById(int id)
        {
            var result = await _context.UserProfiles.Include(u => u.Fkrole)
                .FirstOrDefaultAsync(m => m.PkuserId == id);
            return result;
        }
        public async void UpdateUserProfile(UserProfile userProfile)
        {
            userProfile.Modified = DateTime.Now;
            _context.UserProfiles.Update(userProfile);
            _context.SaveChanges();
        }
        public bool UserProfileExists(int id)
        {
            return _context.UserProfiles.Any(e => e.PkuserId == id);
        }
        public UserProfile Login(UserProfile userProfile)
        {
            var userdata = _context.UserProfiles.Where(x => x.Email == userProfile.Email && x.Password == userProfile.Password).FirstOrDefault();

            return userdata;

        }
    }
}
