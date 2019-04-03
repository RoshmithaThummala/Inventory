using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using projectIntegration;
using System.IO;
using InventoryTools;

namespace ProductCategory
{
    public partial class AddNewNode : Form
    {
        BAL bal = new BAL();
        DAL dal = new DAL();

        Form1 f1 = new Form1();
        public AddNewNode()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Hide();
           // f1.Show();
            bal.CategoryNameC = textnewNode.Text;
            dal.CategoryInsert(bal);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
           // f1.Show();
            //textnewNode.Text = "";
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            //bal.CategNameC = f1.treeView1.SelectedNode.Text;
            //bal.CategoryNameC = textnewNode.Text;
            //dal.CategoryUpdate(bal);
            this.Hide();
        }

        private void AddNewNode_Load(object sender, EventArgs e)
        {

        }
    }
}
