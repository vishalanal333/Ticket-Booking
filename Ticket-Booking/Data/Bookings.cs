using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Data
{
    public class Bookings
    {
        [Key]
        public int TicketId { get; set; }
        public int TrainId { get; set; }
        public string TravellerName { get; set; }
        public int TravellerAge { get; set; }
        public string SourceStation { get; set; }
        public DateTime BookingDate { get; set; }
        public string DestinationStation { get; set; }
        public int Price { get; set; }
    }
}
