using CaKoi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaKoi.Controllers
{
    public class FishTankController : Controller
    {
		public readonly ChamsoccakoiContext _dbContext;
		public FishTankController(ChamsoccakoiContext dbContext) {
			_dbContext = dbContext;
		}
        public IActionResult Index()
        {
            var results = _dbContext.FishTanks.ToList();
            ViewData["FishTankList"] = results;
            return View();
        }
    }
}
