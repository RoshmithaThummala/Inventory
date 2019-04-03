using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ProductCategory;

namespace InventoryTools
{
    public partial class ProductInfoorNewProduct : Form
    {
        DAL dal = new DAL();
        BAL bal = new BAL();

        DataGridView dgvLoc = new DataGridView();
        Panel pnlLoc = new Panel();
        Label lblLoc = new Label();

        DataGridView dgvVendor = new DataGridView();
        Panel pnlVendor = new Panel();
        Label lblAdd = new Label();
        TextBox txtAdd = new TextBox();
        Button btnAdd = new Button();

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }

        }

        private void Enable(Control con)
        {
            foreach (Control c in con.Controls)
            {
                Enable(c);
            }
            con.Enabled = true;
        }

        public ProductInfoorNewProduct()
        {
            InitializeComponent();

            pnlLocation.Visible = false;
            pnlMLoc.Visible = false;

            dgvMLoc.DataSource = dal.Selectloc();
            DataTable dt = new DataTable();
            dt = dal.selectItemCat();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    cboProdctCategry.Items.Add("<Add New...>");
                }
                cboProdctCategry.Items.Add(dt.Rows[i].ItemArray[0]);
            }

            dt = dal.bindtranstype();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboTransType.Items.Add(dt.Rows[i].ItemArray[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bal.Itemname = txtItemname.Text;
                bal.Type = cboProductType.Text;
                bal.Category = cboProdctCategry.Text;
                bal.Description = txtPrdctDescptn.Text;
                bal.Normalpeice = txtPrdctNrmalPrice.Text;
                bal.Retailprice = txtPrdctRetailPrice.Text;
                bal.Wholesaleprice = txtPrdctWhlsale.Text;
                bal.Cost = txtPrdctCost.Text;
                bal.Year = txtPrdctYear.Text;
                bal.Model = txtPrdctModl.Text;
                byte[] image = Readfile(txtbrowse.Text);
                bal.Picture = (object)image;
                bal.Quantityonhand = lblQuant.Text;
                bal.Barcode = txtPrdctBarcode.Text;
                bal.Reorderpoint = txtPrdctReordrPoint.Text;
                bal.Reorderquantity = txtPrdctReordrQuant.Text;
                bal.DefaultLoc = cboPrdctDefLoc.Text;
                bal.Lastvendor = cboPrdctLastVen.Text;
                bal.Standarduom = cboPrdctStndrdUOM.Text;
                bal.Salesuom = cboPrdctStateUOM.Text;
                bal.Purchasinguom = cboPrdctPurchUOM.Text;
                bal.Manufacturer = txtPrdctManufactur.Text;
                bal.Madein = txtPrdctMadein.Text;
                bal.Lenght = txtPrdctLenght.Text;
                bal.Width = txtPrdctWidth.Text;
                bal.Height = txtPrdctHight.Text;
                bal.Weight = txtPrdctWeight.Text;
                bal.Remarks = txtPrdctRemarks.Text;
                if (btnDeactive.Text == "Deactive")
                    bal.Status1 = "Deative";
                else
                    bal.Status1 = "Active";
               
                for (int i = 0; i < dgvPrdct.RowCount - 1; i++)
                {
                    bal.Iiname = txtItemname.Text;
                    bal.Loc = dgvPrdct.Rows[i].Cells[0].Value.ToString();
                    bal.Quantity = dgvPrdct.Rows[i].Cells[1].Value.ToString();
                    bal.Idate1 = dgvPrdct.Rows[i].Cells[2].Value.ToString();
                    dal.ProductLocationInsert(bal);
                }
                
                dal.insert_products(bal);
                MessageBox.Show("Product Details Saved Successfully");
                this.Hide();
                this.Show();
                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            btnNew_Click(null, null);
        }

        byte[] Readfile(string pat)
        {
            byte[] data = null;
            FileInfo fi = new FileInfo(pat);
            FileStream fs = new FileStream(pat, FileMode.Open, FileAccess.Read);
            long numBytes = fi.Length;
            BinaryReader br = new BinaryReader(fs);
            data = br.ReadBytes((int)numBytes);
            return data;


        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ProductInfoorNewProduct pn = new ProductInfoorNewProduct();
            btnOk.Visible = false;
            btnSave.Visible = true;
            pn.Show();
            this.Dispose(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
         
        }

        private void txtSrchname_TextChanged(object sender, EventArgs e)
        {
            txtSrchCode.Text = String.Empty;
            cboSrchDescptn.Text = String.Empty;
            dgvSrchPrdct.Rows.Clear();
            
            bal.Itemcode = txtSrchname.Text;
            DataTable dt=dal.select_products1(bal);
            foreach (DataRow d in dt.Rows)
            {
                int i = dgvSrchPrdct.Rows.Add();
                dgvSrchPrdct.Rows[i].Cells[1].Value = d["category"].ToString();
                dgvSrchPrdct.Rows[i].Cells[2].Value = d["itemnameorcode"].ToString();
                dgvSrchPrdct.Rows[i].Cells[0].Value = d["productid"].ToString();
            }
        }

        private void ProductInfoorNewProduct_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#0094f9");
            panel3.BackColor = ColorTranslator.FromHtml("#b8e4ff");
            dgvPrdct.ForeColor = ColorTranslator.FromHtml("#000000");
            dgvSrchPrdct.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d9f4ff");
            dgvSrchPrdct.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#cceeff");
            dgvSrchPrdct.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
            DataTable dt = dal.select_products_main();
            foreach (DataRow d in dt.Rows)
            {
                int i = dgvSrchPrdct.Rows.Add();
                dgvSrchPrdct.Rows[i].Cells[1].Value = d["category"].ToString();
                dgvSrchPrdct.Rows[i].Cells[2].Value = d["itemnameorcode"].ToString();
                dgvSrchPrdct.Rows[i].Cells[0].Value = d["productid"].ToString();
            }
        }

        private void txtSrchCode_TextChanged(object sender, EventArgs e)
        {
            txtSrchname.Text = String.Empty;
            cboSrchDescptn.Text = String.Empty;
          
            dgvSrchPrdct.Rows.Clear();
           
            bal.Barcode = txtSrchCode.Text;
            DataTable dt= dal.select_products_barcode(bal);
            foreach (DataRow d in dt.Rows)
            {
                int i = dgvSrchPrdct.Rows.Add();
                dgvSrchPrdct.Rows[i].Cells[1].Value = d["category"].ToString();
                dgvSrchPrdct.Rows[i].Cells[2].Value = d["itemnameorcode"].ToString();
                dgvSrchPrdct.Rows[i].Cells[0].Value = d["productid"].ToString();
            }
        }

        private void cboSrchDescptn_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtSrchname.Text = String.Empty;
            txtSrchCode.Text = String.Empty;
                dgvSrchPrdct.Rows.Clear();
            bal.Category = cboSrchDescptn.Text;
            DataTable dt = dal.select_products_description(bal);
            foreach (DataRow d in dt.Rows)
            {

                int i = dgvSrchPrdct.Rows.Add();
                dgvSrchPrdct.Rows[i].Cells[1].Value = d["category"].ToString();
                dgvSrchPrdct.Rows[i].Cells[2].Value = d["itemnameorcode"].ToString();
                dgvSrchPrdct.Rows[i].Cells[0].Value = d["productid"].ToString();
            }

        }

        private void cboSrchDescptn_TextChanged(object sender, EventArgs e)
        {
           
            
          
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSrchCode.Text = String.Empty;
            txtSrchname.Text = String.Empty;
            cboSrchDescptn.Text = String.Empty;
            dgvSrchPrdct.Rows.Clear();
            DataTable dt = dal.select_products_main();
            foreach (DataRow d in dt.Rows)
            {
                int i = dgvSrchPrdct.Rows.Add();
                dgvSrchPrdct.Rows[i].Cells[1].Value = d["category"].ToString();
                dgvSrchPrdct.Rows[i].Cells[2].Value = d["itemnameorcode"].ToString();
                dgvSrchPrdct.Rows[i].Cells[0].Value = d["productid"].ToString();
            }
        }

        private void dgvSrchPrdct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bal.Itemname = dgvSrchPrdct.CurrentRow.Cells[2].Value.ToString();
                bal.Sno1 = Convert.ToInt32(dgvSrchPrdct.CurrentRow.Cells[0].Value.ToString());
                dal.select_products(bal);
                txtItemname.Text = bal.Itemname;
                cboProductType.Text = bal.Type;
                cboProdctCategry.Text = bal.Category;
                txtPrdctDescptn.Text = bal.Description;
                txtPrdctNrmalPrice.Text = bal.Normalpeice;
                txtPrdctRetailPrice.Text = bal.Retailprice;
                txtPrdctWhlsale.Text = bal.Wholesaleprice;
                txtPrdctCost.Text = bal.Cost;
                txtPrdctYear.Text = bal.Year;
                txtPrdctModl.Text = bal.Model;
                byte[] imagedata = (byte[])bal.Picture;
                Image image;
                using (MemoryStream ms = new MemoryStream(imagedata))
                {
                    ms.Write(imagedata, 0, imagedata.Length);
                    image = Image.FromStream(ms);
                }
                pictureBox1.Image = image;
                dgvPrdct.Rows.Clear();
                dgvPrdct.Rows[0].Cells[0].Value = bal.DefaultLoc;
                dgvPrdct.Rows[0].Cells[1].Value = bal.Quantityonhand;
                dgvPrdct.Enabled = false;
                lblQuant.Text = bal.Quantityonhand;
                txtPrdctBarcode.Text = bal.Barcode;
                txtPrdctReordrPoint.Text = bal.Reorderpoint;
                txtPrdctReordrQuant.Text = bal.Reorderquantity;
                cboPrdctDefLoc.Text = bal.DefaultLoc;
                cboPrdctLastVen.Text = bal.Lastvendor;
                cboPrdctStndrdUOM.Text = bal.Standarduom;
                cboPrdctStateUOM.Text = bal.Salesuom;
                cboPrdctPurchUOM.Text = bal.Purchasinguom;
                txtPrdctManufactur.Text = bal.Manufacturer;
                txtPrdctMadein.Text = bal.Madein;
                txtPrdctLenght.Text = bal.Lenght;
                txtPrdctWidth.Text = bal.Width;
                txtPrdctHight.Text = bal.Height;
                txtPrdctWeight.Text = bal.Weight;
                txtPrdctRemarks.Text = bal.Remarks;
                
                btnDeactive.Text = bal.Status1;

                if (btnDeactive.Text == "Deactive")
                {
                    DisableControls(tabPage1);
                    EnableControls(btnDeactive);
                    btnDeactive.Text = "Active";
                }
                else
                {
                    Enable(this);
                    btnDeactive.Text = "Deactive";
                }
                btnOk.Visible = true;

                dgvMovementhistory.DataSource = null;
                dgvOrderHistory.DataSource = null;
                bal.Itemname = dgvSrchPrdct.CurrentRow.Cells[2].Value.ToString();
                dgvMovementhistory.DataSource = dal.select_movementhistory(bal);
                dgvOrderHistory.DataSource = dal.select_orderhistory(bal);

            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Data doesn't inserted properly");
            }
            }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open File";
            dlg.Filter = "All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlg.FileName);
                txtbrowse.Text = dlg.FileName;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            pnlLocation.Visible = false;
        }

        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            txtbrowse.Clear();
        }

        private void dgvPrdct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                pnlLocation.Location = dgvPrdct.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                int x = pnlLocation.Location.X;
                int y = pnlLocation.Location.Y;
                int nx = x + 5;
                int ny = y + 40;
                pnlLocation.Location = new Point(nx, ny);
                pnlLocation.Visible = true;
                pnlLocation.BorderStyle = BorderStyle.FixedSingle;
                pnlLocation.BringToFront();

                dgvLocation.DataSource = dal.Selectloc();
            }
        }

        private void dgvLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int i = dgvPrdct.Rows.Add();
                dgvPrdct.Rows[i].Cells[0].Value = dgvLocation.CurrentRow.Cells[0].Value;
                
                pnlLocation.Visible = false;
            }
        }

        private void lblLocAdd_Click(object sender, EventArgs e)
        {
            Location loc = new Location();
            loc.Show();
            pnlLocation.Visible = false;
        }

        private void dgvPrdct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int a = 0;
            int t = 0;
            if (e.ColumnIndex == dgvPrdct.CurrentRow.Cells[1].ColumnIndex)
            {
                for (int i = 0; i < dgvPrdct.RowCount - 1; i++)
                {
                    a = int.Parse(dgvPrdct.Rows[i].Cells[1].Value.ToString());
                    t = t + a;
                    lblQuant.Text = t.ToString();
                }
            }
        }

        private void cboProdctCategry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProdctCategry.Text == "<Add New...>")
            {
                Form1 f = new Form1();
           
                f.Show();
            }
        }

        private void cboPrdctDefLoc_Click(object sender, EventArgs e)
        {
            pnlLoc.Visible = true;
            dgvLoc.Visible = true;
            pnlLoc.Location = new Point(106, 122);
            pnlLoc.BackColor = Color.White;
            tabPage2.Controls.Add(pnlLoc);
            pnlLoc.Size = new Size(180, 140);
            pnlLoc.BorderStyle = BorderStyle.FixedSingle;

            pnlLoc.Controls.Add(dgvLoc);
            pnlLoc.BringToFront();
            dgvLoc.Size = new Size(180, 100);
            dgvLoc.DataSource = dal.Selectloc();
            dgvLoc.ReadOnly = true;
     

            dgvLoc.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e0e0e0");
            dgvLoc.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLoc.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");

            DataGridViewColumn col = dgvLoc.Columns[0];
            col.Width = 120;

            this.Cursor = Cursors.Hand;

            dgvLoc.CellClick -= new DataGridViewCellEventHandler(dgvLoc_Click);
            dgvLoc.CellClick += new DataGridViewCellEventHandler(dgvLoc_Click);
            lblLoc.Click -= new EventHandler(lblLoc_Click);
            lblLoc.Click += new EventHandler(lblLoc_Click);

            lblLoc.Location = new Point(25, 110);
            lblLoc.Size = new Size(150, 13);
            lblLoc.Text = "ADD NEW LOCATION...";
            pnlLoc.Controls.Add(lblLoc);
        }


        private void dgvLoc_Click(object sender, DataGridViewCellEventArgs e) // Binding Location table to the grid 
        {
            foreach (DataGridViewRow row in dgvLoc.Rows)
            {

                DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
                if (clk.Selected == true)
                {
                    cboPrdctDefLoc.Text = dgvLoc.CurrentRow.Cells[0].Value.ToString();
                }
            }
            pnlLoc.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void lblLoc_Click(object sender, EventArgs e)  // Directing to location table
        {
            this.Cursor = Cursors.Default;

            Location loc = new Location();
            loc.Show();
            pnlLoc.Visible = false;

        }

        private void cboPrdctLastVen_Click(object sender, EventArgs e)
        {
           
       
            pnlVendor.Visible = true;
            dgvVendor.Visible = true;
            pnlVendor.Location = new Point(106, 147);
            pnlVendor.BackColor = Color.White;
            tabPage2.Controls.Add(pnlVendor);
            pnlVendor.Size = new Size(300, 150);
            pnlVendor.BorderStyle = BorderStyle.FixedSingle;

            pnlVendor.Controls.Add(dgvVendor);
            pnlVendor.BringToFront();
            dgvVendor.Size = new Size(300, 100);
            dgvVendor.DataSource = dal.SelectVdetails();
            dgvVendor.ReadOnly = true;
        

            dgvVendor.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e0e0e0");
            dgvVendor.RowsDefaultCellStyle.BackColor = Color.White;
            dgvVendor.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");

            this.Cursor = Cursors.Hand;

            dgvVendor.CellContentClick -= new DataGridViewCellEventHandler(dgvVendor_CellContentClick);
            dgvVendor.CellContentClick += new DataGridViewCellEventHandler(dgvVendor_CellContentClick);
            btnAdd.Click -= new EventHandler(btnAdd_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);

            if (dgvVendor.Columns.Count == 2)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvVendor.AutoGenerateColumns = false;
                dgvVendor.Columns.Add(lnk);
                lnk.HeaderText = "Details";
                lnk.Name = "View Details";
                lnk.Text = "View Details";
                lnk.ActiveLinkColor = Color.Blue;
                lnk.LinkBehavior = LinkBehavior.SystemDefault;
                lnk.UseColumnTextForLinkValue = true;
            }

            lblAdd.Location = new Point(5, 113);
            lblAdd.Size = new Size(83, 23);
            lblAdd.Text = "Add New Name";
            pnlVendor.Controls.Add(lblAdd);
            
            txtAdd.Location = new Point(93, 110);
            txtAdd.Size = new Size(90, 21);
            pnlVendor.Controls.Add(txtAdd);
            
            btnAdd.Location = new Point(205, 110);
            btnAdd.Size = new Size(85, 23);
            btnAdd.Text = "ADD NEW";
            pnlVendor.Controls.Add(btnAdd);
        }


        private void dgvVendor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvVendor.Rows)
            {

                DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
                if (clk.Selected == true)
                {
                    cboPrdctLastVen.Text = dgvVendor.CurrentRow.Cells[0].Value.ToString();
                }
            }

            DataTable dt = new DataTable();
            
            BAL.Nam = dgvVendor.CurrentRow.Cells[0].Value.ToString();
            dt = dal.SelectVname(bal);              //      VIEW DETAILS IN VENDOR FORM  & Procedure is----- "SelectVname"     //
            if (e.ColumnIndex == 2)
            {
                string text = dgvVendor.CurrentRow.Cells[0].Value.ToString();
                if (e.ColumnIndex == 2)
                {
                    VendorInfo vend = new VendorInfo();
                    BAL.Nam = text;
                    
                    vend.Show();
                    
                }
            }
            dgvVendor.Visible = false;
            pnlVendor.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            VendorInfo vend = new VendorInfo();
            vend.textBox4.Text = txtAdd.Text;
            vend.Show();

            dgvVendor.Visible = false;
            pnlVendor.Visible = false;
            this.Cursor = Cursors.Default;
        }

        // Moment History

        //-------------------TRANSACTION TYPE SEARCH------------------------------//

        private void cboTransType_SelectedIndexChanged(object sender, EventArgs e) 
        {
            cboMloc.ResetText();
            dgvMovementhistory.DataSource = null;
            dgvMovementhistory.Rows.Clear();
            bal.Trans = cboTransType.Text;
            DataTable dt = new DataTable();
            dgvMovementhistory.DataSource = dal.selecttranstype(bal);
      
        }

        //-------------------LOCATION------------------------------//

        private void cboMloc_Click(object sender, EventArgs e)
        {
            pnlMLoc.Visible = true;
        }

        private void dgvMLoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboMloc.Text = dgvMLoc.CurrentRow.Cells[0].Value.ToString();

            cboTransType.ResetText();
            dgvMovementhistory.DataSource = null;
            dgvMovementhistory.Rows.Clear();
            bal.Loc = cboMloc.Text;
            DataTable dt = new DataTable();
            dgvMovementhistory.DataSource = dal.selectmovloc(bal);
     
            pnlMLoc.Visible = false;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            pnlMLoc.Visible = false;
        }

        private void btnMRefresh_Click(object sender, EventArgs e)
        {
            cboTransType.ResetText();
            cboMloc.ResetText();
            dgvMovementhistory.DataSource = null;
            dgvMovementhistory.Rows.Clear();
        }

        private void btnDeactive_Click(object sender, EventArgs e)
        {
            if (btnDeactive.Text == "Deactive")
            {
                DisableControls(tabPage1);
                EnableControls(btnDeactive);
                bal.Iiname = txtItemname.Text;
                bal.Status1 = "Deactive";
                dal.updateProductstatus(bal);
                btnDeactive.Text = "Active";
            }
            else
            {
              
                Enable(this);
                bal.Iiname = txtItemname.Text;
                bal.Status1 = "Active";
                dal.updateProductstatus(bal);
                btnDeactive.Text = "Deactive";
            }
        }

        private void dgvSrchPrdct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
