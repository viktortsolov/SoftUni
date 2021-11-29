namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using TeisterMask.Common;

    [XmlType("Project")]
    public class ImportProjectDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.PROJECT_NAME_MIN_LENGTH)]
        [MaxLength(GlobalConstants.PROJECT_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportProjectTasksDTO[] Tasks { get; set; }
    }
}
