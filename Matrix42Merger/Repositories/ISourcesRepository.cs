using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix42Merger.Models;

namespace Matrix42Merger.Repositories
{
    public interface ISourcesRepository
    {
        void Add(SourceModel model);
    }
}
