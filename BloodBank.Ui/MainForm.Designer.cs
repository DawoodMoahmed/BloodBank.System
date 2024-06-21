
namespace BloodBank.Ui
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commaButton1 = new BloodBank.Ui.CommaButton();
            this.panelButton1 = new BloodBank.Ui.PanelButton();
            this.SuspendLayout();
            // 
            // commaButton1
            // 
            this.commaButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.commaButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.commaButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.commaButton1.BorderRadius = 20;
            this.commaButton1.BorderSize = 0;
            this.commaButton1.FlatAppearance.BorderSize = 0;
            this.commaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commaButton1.ForeColor = System.Drawing.Color.White;
            this.commaButton1.HoverColor = System.Drawing.Color.PaleVioletRed;
            this.commaButton1.IsSelected = false;
            this.commaButton1.Location = new System.Drawing.Point(380, 130);
            this.commaButton1.Name = "commaButton1";
            this.commaButton1.SelectedBorderSize = 0;
            this.commaButton1.SelectedColor = System.Drawing.Color.PaleVioletRed;
            this.commaButton1.Size = new System.Drawing.Size(188, 50);
            this.commaButton1.TabIndex = 0;
            this.commaButton1.Text = "commaButton1";
            this.commaButton1.TextColor = System.Drawing.Color.White;
            this.commaButton1.UseVisualStyleBackColor = false;
            // 
            // panelButton1
            // 
            this.panelButton1.BackColor = System.Drawing.Color.White;
            this.panelButton1.BackgroundColor = System.Drawing.Color.White;
            this.panelButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.panelButton1.BorderRadius = 20;
            this.panelButton1.BorderSize = 3;
            this.panelButton1.ForeColor = System.Drawing.Color.White;
            this.panelButton1.HoverColor = System.Drawing.Color.PaleVioletRed;
            this.panelButton1.Location = new System.Drawing.Point(294, 233);
            this.panelButton1.Name = "panelButton1";
            this.panelButton1.Size = new System.Drawing.Size(334, 178);
            this.panelButton1.TabIndex = 1;
            this.panelButton1.TextColor = System.Drawing.Color.White;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelButton1);
            this.Controls.Add(this.commaButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CommaButton commaButton1;
        private PanelButton panelButton1;
    }
}