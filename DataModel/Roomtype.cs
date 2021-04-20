using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.DataModel
{
    public class Roomtype
    {
        public int RoomtypeId { get; set; }
        public string  RoomTypeName { get; set; }
        
      
        public List<Room> Room { get; set; } = new();
    }
}
