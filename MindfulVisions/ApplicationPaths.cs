﻿namespace MindfulVisions
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

        public string ImageDirectory()
        {
            string imagepaths = RootDirectory();
            if (imagepaths.Substring((imagepaths.Length - 1), 1) == @"\")
            {
                return imagepaths + @"Images\";
            }
            return imagepaths + @"\Images\";
        }

        private bool isDebugMode()
        {
            return System.Diagnostics.Debugger.IsAttached;
        }
    }
}
