using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryTools;
using System.IO;
//using RealTime_Project_Current_Stock;
namespace InventoryTools
{
    public partial class currentstock : Form
    {
       // internal currentstockbal customer { get; set; }
        public currentstock()
        {
            InitializeComponent();
        }
        DAL cs1 = new DAL();
        BAL bl = new BAL();
   
        private void currentstock_Load(object sender, EventArgs e)
        {
            ProductInfoorNewProduct info = new ProductInfoorNewProduct();
          
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView1.Visible = true;
         
            dataGridView1.DataSource = cs1.select111();
            dataGridView2.DataSource = cs1.select();
            dataGridView3.DataSource = cs1.location();
            dataGridView4.DataSource = cs1.selectItemCat();
            dataGridView1.DefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            panel1.BackColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView1.EnableHeadersVisualStyles = false;
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            dataGridView2.Columns.Add(link);
            link.HeaderText = "Details";
            link.Name = "item";
            link.Text = "view";
            link.UseColumnTextForLinkValue = true;
           
          }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DAL dal=new DAL();
            BAL bal = new BAL();

            if (dataGridView2.CurrentCell is DataGridViewLinkCell)
            {
                ProductInfoorNewProduct p = new ProductInfoorNewProduct();
                bal.Itemname = dataGridView2.CurrentRow.Cells["itemnameorcode"].Value.ToString();
          
                dal.select_products12(bal);
                p.txtItemname.Text = bal.Itemname;
                p.cboProductType.Text = bal.Type;
                p.cboProdctCategry.Text = bal.Category;
                p.txtPrdctDescptn.Text = bal.Description;
                p.txtPrdctNrmalPrice.Text = bal.Normalpeice;
                p.txtPrdctRetailPrice.Text = bal.Retailprice;
                p.txtPrdctWhlsale.Text = bal.Wholesaleprice;
                p.txtPrdctCost.Text = bal.Cost;
                p.txtPrdctYear.Text = bal.Year;
                p.txtPrdctModl.Text = bal.Model;
                byte[] imagedata = (byte[])bal.Picture;
                Image image;
                using (MemoryStream ms = new MemoryStream(imagedata))
                {
                    ms.Write(imagedata, 0, imagedata.Length);
                    image = Image.FromStream(ms);
                }
                p.pictureBox1.Image = image;
                p.lblQuant.Text = bal.Quantityonhand;
                p.txtPrdctBarcode.Text = bal.Barcode;
                p.txtPrdctReordrPoint.Text = bal.Reorderpoint;
                p.txtPrdctReordrQuant.Text = bal.Reorderquantity;
                p.cboPrdctDefLoc.Text = bal.DefaultLoc;
                p.cboPrdctLastVen.Text = bal.Lastvendor;
                p.cboPrdctStndrdUOM.Text = bal.Standarduom;
                p.cboPrdctStateUOM.Text = bal.Salesuom;
                p.cboPrdctPurchUOM.Text = bal.Purchasinguom;
                p.txtPrdctManufactur.Text = bal.Manufacturer;
                p.txtPrdctMadein.Text = bal.Madein;
                p.txtPrdctLenght.Text = bal.Lenght;
                p.txtPrdctWidth.Text = bal.Width;
                p.txtPrdctHight.Text = bal.Height;
                p.txtPrdctWeight.Text = bal.Weight;
                p.txtPrdctRemarks.Text = bal.Remarks;
                p.dgvMovementhistory.DataSource = null;
                p.dgvOrderHistory.DataSource = null;
                p.dgvMovementhistory.DataSource = dal.select_movementhistory(bal);
                p.dgvOrderHistory.DataSource = dal.select_orderhistory(bal);
                dataGridView2.Visible = false;
                p.btnOk.Visible = true;
                p.Show();
            }
         
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView2.DataSource = cs1.select();
            DataGridViewColumn column = dataGridView2.Columns[0];
            column.Width = 500;
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string location = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox2.Text = location;
            dataGridView3.Hide();
        }
        private void comboBox2_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            DataGridViewColumn column = dataGridView3.Columns[0];
            column.Width = 889;
        }
        private void currentstock_Click(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Hide();
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string location = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox3.Text = location;
            dataGridView4.Hide();
        }
        private void comboBox3_Click(object sender, EventArgs e)
        {
            dataGridView4.Visible = true;
            DataGridViewColumn column = dataGridView4.Columns[0];
            column.Width = 889;
        }
        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
            }
            else
            {
                bl.item = comboBox1.Text;
                string item = comboBox1.Text;
                DataTable dt = cs1.selectitemname(item);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    int a = comboBox1.SelectedIndex.CompareTo(-1);
                    if (a == 0)
                    {
                        dataGridView1.DataSource = dt;
                       
                    }
               
                }
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
              
            }
        }
        private void comboBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
            }
            else
            {
                bl.Location = comboBox2.Text;
                string location = comboBox2.Text;
                DataTable dt = cs1.selectloc(location);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                 
                    dataGridView1.DataSource = null;
                    int a = comboBox2.SelectedIndex.CompareTo(-1);
                    if (a == 0)
                    {
                        dataGridView1.DataSource = dt;
                       
                      }
                  
                }
                comboBox1.Text = string.Empty;
                comboBox3.Text = string.Empty;
            
            }
        }
        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
            }
            else
            {
                bl.Category = comboBox3.Text;
                string category = comboBox3.Text;
                DataTable dt2 = cs1.selectcotegory1(category);
                if (dt2.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt2;
                }
                else
                {
                    dataGridView1.DataSource = null;

                    int a = comboBox3.SelectedIndex.CompareTo(-1);
                    if (a == 0)
                    {
                        dataGridView1.DataSource = dt2;
                     
                    }
                 
                    }
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
              
                DataTable dt = cs1.selectall10();
                if (comboBox3.Text == "All")
                {
                  dataGridView1.DataSource = dt;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
             }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DAL dal = new DAL();
            BAL bal = new BAL();


           
                ProductInfoorNewProduct p = new ProductInfoorNewProduct();
                bal.Itemname = dataGridView1.CurrentRow.Cells[0].Value.ToString();
          
                dal.select_products12(bal);
                p.txtItemname.Text = bal.Itemname;
                p.cboProductType.Text = bal.Type;
                p.cboProdctCategry.Text = bal.Category;
                p.txtPrdctDescptn.Text = bal.Description;
                p.txtPrdctNrmalPrice.Text = bal.Normalpeice;
                p.txtPrdctRetailPrice.Text = bal.Retailprice;
                p.txtPrdctWhlsale.Text = bal.Wholesaleprice;
                p.txtPrdctCost.Text = bal.Cost;
                p.txtPrdctYear.Text = bal.Year;
                p.txtPrdctModl.Text = bal.Model;
                byte[] imagedata = (byte[])bal.Picture;
                Image image;
                using (MemoryStream ms = new MemoryStream(imagedata))
                {
                    ms.Write(imagedata, 0, imagedata.Length);
                    image = Image.FromStream(ms);
                }
                p.pictureBox1.Image = image;
                p.lblQuant.Text = bal.Quantityonhand;
                p.txtPrdctBarcode.Text = bal.Barcode;
                p.txtPrdctReordrPoint.Text = bal.Reorderpoint;
                p.txtPrdctReordrQuant.Text = bal.Reorderquantity;
                p.cboPrdctDefLoc.Text = bal.DefaultLoc;
                p.cboPrdctLastVen.Text = bal.Lastvendor;
                p.cboPrdctStndrdUOM.Text = bal.Standarduom;
                p.cboPrdctStateUOM.Text = bal.Salesuom;
                p.cboPrdctPurchUOM.Text = bal.Purchasinguom;
                p.txtPrdctManufactur.Text = bal.Manufacturer;
                p.txtPrdctMadein.Text = bal.Madein;
                p.txtPrdctLenght.Text = bal.Lenght;
                p.txtPrdctWidth.Text = bal.Width;
                p.txtPrdctHight.Text = bal.Height;
                p.txtPrdctWeight.Text = bal.Weight;
                p.txtPrdctRemarks.Text = bal.Remarks;
                p.dgvMovementhistory.DataSource = null;
                p.dgvOrderHistory.DataSource = null;
                p.dgvMovementhistory.DataSource = dal.select_movementhistory(bal);
                p.dgvOrderHistory.DataSource = dal.select_orderhistory(bal);
                dataGridView2.Visible = false;
                p.btnOk.Visible = true;
                p.Show();
       

        }
     }
 }
     
              
      

  