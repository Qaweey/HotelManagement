using AutoMapper;
using HotelManagementAPI.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repository
{
    public class RoomtypeRepository : IRoomtypeRepository
    {
        private readonly HotelDBContext _context;
        private readonly IMapper _mapper;

        public RoomtypeRepository(HotelDBContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        // To add a room setup
        public async  Task<RoomTypeDto> AddRoometup(RoomTypeDto model)
        {
            try
            {
                var roomadded = _mapper.Map<Roomtype>(model);
                var regroom = await _context.Roomtypes.AddAsync(roomadded);
                await _context.SaveChangesAsync();
                var registeredEntity = regroom.Entity;
                



                return _mapper.Map<RoomTypeDto>(registeredEntity);
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }
    }
}
