using Contracts;
using HotelManagementAPI.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class RoomRepository : IRoomRepository
    {
        private readonly HotelDBContext _context;

        public RoomRepository(HotelDBContext context)
        {
            this._context = context;
        }
        public async Task<bool> Add(Room model)
        {
            try
            {
               await _context.Rooms.AddAsync (model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var roomToDelete= _context.Rooms.FirstOrDefault(s => s.RoomId == id);
                if (roomToDelete is not null)
                {
                    _context.Rooms.Remove(roomToDelete);
                    _context.SaveChanges();
                    return true;

                }
                return false;
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<IEnumerable<Room>> GetAllBookedRooms()
        {
            try
            {
                return await _context.Rooms.Where(s => s.IsBooked == true).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<IEnumerable<Room>> GetAllCheckedInRooms()
        {
            return await _context.Rooms.Where(s => s.IsBooked==true && s.IsCheckedIn==true).ToListAsync();
        }

        public  async Task<IEnumerable<Room>> GetAllUnbookedRooms()
        {
            return await _context.Rooms.Where(s => s.IsBooked == false).ToListAsync();
        }

        public  async Task<IEnumerable<Room>> GetAllUncheckedInRooms()
        {
            return await _context.Rooms.Where(s => s.IsBooked == false && s.IsCheckedIn == false).ToListAsync();
        }

        public decimal RevenueGeneratedPerDay()
        {
            return _context.Rooms.
                Where(s => s.IsBooked == true && s.IsCheckedIn == true).
                Select(s=>s.CostOfRoom)
                .Sum();
        }

        public async  Task<int> TotalNumberOfRooms()
        {
            try
            {
                return await _context.Rooms.CountAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Room model)
        {
            try
            {
                var findRoom = _context.Rooms.Find(model.RoomId);
                if (findRoom is not null)
                {
                    _context.Rooms.Update(model);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateRange(List<Room> rooms)
        {
            try
            {
                
                _context.Rooms.UpdateRange(rooms);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
