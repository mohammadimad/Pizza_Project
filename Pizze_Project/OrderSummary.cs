using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizze_Project
{
    public partial class OrderSummary : Form
    {
        public OrderSummary(string _Size,string _Toppings, string _CrustType, string _WhereToEat, string _TotalPrice)
        {
            InitializeComponent();
            lblSize.Text = _Size;
            lblToppings.Text = _Toppings;
            lblCrustType.Text = _CrustType;
            lblWheretoEat.Text = _WhereToEat;
            lblPrice.Text = _TotalPrice;
        }

        private void OrderSummary_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(22, 22, 22);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(22, 22, 22);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(135, 63, 44);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           // BackColor = Color.FromArgb(135, 63, 44);
            ForeColor = Color.FromArgb(135, 63, 44);
        }
    }
}
