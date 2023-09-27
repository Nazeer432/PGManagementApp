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
    public class RoomBedRepository : IRoomBedRepository
    {
        private readonly HostelDBContext _context;
        public RoomBedRepository(HostelDBContext context)
        {
            _context = context;
        }
        public void AddRoomBed(RoomBed roomBed)
        {
            try
            {
                //roomBed.IsActive = true;
                roomBed.Created = DateTime.Now;
                _context.RoomBeds.Add(roomBed);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void DeleteRoomBed(int id)
        {
            try
            {
                RoomBed roomBed = await GetRoomBedById(id);
               // roomBed.IsActive = false;
                roomBed.Modified = DateTime.Now;
                _context.RoomBeds.Update(roomBed);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RoomBed>> GetAll()
        {
            return await _context.RoomBeds.ToListAsync();
        }

        public async Task<RoomBed> GetRoomBedById(int id)
        {
          return await _context.RoomBeds.FirstOrDefaultAsync(x => x.PkbedId == id);
        }
        public void UpdateRoomBed(RoomBed roomBed)
        {
            roomBed.Modified = DateTime.Now;
            _context.RoomBeds.Update(roomBed);
            _context.SaveChanges();
        }
        public bool RoomBedExists(int id)
        {
            return _context.RoomBeds.Any(e => e.PkbedId == id);
        }
    }
}
