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
        public async  Task<bool> CustomerInformationThatBookRoom(Customer customer)
        {
            try
            {
               await  _hotelDBContext.Customers.AddAsync(customer);
                await _hotelDBContext.SaveChangesAsync();
                return true;
            
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
