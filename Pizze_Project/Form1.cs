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
    public partial class Form1 : Form
    {
        stOrder Order;
        public Form1()
        {
            InitializeComponent();
        }
         struct stOrder {
            public string _Toppings;
            public string _Size;
            public string _CrustType;
            public string _WhereToEat;
            public string _TotalPrice;
        }
        
        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }
            else if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium.Tag);
            }
            else
                return Convert.ToSingle(rbLarge.Tag);
        }
        float CalcuteToppingsPrice()
        {
            float ToppingsTotalPrice = 0;
            if (chkExtra_cheese.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkExtra_cheese.Tag);

            }
            if (chkGreen_Papper.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkGreen_Papper.Tag);
            }
            if (chkMushrooms.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }
            if (chkOnion.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            }
            if (chkOlives.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);

            }
            if (chkTomatoes.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);
            }
            return ToppingsTotalPrice;
        }
        float GetSelectedCrutPrice()
        {
            if (rbThin.Checked)
            {
                return Convert.ToSingle(rbThin.Tag);
            }
            else
                return Convert.ToSingle(rbThick.Tag);
        }
        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalcuteToppingsPrice() + GetSelectedCrutPrice();
        }
        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "₪" + CalculateTotalPrice().ToString();
        }
        void UpdateSize()
        {
            UpdateTotalPrice();
            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }
            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }
            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";
            if (chkExtra_cheese.Checked)
            {
                sToppings = "Extra Chees";
                
            }
            if (chkOnion.Checked)
            {
                sToppings += ", Onion";

            }
            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";

            }
            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }
            if (chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }
            if (chkGreen_Papper.Checked)
            {
                sToppings += ", Green Papper";     
            }
            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            }
            if (sToppings == "")
            {
                sToppings = "No Toppings";
            }
            lblToppings.Text = sToppings;
        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThin.Checked)
            {
                lblCrust.Text = "Think Crust";
                return;
            }

            else
            {
                lblCrust.Text = "Thick Crust";
                return;
            }
        }
        void UpdateWhereToEat()
        {
            if (rbEat_In.Checked)
            {
                lblWhereToEat.Text = "Eat In.";
                return;
            }

            else
            {
                lblWhereToEat.Text = "Take Out.";
                return;
            }
        }
        void ResetForm()
        {

            //reset Groups
            btnOrderPizza.Enabled = true;
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbOrderSummary.Enabled = true;
            gbquestion.Enabled = true;
            gbCrustType.Enabled = true;

            //reset Size
            rbMedium.Checked = true;

            //reset Toppings.
            chkExtra_cheese.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreen_Papper.Checked = false;

            //reset CrustType
            rbThin.Checked = true;

            //reset Where to Eat
            rbEat_In.Checked = true;

            //Reset Order Button
            btnOrderPizza.Enabled = true;

        }
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateCrust();
            UpdateToppings();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rbMedium.Checked = true;
            rbThin.Checked = true;
            rbEat_In.Checked = true;
            UpdateOrderSummary();
        }
      
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbOrderSummary.Enabled = false;
                gbquestion.Enabled = false;
                gbCrustType.Enabled = false;

            }
            else
            MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ResetForm(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void chkExtra_cheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreen_Papper_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void gbOrderSummary_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbTake_Out_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gbSize_Enter(object sender, EventArgs e)
        {

        }

        private void rbLarge_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbSmall_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void chkExtra_cheese_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreen_Papper_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbThin_CheckedChanged_1(object sender, EventArgs e)
        {
             UpdateCrust();
        }

        private void rbThick_CheckedChanged_1(object sender, EventArgs e)
        {
             UpdateCrust();
        }

        private void rbEat_In_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTake_Out_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }
         
        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            Order._Size = lblSize.Text;
            Order._Toppings = lblToppings.Text;
            Order._TotalPrice = lblTotalPrice.Text;
            Order._WhereToEat = lblWhereToEat.Text;
            Order._CrustType = lblCrust.Text;
            if (MessageBox.Show("Confirm Order", "Confirm",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                OrderSummary FormOrderSummary = new OrderSummary(Order._Size, Order._Toppings, Order._CrustType, Order._WhereToEat, Order._TotalPrice);
                FormOrderSummary.ShowDialog();
                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbquestion.Enabled = false;

            }
            else

                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm(); 
        }
    }
}
