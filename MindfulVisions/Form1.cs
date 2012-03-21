using System;
using System.Diagnostics;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool _appStateActive;

        public Form1()
        {
            InitializeComponent();
        }

        private bool IsActive
        {
            set { _appStateActive = value; }
            get
            {
                if (_appStateActive)
                {
                    return true;
                }
                return false;
            }
        }

        public void DisplayMindfulnessWindow()
        {
            var mindfulnessWindow = new Form2(ref timer1, this);
            mindfulnessWindow.Visible = true;
            mindfulnessWindow.Show();
            timer1.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            IsActive = true;

            // Probably first load time if settings are blank
            if (Settings.Default.mindfulnessDelay == "" || Settings.Default.mindfulnessLiveTime == "" ||
                Settings.Default.Sounds == null)
            {
                var cfgWnd = new Configuration(this);
                cfgWnd.Show();
                timer1.Interval = (5*60000);
                timer1.Enabled = false;
            }
            else
            {
                timer1.Interval = (short.Parse(Settings.Default.mindfulnessDelay)*60000); // 60,000ms == 1 minute
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsActive)
            {
                DisplayMindfulnessWindow();
            }
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pauseToolStripMenuItem.Text == "Pause")
            {
                IsActive = false;
                pauseToolStripMenuItem.Text = "Resume";
            }
            else
            {
                IsActive = true;
                pauseToolStripMenuItem.Text = "Pause";
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var configWindow = new Configuration(this);
            configWindow.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void testToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var wndAbout = new About();
            wndAbout.Show();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("http://bawk.org/mindfulvisions/help/");
        }
    }
}