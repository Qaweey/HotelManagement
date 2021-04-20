using AutoMapper;
using HotelManagementAPI.DataModel;
using HotelManagementAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.ModelDtos
{
    public class MapDto:Profile
    {
        public MapDto()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Roomtype, RoomTypeDto>().ReverseMap();
        }
    }
}
