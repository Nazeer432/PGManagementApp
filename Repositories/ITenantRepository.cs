using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITenantRepository
    {
        Task<List<Tenant>> GetAll();
        List<TenantsDb> GetAllTenantsByStatus();
        void AddTenant(TenantsDb tenant);
        void UpdateTenant(TenantsDb tenant);
        void DeleteTenant(int id);
        Tenant GetTenantById(int id);
       Task<TenantsDb> GetTenantEditById(int id);
        List<SelectListItem> GetAllPrimaryTenants();
        bool TenantExists(int id);
    }
}
