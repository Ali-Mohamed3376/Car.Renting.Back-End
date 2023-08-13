namespace Car.Renting.BL;
public class CustomerToViewDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; } 
    public string? Nationality { get; set; } 
    public string? DrivingLicenseNo { get; set; }
    public string? AdvancedPayment { get; set; } 
}
