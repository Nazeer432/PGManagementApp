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
    public class HostelRepository : IHostelRepository
    {
        private readonly HostelDBContext _context;
        public HostelRepository(HostelDBContext context)
        {
            _context = context;
        }
        public void AddHostel(Hostel hostel)
        {
            try
            {
                hostel.IsActive = true;               
                hostel.Created = DateTime.Now;
                _context.Hostels.Add(hostel);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void DeleteHostel(int id)
        {
            try
            {
                Hostel hostel = await GetHostelById(id);
                hostel.IsActive = false;
                hostel.Modified = DateTime.Now;
                _context.Hostels.Update(hostel);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Hostel>> GetAll()
        {
            return await _context.Hostels.ToListAsync();
        }

        public async Task<Hostel> GetHostelById(int id)
        {
          return await _context.Hostels.FirstOrDefaultAsync(x => x.PkhostelId == id);
        }
        public void UpdateHostel(Hostel hostel)
        {
            hostel.Modified = DateTime.Now;
            _context.Hostels.Update(hostel);
            _context.SaveChanges();
        }
        public bool HostelExists(int id)
        {
            return _context.Hostels.Any(e => e.PkhostelId == id);
        }
    }
}
