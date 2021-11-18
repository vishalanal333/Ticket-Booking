using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Models
{
    public class TrainRouteModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TrainId { get; set; }
        [Required]
        public string StationName { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
