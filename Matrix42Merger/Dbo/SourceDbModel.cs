using System;
using System.ComponentModel.DataAnnotations;

namespace Matrix42Merger.Dbo
{
    public class SourceDbModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int TargetSource { get; set; }

        [Required]
        [MaxLength(50)]
        public string SourceId { get; set; }
    }
}