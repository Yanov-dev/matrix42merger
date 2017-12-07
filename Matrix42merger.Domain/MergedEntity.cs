using System;
using System.Collections.Generic;

namespace Matrix42merger.Domain
{
    public class MergedEntity
    {
        public MergedEntity()
        {
            Sources = new List<Source>();
        }

        public string CommonCriteria { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public int MergedTargetSource { get; set; }

        public List<Source> Sources { get; set; }

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
            return (int) Math.Pow(targetSource, 2);
        }
    }
}