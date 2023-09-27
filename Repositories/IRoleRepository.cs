using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
        Role GetRoleById(int id);
    }
}
