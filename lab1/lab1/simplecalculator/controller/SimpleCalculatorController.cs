using Microsoft.AspNetCore.Mvc;
using lab1.simplecalculator.model;
using lab1.simplecalculator.service;

namespace lab1.calculatoroflifetime.controller
{
    public class SimpleCalculatorController : Controller
    {
        private SimpleCalculatorService simpleCalculatorService;

        public SimpleCalculatorController(SimpleCalculatorService simpleCalculatorService)
        {
            this.simpleCalculatorService = simpleCalculatorService;
        }

        [HttpGet]
        public IActionResult SimpleCalculator()
        {
            return View("../SimpleCalculator/SimpleCalculator");
        }

        [HttpPost]
        public IActionResult SimpleCalculator(SimpleCalculator simpleCalculator)
        {
            ViewData["Result"] = simpleCalculatorService.calculate(simpleCalculator.content);

            return View(simpleCalculator);
        }
    }
}