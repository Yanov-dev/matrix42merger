using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matrix42Merger.Models
{
    public class MergedEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string CommonCriteria { get; set; }

        public virtual ICollection<Source> Sources { get; set; }
    }
}