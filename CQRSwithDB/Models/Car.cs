namespace CQRSwithDB.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public float Mileage { get; set; }
        public float Price { get; set; }
    }
}
