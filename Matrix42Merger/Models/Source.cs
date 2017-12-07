using System;
using System.ComponentModel.DataAnnotations;

namespace Matrix42Merger.Models
{
    public class Source
    {
        [Key]
        public Guid Id { get; set; }

        public int TargetSource { get; set; }

        [MaxLength(50)]
        public string SourceId { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string CommonCriteria { get; set; }
    }
}