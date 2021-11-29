namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using TeisterMask.Common;

    [XmlType("Task")]
    public class ImportProjectTasksDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.TASK_NAME_MIN_LENGTH)]
        [MaxLength(GlobalConstants.TASK_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(GlobalConstants.TASK_EXEC_TYPE_MIN_VALUE, GlobalConstants.TASK_EXEC_TYPE_MAX_VALUE)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(GlobalConstants.TASK_LABEL_TYPE_MIN_VALUE, GlobalConstants.TASK_LABEL_TYPE_MAX_VALUE)]
        public int LabelType { get; set; }
    }
}
