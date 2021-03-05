using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerExamples.Example3
{
    public class MergeStartEventArgs:EventArgs
    {
        public int AllFilesCount { get; set; }
        public MergeStartEventArgs(int allFilesCount)
        {
            AllFilesCount = allFilesCount;
        }
    }
}
