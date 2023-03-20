using FoodieApi.Model;
using FoodieApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieBookingController : ControllerBase
    {
        private readonly MovieBookingServices _MovieBookingServices;
        public MovieBookingController(MovieBookingServices mbServices)
        {
            this._MovieBookingServices = mbServices;
        }

        [HttpGet]
        public async Task<List<MovieTicket>> Get()
        {
           return await _MovieBookingServices.GetMovieTickets();
        }

        [HttpGet("GetById")]        
        public async Task<ActionResult<MovieTicket>> GetbyId(string id)
        {
            var food = await _MovieBookingServices.GetById(id);
            if (food is null)
                return NotFound();

            return food;
        }

        [HttpPost]
        public async Task<OkObjectResult> Insert(MovieTicket movieTickets)
        {
            await _MovieBookingServices.InsertMovieTicket(movieTickets);
            return Ok(movieTickets);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id,MovieTicket mbTickets)
        {
            var existingitem = await _MovieBookingServices.GetById(id);
            
            if (existingitem is null)
            {
                return NotFound();
            }
            mbTickets.Id = existingitem.Id;
            await _MovieBookingServices.UpdatemovieTicketDetails(id, mbTickets);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var existingitem = await _MovieBookingServices.GetById(id);

            if (existingitem is null)
            {
                return NotFound();
            }
            await _MovieBookingServices.DeleteMovieDetails(id);
            return NoContent();
        }


    }

    
}
