using AutoMapper;
using Contracts;
using HotelManagementAPI.DataModel;
using HotelManagementAPI.DTOS.ResponseDtos;
using HotelManagementAPI.ModelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public AdminController(IRoomRepository roomRepository ,IMapper mapper)
        {
            this._roomRepository = roomRepository;
            this._mapper = mapper;
        }
        // GET: api/<RoomController>
        [HttpGet("BookedRooms")]
        public async  Task<ActionResult<IEnumerable<RoomDto>>> GetBookedRooms()
        {
            var listOfBookedRoom =  await _roomRepository.GetAllBookedRooms();
            var me = _mapper.Map<IEnumerable<RoomDto>>(listOfBookedRoom);

            return Ok(me);
        }
        [HttpGet("UnbookedRooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetUnbookedRoom()
        {
            try
            {
                var listOfBookedRoom = await _roomRepository.GetAllUnbookedRooms();
                var rooms = _mapper.Map<IEnumerable<RoomDto>>(listOfBookedRoom);

                return Ok(rooms);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                 
            }
        }
        [HttpGet("CheckedRooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetCheckedRooms()
        {
            try
            {
                var listOfBookedRoom = await _roomRepository.GetAllCheckedInRooms();
                var listOfRoom = _mapper.Map<IEnumerable<RoomDto>>(listOfBookedRoom);

                return Ok(listOfRoom);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("UncheckedRooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetUncheckedRooms()
        {
            try
            {
                var listOfBookedRoom = await _roomRepository.GetAllUncheckedInRooms();
                var listOfRoom = _mapper.Map<IEnumerable<RoomDto>>(listOfBookedRoom);

                return Ok(listOfRoom);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<RoomController>/5
        [HttpGet("TheTotalNumberOfRooms")]
        public async  Task<ActionResult<int> > TheTotalNumberOfRooms()
        {
            try
            {
                var numberOfRoom=await _roomRepository.TotalNumberOfRooms();
                return Ok(numberOfRoom);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<RoomController>
        [HttpGet("TotalNumberOfRevenue")]
        public ActionResult<decimal> TheTotalNumberOfRevenue()
        {
            try
            {
                var numberOfRoom = _roomRepository.RevenueGeneratedPerDay();
                return Ok(numberOfRoom);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // PUT api/<RoomController>/5
        [HttpPost("CreateRooms")]
        public  async Task<ActionResult> CreateRoom( [FromBody] RoomDto model)
        {
            try
            {
                var createRoom = _mapper.Map<Room>(model);
                await _roomRepository.Add(createRoom);
                return Ok(new Response { Success = "false", Message = "The operation was successful" });
            }
            catch (Exception)
            {

                return BadRequest(new Response { Success = "false", Message = "The operation was not  successful" });
            }
        }


        // DELETE api/<RoomController>/5
        [HttpDelete("DeleteRooms")]
        public ActionResult Delete(int id)
        {
            try
            {
                _roomRepository.Delete(id);
                return Ok(new Response { Success = "false", Message = "The operation was successful" });

            }
            catch (Exception)
            {
                return BadRequest(new Response { Success = "false", Message = "The operation was not  successful" });

            }
        }
    }
}
