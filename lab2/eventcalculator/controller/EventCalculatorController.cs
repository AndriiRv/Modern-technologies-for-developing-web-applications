using Microsoft.AspNetCore.Mvc;
using lab2.eventcalculator.model;
using lab2.eventcalculator.service;

namespace lab2.eventcalculator.controller
{
    public class EventCalculatorController : Controller
    {
        private EventCalculatorService eventCalculatorService;

        public EventCalculatorController(EventCalculatorService eventCalculatorService)
        {
            this.eventCalculatorService = eventCalculatorService;
        }

        [HttpGet]
        public IActionResult EventCalculator()
        {
            return View("../EventCalculator/EventCalculator");
        }

        [HttpPost]
        public IActionResult EventCalculator(EventCalculator eventCalculator)
        {
            ViewData["Result"] = eventCalculatorService.getCalculationDate(eventCalculator.pathToFile);

            ViewData["CurrentDate"] = eventCalculatorService.getCurrentDateTime();

            return View(eventCalculator);
        }
    }
}