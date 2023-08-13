using Car.Renting.BL;
using Car.Renting.BL.Dtos.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Renting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarManager manager;

        public CarsController(ICarManager manager)
        {
            this.manager = manager;
        }

        #region Get All Cars

        [HttpGet]
        [Route("all_Cars")]
        public ActionResult<IEnumerable<CarViewDto>> GetAllCars()
        {
            IEnumerable<CarViewDto> result = manager.GetAll();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        #endregion

        #region Get Car By Id

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CarByIdDto> GetByID(Guid id)
        {

            CarByIdDto car = manager.GetById(id);
            if (car is null) { return NotFound(); }
            return Ok(car);
        }
        #endregion

        #region Car Filteration

        [HttpPost]
        [Route("CarFilteration")]
        public ActionResult Filter(CarFilterationDto dto)
        {
            var result = manager.CarsAfterFilteration(dto);

            return Ok(result.ToList());

        }

        #endregion

        #region Get All Brands Name

        [HttpGet]
        [Route("Brands")]
        public ActionResult<IEnumerable<BrandsDto>> GetAllBrands()
        {
            var brandsResult = manager.GetAllBrands();
            if (brandsResult is null)
            {
                return NotFound();
            }
            return Ok(brandsResult);
        }

        #endregion

        #region Get All Models Name

        [HttpGet]
        [Route("ModelNames")]
        public ActionResult<IEnumerable<ModelNamesDto>> GetAllModels()
        {
            var modelsResult = manager.GetAllModels();
            if (modelsResult is null)
            {
                return NotFound();
            }
            return Ok(modelsResult);
        }

        #endregion

        #region Get All Model Years

        [HttpGet]
        [Route("ModelYears")]
        public ActionResult<IEnumerable<ModelYearsDto>> GetAllModelYears()
        {
            var modelYearsResult = manager.GetAllModelYears();
            if (modelYearsResult is null)
            {
                return NotFound();
            }
            return Ok(modelYearsResult);
        }

        #endregion

        #region Add Car

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(CarToAddDto dto)
        {
            var result = manager.AddCar(dto);
            return result ? Ok(result) : BadRequest();
        }

        #endregion
    }
}
