namespace FieldAgent.Core.Entities
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }

        public int AgencyID { get; set; }
        public Agency Agency { get; set; }
    }
}
