using Microsoft.AspNetCore.Mvc;
using lab1.imagereviewer.model;
using lab1.imagereviewer.service;

namespace lab1.imagereviewer.controller
{
    public class ImageReviewerController : Controller
    {
        private ImageReviewerService service;

        public ImageReviewerController(ImageReviewerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult ImageReviewer()
        {
            return View("../ImageReviewer/ImageReviewer");
        }

        [HttpPost]
        public IActionResult ImageReviewer(ImageReviewer ImageReviewer)
        {
            ViewData["Result"] = service.getImageAsStringByPath(ImageReviewer.pathToImage);

            return View(ImageReviewer);
        }
    }
}
