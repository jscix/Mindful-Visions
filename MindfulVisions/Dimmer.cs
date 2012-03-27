using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MindfulVisions
{
    internal class Dimmer
    {
        private readonly List<DimmerWindow> _dimmerWindows = new List<DimmerWindow>();

        public void Dim()
        {
            foreach (Screen monitor in Screen.AllScreens)
            {
                DimmerWindow window = new DimmerWindow {
                                                    BackColor = Color.Black,
                                                    Opacity = .8,
                                                    FormBorderStyle = FormBorderStyle.None,
                                                    StartPosition = FormStartPosition.Manual,
                                                    ShowIcon = false,
                                                    ShowInTaskbar = false
                                                       };
                window.StartPosition = FormStartPosition.Manual;
                window.Location = new Point(monitor.Bounds.Left, monitor.Bounds.Top);
                window.WindowState = FormWindowState.Normal;
                window.WindowState = FormWindowState.Maximized;
                _dimmerWindows.Add(window);
                window.Show();
            }
            
        }

        public void RemoveDim()
        {
            foreach (var dimmerWindow in _dimmerWindows)
            {
                dimmerWindow.Close();
            }
            _dimmerWindows.Clear();
        }

    }

}