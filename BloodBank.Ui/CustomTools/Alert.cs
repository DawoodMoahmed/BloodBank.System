using Comma.Winform.Enums;
using BloodBank.Ui.Properties;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace BloodBank.Ui
{
    public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
        }

        public AlertAction action;
        private void CloseButton_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = AlertAction.Close;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case AlertAction.Wait:
                    timer1.Interval = 5000;
                    action = AlertAction.Close;
                    break;
                case AlertAction.Start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = AlertAction.Wait;
                        }
                    }
                    break;
                case AlertAction.Close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
            //switch (this.action)
            //{
            //    case AlertAction.Wite:
            //        timer1.Interval = 10000;
            //        action = AlertAction.Close;
            //        break;
            //    case AlertAction.Start:
            //        timer1.Interval = 1;
            //        this.Opacity += 0.1;
            //        if (this.x < this.Location.X)
            //        {
            //            this.Left--;
            //        }
            //        else
            //        {
            //            if (this.Opacity == 1.0)
            //            {
            //                action = AlertAction.Wite;
            //            }
            //        }
            //        break;
            //    case AlertAction.Close:
            //        timer1.Interval = 1;
            //        this.Opacity -= 0.1;

            //        this.Left -= 3;
            //        if (base.Opacity == 0.0)
            //        {
            //            this.Close();
            //        }
            //        break;

            //}
        }

        private int x, y;
        public void ShowAlert(string msg, AlertType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Alert frm = (Alert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case AlertType.Success:
                    this.pictureBox1.Image = Resources.ok;
                    this.BackColor = Color.SeaGreen;
                    break;
                case AlertType.Error:
                    this.pictureBox1.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case AlertType.Info:
                    this.pictureBox1.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case AlertType.Warning:
                    this.pictureBox1.Image = Resources.info;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.MessageText.Text = msg;

            this.Show();
            this.action = AlertAction.Start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        public void Success(string mesage)
        {
            ShowAlert(mesage, AlertType.Success);
        }

        public void Info(string mesage)
        {
            ShowAlert(mesage, AlertType.Info);
        }

        public void Error(string mesage)
        {
            ShowAlert(mesage, AlertType.Error);
        }

        public void Warning(string mesage)
        {
            ShowAlert(mesage, AlertType.Warning);
        }
        //public void ShowAlert(string mesage)
        //{
        //    this.Opacity = 0.0;
        //    this.StartPosition = FormStartPosition.Manual;

        //    string formName;

        //    for (int i = 0; i < 10; i++)
        //    {
        //        formName = $"alert{i}";
        //        Alert form = (Alert)Application.OpenForms[formName];

        //        if (form == null)
        //        {
        //            this.Name = formName;
        //            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;

        //            this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
        //            this.Location = new System.Drawing.Point(this.x, this.y);
        //            break;
        //        }
        //    }

        //    this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

        //    this.MessageText.Text = mesage;
        //    this.Show();
        //    this.Action = AlertAction.Start;
        //    this.timer1.Interval = 1;
        //    this.timer1.Start();

        //}
    }
}
