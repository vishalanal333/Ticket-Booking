using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Models
{
    public class TrainModel
    {
        [Required]
        public int TrainId { get; set; }
        [Required]
        public string TrainName { get; set; }
        [Required]
        public int Seats { get; set; }
    }
}
