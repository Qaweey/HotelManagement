using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.DTOS.ResponseDtos
{
    public class Response
    {
        public string  Success { get; set; }
        public string Token   { get; set; }
        public string Message { get; set; }
    }
}
