using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryTools
{
    public partial class PaymentTerms : Form
    {
        public PaymentTerms()
        {
            InitializeComponent();
        }
        DAL dal = new DAL();
        BAL bal = new BAL();
        private void PaymentTerms_Load(object sender, EventArgs e)
        {
            dgvPayterms.DataSource = dal.select_payterms();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BAL.Paymenttr = dgvPayterms.CurrentRow.Cells[0].Value.ToString();
            DataTable dt = dal.selectpaymentterms1();
            if (dt.Rows.Count == 0)
            {
                bal.Paymenttermsname = dgvPayterms.CurrentRow.Cells[0].Value.ToString();
                bal.Daysdue = int.Parse(dgvPayterms.CurrentRow.Cells[1].Value.ToString());
                dal.insertpayment(bal);
            }
            else
            {
                MessageBox.Show("Existing Paymenttermsname");
            }
            this.Hide();
  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
