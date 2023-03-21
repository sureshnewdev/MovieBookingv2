using FoodieApi.Model;
using FoodieApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using System.Text.Json;

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
            try
            {
                InsertBI(movieTickets);
            }
            catch (Exception ex)
            {

                // Serilog
            }
            return Ok(movieTickets);
        }

        private void InsertBI(MovieTicket movieTickets)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373");
            //            {
            //                "MovieName": "EEEE",
            //    "BookedTime": "10/10/2020",
            //    "BookedSeasion": "BB"
            //}
            var analytical = new { MovieName = movieTickets.MovieName, BookedSeasion = DateTime.Now.Month < 5 ? "Before Summar" : "Afer Summar" };

            var jsonString = "[ " + JsonSerializer.Serialize(analytical) + " ]";
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44384/MovieBooking", content).Result;
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
