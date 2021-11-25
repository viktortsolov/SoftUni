namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ImportUserDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public string Age { get; set; }
    }
}
