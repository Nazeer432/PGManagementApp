using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class RoomDb
    {
        public int PkroomId { get; set; }
        public string RoomName { get; set; } = null!;
        public byte? RoomStatus { get; set; }
        public int? FkbranchId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public int FkhostelId { get; set; }
        public int? NumberOfBeds { get; set; }
        public bool IsGuestRoom { get; set; }
        public byte? RoomType { get; set; }
        public int? FilledBeds { get; set; }
        public string RoomWithType { get; set; }
    }
}
