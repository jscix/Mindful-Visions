using System;
using System.IO;

namespace MindfulVisions
{
    internal class Images
    {
        public string PickRandomImage()
        {
            var rand = new Random();
            string[] files = Directory.GetFiles(new ApplicationPaths().ImageDirectory(), "*.jpg");
            return files[rand.Next(files.Length)];
        }
    }
}