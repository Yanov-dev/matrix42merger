using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Guid MergedEntityDbModelId { get; set; }

        [ForeignKey("MergedEntityDbModelId")]
        public virtual MergedEntityDbModel MergedEntity { get; set; }
    }
}