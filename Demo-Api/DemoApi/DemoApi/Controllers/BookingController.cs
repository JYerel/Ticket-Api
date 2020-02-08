using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoApi.Models;

/*
My concept for this exercise was to create two entities (one for the Event ticket information and two for the user ticket order)
In my Model:
TicketModel will hold the main ticket information (what the user sees), And TicketInfoModel will hold the tickets individual information (when the user select to book the time slot)
Both containing their own unique ID. E.g. Ticket can have many TicketSession
UserTicketModel will hold users tickets information when booked. Containing the Ticket Id, and Session Id to cross reference with TicketModel.

Lastly, BookingController allows you to:
// GET: api/Booking
Get All tickets available
// GET: api/Booking/5
Get The Ticket Information 
// GET: api/Booking/5/1
Get the Ticket Session Information
// POST: api/Booking
Book the ticket passing the ticket Id and sessionId
// PUT: api/Booking/5
Update the user ticket to a different session passing the sessionId and UserTicketModel
// DELETE: api/Booking/DeleteUserTicket/1/1
And Delete Users Ticket passing the Id and SessionId, assuming we Already know the current UserTicket.
*/
namespace DemoApi.Controllers
{
    public class BookingController : ApiController
    {

        List<TicketModel> ticket = new List<TicketModel>();

        List<UserTicketModel> userTicketList = new List<UserTicketModel>();


        // GET: api/Booking
        public List<TicketModel> Get()
        {
            // Get all tickets available for booking
            return ticket;
        }

        // GET: api/Booking/5
        [Route("api/Booking/{Id:int}")]
        [HttpGet]
        public TicketModel Get(int id)
        {
            // Returns all available ticket sessions
            return ticket.Where(ticket => ticket.Id == id).FirstOrDefault();
        }

        // GET: api/Booking/5/1
        [Route("api/Booking/GetTicketInfo/{Id:int}/{SessionId:int}")]
        [HttpGet]
        public TicketModel Get(int id, int sessionId)
        {
            // Returns corresponding ticket session associated (e.g. time slot)
            return ticket.Where(ticket => ticket.Id == id && ticket.TicketInfo.SessionId == sessionId).FirstOrDefault();
        }

        // POST: api/Booking
        public UserTicketModel Post(UserTicketModel userTicketOrder)
        {
            // Book Ticket
            userTicketList.Add(userTicketOrder);
            return userTicketOrder;
        }

        // DELETE: api/Booking/DeleteUserTicket/1/1
        [Route("api/Booking/DeleteUserTicket/{Id:int}/{SessionId:int}")]
        [HttpDelete]
        public void Delete(int id, int sessionId)
        {
            // Cancel Ticket
            UserTicketModel userTicketTemplate = new UserTicketModel();
            userTicketList.Add(userTicketTemplate); // Add to list for deletion
            
            foreach (var itemsBooked in userTicketList)
            {
                if (itemsBooked.Id == id && itemsBooked.SessionId == sessionId)
                   userTicketList.Remove(itemsBooked);
            }
        }

        // PUT: api/Booking/5
        public UserTicketModel Put(int sessionid, UserTicketModel userTicketOrder)
        {
            // Change User Ticket Information
            // To Different Slot
            List<TicketModel> ticketList = new List<TicketModel>(); // Get the lists

            // Find the ticket session, if found then eligible to change session time.
            foreach (var ticket in ticketList)
            {
                if (ticket.TicketInfo.SessionId == sessionid && userTicketOrder.Id == ticket.Id)
                    userTicketOrder.SessionId = sessionid;
            }
            return userTicketOrder;
        }

        // --- Demo Data
        public BookingController()
        {
            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "11:00-12:00",
                    Cost = 80.00
                },
                Id = 1,
                EventType = "Concert",
                EventName = "Creamfields 2020"
            });

            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "09:00-10:00",
                    Cost = 50.00
                },
                Id = 2,
                EventType = "Concert",
                EventName = "Parklife 2020"
            });

            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "10:00-12:00",
                    Cost = 90.00
                },
                Id = 3,
                EventType = "Concert",
                EventName = "Cirque du Soleil"
            });

            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "13:00-14:00",
                    Cost = 100.00
                },
                Id = 4,
                EventType = "Theatre",
                EventName = "A Taste Of Honey"
            });

            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "16:00-19:00",
                    Cost = 80.00
                },
                Id = 5,
                EventType = "Theatre",
                EventName = "Only Fools and Horses"
            });

            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "10:00-12:00",
                    Cost = 70.00
                },
                Id = 6,
                EventType = "Theatre",
                EventName = "Thriller Live"
            });

            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "09:00-12:00",
                    Cost = 80.50
                },
                Id = 7,
                EventType = "Family",
                EventName = "The Art of the Brick"
            });
            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "09:00-10:00",
                    Cost = 40.00
                },
                Id = 8,
                EventType = "Family",
                EventName = "Body Worlds"
            });
            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "11:00-12:00",
                    Cost = 80.00
                },
                Id = 9,
                EventType = "Family",
                EventName = "Grand Designs Live 2020"
            });

            ticket.Add(new TicketModel
            {
                TicketInfo = new TicketInfoModel()
                {
                    SessionId = 1,
                    TimeAvailable = "18:00-13:00",
                    Cost = 100.00
                },
                Id = 10,
                EventType = "Music",
                EventName = "Catch a Groove"
            });
        }      
    }
}
