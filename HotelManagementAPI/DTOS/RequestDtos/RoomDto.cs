using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.ModelDtos
{
    public class RoomDto
    {
       
        
       
        public bool IsBooked { get; set; }
        public decimal TotalAmountToPay()
        {
            return (CostOfRoom * NumberOfDays);
        }
        public decimal  CostOfRoom { get; set; }
        


        public int NumberOfDays { get; set; }

    }
}
