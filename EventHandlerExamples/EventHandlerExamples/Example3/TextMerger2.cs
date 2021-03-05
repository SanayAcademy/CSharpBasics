using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerExamples.Example3
{
    class TextMerger2
    {
        private readonly string _path;
        public event EventHandler<MergeStartEventArgs> MergeStart;
        public event EventHandler<FileProcessedEventArgs> FileProcessed;
        public event EventHandler<EventArgs> MergeCompleted;

        private void onComplete()
        {
            MergeCompleted?.Invoke(this, new EventArgs());
        }
        private void onFileProcessed(string filename)
        {
            FileProcessed?.Invoke(this, new FileProcessedEventArgs(filename));
        }
        private void onMergeStart(int allFilesCount)
        {
            //if(MergeStart!=null)
            //    MergeStart.Invoke(this, new MergeStartEventArgs(allFilesCount));
            
           MergeStart?.Invoke(this, new MergeStartEventArgs(allFilesCount));
        }
        public TextMerger2(string path)
        {
            _path = path;
        }
        public void DoMerge()
        {
            var fileList = System.IO.Directory.GetFiles(_path, "*.txt");
            onMergeStart(fileList.Length);


            foreach (var file in fileList)
            {
                var currentFileContent = System.IO.File.ReadAllLines(file);
                System.Threading.Thread.Sleep(1000);
                System.IO.File.AppendAllLines(_path + @"\merge.txt", currentFileContent);

                onFileProcessed(file);
            }
            onComplete();
        }
    }
}
