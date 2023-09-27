using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomRepository
    {
       Task<List<Room>> GetAll();
       Task<List<Room>> GetGuestRooms();
        bool AddRoom(Room room);
        bool UpdateRoom(Room room);
        Task<bool> DeleteRoom(int id);
       Task<Room> GetRoomById(int id);
        bool RoomExists(int id);
        public  List<RoomDb> GetRoomsByStatus(int statusId, bool isGuestRoom, bool showBeds = false);
    }
}
