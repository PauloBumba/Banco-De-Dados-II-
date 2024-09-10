namespace Aspnet.com.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressName { get; set; }
        public string Street { get; set; }
        public int PersoId {  get; set; }
        public Person Person { get; set; }


    }
}
