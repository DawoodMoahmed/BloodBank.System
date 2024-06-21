using System.Collections.Generic;
using System.Windows.Forms;

namespace BloodBank.Ui.CustomTools.Extension
{
    public class NavigationControl
    {
        List<UserControl> userControls = new List<UserControl>();
        Panel panel;

        public NavigationControl(List<UserControl> userControls, Panel panel)
        {
            this.userControls = userControls;
            this.panel = panel;
        }

        public void AddUserControl()
        {
            for (int i = 0; i < userControls.Count; i++)
            {
                userControls[i].Dock = DockStyle.Fill;
                panel.Controls.Add(userControls[i]);
            }
        }



        public void Display(int index)
        {
            userControls[index].BringToFront();
        }
    }
}
