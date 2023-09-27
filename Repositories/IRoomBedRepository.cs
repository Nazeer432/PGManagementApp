using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomBedRepository
    {
       Task<List<RoomBed>> GetAll();
        void AddRoomBed(RoomBed roomBed);
        void UpdateRoomBed(RoomBed roomBed);
        void DeleteRoomBed(int id);
       Task<RoomBed> GetRoomBedById(int id);
        bool RoomBedExists(int id);
    }
}
