using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBranchRepository
    {
       Task<List<Branch>> GetAll();
        void AddBranch(Branch branch);
        void UpdateBranch(Branch branch);
        void DeleteBranch(int id);
       Task<Branch> GetBranchById(int id);
        bool BranchExists(int id);
    }
}
