using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SoftUniAirlines.Data;
using SoftUniAirlines.Models;

namespace SoftUniAirlines.Controllers
{
    public class FlightsController : Controller
    {
        private readonly FlightDbContext context;

        public FlightsController(FlightDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<Flight> flight =
                this.context.Flights
                .ToList();

            return View(flight);
        }

        [HttpGet]
        [Route("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(Flight flight)
        {
            this.context.Flights.Add(flight);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/edit/{id}")]
        public IActionResult Edit(int id)
        {
            Flight flight = this.context.Flights
                .Find(id);

            return View(flight);
        }

        [HttpPost]
        [Route("/edit/{id}")]
        public IActionResult Edit(Flight flight)
        {
            this.context.Flights.Update(flight);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            Flight flight = this.context.Flights
                .Find(id);

            return View(flight);
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public IActionResult Delete(Flight flight)
        {
            this.context.Flights.Remove(flight);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
