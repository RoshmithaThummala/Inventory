using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using productlistproject;
using InventoryTools;
using System.IO;


namespace InventoryTools
{
    public partial class Product_List : Form
    {
        BAL cs = new BAL();
        DAL cs1 = new DAL();
        public Product_List()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = cs1.select115();
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            panel2.Visible = false;

            DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
            dataGridView2.Columns.Add(dgvLink);
            dgvLink.HeaderText = "Details";
            dgvLink.Name = "SiteName";
            dgvLink.LinkColor = Color.Blue;
            dgvLink.Text = "View";
            dgvLink.UseColumnTextForLinkValue = true;

            dataGridView2.Visible = false;
            dt = cs1.selectgrid();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = dr["itemnameorcode"].ToString();
                dataGridView2.Rows[i].Cells[1].Value = dr["description"].ToString();
                dataGridView2.Rows[i].Cells[2].Value = dr["category"].ToString();
                dataGridView2.Rows[i].Cells[3].Value = dr["normalprice"].ToString();
            }

            dt = cs1.selectcategory();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["categoryname"]).ToString();
            }
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            panel2.Visible = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();    
            if (e.ColumnIndex == 4)
            {
                ProductInfoorNewProduct obj = new ProductInfoorNewProduct();
                obj.Show();
                cs.Itemname = comboBox2.Text;
                DataTable dt = new DataTable();
                dt = cs1.selectname(cs);
                if (dt.Rows.Count > 0)
                {
                    obj.txtItemname.Text = dt.Rows[0]["itemnameorcode"].ToString();
                    obj.cboProductType.Text = dt.Rows[0]["type"].ToString();
                    obj.cboProdctCategry.Text = dt.Rows[0]["category"].ToString();
                    obj.txtPrdctDescptn.Text = dt.Rows[0]["description"].ToString();
                    obj.txtPrdctNrmalPrice.Text = dt.Rows[0]["normalprice"].ToString();
                    obj.txtPrdctRetailPrice.Text = dt.Rows[0]["retailpreice"].ToString();
                    obj.txtPrdctWhlsale.Text = dt.Rows[0]["wholesaleprice"].ToString();
                    obj.txtPrdctCost.Text = dt.Rows[0]["cost"].ToString();
                    obj.txtPrdctYear.Text = dt.Rows[0]["year"].ToString();
                    obj.txtPrdctModl.Text = dt.Rows[0]["model"].ToString();
              
                    byte[] imagedata = (byte[])dt.Rows[0]["picture"];
                    Image image;
                    using (MemoryStream ms = new MemoryStream(imagedata))
                    {
                        ms.Write(imagedata, 0, imagedata.Length);
                        image = Image.FromStream(ms);
                    }
                    obj.pictureBox1.Image = image;
                    obj.txtPrdctBarcode.Text = dt.Rows[0]["barcode"].ToString();
                    obj.txtPrdctReordrPoint.Text = dt.Rows[0]["reorderpoint"].ToString();
                    obj.txtPrdctReordrQuant.Text = dt.Rows[0]["reorderquantity"].ToString();
                    obj.cboPrdctDefLoc.Text = dt.Rows[0]["location"].ToString();
                    obj.cboPrdctLastVen.Text = dt.Rows[0]["lastvendor"].ToString();
                    obj.cboPrdctStateUOM.Text = dt.Rows[0]["standarduom"].ToString();
                    obj.cboPrdctStateUOM.Text = dt.Rows[0]["salesuom"].ToString();
                    obj.cboPrdctPurchUOM.Text = dt.Rows[0]["purchasinguom"].ToString();
                    obj.txtPrdctManufactur.Text = dt.Rows[0]["manufacturer"].ToString();
                    obj.txtPrdctMadein.Text = dt.Rows[0]["madein"].ToString();
                    obj.txtPrdctLenght.Text = dt.Rows[0]["length"].ToString();
                    obj.txtPrdctHight.Text = dt.Rows[0]["height"].ToString();
                    obj.txtPrdctWidth.Text = dt.Rows[0]["width"].ToString();
                    obj.txtPrdctWeight.Text = dt.Rows[0]["weight"].ToString();
                    obj.txtPrdctRemarks.Text = dt.Rows[0]["remarks"].ToString();
                    
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            dataGridView1.Columns[0].Visible = false;
            cs.Description = textBox2.Text;
            DataTable dt = new DataTable();
            dt = cs1.selectdesc(cs);
            dataGridView1.DataSource = dt;

            comboBox3.ResetText();
            comboBox4.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            
            cs.Itemname = comboBox2.Text;
            DataTable dt = new DataTable();
            dt = cs1.selectitem(cs);           
            dataGridView1.DataSource = dt;

            comboBox3.ResetText();
            comboBox4.ResetText();
            textBox2.Clear();
            comboBox1.ResetText();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
            cs.Category = comboBox1.Text;
            DataTable dt = new DataTable();
            dt = cs1.selectcattext(cs);          
            dataGridView1.DataSource = dt;

            comboBox3.ResetText();
            comboBox4.ResetText();
            textBox2.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            cs.Type = comboBox3.Text;
            DataTable dt = new DataTable();
            dt = cs1.selecttypetext(cs);            
            dataGridView1.DataSource = dt;

            comboBox1.ResetText();
            comboBox4.ResetText();
            textBox2.Clear();
            comboBox2.ResetText();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.ResetText();
            comboBox1.ResetText();
            textBox2.Clear();
            comboBox2.ResetText();
            
            cs.Status1 = comboBox4.Text;
            DataTable dt = new DataTable();
            dt = cs1.selectactive(cs);
            if (comboBox4.Text == "Active")
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.DataSource = dt;
            }
            if (comboBox4.Text == "Inactive") 
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.DataSource = dt;
            }
            
            if(comboBox4.Text=="ShowAll")
            {
                dt = cs1.select115();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = true;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    chk.TrueValue = CheckState.Checked;
                    chk.FalseValue = CheckState.Unchecked;
                    cs.Status1 = Convert.ToString(dataGridView1.Rows[i].Cells[11].Value);
                    if (cs.Status1 == "Active")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = chk.TrueValue;
                    }
                    else if (cs.Status1 == "Inactive")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = chk.FalseValue;
                    }
                }
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();          
            dataGridView2.Visible = false;
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductInfoorNewProduct obj1 = new ProductInfoorNewProduct();
            obj1.Show();
            panel2.Visible = false;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void Product_List_Load(object sender, EventArgs e)
        {

        }

    }
}
