using Aspnet.com.Models;

public class Person
{
    public int PErsonId { get; set; }
    public string? Name { get; set; } // Propriedade anulável
    public ICollection<Address>? Addresses { get; set; } // Propriedade anulável
    public ICollection<Order>? Orders { get; set; } // Propriedade anulável
}
