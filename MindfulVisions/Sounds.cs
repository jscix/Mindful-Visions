using MindfulVisions.Properties;

namespace MindfulVisions
{
    using System.Windows.Forms;
    using System.Linq;

    public class Sounds
    {
        public bool ValidateSoundList(ListView list)
        {
            return list.Items.Cast<ListViewItem>().Any(item => item.Checked);
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
