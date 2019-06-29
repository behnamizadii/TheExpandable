using Microsoft.AspNetCore.Mvc;

namespace TheExpandable.StoreApi.Controllers
{
    public interface IMainController
    {
        object Get();
    }
    
    [Route("Main")]
    public class MainController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return new { Name = "Ben Izadi",  Email= "ben.izadi@outlook.com"};
        }
    }
}