using System.Drawing;
using System.Windows.Forms;

namespace BloodBank.Ui.CustomTools
{
    partial class CommaButton2
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
            activeButtonPanel = new Panel();
            SuspendLayout();
            // 
            // commaButton1
            // 
            commaButton1.BackColor = Color.FromArgb(50, 58, 99);
            commaButton1.BackgroundColor = Color.FromArgb(50, 58, 99);
            commaButton1.BorderColor = Color.PaleVioletRed;
            commaButton1.BorderRadius = 0;
            commaButton1.BorderSize = 0;
            commaButton1.Dock = DockStyle.Left;
            commaButton1.FlatAppearance.BorderSize = 0;
            commaButton1.FlatStyle = FlatStyle.Flat;
            commaButton1.Font = new Font("Tajawal", 9F);
            commaButton1.ForeColor = Color.White;
            commaButton1.HoverColor = Color.FromArgb(255, 0, 66);
            commaButton1.IsSelected = false;
            commaButton1.Location = new Point(0, 0);
            commaButton1.Margin = new Padding(3, 3, 3, 5);
            commaButton1.Name = "commaButton1";
            commaButton1.SelectedBorderSize = 0;
            commaButton1.SelectedColor = Color.PaleVioletRed;
            commaButton1.Size = new Size(189, 40);
            commaButton1.TabIndex = 1;
            commaButton1.Text = "صلاحيات المستخدمين";
            commaButton1.TextColor = Color.White;
            commaButton1.UseVisualStyleBackColor = false;
            commaButton1.Click += commaButton1_Click;
            // 
            // activeButtonPanel
            // 
            activeButtonPanel.BackColor = Color.FromArgb(255, 0, 66);
            activeButtonPanel.Dock = DockStyle.Right;
            activeButtonPanel.Location = new Point(189, 0);
            activeButtonPanel.Name = "activeButtonPanel";
            activeButtonPanel.Size = new Size(5, 40);
            activeButtonPanel.TabIndex = 2;
            // 
            // CommaButton2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(activeButtonPanel);
            Controls.Add(commaButton1);
            Name = "CommaButton2";
            Size = new Size(194, 40);
            ResumeLayout(false);
        }

        #endregion

        private CommaButton commaButton1;
        private Panel activeButtonPanel;
    }
}
