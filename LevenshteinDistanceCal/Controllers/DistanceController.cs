using Microsoft.AspNetCore.Mvc;
using LevenshteinDistanceCal.Models;
using LevenshteinDistanceCal.Factories;
using Microsoft.AspNetCore.Authorization;

namespace LevenshteinDistanceCal.Controllers
{

    public class DistanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Produces("application/json")]
        [Route("api/Distance")]

        // POST: api/Maths/CalculateLevenshteinDistance
        [HttpPost("[action]")]
        public IActionResult CalculateLevenshteinDistance([FromForm] LevenshteinDistanceModel model)
        {
            if (ModelState.IsValid)
            {
                    float result = MathsFactory.Similarity(model.Target.ToLower(), model.Source.ToLower());
                    ViewBag.Distance = $"Similarity (%): { result }";
            }

            return View("Index");
        }
    }
}