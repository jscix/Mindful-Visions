using System;
using System.Diagnostics;
using System.Windows.Forms;
using MindfulVisions.Properties;

namespace MindfulVisions
{
    public partial class MindfulVisions : Form
    {
        private bool _appStateActive;

        public MindfulVisions()
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
            var mindfulnessWindow = new MindfulessWindow(ref timer1, this);
            mindfulnessWindow.Visible = true;
            mindfulnessWindow.Show();
            timer1.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            new Dimmer().test();

            Visible = false;
            ShowInTaskbar = false;
            IsActive = true;

            // Probably first load if settings are blank
            if (Settings.Default.mindfulnessDelay == "" || Settings.Default.mindfulnessLiveTime == "" ||
                Settings.Default.Sounds == null)
            {
                Settings.Default.useSound = false;
                Settings.Default.screenDimmer = false;
                
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}