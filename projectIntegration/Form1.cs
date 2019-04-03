using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using InventoryTools;

namespace ProductCategory
{
    public partial class Form1 : Form
    {
        DAL dal = new DAL();
        BAL bal = new BAL();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project;User ID=sa;Password=abc");
        TreeNode mainNode = new TreeNode();
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainNode.Name = "mainNode";
            mainNode.Text = "Product Categories";
            this.treeView1.Nodes.Add(mainNode);
            dt = dal.TviewParent();
            foreach (DataRow dr in dt.Rows)
            {
                mainNode = treeView1.Nodes[0].Nodes.Add(dr["categoryName"].ToString());
                treeView1.ExpandAll();
                PopulateTreeView(dr["categoryName"].ToString(), mainNode);
            }

            //**********************Adding contextMenuStrip to TreeView

            treeView1.ContextMenuStrip = ContextMenu1;
            foreach (TreeNode RootNode in treeView1.Nodes)
            {
                RootNode.ContextMenuStrip = ContextMenu1;
            }
            this.BackColor = ColorTranslator.FromHtml("#80dfff");
            panel3.BackColor = ColorTranslator.FromHtml("#f2f2f2");

            dgvProduct.BackgroundColor = ColorTranslator.FromHtml(" #e5faff");
            dgvProduct.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e5ffe5");
            dgvProduct.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#b3ffd9");
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#33ccff");
            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProduct.Font, FontStyle.Bold);
            dgvProduct.EnableHeadersVisualStyles = false;
        }

        private void PopulateTreeView(string categoryName, TreeNode mainNode)
        {
            String Seqchildc = "SELECT itemnameorcode FROM products WHERE category='"+categoryName+"'";
            SqlDataAdapter dachildmnuc = new SqlDataAdapter(Seqchildc, con);
            DataTable dtchildc = new DataTable();
            dachildmnuc.Fill(dtchildc);
            TreeNode childNode;
            foreach (DataRow dr in dtchildc.Rows)
            {
                if (mainNode == null)
                    childNode = treeView1.Nodes[0].Nodes.Add(dr["itemnameorcode"].ToString());
                    
                else
                    childNode = mainNode.Nodes.Add(dr["itemnameorcode"].ToString());
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dgvProduct.DataSource = null;
            dgvProduct.Rows.Clear();

            bal.CategoryC=treeView1.SelectedNode.Text;
            dt = dal.CategoryRetrieve(bal);
         
            foreach(DataRow dr in dt.Rows)
            {
                int i = dgvProduct.Rows.Add();
                dgvProduct.Rows[i].Cells[0].Value = dt.Rows[i]["itemnameorcode"].ToString();
                dgvProduct.Rows[i].Cells[1].Value = dt.Rows[i]["description"].ToString();
                dgvProduct.Rows[i].Cells[2].Value = dt.Rows[i]["normalprice"].ToString();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewNode frm = new AddNewNode();
            frm.btnupdate.Visible = false;
            frm.ShowDialog();
            string TempNodeText = frm.textnewNode.Text;
            frm.Dispose();
            if (!string.IsNullOrEmpty(TempNodeText.Trim()))
            {
                TreeNode Node = new TreeNode();
                Node.Text = TempNodeText;
                treeView1.Nodes[0].Nodes.Add(Node);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            bal.CategNameC = treeView1.SelectedNode.Text;
            AddNewNode fm = new AddNewNode();
            fm.btnok.Visible = false;
            fm.btnupdate.Location = new Point(85, 93);
            fm.btnupdate.Visible = true;
            fm.textnewNode.Text = bal.CategNameC;
            fm.ShowDialog();
            string TempNodeText = fm.textnewNode.Text;
            fm.Dispose();
            TreeNode SelectedNode = treeView1.SelectedNode;
            if (!string.IsNullOrEmpty(TempNodeText.Trim()))
            {
                SelectedNode.Text = TempNodeText;
            }
        
            bal.CategoryNameC = fm.textnewNode.Text;
            dal.CategoryUpdate(bal);
         
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bal.CategoryNameC = mainNode.Text;
            dal.CategoryDelete(bal);
            treeView1.SelectedNode.Remove();
        }

    
        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //          bal.CategoryNameC = treeView1.SelectedNode.Text;
            //bal.CategNameC = node.Text;
            //dal.CategoryUpdate(bal);
        }
      
        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                bal.CategoryNameC = treeView1.SelectedNode.Text;
                //bal.CategoryNameC = fm.textnewNode.Text;
                dal.CategoryUpdate(bal);
            }
        }
    }
}
