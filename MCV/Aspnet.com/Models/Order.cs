using System.Collections.Generic;

namespace Aspnet.com.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }

        // Propriedade de navegação para o relacionamento muitos-para-muitos
        public ICollection<Person> Persons { get; set; }
    }
}
