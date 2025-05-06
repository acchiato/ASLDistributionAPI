namespace ASLDistributionAPI.Models
{
    public class CreateJobQueryModel
    {
        public JobDetails Details { get; set; }
        public Address PickupAddress { get; set; }
        public Address DeliveryAddress { get; set; }
        public ItemsInformation ItemsInfo { get; set; }

        public class JobDetails
        {
            public ClientInfo Client { get; set; }
            public DateTime RequestedDate { get; set; }
            public ServiceTypeInformation ServiceType { get; set; }
            public int? JobOption { get; set; }
            public string Description { get; set; }
            public string SalesOrder { get; set; }
            public string CarrierRef { get; set; }
            public string Reference1 { get; set; }
            public string Reference2 { get; set; }
            public string Comments { get; set; }
            public string Ready { get; set; }
            public string CloseTime { get; set; }

            public class ClientInfo
            {
                public string EDIClientID { get; set; }
            }

            public class ServiceTypeInformation
            {
                public string ServiceCode { get; set; }
                public List<ServiceTypeOption> ServiceTypeOptions { get; set; }

                public class ServiceTypeOption
                {
                    public string ServiceTypeOptionCode { get; set; }
                }
            }
        }

        public class Address
        {
            public string RouteCode { get; set; }
            public string CompanyName { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Address3 { get; set; }
            public string City { get; set; }
            public string ProvinceStateCode { get; set; }
            public string PostalZipCode { get; set; }
            public string CountryCode { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public bool TransitNotification { get; set; }
            public bool PODNotification { get; set; }
        }

        public class ItemsInformation
        {
            public string UOM_W { get; set; }
            public string UOM_L { get; set; }
            public List<Item> Items { get; set; }

            public class Item
            {
                public string Description { get; set; }
                public decimal Weight { get; set; }
                public decimal Length { get; set; }
                public decimal Width { get; set; }
                public decimal Height { get; set; }
                public string Barcode { get; set; }
            }
        }
    }
}
