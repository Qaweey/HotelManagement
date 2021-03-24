using HotelManagementAPI.ModelDtos;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterCustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly LinkGenerator linkGenerator;

        public RegisterCustomerController(ICustomerRepository customerRepository, LinkGenerator linkGenerator)
        {
            this.customerRepository = customerRepository;
            this.linkGenerator = linkGenerator;
        }
        // GET: api/<RegisterCustomerController>

        [HttpPost]
        public async  Task<ActionResult< CustomerDto>> Register(CustomerDto model)
        {
            try
            {
                var reg =  await customerRepository.RegisterCustomer(model);
                return Ok(reg);
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status202Accepted);
            }
            

            
        }

        // POST api/<RegisterCustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RegisterCustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterCustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
