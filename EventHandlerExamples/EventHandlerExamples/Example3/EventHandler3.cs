using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandlerExamples.Example3
{
    public partial class EventHandler3 : Form
    {
        public EventHandler3()
        {
            InitializeComponent();
        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {

            var textMergerAgent = new TextMerger2(txtPath.Text);
            textMergerAgent.MergeStart += TextMergerAgent_MergeStart;
            textMergerAgent.FileProcessed += TextMergerAgent_FileProcessed;
            textMergerAgent.FileProcessed += TextMergerAgent_FileProcessed_002;
            textMergerAgent.MergeCompleted += TextMergerAgent_MergeCompleted;
            textMergerAgent.DoMerge(); 
        }

        private void TextMergerAgent_FileProcessed_002(object sender, FileProcessedEventArgs e)
        {
            Console.WriteLine(e.FileName);
        }

        private void TextMergerAgent_MergeCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Done!");
        }

        private void TextMergerAgent_FileProcessed(object sender, FileProcessedEventArgs e)
        {
            progressBar1.Value += 1;
            lstDone.Items.Add(e.FileName);
            lblCurrentFile.Text = e.FileName;

            Application.DoEvents();
        }

        private void TextMergerAgent_MergeStart(object sender, MergeStartEventArgs e)
        {
            progressBar1.Maximum = e.AllFilesCount;
        }

        private void EventHandler3_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Form Loaded !");

        }
    }
}
