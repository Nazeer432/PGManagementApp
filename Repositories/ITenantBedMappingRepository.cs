using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITenantBedMappingRepository
    {
        Task<List<TenantBedMapping>> GetAll();
        void AddTenantBedMapping(TenantBedMapping bedMapping);
        void UpdateTenantBedMapping(TenantBedMapping bedMapping);
        void DeleteTenantBedMapping(int id);
        Task<TenantBedMapping> GetTenantBedMappingById(int id);
        bool TenantBedMappingExists(int id);
    }
}
