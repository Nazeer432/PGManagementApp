using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IHostelRepository
    {
       Task<List<Hostel>> GetAll();
        void AddHostel(Hostel hostel);
        void UpdateHostel(Hostel hostel);
        void DeleteHostel(int id);
       Task<Hostel> GetHostelById(int id);
        bool HostelExists(int id);
    }
}
