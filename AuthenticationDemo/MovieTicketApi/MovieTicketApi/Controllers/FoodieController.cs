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
    public class FoodieController : ControllerBase
    {
        private readonly FoodServices _foodservices;
        public FoodieController(FoodServices foodServices)
        {
            this._foodservices = foodServices;
        }

        [HttpGet]
        public async Task<List<Foods>> Get()
        {
           return await _foodservices.GettheFood();
        }

        [HttpGet("GetById")]        
        public async Task<ActionResult<Foods>> GetbyId(string id)
        {
            var food = await _foodservices.GetById(id);
            if (food is null)
                return NotFound();

            return food;
        }

        [HttpPost]
        public async Task<OkObjectResult> Insert(Foods foods)
        {
            await _foodservices.InsertFoodDetails(foods);
            return Ok(foods);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id,Foods foods)
        {
            var existingitem = await _foodservices.GetById(id);
            
            if (existingitem is null)
            {
                return NotFound();
            }
            foods.Id = existingitem.Id;
            await _foodservices.UpdateFoodDetails(id, foods);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var existingitem = await _foodservices.GetById(id);

            if (existingitem is null)
            {
                return NotFound();
            }
            await _foodservices.DeleteFoodDetails(id);
            return NoContent();
        }


    }

    
}
