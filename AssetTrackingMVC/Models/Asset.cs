namespace AssetTrackingMVC.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }   
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; }

        public Office? Office { get; set; }
        public int OfficeId { get; set; } // Foreing Key

        

    }
}
