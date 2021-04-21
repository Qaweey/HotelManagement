using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.DataModel
{
    public class Room
    {
        public int RoomId { get; set; }
        public string  RoomNumber { get; set; }
        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal CostOfRoom { get; set; }
        public int CustomerId { get; set; }
        public bool IsCheckedIn { get; set; }
        
        public bool IsBooked { get; set; }

        public int RoomtypeId { get; set; }
        //Navigational Properties
        public Roomtype Rometype { get; set; }
        public Customer Customer { get; set; }

    }
}
