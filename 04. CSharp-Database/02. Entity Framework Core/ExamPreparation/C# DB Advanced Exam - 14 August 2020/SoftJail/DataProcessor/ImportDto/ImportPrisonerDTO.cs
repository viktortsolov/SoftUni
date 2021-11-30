namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ImportPrisonerDTO
    {
        [XmlAttribute("id")]
        public int id { get; set; }
    }
}
