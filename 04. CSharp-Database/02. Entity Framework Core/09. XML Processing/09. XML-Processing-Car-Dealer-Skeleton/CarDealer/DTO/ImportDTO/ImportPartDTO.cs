namespace CarDealer.DTO.ImportDTO
{
    using System.Xml.Serialization;

    [XmlType("Part")]
    public class ImportPartDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("quantity")]
        public string Quantity { get; set; }

        [XmlElement("supplierId")]
        public string SupplierId { get; set; }
    }
}
