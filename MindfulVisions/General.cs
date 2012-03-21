using System.Diagnostics;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    internal class General
    {
        public string ApplicationPath()
        {
            return isDebugMode() ? @"C:\Users\Jesse\Documents\Visual Studio 2010\Projects\MindfulVisions\MindfulVisions\" : Application.StartupPath;
        }

        public string SoundsPath()
        {
            string soundspath = ApplicationPath();
            if (soundspath.Substring((soundspath.Length - 1), 1) == @"\")
            {
                return soundspath + @"Sounds\";
            }
            return soundspath + @"\Sounds\";
        }

        private bool isDebugMode()
        {
            return Debugger.IsAttached;
        }

        public bool ValidateSoundList(ListView list)
        {
            foreach (ListViewItem item in list.Items)
            {
                if (item.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateSoundList()
        {
            if (Settings.Default.Sounds.Count == 0 || Settings.Default.Sounds == null)
            {
                return false;
            }
            return true;
        }
    }
}