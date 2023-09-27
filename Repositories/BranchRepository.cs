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
    public class BranchRepository : IBranchRepository
    {
        private readonly HostelDBContext _context;
        public BranchRepository(HostelDBContext context)
        {
            _context = context;
        }
        public void AddBranch(Branch branch)
        {
            try
            {
                branch.IsActive = true;               
                branch.Created = DateTime.Now;
                _context.Branches.Add(branch);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void DeleteBranch(int id)
        {
            try
            {
                Branch branch = await GetBranchById(id);
                branch.IsActive = false;
                branch.Modified = DateTime.Now;
                _context.Branches.Update(branch);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Branch>> GetAll()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetBranchById(int id)
        {
          return await _context.Branches.FirstOrDefaultAsync(x => x.PkbranchId == id);
        }
        public void UpdateBranch(Branch branch)
        {
            branch.Modified = DateTime.Now;
            _context.Branches.Update(branch);
            _context.SaveChanges();
        }
        public bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.PkbranchId == id);
        }
    }
}
