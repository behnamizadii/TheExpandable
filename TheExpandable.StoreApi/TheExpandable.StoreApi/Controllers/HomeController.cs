using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TheExpandable.DataAccess;
using TheExpandable.Entities;

namespace TheExpandable.StoreApi.Controllers
{
    
    /// <summary>
    /// Home Controller, the entry point
    /// </summary>
    [Route("Home")]
    [EnableCors("CorsPolicy")]
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepo;
        /// <summary>
        /// Constructor of the Home Controller
        /// </summary>
        /// <param name="itemRepo"></param>
        public HomeController(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        /// <summary>
        /// Get an Item By Id
        /// </summary>
        /// <param name="itemId">The Id of the item you want to get</param>
        /// <returns>An object of Items to be a list later</returns>
        [Route("GetItem/{id?}")]
        [HttpGet]
        public IActionResult GetItem(string itemId)
        {
            try
            {
                if (string.IsNullOrEmpty(itemId))
                    return BadRequest("No ID Provided");

                var result = _itemRepo.GetItemById(itemId);
                return Ok(result);
            }
            catch (Exception )
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Get all the Items
        /// </summary>
        /// <returns>A list of Items</returns>
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _itemRepo.GetAllItems();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Somehting went wrong");
            }
        }

    }
}