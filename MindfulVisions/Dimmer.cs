using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal class Dimmer
    {
        public void Dim(Form obj)
        {
            obj.BackColor = Color.Black;
            obj.Opacity = .8;
            obj.FormBorderStyle = FormBorderStyle.None;
            obj.StartPosition = FormStartPosition.Manual;
            obj.ShowIcon = false;
            obj.ShowInTaskbar = false;
            obj.Height = Screen.PrimaryScreen.Bounds.Height;
            obj.Width = Screen.PrimaryScreen.Bounds.Width;
            obj.WindowState = FormWindowState.Maximized;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }

        public void RemoveDim(Form obj)
        {
            obj.WindowState = FormWindowState.Normal;
            obj.Visible = false;
        }
    }
}