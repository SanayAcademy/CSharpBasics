using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerExamples.Example1
{
    class TextMerger1
    {
        private readonly string _path;
        public TextMerger1(string path)
        {
            _path = path;
        }
        public string[] DoMerge()
        {
            var fileList = System.IO.Directory.GetFiles(_path, "*.txt");
            foreach (var file in fileList)
            {
                var currentFileContent = System.IO.File.ReadAllLines(file);
                System.Threading.Thread.Sleep(1000);
                System.IO.File.AppendAllLines(_path + @"\merge.txt", currentFileContent);
            }
            return fileList;
        }
    }

}
