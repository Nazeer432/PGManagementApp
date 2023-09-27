using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Data.AppConstants;

namespace Repositories
{
    public class TenantBedMappingRepository : ITenantBedMappingRepository
    {
        private readonly HostelDBContext _context;
        public TenantBedMappingRepository(HostelDBContext context)
        {
            _context = context;
        }
        public void AddTenantBedMapping(TenantBedMapping bedMapping)
        {
            try
            {
                bedMapping.IsActive = true;
                bedMapping.Created = DateTime.Now;
                _context.TenantBedMappings.Add(bedMapping);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void DeleteTenantBedMapping(int id)
        {
            try
            {
                TenantBedMapping bedMapping = await GetTenantBedMappingById(id);
                bedMapping.IsActive = false;
                bedMapping.Modified = DateTime.Now;
                _context.TenantBedMappings.Update(bedMapping);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<TenantBedMapping>> GetAll()
        {
            return await _context.TenantBedMappings.ToListAsync();
        }
        public async Task<TenantBedMapping> GetTenantBedMappingById(int id)
        {
          return await _context.TenantBedMappings.FirstOrDefaultAsync(x => x.PktenantBedId == id);
        }
        public void UpdateTenantBedMapping(TenantBedMapping bedMapping)
        {
            bedMapping.Modified = DateTime.Now;
            _context.TenantBedMappings.Update(bedMapping);
            _context.SaveChanges();
        }
        public bool TenantBedMappingExists(int id)
        {
            return _context.TenantBedMappings.Any(e => e.PktenantBedId == id);
        }
    }
}
