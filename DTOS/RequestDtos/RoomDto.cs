using HotelManagementAPI.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.ModelDtos
{
    public class RoomDto
    {

        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        [Column("amount", TypeName = "decimal(19, 4)")]
        public decimal CostOfRoom { get; set; }
        public int CustomerId { get; set; }
        public bool IsCheckedIn { get; set; }
        public bool IsCheckedOut { get; set; }
        public bool IsBooked { get; set; }

        public int RoomtypeId { get; set; }
        //Navigational Properties
       




    }
}
