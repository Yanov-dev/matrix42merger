using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Matrix42Merger.Models
{
    public class SourceModel
    {
        public int Id { get; set; }

        public int TargetSource { get; set; }

        public string SourceId { get; set; }
    }
}