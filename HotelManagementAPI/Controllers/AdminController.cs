using HotelManagementAPI.ModelDtos;
using HotelManagementAPI.Repository;
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
        private readonly IRoomtypeRepository roomtypeRepository;

        public AdminController( IRoomRepository roomRepository,IRoomtypeRepository roomtypeRepository)
        {
            this._roomRepository = roomRepository;
            this.roomtypeRepository = roomtypeRepository;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<ActionResult<int >> TotalRoomCount()
        {
            try
            {
                var count = await _roomRepository.TotalRoomsCount();
                return Ok(count);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> BookedRooms()
        {
            try
            {
                var bookedroom = _roomRepository.ListOfRoomsbooked();
                return Ok(bookedroom);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> UnBookedRooms()
        {
            try
            {
                var unbookedroom = _roomRepository.ListOfUbookedRoom();
                return Ok(unbookedroom);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //The customer that booked and amount payed
        [HttpGet]
        public async Task<ActionResult<RoomDto>> GetRoomsByCustomer(int id)
        {
            try
            {
                var get = await _roomRepository.GetRoomsByCustomer(id);
                if (get is not null)
                {
                    return Ok(get);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult <RoomTypeDto> AddRoomSetUp(RoomTypeDto model)
        {
            try
            {
                var addedroomtype = roomtypeRepository.AddRoometup(model);
                return Ok(addedroomtype);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }



    }
}
