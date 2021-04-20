using HotelManagementAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
  public   interface IRoomRepository
    {
        
        Task<IEnumerable<Room>> GetAllBookedRooms();
        Task<IEnumerable<Room>> GetAllUnbookedRooms();
        Task<IEnumerable<Room>> GetAllCheckedInRooms();
        Task<IEnumerable<Room>> GetAllUncheckedInRooms();

        Task<bool> Add(Room model);
        bool Update(Room model);
         bool Delete(int id);
        bool UpdateRange(List<Room> rooms);
        Task<int> TotalNumberOfRooms();
        decimal RevenueGeneratedPerDay();  



    }
}
