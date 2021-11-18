using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Data
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public int Seats { get; set; }
    }
}
