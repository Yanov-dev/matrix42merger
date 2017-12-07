using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matrix42Merger.Models
{
    public class MergedEntity
    {
        public string CommonCriteria { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public int MergedTargetSource { get; set; }

        public List<Source> Sources { get; set; }

        public MergedEntity()
        {
            Sources = new List<Source>();
        }

        public void AddSource(Source source)
        {
            Sources.Add(source);
            MergedTargetSource |= GetTargetSourceFlag(source.TargetSource);
        }

        public void RemoveSource(Source source)
        {
            // todo

            MergedTargetSource &= ~GetTargetSourceFlag(source.TargetSource);
        }

        private int GetTargetSourceFlag(int targetSource)
        {
            return (int)Math.Pow(targetSource, 2);
        }
    }
}