using Car.Renting.DAL;
using Car.Renting.DAL.Data;

namespace Car.Renting.BL;
public class BookingCarsManager : IBookingCarsManager
{
    private readonly IUnitOfWork unitOfWork;

    public BookingCarsManager(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public bool Add(BookingToAddDto bookingToAddDto)
    {

        //// First Check On Customer if is exist in DB
        var customerFromDb = unitOfWork.CustomerRepo.GetByID(bookingToAddDto.CustomerId);

        var bookingOrder = new BookingCars
        {
            Id = Guid.NewGuid(),
            CustomerId = bookingToAddDto.CustomerId,
            TransactionDate = bookingToAddDto.TransactionDate,
            RentedCars = bookingToAddDto.RntedCars.Select(c => new RentedCars
            {
                CarId = c.CarId,
                Quantity = c.QuantityOfCars,
                RentDuration = c.RentDuration
            }).ToList()

        };

        unitOfWork.BookingRepo.Add(bookingOrder);
        return unitOfWork.Savechanges() > 0 ? true : false;
    }
}
