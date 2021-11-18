using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Models
{
    public class BookingModel
    {
        public int TicketId { get; set; }
        public int TrainId { get; set; }
        [Required]
        public string TravellerName { get; set; }
        [Required]
        public int TravellerAge { get; set; }
        public string SourceStation { get; set; }
        public string DestinationStation { get; set; }
        public int Price { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
