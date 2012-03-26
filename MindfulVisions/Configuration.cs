using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MindfulVisions.Properties;

namespace MindfulVisions
{
    public partial class Configuration : Form
    {
        public MindfulVisions MindfulVisionsReference;

        public Configuration(MindfulVisions form)
        {
            InitializeComponent();
            MindfulVisionsReference = form;
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            try
            {
                loadActiveSounds();

                if (Settings.Default.Sounds != null)
                {
                    StringCollection activeSounds = Settings.Default.Sounds;

                    foreach (ListViewItem soundFile in listView1.Items.Cast<ListViewItem>().Where(soundFile => activeSounds.Contains(soundFile.Text)))
                    {
                        soundFile.Checked = true;
                    }
                }

                checkBox1.CheckState = Settings.Default.screenDimmer ? CheckState.Checked : CheckState.Unchecked;
                checkBox2.Checked = Settings.Default.useSound;

                label7.Text = Settings.Default.mindfulnessDelay;
                label8.Text = (0.5 * Convert.ToDouble(Settings.Default.mindfulnessLiveTime)).ToString();

                trackBar1.Value = Convert.ToInt32(Settings.Default.mindfulnessDelay);
                trackBar2.Value = Convert.ToInt32(Settings.Default.mindfulnessLiveTime);
                
                
            }
            catch (Exception x)
            {
                new debugger(x.GetType().ToString(), x.Message, x.StackTrace).Show();
            }
        }

        private void loadActiveSounds()
        {
            string directoryPath = new General().SoundsPath();

            string[] soundFilesList = Directory.GetFiles(directoryPath);

            foreach (string soundPath in soundFilesList)
            {
                string soundFile = soundPath.Split('\\').Last();
                listView1.Items.Add(soundPath, soundFile, 3);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateConfigSettings())
                {
                    Settings.Default.useSound = checkBox2.Checked;
                    Settings.Default.mindfulnessDelay = trackBar1.Value.ToString(); //comboBox1.Text;
                    Settings.Default.mindfulnessLiveTime = trackBar2.Value.ToString(); //comboBox2.Text;
                    Settings.Default.screenDimmer = checkBox1.CheckState == CheckState.Checked;

                    var activeSounds = new string[listView1.Items.Count];

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Checked)
                        {
                            activeSounds[i] = listView1.Items[i].Text;
                        }
                    }

                    Settings.Default.Sounds = new StringCollection();

                    foreach (string soundFile in activeSounds)
                    {
                        Settings.Default.Sounds.Add(soundFile);
                    }

                    Settings.Default.Save();
                    Settings.Default.Upgrade();

                    MindfulVisionsReference.timer1.Interval = (short.Parse(Settings.Default.mindfulnessDelay) * 60000);
                    MindfulVisionsReference.timer1.Enabled = true;

                    Close();
                }
            }
            catch (Exception x)
            {
                new debugger(x.GetType().ToString(), x.Message, x.StackTrace).Show();
            }
        }

        private bool ValidateConfigSettings()
        {
            if (trackBar2.Value == 0 || trackBar1.Value == 0)
            {
                MessageBox.Show(
                    "Please select how often and for how long you would like your mindfulness reminder to be displayed.",
                    "You need to choose some options.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (checkBox2.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("Please select the Sound tab, and mark the checkbox.",
                                "You need to choose some options.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (checkBox2.Checked && new General().ValidateSoundList(listView1) == false)
            {
                MessageBox.Show(
                    "Please select the Sound tab, and uncheck the Use Sounds option, or select at least one sound to use.",
                    "You need to choose some options.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0 || trackBar1.Value == 0)
            {
                MessageBox.Show(
                    "Please select how often and for how long you would like your mindfulness reminder to be displayed.",
                    "You need to choose some options.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkBox2.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("Please select the Sound tab, and mark the checkbox.",
                                "You need to choose some options.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkBox2.Checked && new General().ValidateSoundList(listView1) == false)
            {
                MessageBox.Show(
                    "Please select the Sound tab, and uncheck the Use Sounds option, or select at least one sound to use.",
                    "You need to choose some options.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Wave Files (*.wav)|*.wav";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.InitialDirectory = new General().SoundsPath();

                if (Directory.Exists(new General().SoundsPath()) == false)
                    Directory.CreateDirectory(new General().SoundsPath());

                if (openFileDialog1.ShowDialog() == DialogResult.OK &&
                    File.Exists(new General().SoundsPath() + openFileDialog1.FileName.Split('\\').Last()) == false)
                {
                    File.Copy(openFileDialog1.FileName,
                              new General().SoundsPath() + openFileDialog1.FileName.Split('\\').Last());

                    listView1.Clear();
                    string directoryPath = new General().SoundsPath();
                    string[] filePaths = Directory.GetFiles(directoryPath);

                    foreach (string soundPath in filePaths)
                    {
                        string soundFile = soundPath.Split('\\').Last();
                        listView1.Items.Add(soundPath, soundFile, 3);
                    }
                }
            }
            catch (Exception x)
            {
                new debugger(x.GetType().ToString(), x.Message, x.StackTrace).Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lstItem in listView1.Items)
            {
                if (lstItem.Checked)
                {
                    DialogResult diagResult = MessageBox.Show("Are you sure you wish to delete " + lstItem.Text + "?",
                                                              "File Deletion", MessageBoxButtons.YesNoCancel,
                                                              MessageBoxIcon.Warning);
                    if (diagResult == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(new General().SoundsPath() + lstItem.Text);
                            listView1.Items.Remove(lstItem);
                        }
                        catch (Exception err)
                        {
                            new debugger(err.GetType().ToString(), err.Message, err.StackTrace).Show();
                        }
                    }
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label8.Text = Convert.ToDouble(0.5 * trackBar2.Value).ToString();
        }
    }
}