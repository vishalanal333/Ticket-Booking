using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Models
{
    public class TrainBookingModel
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public int AvailableSeats { get; set; }
        public int TotalSeats { get; set; }
        public int Price { get; set; }
    }
}
