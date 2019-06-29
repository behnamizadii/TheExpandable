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

        [Route("GetItem/{id?}")]
        [HttpGet]
        public object GetItem(string id)
        {
            return string.IsNullOrEmpty(id) ? new {ID = "No ID Provided"} : new {ID=id};
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {Name="Ben"});
        }
    }
}