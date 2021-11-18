using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking.Data;
using Ticket_Booking.Models;

namespace Ticket_Booking.Repository
{
    public class TrainBookingRepository
    {
        private readonly TrainBookingContext _context;

        public TrainBookingRepository(TrainBookingContext context)
        {
            _context = context;
        }

        public int AddNewTrain(TrainModel model)
        {
            var newTrain = new Train()
            {
                TrainName = model.TrainName,
                Seats = model.Seats
            };
            _context.Train.Add(newTrain);
            _context.SaveChanges();
            return newTrain.TrainId;
        }
        public int AddNewBoooking(BookingModel model)
        {
            var newbooking = new Bookings()
            {
                TrainId = model.TrainId,
                TravellerName = model.TravellerName,
                TravellerAge = model.TravellerAge,
                SourceStation = model.SourceStation,
                DestinationStation = model.DestinationStation,
                Price = model.Price,
                BookingDate = DateTime.Now
            };
            _context.Bookings.Add(newbooking);
            _context.SaveChanges();
            return newbooking.TicketId;
        }
        public BookingModel GetBoookingById(int id)
        {
            var booking = _context.Bookings.Find(id);
            return new BookingModel()
            {
                SourceStation = booking.SourceStation,
                DestinationStation = booking.DestinationStation,
                BookingDate = booking.BookingDate,
                Price = booking.Price,
                TrainId = booking.TrainId,
                TicketId = booking.TicketId,
                TravellerName = booking.TravellerName,
                TravellerAge = booking.TravellerAge,
            };
        }
        public List<TrainModel> GetAllTrains()
        {
            var trains = new List<TrainModel>();
            var alltrain = _context.Train.ToList();
            if (alltrain?.Any() == true)
            {
                foreach (var train in alltrain)
                {
                    trains.Add(new TrainModel()
                    {
                        TrainId = train.TrainId,
                        TrainName = train.TrainName,
                        Seats = train.Seats
                    });
                }
            }
            return trains;
        }
        public List<TrainModel> SearchTrains(string title)
        {
            var trains = new List<TrainModel>();
            var searchedtrain = _context.Train.Where(x => x.TrainName.Contains(title)).ToList();
            if (searchedtrain?.Any() == true)
            {
                foreach (var train in searchedtrain)
                {
                    trains.Add(new TrainModel()
                    {
                        TrainId = train.TrainId,
                        TrainName = train.TrainName,
                        Seats = train.Seats
                    });
                }
            }
            return trains;
        }
        public int AddRoute(TrainRouteModel model)
        {
            var newRoute = new TrainRoute()
            {
                TrainId = model.TrainId,
                StationName = model.StationName,
                Distance = model.Distance,
                Price = model.Price
            };
            _context.TrainRoute.Add(newRoute);
            _context.SaveChanges();
            return newRoute.Id;
        }
        public List<TrainRouteModel> GetAllRoute(int trainId)
        {
            var routes = new List<TrainRouteModel>();
            var allroutes = _context.TrainRoute.Where(x => x.TrainId == trainId).ToList();
            if(allroutes?.Any() == true)
            {
                foreach(var route in allroutes)
                {
                    routes.Add(new TrainRouteModel()
                    {
                        Id = route.Id,
                        StationName = route.StationName,
                        Distance = route.Distance,
                        TrainId =  route.TrainId,
                        Price = route.Price
                    });
                }
            }
            return routes;
        }
        public bool DeleteRoute(int id)
        {
            var delete = _context.TrainRoute.Find(id);
            _context.TrainRoute.Remove(delete);
            _context.SaveChanges();
            return true;

        }
        public List<StationModel> GetAllStation()
        {
            var stations = new List<StationModel>();
            var allStations = _context.Stations.ToList();
            if (allStations?.Any() == true)
            {
                foreach (var station in allStations)
                {
                    stations.Add(new StationModel()
                    {
                        StationName = station.StationName,
                        StationCode = station.StationCode
                    });
                }
            }
            return stations;
        }
        public List<BookingModel> GetAllTrainBookings(BookingModel model)
        {
            var bookings = new List<BookingModel>();
            var allBookings = _context.Bookings.Where(x => x.TrainId == model.TrainId && x.BookingDate.Date == model.BookingDate.Date).ToList();
            if (allBookings?.Any() == true)
            {
                foreach (var booking in allBookings)
                {
                    bookings.Add(new BookingModel()
                    {
                        TicketId = booking.TicketId,
                        TrainId = booking.TrainId,
                        TravellerName = booking.TravellerName,
                        TravellerAge = booking.TravellerAge,
                        SourceStation = booking.SourceStation,
                        DestinationStation = booking.DestinationStation,
                        Price = booking.Price,
                        BookingDate = booking.BookingDate
                    });
                }
            }
            return bookings;
        }
        public int CountAvailableSeats(int trainId , DateTime bookingDate)
        {
            var count = _context.Bookings.Where(x => x.TrainId == trainId && x.BookingDate.Date == bookingDate.Date).Count();
            return count;
        }
        public List<TrainBookingModel> GetAvailableTrains (TrainSearchModel model)
        {
            var trains = new List<TrainBookingModel>();
            List<int> allTrains = _context.TrainRoute.Where(x => x.StationName == model.StartingPoint || x.StationName == model.EndingPoint).Select(x => x.TrainId).Distinct().ToList();

            foreach (var trainId in allTrains)
            {
                var routes = _context.TrainRoute.Where(x => x.TrainId == trainId).ToList();

                var startingStation = routes.FirstOrDefault(x => x.StationName == model.StartingPoint);
                var endingStation = routes.FirstOrDefault(x => x.StationName == model.EndingPoint);
                
                if(startingStation != null && endingStation != null && startingStation.Id < endingStation.Id)
                {
                    var totalPrice = endingStation.Price - startingStation.Price;
                    var train = _context.Train.Find(trainId);
                    trains.Add(new TrainBookingModel()
                    {
                        TrainId = train.TrainId,
                        TrainName = train.TrainName,
                        TotalSeats = train.Seats,
                        AvailableSeats = train.Seats-CountAvailableSeats(train.TrainId,DateTime.Now),
                        Price = totalPrice

                    });
                }
            }
            return trains;
        }
        public TrainRouteModel GetRouteById(int id)
        {
            return _context.TrainRoute.Where(x => x.Id == id).Select(route => new TrainRouteModel()
            {
                Id = route.Id,
                TrainId = route.TrainId,
                StationName = route.StationName,
                Distance = route.Distance,
                Price = route.Price
            }).FirstOrDefault();

        }
        public bool UpdateRoute(TrainRouteModel model)
        {
            var id = model.Id;
            var route = _context.TrainRoute.Find(id);
            route.TrainId = model.TrainId;
            route.StationName = model.StationName;
            route.Distance = model.Distance;
            route.Price = model.Price;
            _context.TrainRoute.Update(route);
            _context.SaveChanges();
            return true;
        }
    }
}
