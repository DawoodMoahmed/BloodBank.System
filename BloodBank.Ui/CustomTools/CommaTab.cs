using System;
using System.Drawing;
using System.Windows.Forms;

namespace BloodBank.Ui.CustomTools
{
    public class CommaTab : TabControl
    {
        private Point _lastClick;
        private ContextMenuStrip _contextMenu;
        Image closeImage = Properties.Resources.Close15px;
        Point imageLoacation = new Point(20, 4);
        Point imageHitArea = new Point(20, 4);
        public CommaTab()
        {
            _contextMenu = GetContextMenu();
            this.ItemSize = new Size(190, 30);
            this.Padding = new Point(20, 4);

        }
        private ContextMenuStrip GetContextMenu()
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();

            menuStrip.Items.Add("اغلاق", null, new EventHandler(Item_Clicked));
            menuStrip.Items.Add("اغلاق الكل", null, new EventHandler(CloseAll_Clicked));

            return menuStrip;
        }


        private void Item_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle rectangle = this.GetTabRect(i);

                if (rectangle.Contains(this.PointToClient(Cursor.Position)))
                {
                    this.TabPages.RemoveAt(i);
                }
            }
        }

        private void CloseAll_Clicked(object sender, EventArgs e)
        {
            this.TabPages.Clear();
            //for (int i = 0; i < this.TabCount; i++)
            //{
            //    //Rectangle rectangle = this.GetTabRect(i);


            //    this.TabPages.RemoveAt(i);

            //}
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Right)
            {
                _contextMenu.Show(Cursor.Position);
            }

        }
    }
}
