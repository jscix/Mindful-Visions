using System;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MindfulVisions
{
    internal class Dimmer
    {

        public void test()
        {
            foreach (Screen monitor in Screen.AllScreens)
            {
                dimmerWindow window = new dimmerWindow
                                                {
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
                window.Show();
            }
            
        }

        public void RemoveDim(Form obj)
        {
            obj.WindowState = FormWindowState.Normal;
            obj.Visible = false;
        }

        public void SetBrightness(byte targetBrightness)
        {
           ManagementScope scope = new ManagementScope("root\\WMI");
            SelectQuery query = new SelectQuery("WmiMonitorBrightnessMethods");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                using (ManagementObjectCollection objectCollection = searcher.Get())
                {
                    foreach (ManagementObject mObj in objectCollection)
                    {
                        mObj.InvokeMethod("WmiSetBrightness",
                            new Object[] { UInt32.MaxValue, targetBrightness });
                        break;
                    }
                }
            }
        }

    }

}