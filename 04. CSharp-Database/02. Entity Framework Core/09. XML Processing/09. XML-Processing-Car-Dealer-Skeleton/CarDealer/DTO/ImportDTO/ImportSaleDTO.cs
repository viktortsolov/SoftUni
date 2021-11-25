namespace CarDealer.DTO.ImportDTO
{
    using System.Xml.Serialization;

    [XmlType("Sale")]
    public class ImportSaleDTO
    {
        [XmlElement("carId")]
        public string CarId { get; set; }

        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        [XmlElement("discount")]
        public string Discount { get; set; }
    }
}
