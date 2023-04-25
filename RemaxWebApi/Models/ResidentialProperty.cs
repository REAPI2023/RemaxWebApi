namespace RemaxWebApi.Models
{
    public class ResidentialProperty : Property
    {
        public int NoOfBeds { get; set; }
        public int NoOfBathRooms { get; set; }
        public int NoOfBalcony { get; set; }
        public double Dimention { get; set; }
        public int FlatFloor { get; set; }
        public int TotalFloors { get; set; }
        public int NoOfFlatsInAFloor { get; set; }
        public int PropertyAge { get; set; }
        public int NoOfLifts { get; set; }

    }
}
