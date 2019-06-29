using Microsoft.AspNetCore.Mvc;

namespace TheExpandable.StoreApi.Controllers
{
    
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route("Index")]
        [HttpGet]
        public object Index(string id)
        {
            return string.IsNullOrEmpty(id) ? new {ID = "No ID Provided"} : new {ID=id};
        }

        /// <summary>
        /// Get an Item By Id
        /// </summary>
        /// <param name="itemId">The Id of the item you want to get</param>
        /// <returns>An object of Items to be a list later</returns>
        [Route("GetItem/{id?}")]
        [HttpGet]
        public object GetItem(string itemId)
        {
            return string.IsNullOrEmpty(itemId) ? new {ID = "No ID Provided"} : new {ID=itemId};
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {Name="Ben"});
        }
    }
}