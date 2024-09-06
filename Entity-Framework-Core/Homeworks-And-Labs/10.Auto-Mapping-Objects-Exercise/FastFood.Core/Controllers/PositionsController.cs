namespace FastFood.Web.Controllers
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using FastFood.Services.Data;
    using FastFood.Web.ViewModels.Positions;
    using Microsoft.AspNetCore.Mvc;

    public class PositionsController : Controller
    {
        private readonly IPositionsService positionService;

        public PositionsController(IPositionsService positionService)
        {
            this.positionService = positionService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await this.positionService.CreateAsync(model);

            return RedirectToAction("All", "Positions");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<PositionsAllViewModel> positions =
                await this.positionService.GetAllAsync();

            return View(positions.ToList());
        }
    }
}
