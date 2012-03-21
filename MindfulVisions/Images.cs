using System;
using System.IO;

namespace WindowsFormsApplication1
{
    internal class Images
    {
        public string PickRandomImage()
        {
            var rand = new Random();
            string[] files = Directory.GetFiles("images\\", "*.jpg");
            return files[rand.Next(files.Length)];
        }
    }
}