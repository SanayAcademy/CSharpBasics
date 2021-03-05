using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandlerExamples.Example1
{
    public partial class EventHandler1 : Form
    {
        public EventHandler1()
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
            var textMergerAgent = new TextMerger1(txtPath.Text);
            var result=textMergerAgent.DoMerge();
            lstDone.Items.AddRange(result);

            MessageBox.Show("Done!");
        }
    }
}
