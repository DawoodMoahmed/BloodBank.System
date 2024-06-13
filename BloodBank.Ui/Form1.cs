using BloodBank.Core.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank.Ui
{
    public partial class Form1 : Form
    {
        private DonorApp app;
        public Form1()
        {
            InitializeComponent();
            app = new DonorApp();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
          var reslut = await  app.CreateAsync(new Core.Domain.Donor() { 
            
            
            });
        }
    }
}
