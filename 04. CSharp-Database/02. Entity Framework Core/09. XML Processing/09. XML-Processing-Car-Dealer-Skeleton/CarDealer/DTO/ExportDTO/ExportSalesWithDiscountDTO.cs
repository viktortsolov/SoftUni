namespace CarDealer.DTO.ExportDTO
{
    using System.Xml.Serialization;

    [XmlType("Sale")]
    public class ExportSalesWithDiscountDTO
    {
        [XmlElement("car")]
        public ExportSalesCarDTO Car { get; set; }

        [XmlElement("discount")]
        public string Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("price-with-discount")]
        public string PriceWithDiscount { get; set; }
    }
}
