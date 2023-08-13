using Car.Renting.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Renting.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager manager;

        public CustomerController(ICustomerManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(CustomerToAddDto customer)
        {
            var result = manager.Add(customer);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPost]
        [Route("GetUserByName")]
        public ActionResult<CustomerToViewDto> GetCustomerByName( CustomerNameDto customerName)
        {
            var customer = manager.GetUserByName(customerName);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
