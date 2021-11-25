namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductsInRange
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        //[XmlElement(IsNullable = false)]
        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
