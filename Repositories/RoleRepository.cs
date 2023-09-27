using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Data.AppConstants;

namespace Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HostelDBContext _context;
        public RoleRepository(HostelDBContext context)
        {
            _context = context;
        }
        public void AddRole(Role role)
        {
            try
            {
                role.IsActive = true;
                role.Created = DateTime.Now;
                _context.Roles.Add(role);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRole(int id)
        {
            try
            {
                Role role = GetRoleById(id);
                role.IsActive = false;
                role.Modified = DateTime.Now;
                _context.Roles.Update(role);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
          return _context.Roles.FirstOrDefault(x => x.PkroleId == id);
        }

        public void UpdateRole(Role role)
        {
            role.Modified = DateTime.Now;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
    }
}
