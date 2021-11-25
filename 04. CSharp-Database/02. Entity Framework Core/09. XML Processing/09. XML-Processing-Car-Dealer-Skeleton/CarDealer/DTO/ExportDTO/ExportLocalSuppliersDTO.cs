namespace CarDealer.DTO.ExportDTO
{
    using System.Xml.Serialization;

    [XmlType("suplier")]
    public class ExportLocalSuppliersDTO
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public string PartsCount { get; set; }
    }
}
