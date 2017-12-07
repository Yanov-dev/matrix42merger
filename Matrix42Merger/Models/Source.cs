using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matrix42Merger.Models
{
    public class Source
    {
        public int TargetSource { get; set; }

        public string SourceId { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string CommonCriteria { get; set; }
    }
}