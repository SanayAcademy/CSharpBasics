using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerExamples.Example3
{
    public class FileProcessedEventArgs:EventArgs
    {
        public string FileName { get; set; }
        public FileProcessedEventArgs(string fileName)
        {
            FileName = fileName;
        }
    }

}
