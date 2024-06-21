using System;
using System.Drawing;
using System.Windows.Forms;

namespace BloodBank.Ui.CustomTools
{
    public partial class CommaButton2 : UserControl
    {
        private Color activeSelectdColor = Color.FromArgb(255, 0, 66);
        private Color unActiveSelectdColor = Color.FromArgb(50, 58, 78);

        private Color activeButtonColor = Color.FromArgb(50, 58, 99);
        private Color unActiveButtonColor = Color.FromArgb(50, 58, 78);
        private bool isSelectd;

        public bool IsSelectd
        {
            get => isSelectd;
            set
            {
                if (value == true)
                {
                    commaButton1.BackColor = activeButtonColor;
                    activeButtonPanel.BackColor = activeSelectdColor;
                }
                else
                {
                    commaButton1.BackColor = unActiveButtonColor;
                    activeButtonPanel.BackColor = unActiveSelectdColor;
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

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        private bool havPermation;

        public bool HavPermation
        {
            get { return havPermation; }
            set
            {

                havPermation = value;
                commaButton1.Visible = value;

            }
        }


        private Action action1;
        public CommaButton2(string category, string title, Action action, bool havPermation, bool isSelected = false)
        {
            InitializeComponent();
            Category = category;
            Title = title;
            action1 = action;
            HavPermation = havPermation;
            commaButton1.Cursor = Cursors.Hand;

            IsSelectd = isSelected;
        }

        private void commaButton1_Click(object sender, EventArgs e)
        {
            action1.Invoke();
            IsSelectd = true;

        }
    }
}
