using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matrix42Merger.Models
{
    public class MergedEntry
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int MergedTargetSource { get; set; }


    }
}