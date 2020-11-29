using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using lab1.calculator.service;
using lab1.calculatoroflifetime.model;
using lab1.Models;

namespace lab1.simplecalculator.controller
{
    public class CalculatorController : Controller
    {
        private CalculatorService calculatorService;

        public CalculatorController(CalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("../Calculator/Index");
        }

        [HttpPost]
        public IActionResult Index(Calculator calculator)
        {
            ViewData["Result"] = calculatorService.getLivedDateTime(calculator);

            return View(calculator);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
