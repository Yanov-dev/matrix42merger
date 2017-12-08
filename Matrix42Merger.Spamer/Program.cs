using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix42Merger.Spamer
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<HostSpamer>();

            list.Add(new HostSpamer(Path.Combine(Directory.GetCurrentDirectory(), "DataSources", "Source1.json"), 1));
            list.Add(new HostSpamer(Path.Combine(Directory.GetCurrentDirectory(), "DataSources", "Source2.json"), 2));
            list.Add(new HostSpamer(Path.Combine(Directory.GetCurrentDirectory(), "DataSources", "Source3.json"), 3));

            var tasks = new Task[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                var localIndex = i;
                tasks[i] = Task.Run(() => { list[localIndex].Start(); });
            }

            Task.WhenAll(tasks);
            Console.ReadKey();
        }
    }
}
