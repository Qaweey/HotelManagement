using AutoMapper;
using HotelManagementAPI.DataModel;
using HotelManagementAPI.ModelDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly HotelDBContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(HotelDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public  async Task<CustomerDto> RegisterCustomer(CustomerDto model)
        {
            try
            {
                var registeredCustomers = _mapper.Map<Customer>(model);
                var regCus = await _context.Customers.AddAsync(registeredCustomers);
                await _context.SaveChangesAsync();
                var registeredEntity = regCus.Entity;
                //EmailSercvices



                return _mapper.Map<CustomerDto>(registeredEntity);
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

      
    }
}
