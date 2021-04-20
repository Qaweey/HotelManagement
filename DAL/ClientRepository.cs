using HotelManagementAPI.DataModel;
using HotelManagementAPI.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repositories
{
    
    public class ClientRepository : IClientRepository
    {
        private readonly HotelDBContext _hotelDBContext;

        public ClientRepository(HotelDBContext hotelDBContext)
        {
            this._hotelDBContext = hotelDBContext;
        }
        public Task<bool> BookARoom(CustomerDto customer)
        {
           
        }
    }
}
