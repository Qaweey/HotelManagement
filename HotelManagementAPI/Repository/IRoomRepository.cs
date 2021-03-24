using HotelManagementAPI.DataModel;
using HotelManagementAPI.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repository
{
    public interface IRoomRepository
    {
        //Room count 
        Task<int> TotalRoomsCount();

       IEnumerable<RoomDto>ListOfRooms();
        IEnumerable<RoomDto> ListOfRoomsbooked();
       IEnumerable<RoomDto> ListOfUbookedRoom();
        Task<RoomDto> GetRoomsByCustomer(int id);



    }
}
