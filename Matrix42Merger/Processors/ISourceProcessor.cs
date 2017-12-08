using System.Threading.Tasks;
using Matrix42merger.Domain;

namespace Matrix42Merger.Processors
{
    public interface ISourceProcessor
    {
        Task Add(Source source);
    }
}