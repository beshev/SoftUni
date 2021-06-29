using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class XmlTaskImportModel
    {
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        [Range(0, 3)]
        public int ExecutionType { get; set; }

        [Range(0,4)]
        public int LabelType { get; set; }
    }
}