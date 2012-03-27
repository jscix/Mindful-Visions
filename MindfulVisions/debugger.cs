using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MindfulVisions
{
    public partial class Debugger : Form
    {
        public Debugger(string errorType, string errorMessage, string stackTrace)
        {
            InitializeComponent();
            richTextBox1.Text = "Type of error: " + errorType + Environment.NewLine;
            richTextBox1.Text += "Error contents: " + errorMessage + Environment.NewLine;
            richTextBox1.Text += "Stack Trace:" + Environment.NewLine + stackTrace;
        }

        private void debugger_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult msgboxResponse = MessageBox.Show("Copying this will overwrite your clipboard", "Warning",
                                                          MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (msgboxResponse == DialogResult.OK)
            {
                Clipboard.SetText(richTextBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Please click the 'Copy' button, and after the website loads, click the button on the website labeled 'Create new ticket', from there you should be able to file this error so I can attempt to fix it, thank you!",
                "Reporting a bug", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("http://mindfulvisions.lighthouseapp.com/projects/91739-mindful-visions/tickets");
        }
    }
}