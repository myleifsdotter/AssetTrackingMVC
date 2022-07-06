namespace AssetTrackingMVC.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public List<Asset>? Assets { get; set; }

        //public Address? Address { get; set; }
        //public int AddressId { get; set; }
    }
     
}
