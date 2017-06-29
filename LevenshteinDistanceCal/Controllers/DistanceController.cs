using Microsoft.AspNetCore.Mvc;
using LevenshteinDistanceCal.Models;
using LevenshteinDistanceCal.Factories;
using Microsoft.AspNetCore.Authorization;

namespace LevenshteinDistanceCal.Controllers
{
    [Authorize]
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
                    int result = MathsFactory.Compute(model.Target, model.Source);
                    ViewBag.Distance = $"Distance: { result }";
            }

            return View("Index");
        }
    }
}