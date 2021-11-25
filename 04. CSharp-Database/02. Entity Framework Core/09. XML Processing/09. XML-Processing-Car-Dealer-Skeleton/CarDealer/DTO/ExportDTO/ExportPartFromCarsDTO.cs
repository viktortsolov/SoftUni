namespace CarDealer.DTO.ExportDTO
{
    using System.Xml.Serialization;

    [XmlType("part")]
    public class ExportPartFromCarsDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public string Price { get; set; }
    }
}
