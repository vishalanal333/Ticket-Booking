using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Data
{
    public class TrainRoute
    {
        [Key]
        public int Id { get; set; }
        public int TrainId { get; set; }
        public string StationName { get; set; }
        public int Distance { get; set; }
        public int Price { get; set; }
    }
}
