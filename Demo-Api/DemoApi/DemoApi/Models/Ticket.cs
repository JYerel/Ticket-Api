using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoApi.Models
{
    public class TicketModel
    {
        public TicketInfoModel TicketInfo { get; set; }

        [Range(1, 100, ErrorMessage = "Ticket ID does not exist in the list")]
        public int Id { get; set; }

        public string EventType { get; set; }

        public string EventName { get; set; }
    }

    public class TicketInfoModel
    {
        public int SessionId { get; set; }

        public string TimeAvailable { get; set; }

        public double Cost { get; set; }


    }
}