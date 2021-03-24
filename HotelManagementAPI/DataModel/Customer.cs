using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.DataModel
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string  Email { get; set; }
        public int NumberOfdaysToBook { get; set; }
        public List<Room> ListOfRoom { get; set; } = new();

    }
}
