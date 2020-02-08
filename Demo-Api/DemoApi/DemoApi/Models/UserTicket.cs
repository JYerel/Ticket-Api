using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApi.Models
{
    public class UserTicketModel
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string State { get; set; }

        public UserTicketModel()
        {
            Id = 1;
            SessionId = 1;
            UserId = 100;
            UserName = "Jose Q";
            State = "BOOKED";
        }
    }
}