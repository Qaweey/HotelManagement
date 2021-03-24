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
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDBContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(HotelDBContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public IEnumerable<RoomDto> ListOfRoomsbooked()
        {
            try
            {
                return this.ListOfRooms().Where(s => s.IsBooked == true).ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error occured");
            }
        }

        public    IEnumerable<RoomDto> ListOfRooms()
        {
            var listOfRooms = _context.Rooms;
            var listOfRoomDto = new List<RoomDto>();
            foreach (var item in listOfRooms )
            {
                var roomdto = new RoomDto
                {

                    RoomNumber = item.RoomNumber,


                };
                listOfRoomDto.Add(roomdto);

            }
            return  listOfRoomDto;
        }

        public async  Task<int> TotalRoomsCount()
        {
            
            try
            {
                return await _context.Rooms.CountAsync();
            }
            catch (Exception)
            {

                throw new Exception("Error occured");
            }
        }

        public  IEnumerable<RoomDto>ListOfUbookedRoom()
        {
            try
            {

                return  this.ListOfRooms().Where(s => s.IsBooked == false).ToList();
            }
            catch (Exception)
            {

                throw new Exception("error occured");
            }
        }

        public async  Task<RoomDto> GetRoomsByCustomer(int id)
        {
            var getRoomByCustomer =  await _context.Rooms.Include(s => s.Rometype).Include(s => s.Customer).Where(s => s.RoomId == id).FirstOrDefaultAsync();
            var cusDto = new RoomDto
            {
                CustomerName = getRoomByCustomer.Customer.CustomerName,
                RoomNumber = getRoomByCustomer.RoomNumber,
                NumberOfDays = getRoomByCustomer.Customer.NumberOfdaysToBook,
                RoomTypeAmount = getRoomByCustomer.Rometype.Amount


            };
            return cusDto;
            
        }
    }
}
