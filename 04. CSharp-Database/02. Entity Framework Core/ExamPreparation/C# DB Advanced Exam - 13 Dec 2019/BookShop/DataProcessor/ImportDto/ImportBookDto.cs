namespace BookShop.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Book")]
    public class ImportBookDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Required]
        [Range(1, 3)]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Required]
        [Range((double)0.01m, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [XmlElement("Pages")]
        [Required]
        [Range(50, 5000)]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}
