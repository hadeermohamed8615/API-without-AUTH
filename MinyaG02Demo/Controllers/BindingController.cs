using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinyaG02Demo.Models;

namespace MinyaG02Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///Primitive DT => Route Data | Query String
    ///Complex DT => Request Body
    public class BindingController : ControllerBase
    {
        [HttpPost("{id}")]
        public IActionResult TestBinding([FromQuery]int num)
        {
            return Content("Ay7aga");
        }
        [HttpPost]
        public IActionResult TestBindingComplex(Department d,string name)
        {
            return Content("Ay7aga");
        }
    }
}
