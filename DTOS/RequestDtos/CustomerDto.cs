using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.ModelDtos
{
    public class CustomerDto
    {
        public string CustomerName { get; set; }
        public DateTime DateOfBooking { get; set; } = DateTime.UtcNow;

        public int NumberOfdaysToBook { get; set; }
        public List<RoomDto> listOfRooms { get; set; } = new ();




       




    }
}
