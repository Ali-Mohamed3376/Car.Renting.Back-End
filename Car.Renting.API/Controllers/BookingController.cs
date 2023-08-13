using Car.Renting.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Renting.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingCarsManager manager;

        public BookingController(IBookingCarsManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(BookingToAddDto booking)
        {
            var result = manager.Add(booking);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }


    }
}
