namespace SeeSharpCarCare.Core.Services;

public class InvoiceService
{
    public InvoiceService() { }

    public double Balance { get; set; }

    public double Tax { get; set; }

    public double Total { get; set; }

    public void CalculateBalance()
    {
        Total = Balance * (1 + Tax);
    }



}