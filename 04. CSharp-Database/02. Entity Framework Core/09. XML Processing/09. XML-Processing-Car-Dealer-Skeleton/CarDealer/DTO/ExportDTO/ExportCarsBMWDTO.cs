namespace CarDealer.DTO.ExportDTO
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarsBMWDTO
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}
