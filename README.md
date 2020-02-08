# Ticket-Api
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
