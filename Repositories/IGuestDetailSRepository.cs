using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGuestDetailSRepository
    {
       Task<List<GuestDetail>> GetAllGuestDetails();
       Task GetGuestDetailById(int id);
        bool AddGuestDetail(Room room);
        bool UpdateGuestDetail(Room room);
        Task<bool> DeleteRoom(int id);
       Task<Room> GetRoomById(int id);
        bool RoomExists(int id);
        public  List<RoomDb> GetRoomsByStatus(int statusId, bool isGuestRoom);
    }
}
