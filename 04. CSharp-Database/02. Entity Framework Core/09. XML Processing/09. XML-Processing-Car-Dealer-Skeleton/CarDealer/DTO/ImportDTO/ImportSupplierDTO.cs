namespace CarDealer.DTO.ImportDTO
{
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportSupplierDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public string IsImporter { get; set; }
    }
}
