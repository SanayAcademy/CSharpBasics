using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandlerExamples.Example2
{
    public partial class EventHandler2 : Form
    {
        public EventHandler2()
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

            var fileList = System.IO.Directory.GetFiles(txtPath.Text, "*.txt");
            progressBar1.Maximum = fileList.Length;
            foreach (var file in fileList)
            {
                lblCurrentFile.Text = file;
                var currentFileContent = System.IO.File.ReadAllLines(file);
                System.Threading.Thread.Sleep(1000);
                System.IO.File.AppendAllLines(txtPath.Text + @"\merge.txt", currentFileContent);

                progressBar1.Value += 1;
                lstDone.Items.Add(file);
                Application.DoEvents();
            }


            MessageBox.Show("Done!");

        }
    }
}
