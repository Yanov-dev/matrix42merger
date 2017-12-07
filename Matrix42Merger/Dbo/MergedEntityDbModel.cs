using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Matrix42Merger.Models;

namespace Matrix42Merger.Dbo
{
    internal class MergedEntityDbModel
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