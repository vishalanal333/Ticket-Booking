using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Data
{
    public class TrainBookingContext : DbContext
    {
        public TrainBookingContext(DbContextOptions<TrainBookingContext> options) : base(options)
        {

        }
        public DbSet<Train> Train { get; set; }
        public DbSet<TrainRoute> TrainRoute { get; set; }
        public DbSet<Stations> Stations { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
    }
}
