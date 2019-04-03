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
    public partial class Taxing : Form
    {
        public Taxing()
        {
            InitializeComponent();
        }
        SaleOrderWith_shipping_details s = new SaleOrderWith_shipping_details();
        DAL dal = new DAL();
        BAL bal = new BAL();
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            bal.Taxschemename = dgvAddTaxing.CurrentRow.Cells[0].Value.ToString();
            bal.Taxname = dgvAddTaxing.CurrentRow.Cells[1].Value.ToString();
            bal.Taxrate=dgvAddTaxing.CurrentRow.Cells[2].Value.ToString();
            var cbx = (DataGridViewCheckBoxCell)dgvAddTaxing.CurrentRow.Cells[3];
            if (cbx.Value != null && (bool)cbx.Value)
            {
                bal.Taxonshipping = "True";
            }
            else
            {
                bal.Taxonshipping = "False";
            }
            bal.Secondarytax = dgvAddTaxing.CurrentRow.Cells[4].Value.ToString();
            bal.Secondarytaxrate = dgvAddTaxing.CurrentRow.Cells[5].Value.ToString();
            var cbx1 = (DataGridViewCheckBoxCell)dgvAddTaxing.CurrentRow.Cells[6];
            if (cbx1.Value != null && (bool)cbx1.Value)
            {
                bal.Secondarytaxon = "True";
            }
            else
            {
                bal.Secondarytaxon = "False";
            }
            var cbx2 = (DataGridViewCheckBoxCell)dgvAddTaxing.CurrentRow.Cells[7];
            if (cbx2.Value != null && (bool)cbx2.Value)
            {
                bal.Compoondsecondary= "True";
            }
            else
            {
                bal.Compoondsecondary = "False";
            }
            dal.insert_taxing(bal);
           
        

            this.Hide();
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Taxing_Load(object sender, EventArgs e)
        {

        }
    }
}
