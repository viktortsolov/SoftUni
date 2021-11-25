namespace CarDealer.DTO.ExportDTO
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarsWithDistanceDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}
