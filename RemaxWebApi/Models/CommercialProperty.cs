namespace RemaxWebApi.Models
{
    public class CommercialProperty : Property
    {
        public double SuperBuiltUpArea { get; set; }
        public double CarpetArea { get; set; }
        public int ContractType { get; set; }//Rent/Lease/Sale
        public double Maintenance { get; set; }
        public double SecurityDeposit { get; set; }
        public bool PantryAvailable { get; set; }
        public int NoOfCabins { get; set; }
        public int NoOfWashRooms { get; set; }
        public int NoOfWorkStations { get; set; }
        public int LockInPeriod { get; set; }
        public string FloorDetails { get; set; }
    }
}
