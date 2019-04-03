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
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
        }
        DAL dal = new DAL();
        BAL bal = new BAL();
        private void Location_Load(object sender, EventArgs e)
        {
            dgvLocation.DataSource = dal.location();
        }

        private void btnLocCancl_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btnLocSave_Click(object sender, EventArgs e)
        {

            BAL.Loca = dgvLocation.CurrentRow.Cells[0].Value.ToString();
            DataTable dt = dal.selectloc1();
            if (dt.Rows.Count == 0)
            {
                bal.Locationname = dgvLocation.CurrentRow.Cells[0].Value.ToString();
                dal.insertlocation(bal);
            }
            else
            {
                MessageBox.Show("Existing Location");
            }
            this.Hide();

        
        }
    }
}
