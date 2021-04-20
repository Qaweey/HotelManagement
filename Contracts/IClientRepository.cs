﻿using HotelManagementAPI.DataModel;
using HotelManagementAPI.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repositories
{
   public  interface IClientRepository
    {
        Task<bool> CustomerInformationThatBookRoom(Customer customer);
    }
}
