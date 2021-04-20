using HotelManagementAPI.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Repositories
{
   public  interface IEmailSender
    {
        Task sendEmail(string email);
    }
}
