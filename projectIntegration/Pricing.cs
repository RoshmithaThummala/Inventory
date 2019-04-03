using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryTools;

namespace InventoryTools
{
    public partial class Pricing : Form
    {
        public Pricing()
        {
            InitializeComponent();
        }
       
        BAL bal = new BAL();
        DAL dal = new DAL();
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            BAL.Pricing = dgvPricingAdd.CurrentRow.Cells[1].Value.ToString();
            DataTable dt = dal.selectpricing();
            if (dt.Rows.Count == 0)
            {
                bal.Seno = dgvPricingAdd.CurrentRow.Cells[0].Value.ToString();
                bal.Pricingname = dgvPricingAdd.CurrentRow.Cells[1].Value.ToString();
                bal.Currency = dgvPricingAdd.CurrentRow.Cells[2].Value.ToString();
                dal.insert_pricing(bal);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Existing Pricing/Currency");
            }
           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Pricing_Load(object sender, EventArgs e)
        {

        }
    }
}
