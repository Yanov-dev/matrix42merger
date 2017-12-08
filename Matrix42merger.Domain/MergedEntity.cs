using System;
using System.Collections.Generic;
using System.Linq;

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
            // dictionary will be better
            var sourceId = GetCombinedSourceId(source);
            if (Sources.All(e => !GetCombinedSourceId(e).Equals(sourceId)))
                Sources.Add(source);

            MergedTargetSource |= GetTargetSourceFlag(source.TargetSource);
        }

        public void RemoveSource(Source source)
        {
            var sourceId = GetCombinedSourceId(source);
            var existedSource = Sources.FirstOrDefault(e => GetCombinedSourceId(e).Equals(sourceId));
            if (existedSource != null)
                Sources.Remove(existedSource);

            MergedTargetSource &= ~GetTargetSourceFlag(source.TargetSource);
        }

        private int GetTargetSourceFlag(int targetSource)
        {
            return (int) Math.Pow(targetSource, 2);
        }

        private string GetCombinedSourceId(Source source)
        {
            return $"{source.TargetSource}-{source.SourceId}";
        }
    }
}