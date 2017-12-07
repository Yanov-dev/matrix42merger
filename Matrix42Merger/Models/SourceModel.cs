using System.ComponentModel.DataAnnotations;

namespace Matrix42Merger.Models
{
    public class SourceModel
    {
        public int Id { get; set; }

        public int TargetSource { get; set; }

        [MaxLength(50)]
        public string SourceId { get; set; }
    }
}