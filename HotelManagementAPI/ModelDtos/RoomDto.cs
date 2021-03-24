using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.ModelDtos
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string  CustomerName { get; set; }
        public bool IsBooked { get; set; }
        public decimal AmountToPay()
        {
            return (RoomTypeAmount * NumberOfDays);
        }
        public decimal  RoomTypeAmount { get; set; }
        


        public int NumberOfDays { get; set; }

    }
}
