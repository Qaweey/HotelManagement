﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.DataModel
{
    public class Room
    {
        public int RoomId { get; set; }
        public string  RoomNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int RoomtypeId { get; set; }
        //Navigational Properties
        public Roomtype Rometype { get; set; }

    }
}
