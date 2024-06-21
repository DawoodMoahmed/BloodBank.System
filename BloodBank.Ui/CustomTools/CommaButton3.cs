using System;
using System.Drawing;
using System.Windows.Forms;

namespace BloodBank.Ui.CustomTools
{
    public partial class CommaButton3 : UserControl
    {
        //private Color activeButtonColor = Color.FromArgb(50, 58, 68);
        //private Color unActiveButtonColor = Color.FromArgb(50, 58, 99);
        private Color activeButtonColor = Color.FromArgb(50, 58, 99);
        //private Color activeButtonColor = Color.FromArgb(50, 58, 78);
        private Color unActiveButtonColor = Color.FromArgb(44, 50, 68);
        private bool isSelectd;

        public bool IsSelectd
        {
            get => isSelectd;
            set
            {
                if (value == true)
                {
                    commaButton1.BackColor = activeButtonColor;
                }
                else
                {
                    commaButton1.BackColor = unActiveButtonColor;
                }
                isSelectd = value;
            }

        }
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    title = value;
                    commaButton1.Text = value;
                }
                else
                {
                    title = "افتراضي";
                    commaButton1.Text = "افتراضي";
                }
            }
        }
        private Image icon;

        public Image Icon
        {
            get { return icon; }
            set
            {
                if (value is null)
                {
                    icon = Properties.Resources.info;

                }
                else
                {
                    commaButton1.Image = value;
                    icon = value;

                }
            }
        }


        private Action action1;
        public CommaButton3(string title, Image icon, Action action, bool isSelected = false)
        {
            InitializeComponent();
            Title = title;
            Icon = icon;
            action1 = action;
            IsSelectd = isSelected;
            commaButton1.Cursor = Cursors.Hand;

        }
        private void commaButton1_Click(object sender, EventArgs e)
        {
            action1.Invoke();
            IsSelectd = true;

        }
    }
}
