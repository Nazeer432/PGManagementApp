using Data.Models;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.ApplicationEnums;
//using static Data.AppConstants;

namespace Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HostelDBContext _context;
        public RoomRepository(HostelDBContext context)
        {
            _context = context;
        }
        public bool AddRoom(Room room)
        {
            try
            {
                room.Created = DateTime.Now;
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRoom(int id)
        {
            try
            {
                Room room = await GetRoomById(id);
                room.RoomStatus = (byte)RoomStatus.Delete;
                room.Modified = DateTime.Now;
                _context.Rooms.Update(room);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<Room>> GetAll()
        {
            var data = await _context.Rooms.Where(x => x.IsGuestRoom == false).ToListAsync();

            data.Select(x => new Room()
            {
                PkroomId = x.PkroomId,
                RoomName = x.RoomName,
                RoomType = x.RoomType,
                NumberOfBeds = x.NumberOfBeds,
                FilledBeds = x.FilledBeds,
                RoomStatus = x.RoomStatus,
                Created = x.Created,
                Modified = x.Modified,
                Fkbranch = _context.Set<Branch>().FirstOrDefault(y => y.PkbranchId == x.FkbranchId),
                Fkhostel = _context.Set<Hostel>().FirstOrDefault(y => y.PkhostelId == x.FkhostelId),

            }).ToList();
            return data;
        }
        public async Task<List<Room>> GetGuestRooms()
        {
            var data = await _context.Rooms.Where(x => x.IsGuestRoom == true).ToListAsync();

            data.Select(x => new Room()
            {
                PkroomId = x.PkroomId,
                RoomName = x.RoomName,
                RoomType = x.RoomType,
                NumberOfBeds = x.NumberOfBeds,
                FilledBeds = x.FilledBeds,
                RoomStatus = x.RoomStatus,
                Created = x.Created,
                Modified = x.Modified,
                Fkbranch = _context.Set<Branch>().FirstOrDefault(y => y.PkbranchId == x.FkbranchId),
                Fkhostel = _context.Set<Hostel>().FirstOrDefault(y => y.PkhostelId == x.FkhostelId),

            }).ToList();
            return data;
        }
        public async Task<Room> GetRoomById(int id)
        {
            var data = await _context.Rooms
             .Include(s => s.Fkbranch).ThenInclude(s => s.Fkhostel)
             .FirstOrDefaultAsync(s => s.PkroomId == id);
            return data;
        }
        public bool UpdateRoom(Room room)
        {
            try
            {
                room.Modified = DateTime.Now;
                _context.Rooms.Update(room);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.PkroomId == id);
        }

        public List<RoomDb> GetRoomsByStatus(int statusId, bool isGuestRoom, bool showBeds = false)
        {
            List<Room> data = _context.Rooms.Where(x => x.RoomStatus == statusId && x.IsGuestRoom == isGuestRoom).ToList();
            List<RoomDb> roomDBs = new List<RoomDb>();
            foreach (Room db in data)
            {
                RoomDb roomDb = new RoomDb()
                {
                    PkroomId = db.PkroomId,
                    RoomName = db.RoomName,
                    RoomType = db.RoomType,
                    NumberOfBeds = db.NumberOfBeds,
                    FilledBeds = db.FilledBeds,
                    RoomStatus = db.RoomStatus,
                    Created = db.Created,
                    Modified = db.Modified,
                    RoomWithType = GetRoomFullName(db, showBeds)
                };
                roomDBs.Add(roomDb);
            }
            return roomDBs;
        }
        private string GetRoomFullName(Room room, bool showBeds)
        {
            if (showBeds)
            {
                return room.RoomName + " | " + "" + @Enum.GetName(typeof(RoomType), room.RoomType) + " | " + (room.NumberOfBeds - room.FilledBeds) + " (Avl beds)";
            }
            else
            {
                return room.RoomName + " | " + "" + @Enum.GetName(typeof(RoomType), room.RoomType);
            }
        }
    }
}
