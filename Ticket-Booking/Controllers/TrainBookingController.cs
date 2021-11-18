using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking.Models;
using Ticket_Booking.Repository;

namespace Ticket_Booking.Controllers
{
    public class TrainBookingController : Controller
    {
        private readonly TrainBookingRepository _trainBookingRepository = null;

        public TrainBookingController(TrainBookingRepository trainBookingRepository)
        {
            _trainBookingRepository = trainBookingRepository;
        }
        [HttpPost]
        public IActionResult AddNewTrain(TrainModel trainModel)
        {
            if (ModelState.IsValid)
            {
              _trainBookingRepository.AddNewTrain(trainModel);

            }
            return RedirectToAction("SearchTrains", "TrainBooking");
        }
        public ViewResult SearchTrains()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchTrains(string trainName)
        {
            if(string.IsNullOrEmpty(trainName))
            {
                return GetAllTrains();
            }

            return Json(_trainBookingRepository.SearchTrains(trainName));
           
        }
        [HttpGet]
        public IActionResult GetAllTrains()
        {
            return Json(_trainBookingRepository.GetAllTrains());

        }


        public ViewResult AddRoute(int id)
        {
            var model = new TrainRouteModel() { TrainId = id };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddRoute(TrainRouteModel route)
        {
            if (ModelState.IsValid)
            {
                _trainBookingRepository.AddRoute(route);
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult GetAllRoutes(TrainRouteModel route)
        {
            return Json(_trainBookingRepository.GetAllRoute(route.TrainId));
        }
        public IActionResult DeleteRoute(TrainRouteModel route)
        {
            _trainBookingRepository.DeleteRoute(route.Id);
            return Json(_trainBookingRepository.GetAllRoute(route.TrainId));
        }
        
        public IActionResult GetRouteById(int id)
        {
            return Json(_trainBookingRepository.GetRouteById(id));
        }
        public IActionResult UpdateRoute(TrainRouteModel model)
        {
            _trainBookingRepository.UpdateRoute(model);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllStations()
        {
            return Json(_trainBookingRepository.GetAllStation());
        }

        [HttpPost]
        public IActionResult SearchTrainByStation(TrainSearchModel model)
        {
            return Json(_trainBookingRepository.GetAvailableTrains(model));
        }
        [HttpPost]
        public IActionResult BookingTrain(BookingModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _trainBookingRepository.AddNewBoooking(model);
                return Json(_trainBookingRepository.GetBoookingById(id));
            }

            return Ok();
        }
        public ViewResult GetAllTrainBookings()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAllTrainBookings(BookingModel model)
        {
            return Json(_trainBookingRepository.GetAllTrainBookings(model));
        }


    }
}
