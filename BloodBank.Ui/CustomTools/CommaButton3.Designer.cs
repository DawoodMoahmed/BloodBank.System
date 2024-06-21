using System.Drawing;
using System.Windows.Forms;

namespace BloodBank.Ui.CustomTools
{
    partial class CommaButton3
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            commaButton1 = new CommaButton();
            SuspendLayout();
            // 
            // commaButton1
            // 
            commaButton1.BackColor = Color.FromArgb(44, 50, 68);
            commaButton1.BackgroundColor = Color.FromArgb(44, 50, 68);
            commaButton1.BorderColor = Color.PaleVioletRed;
            commaButton1.BorderRadius = 0;
            commaButton1.BorderSize = 0;
            commaButton1.FlatAppearance.BorderSize = 0;
            commaButton1.FlatStyle = FlatStyle.Flat;
            commaButton1.Font = new Font("Tajawal", 9F);
            commaButton1.ForeColor = Color.White;
            commaButton1.HoverColor = Color.FromArgb(255, 0, 66);
            commaButton1.Image = Properties.Resources.Services;
            commaButton1.ImageAlign = ContentAlignment.TopCenter;
            commaButton1.IsSelected = false;
            commaButton1.Location = new Point(0, 0);
            commaButton1.Margin = new Padding(3, 3, 3, 5);
            commaButton1.Name = "commaButton1";
            commaButton1.SelectedBorderSize = 0;
            commaButton1.SelectedColor = Color.PaleVioletRed;
            commaButton1.Size = new Size(73, 66);
            commaButton1.TabIndex = 7;
            commaButton1.Text = "شؤون الموظفين";
            commaButton1.TextAlign = ContentAlignment.BottomCenter;
            commaButton1.TextColor = Color.White;
            commaButton1.UseVisualStyleBackColor = false;
            commaButton1.Click += commaButton1_Click;
            // 
            // CommaButton3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(commaButton1);
            Name = "CommaButton3";
            Size = new Size(73, 66);
            ResumeLayout(false);
        }

        #endregion

        private CommaButton commaButton1;
    }
}
