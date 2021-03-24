using HotelManagementAPI.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> RegisterCustomer(CustomerDto model);
        

    }
}
