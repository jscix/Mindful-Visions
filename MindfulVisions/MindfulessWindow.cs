using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using MindfulVisions.Properties;

namespace MindfulVisions
{
    public partial class MindfulessWindow : Form
    {
        private readonly Dimmer _screen = new Dimmer();
        public MindfulVisions DimmingWindow; // reference to MindfulVisions
        public Timer RefTimer; // reference to timer1, on MindfulVisions

        public MindfulessWindow(ref Timer timer, MindfulVisions refForm)
        {
            InitializeComponent();
            RefTimer = timer;
            DimmingWindow = refForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // if (Settings.Default.screenDimmer) _screen.Dim(DimmingWindow);
            timer1.Interval = int.Parse("" + (double.Parse(Settings.Default.mindfulnessLiveTime)*60000)); // 60,000ms == 1 minute
            timer1.Enabled = true;

            if (Settings.Default.useSound && new General().ValidateSoundList())
            {
                try
                {
                    string[] filePaths = Directory.GetFiles(new General().SoundsPath());
                    StringCollection userSounds = Settings.Default.Sounds;

                    string rndSound = null;
                    do
                    {
                        int rndNum = new Random().Next(filePaths.Length);
                        string soundFile = filePaths[rndNum];
                        string tmpString = soundFile.Split('\\').Last();

                        if (userSounds.Contains(tmpString))
                        {
                            rndSound = filePaths[rndNum];
                        }
                    } while (rndSound == null);

                    var soundPlayer = new SoundPlayer();
                    soundPlayer.SoundLocation = rndSound;
                    soundPlayer.Play();
                }
                catch (Exception x)
                {
                    new debugger(x.GetType().ToString(), x.Message, x.StackTrace).Show();
                }
            }

            try
            {
                string[] textFile = File.ReadAllLines(new General().ApplicationPath() + @"\Tips.txt");
                Tip.Text = textFile[new Random().Next(textFile.Length)];
            }
            catch (Exception x)
            {
                new debugger(x.GetType().ToString(), x.Message, x.StackTrace).Show();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Settings.Default.screenDimmer) _screen.RemoveDim(DimmingWindow);
            RefTimer.Enabled = true;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Tip_Click(object sender, EventArgs e)
        {

        }
    }
}