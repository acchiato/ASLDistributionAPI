namespace ASLDistributionAPI.Models
{
    public class ShipmentModel
    {
        public string CarrierReferenceNumber { get; set; }
        public string Delivery_Company { get; set; }
        public string Delivery_Address1 { get; set; }
        public string Delivery_City { get; set; }
        public string Delivery_ProvState { get; set; }
        public string Delivery_PostalZip { get; set; }
        public string Delivery_Country { get; set; }
        public string Delivery_Phone { get; set; }
        public string ServiceCode { get; set; }
    }
}
