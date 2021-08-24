using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieCreateRequestModel model)
        {
            var movie = await _adminService.CreateMovie(model);
            return Ok(movie);
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieCreateRequestModel model)
        {
            var movie = await _adminService.UpdateMovie(model);
            if(movie == null)
            {
                return BadRequest($"No Movie Found For Id = {model.Id}");
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetAllPurchases()
        {
            var purchases = await _adminService.GetAllPurchases();
            if(purchases == null)
            {
                return NotFound("No Purchase Found");
            }
            return Ok(purchases);
        }

    }
}
