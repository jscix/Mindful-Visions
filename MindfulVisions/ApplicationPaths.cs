namespace MindfulVisions
{
    using System.Diagnostics;
    using System.Windows.Forms;

    public class ApplicationPaths
    {
        public string RootDirectory()
        {
            return isDebugMode() ? @"C:\Users\Jesse\Documents\Visual Studio 2010\Projects\MindfulVisions\MindfulVisions\" : Application.StartupPath;
        }

        public string SoundDirectory()
        {
            string soundspath = RootDirectory();
            if (soundspath.Substring((soundspath.Length - 1), 1) == @"\")
            {
                return soundspath + @"Sounds\";
            }
            return soundspath + @"\Sounds\";
        }

        private bool isDebugMode()
        {
            return System.Diagnostics.Debugger.IsAttached;
        }
    }
}
