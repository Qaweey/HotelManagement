using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repository
{
    public interface IRoomtypeRepository
    {
        Task<RoomTypeDto> AddRoometup(RoomTypeDto model);
    }
}
