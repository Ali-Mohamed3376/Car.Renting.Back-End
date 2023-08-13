namespace Car.Renting.BL;
public class CustomerToAddDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; } 
    public string? Nationality { get; set; } 
    public string? DrivingLicenseNo { get; set; } 
    public string? AdvancedPayment { get; set; } 
}
