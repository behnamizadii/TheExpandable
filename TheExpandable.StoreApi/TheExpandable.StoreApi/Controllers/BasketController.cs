using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TheExpandable.DataAccess;

namespace TheExpandable.StoreApi.Controllers
{
    /// <summary>
    /// Basket Controller
    /// </summary>
    [Route("Basket")]
    [EnableCors("CorsPolicy")]
    public class BasketController : Controller
    {
        private IBasketRepository _basketRepo;

        /// <summary>
        /// Basket Controller Constructor
        /// </summary>
        /// <param name="basketRepo"></param>
        public BasketController(IBasketRepository basketRepo)
        {
            _basketRepo = basketRepo;
        }
        
        /// <summary>
        /// Add an Item to the basket
        /// </summary>
        /// <returns>Basket information</returns>
        [Route("Add/{id}")]
        [HttpPut]
        public IActionResult Add(string itemId)
        {
            try
            {
                if (string.IsNullOrEmpty(itemId))
                    return BadRequest("No ID Provided");

                var result = _basketRepo.Add(itemId);
                return Ok(result);
            }
            catch (Exception )
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Remove Item from basket
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>Basket information</returns>
        [Route("Remove/{id}")]
        [HttpDelete]
        public IActionResult Remove(string itemId)
        {
            try
            {
                if (string.IsNullOrEmpty(itemId))
                    return BadRequest("No ID Provided");

                var result = _basketRepo.Remove(itemId);
                return Ok(result);
            }
            catch (Exception )
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}