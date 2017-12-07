using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matrix42Merger.Dbo
{
    public class MergedEntityDbModel
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string CommonCriteria { get; set; }

        [MaxLength(50)]
        public string Date { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int MergedTargetSource { get; set; }

        public virtual ICollection<SourceDbModel> Sources { get; set; }
    }
}