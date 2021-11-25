namespace CarDealer.DTO.ExportDTO
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarAndPartsDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportPartFromCarsDTO[] Parts { get; set; }
    }
}
