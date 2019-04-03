using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Inventory;
using InventoryTools;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;
using System.Data.SqlClient;

namespace InventoryTools
{

    public partial class PurhcaseOrder : Form
    {
        BAL p = new BAL();
        DAL d = new DAL();
        VendorInfo vendinfo = new VendorInfo();
        Location loc = new Location();
        ProductInfoorNewProduct np = new ProductInfoorNewProduct();
        PaymentTerms pt = new PaymentTerms();
        Taxing ts = new Taxing();
        Address ad = new Address();

        //----------------PURCHASE ORDER-------------//
        //----------------Vendor------------------//
        DataGridView dgvVendor = new DataGridView();
        Panel pnlVendor = new Panel();
        Label lblAdd = new Label();
        TextBox txtAdd = new TextBox();
        Button btnAdd = new Button();

        //--------------Location-----------------//
        DataGridView dgvLoc = new DataGridView();
        Panel pnlLoc = new Panel();
        Label lblLoc = new Label();

        //------------Link--------------//
        DataGridView dgvPay = new DataGridView();
        Panel pnlPay = new Panel();
        Label lblPay = new Label();
        //public Label lblTerms = new Label();
        //public ComboBox cmbTerms = new ComboBox();
        //public Label lblVOrder = new Label();
        //public TextBox txtVOrder = new TextBox();
        TextBox txtSaddr = new TextBox();
        Label lblCarrier = new Label();
        ComboBox cmbCarrier = new ComboBox();
        TextBox txtFreight = new TextBox();
        Label lblFreight = new Label();

        //----------Calender---------------//
        MonthCalendar mc = new MonthCalendar();
        MonthCalendar mcd = new MonthCalendar();
        MonthCalendar mcsd = new MonthCalendar();
        MonthCalendar mcfrom = new MonthCalendar();
        MonthCalendar mcto = new MonthCalendar();

        //----------Item-------------------//
        DataGridView dgvItem = new DataGridView();
        Panel pnlItem = new Panel();
        Label lblItem = new Label();
        TextBox txtItem = new TextBox();
        Button btnItem = new Button();

        //---------------Taxing Scheme------------//
        DataGridView dgvTax = new DataGridView();
        Panel pnlTax = new Panel();
        Label lblTax = new Label();
        Label lblSTax = new Label();
        Label lblCTax = new Label();
        TextBox txtSTax = new TextBox();
        TextBox txtCTax = new TextBox();

        //------------Fulfilled & Paid-----------//
        public Button btnFul = new Button();
        public Button btnPay = new Button();

        //-----------SEARCH------------//
        //-----------Inventory Search-------------//
        Panel pnlISearch = new Panel();
        CheckBox chkISearchA = new CheckBox();
        CheckBox chkISearchU = new CheckBox();
        CheckBox chkISearchS = new CheckBox();
        CheckBox chkISearchF = new CheckBox();

        //------------Panel SeARCH--------------//
        Panel pnlPSearch = new Panel();
        CheckBox chkPSearchA = new CheckBox();
        CheckBox chkPSearchU = new CheckBox();
        CheckBox chkPSearchP = new CheckBox();
        CheckBox chkPSearch = new CheckBox();
        CheckBox chkPSearchO = new CheckBox();

        //-----------Vendor Search---------------//
        DataGridView dgvVendorSearch = new DataGridView();
        Panel pnlVendorSearch = new Panel();
        Label lblAddSearch = new Label();
        TextBox txtAddSearch = new TextBox();
        Button btnAddSearch = new Button();

        //--------------Location Search-----------------//
        DataGridView dgvLocSearch = new DataGridView();
        Panel pnlLocSearch = new Panel();
        Label lblLocSearch = new Label();

        //-----------Req. Date Search-------------------//
        Panel pnlDate = new Panel();
        Label all = new Label();
        Label today = new Label();
        Label thisweek = new Label();
        Label thismonth = new Label();
        Label thisquarter = new Label();
        Label thisyear = new Label();
        Label yesterday = new Label();
        Label lastweek = new Label();
        Label lastmonth = new Label();
        Label lastquarter = new Label();
        Label lastyear = new Label();
        Label last7days = new Label();
        Label last30days = new Label();
        Label last90days = new Label();
        Label last365days = new Label();
        Label tomorrow = new Label();
        Label nextweek = new Label();
        Label nextmonth = new Label();
        Label nextquarter = new Label();
        Label nextyear = new Label();
        Label Cdrange = new Label();
        Label from = new Label();
        ComboBox txtfrom = new ComboBox();
        Label to = new Label();
        ComboBox txtto = new ComboBox();

        PictureBox pb = new PictureBox();
        PictureBox pb1 = new PictureBox();
        PictureBox pb2 = new PictureBox();
        PictureBox pb3 = new PictureBox();
        
        //-------------RETURN---------//
        //-------------LINK------------//
        Label lblRFreight = new Label();
        Label lblRSTax = new Label();
        Label lblRCTax = new Label();
        TextBox txtRFreight = new TextBox();
        TextBox txtRSTax = new TextBox();
        TextBox txtRCTax = new TextBox();

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
        
        public PurhcaseOrder()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            //DataTable dt = new DataTable();

            //dt = d.SelectOrder();
            //dataGridView1.DataSource = dt;
            //dataGridView1.DataBind();

            dataGridView1.DataSource = d.SelectOrder();

            //AutoEventWireUp = false; 


            //    --------      TABPAGE1       ----------     // 
            //    --------    PURCHASE ORDER   ----------     //

            //    --------      LOCATION       ----------     //
            lbl30.Location = new Point(200, 15);
            cmbbox12.Location = new Point(250, 13);

            //    ---------      ADD SHIPPING   ---------       //

            lblShp.Visible = false;
            txtshp.Visible = false;

            lblRshp.Visible = false;
            txtRshp.Visible = false;

            lblReturnShp.Visible = false;
            txtReturnShp.Visible = false;

            lblUSAddr.Visible = false;
            txtboxUShp.Visible = false;

            lblTerms.Visible = false;
            cmbTerms.Visible = false;

            lblVOrder.Visible = false;
            txtVOrder.Visible = false;

            lblTermsR.Visible = false;
            cmbTermsR.Visible = false;

            lblVOrderR.Visible = false;
            txtVOrderR.Visible = false;

            lblTermsReturn.Visible = false;
            cmbTermsReturn.Visible = false;

            lblVOrderReturn.Visible = false;
            txtVOrderReturn.Visible = false;

            lblTermsU.Visible = false;
            cmbTermsU.Visible = false;

            lblVOrderU.Visible = false;
            txtVOrderU.Visible = false;

            lbl30.Location = new Point(216,11);
            cmbbox12.Location = new Point(290,8);

                        //     --------     NON-VENDOR     --------   //

            cmbbox4.Items.Add("0%");
            cmbbox4.Items.Add("0");

            //     --------      CURRENCY      ---------    //

            cmbbox5.Items.Add("India (Rupees)");
            cmbbox5.Items.Add("US (Dollar($))");
            cmbbox5.Items.Add("France (Euro)");
            cmbbox5.Items.Add("Switzerland (Swiss franc)");
            cmbbox5.Items.Add("UK (Pounds)");

            //----------     Fullfilled     ------------            //
            txtbox19.Text = "Unfullfilled";
            txtboxPay.Text = "Unpaid";

            //-----------     Show Cancelled     -------------//
            cmbScancelled.Items.Add("Active Only");
            cmbScancelled.Items.Add("Active and Cancelled");
            cmbScancelled.Items.Add("Cancelled Only");

            //    ------------            TABPAGE2      --------       //
            //      ---------              RECEIVE       ----------    //


            //    ------------            TABPAGE3      --------       //
            //      ---------              RETURN       ----------    //

            //lblReturnF.Visible = false;
            //txtReturnF.Visible = false;

            //lblReturnCTax.Visible = false;
            //txtReturnCTax.Visible = false;

            //lblReturnSTax.Visible = false;
            //txtReturnSTax.Visible = false;

            //lbl27.Location = new Point(405, 397);
            //txtbox8.Location = new Point(456, 394);

            //lbl28.Location = new Point(405, 423);
            //txtbox9.Location = new Point(456, 420);

            //  -----------          TABPAGE4       -------------    //
            //  -----------          UNSTOCK        -------------    //
        }


        private void cmbbox9_Click(object sender, EventArgs e)        //         -----------     VENDOR INFO     -----------     //
        {
            //vend.Hide();
            //dgvVendor.DataSource = null;
            //dgvVendor.Rows.Clear();
            pnlVendor.Visible = true;
            dgvVendor.Visible = true;
            pnlVendor.Location = new Point(61, 28);
            pnlVendor.BackColor = Color.White;
            tabPage1.Controls.Add(pnlVendor);
            pnlVendor.Size = new Size(300, 150);
            pnlVendor.BorderStyle = BorderStyle.FixedSingle;

            pnlVendor.Controls.Add(dgvVendor);
            pnlVendor.BringToFront();
            dgvVendor.Size = new Size(300, 100);
            dgvVendor.DataSource = d.SelectVdetails();
            dgvVendor.ReadOnly = true;
            //dgvVendor.AutoResizeColumns();

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
            //lblAdd.BackColor = Color.Black;
            lblAdd.Text = "Add New Name";
            //pnlLocation.Controls.Add(lblAdd);
            pnlVendor.Controls.Add(lblAdd);
            //lblAdd.BackColor = ColorTranslator.FromHtml("#ffffff");


            txtAdd.Location = new Point(93, 110);
            txtAdd.Size = new Size(90, 21);
            pnlVendor.Controls.Add(txtAdd);
            //txtAdd.BackColor = ColorTranslator.FromHtml("#b3a8a2");

            btnAdd.Location = new Point(205, 110);
            btnAdd.Size = new Size(85, 23);
            //btnAdd.BackColor = Color.Black;
            btnAdd.Text = "ADD NEW";
            //btnAdd.BackColor = ColorTranslator.FromHtml("#efefef");
            //pnlLocation.Controls.Add(btnAdd);
            pnlVendor.Controls.Add(btnAdd);
        }


        private void dgvVendor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvVendor.Rows)
            {

                DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
                if (clk.Selected == true)
                {
                    cmbbox9.Text = dgvVendor.CurrentRow.Cells[0].Value.ToString();
                }
            }

            DataTable dt = new DataTable();
            dt = d.SelectVFdetails();                  //          USED TO FILL THE COMMON DETAILS   &&   Procedure is------"spFillVDetails"      /// 
            if (e.ColumnIndex < 2)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = e.RowIndex; i < dt.Rows.Count; i++)
                    {
                        cmbbox9.Text = dt.Rows[i]["vendorname"].ToString();
                        txtbox14.Text = dt.Rows[i]["contactname"].ToString();
                        txtbox15.Text = dt.Rows[i]["phone"].ToString();
                        txtshp.Text = txtbox16.Text = dt.Rows[i]["address"].ToString();
                        //cmbbox2.Text = dt.Rows[i]["paymentterms"].ToString();
                        //cmbbox3.Text = dt.Rows[i]["taxingscheme"].ToString();
                        //cmbbox5.Text = dt.Rows[i]["currency"].ToString();
                        //txtbox2.Text = dt.Rows[i]["remarks"].ToString();
                        break;
                    }
                }
            }

            BAL.Nam = dgvVendor.CurrentRow.Cells[0].Value.ToString();
            dt = d.SelectVname(p);              //      VIEW DETAILS IN VENDOR FORM  & Procedure is----- "SelectVname"     //
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
            VendorInfo vend = new VendorInfo();        //        -----------  VENDOR  FORM     ----------------       //
            vend.textBox4.Text = txtAdd.Text;
            vend.Show();

            dgvVendor.Visible = false;
            pnlVendor.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void txtbox16_Click(object sender, EventArgs e)       //      DIRECTING TO ADDRESS FORM      //
        {
            txtbox16.Text = String.Empty;

            //Address ad = new Address();
            //ad.Show();
            //ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked);
        }

        private void address_ButtonClicked(object sender, InventoryTools.Address.AddressUpdateEventArgs e)
        {
            txtshp.Text = "";
             txtshp.Text += e.Street + "\r\n";
            txtshp.Text += e.City + "\r\n";
            txtshp.Text += e.State + "\r\n";
            txtshp.Text += e.Country + "\r\n";
            txtshp.Text += e.Postalcode + "\r\n";
            txtshp.Text += e.Remarks + "\r\n";
            txtshp.Text += e.Type;
 
        }

        private void cmbbox12_Click(object sender, EventArgs e)  // ------ LOCATION  --------  //
        {
            pnlLoc.Visible = true;
            dgvLoc.Visible = true;
            pnlLoc.Location = new Point(251, 35);
            pnlLoc.BackColor = Color.White;
            tabPage1.Controls.Add(pnlLoc);
            pnlLoc.Size = new Size(180, 140);
            pnlLoc.BorderStyle = BorderStyle.FixedSingle;

            pnlLoc.Controls.Add(dgvLoc);
            pnlLoc.BringToFront();
            dgvLoc.Size = new Size(180, 100);
            dgvLoc.DataSource = d.Selectloc();
            dgvLoc.ReadOnly = true;
            //dgvLoc.BackgroundColor = Color.White;

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
                    cmbbox12.Text = dgvLoc.CurrentRow.Cells[0].Value.ToString();
                }
            }
            pnlLoc.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void lblLoc_Click(object sender, EventArgs e)  // Directing to location table
        {
            this.Cursor = Cursors.Default;

            //purhcaseorder po = new purhcaseorder();
            //BAL.povname = cmbbox9.text;
            //BAL.pocname = txtbox14.text;
            //BAL.poph = txtbox15.text;
            //BAL.poaddr = txtbox16.text;

            Location loc = new Location();
            loc.Show();
            pnlLoc.Visible = false;

        }

        public void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  // LINK  //
        {
            this.Cursor = Cursors.Hand;
            if (lnklbl2.Text == "Add Shipping")
            {
                add_shp();
                this.Cursor = Cursors.Default;
            }
            else
            {

                lnklbl2.Text = "Add Shipping";

                lblShp.Visible = false;
                txtshp.Visible = false;
                lblTerms.Visible = false;
                cmbTerms.Visible = false;

                lblVOrder.Visible = false;
                txtVOrder.Visible = false;

                lblCarrier.Visible = false;
                cmbCarrier.Visible = false;

                lblFreight.Visible = false;
                txtFreight.Visible = false;

                lbl30.Location = new Point(213, 11);          //---------LOCATION LABEL---------//
                cmbbox12.Location = new Point(278, 8);       //---------LOCATION TEXTBOX---------//

                lbl7.Location = new Point(12, 342);           //---------DUEDATE LABEL---------//
                cmbbox2.Location = new Point(80, 334);        //---------DUEDATE COMBOBOX---------//

                lbl8.Location = new Point(12, 370);         //---------TAX LABEL---------//
                cmbbox3.Location = new Point(80, 375);       //---------TAX COMBOBOX---------//

                lbl9.Location = new Point(7, 414);         //---------NON-VENDOR LABEL---------//
                cmbbox4.Location = new Point(80, 411);       //---------NON-VENDOR COMBOBOX---------//

                lbl10.Location = new Point(12, 453);        //---------CURRENCY LABEL---------//
                cmbbox5.Location = new Point(80, 445);      //---------CURRENCY COMBOBOX---------//

                lbl14.Location = new Point(474, 375);       //---------TOTAL LABEL---------//
                txtbox4.Location = new Point(542, 368);     //---------TOTAL TEXTBOX---------//

                lbl15.Location = new Point(477, 406);       //---------PAID LABEL---------//
                txtbox5.Location = new Point(542, 399);     //---------PAID TEXTBOX---------//

                lblPaging.Location = new Point(477, 441);       //---------Paging LABEL---------//
                Paying.Location = new Point(544, 434);

                lbl16.Location = new Point(477, 478);       //---------BALANCE LABEL---------//
                txtbox6.Location = new Point(544, 475);     //---------BALANCE TEXTBOX---------//

                this.Cursor = Cursors.Default;

                //no_shp();
                //this.Cursor = Cursors.Default;
            }
        }

        public void add_shp()
        {
            lblShp.Visible = true;
            txtshp.Visible = true;

            lblTerms.Visible = true;
            cmbTerms.Visible = true;

            lblVOrder.Visible = true;
            txtVOrder.Visible = true;

            lblCarrier.Visible = true;
            cmbCarrier.Visible = true;

            lblFreight.Visible = true;
            txtFreight.Visible = true;

            lnklbl2.Text = "No Shipping";

            cmbTerms.DropDownHeight = 1;
            cmbTerms.DropDownWidth = 1;
            cmbTerms.Click -= new EventHandler(cmbTerms_Click);
            cmbTerms.Click += new EventHandler(cmbTerms_Click);

            lblCarrier.Location = new Point(12, 342);
            lblCarrier.Size = new Size(48, 26);
            lblCarrier.Text = "Carrier";
            tabPage1.Controls.Add(lblCarrier);

            cmbCarrier.Location = new Point(80, 334);
            cmbCarrier.Size = new Size(121, 21);
            //cmbCarrier.DropDownHeight = 1;           
            //cmbCarrier.DropDownWidth = 1;
            tabPage1.Controls.Add(cmbCarrier);

            DataTable dt = new DataTable();
            dt = d.carrier();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbCarrier.Items.Add(dt.Rows[i]["carrier"].ToString());
                }
            }


            lblFreight.Location = new Point(474, 375);
            lblFreight.Size = new Size(53, 13);
            lblFreight.Text = "Freight";
            tabPage1.Controls.Add(lblFreight);

            txtFreight.Location = new Point(542, 368);
            txtFreight.Size = new Size(86, 13);
            //cmbTerms.Click -= new EventHandler(cmbTerms_Click);
            txtFreight.Leave -= new EventHandler(txtFreight_Leave);
            txtFreight.Leave += new EventHandler(txtFreight_Leave);
            tabPage1.Controls.Add(txtFreight);

            lnklbl2.Location = new Point(541, 162);       //---------LINK---------//

            lbl30.Location = new Point(216, 75);          //---------LOCATION LABEL---------//
            cmbbox12.Location = new Point(290, 75);       //---------LOCATION TEXTBOX---------//

            lbl7.Location = new Point(12, 378);           //---------DUEDATE LABEL---------//
            cmbbox2.Location = new Point(80, 378);        //---------DUEDATE COMBOBOX---------//

            lbl8.Location = new Point(12, 414);         //---------TAX LABEL---------//
            cmbbox3.Location = new Point(80, 411);       //---------TAX COMBOBOX---------//

            lbl9.Location = new Point(12, 453);         //---------NON-VENDOR LABEL---------//
            cmbbox4.Location = new Point(80, 445);       //---------NON-VENDOR COMBOBOX---------//

            lbl10.Location = new Point(12, 486);        //---------CURRENCY LABEL---------//
            cmbbox5.Location = new Point(80, 479);      //---------CURRENCY COMBOBOX---------//

            lbl14.Location = new Point(477, 406);       //---------TOTAL LABEL---------//
            txtbox4.Location = new Point(542, 399);     //---------TOTAL TEXTBOX---------//

            lbl15.Location = new Point(477, 441);       //---------PAID LABEL---------//
            txtbox5.Location = new Point(542, 434);     //---------PAID TEXTBOX---------//

            lblPaging.Location = new Point(477, 475);       //---------Paging LABEL---------//
            Paying.Location = new Point(542, 475);

            lbl16.Location = new Point(477, 512);       //---------BALANCE LABEL---------//
            txtbox6.Location = new Point(542, 512);     //---------BALANCE TEXTBOX---------//

            this.Cursor = Cursors.Default;

            //if(cmbbox3.Text == "NO TAX")
            //{
            //    lblFreight.Location = new Point(477, 375);
            //    txtFreight.Location = new Point(542, 368);

            //    lbl14.Location = new Point(477, 406);
            //    txtbox4.Location = new Point(542, 399);

            //    lbl15.Location = new Point(477, 441);
            //    txtbox5.Location = new Point(542, 434);

            //    lblPaging.Location = new Point(477, 475);
            //    Paging.Location = new Point(542, 475);

            //    lbl16.Location = new Point(477, 515);
            //    txtbox6.Location = new Point(542, 512);
            //    //break;
            //}

            if (cmbbox3.Text != "NO TAX" && cmbbox3.Text != "")
            {
                lblSTax.Visible = true;
                txtSTax.Visible = true;

                lblCTax.Visible = true;
                txtCTax.Visible = true;

                lblSTax.Location = new Point(477, 406);
                lblSTax.Size = new Size(53, 13);
                lblSTax.Text = "STAX";
                tabPage1.Controls.Add(lblSTax);

                txtSTax.Location = new Point(542, 399);
                txtSTax.Size = new Size(86, 13);
                tabPage1.Controls.Add(txtSTax);

                lblCTax.Location = new Point(477, 441);
                //lblCTax.BackColor = Color.Black;
                lblCTax.Size = new Size(53, 13);
                lblCTax.Text = "CTAX";
                tabPage1.Controls.Add(lblCTax);

                txtCTax.Location = new Point(542, 434);
                txtCTax.Size = new Size(86, 13);
                tabPage1.Controls.Add(txtCTax);

                lbl14.Location = new Point(477, 475);
                txtbox4.Location = new Point(542, 475);

                lbl15.Location = new Point(477, 515);
                txtbox5.Location = new Point(542, 512);

                lblPaging.Location = new Point(477, 555);
                Paying.Location = new Point(542, 547);

                lbl16.Location = new Point(477, 589);
                txtbox6.Location = new Point(542, 582);
            }
        }

        public void no_shp()
        {
            lnklbl2.Text = "Add Shipping";

            lblTerms.Visible = false;
            cmbTerms.Visible = false;

            lblVOrder.Visible = false;
            txtVOrder.Visible = false;

            lblCarrier.Visible = false;
            cmbCarrier.Visible = false;

            lblFreight.Visible = false;
            txtFreight.Visible = false;

            lblShp.Visible = false;
            txtshp.Visible = false;

            if (cmbbox3.Text == "NO TAX" || cmbbox3.Text == "No Tax")
            {
                //lblSTax.Visible = false;
                //lblCTax.Visible = false;

                //txtCTax.Visible = false;
                //txtSTax.Visible = false;

                lbl30.Location = new Point(213, 11);          //---------LOCATION LABEL---------//
                cmbbox12.Location = new Point(278, 8);       //---------LOCATION TEXTBOX---------//

                lbl7.Location = new Point(12, 342);           //---------DUEDATE LABEL---------//
                cmbbox2.Location = new Point(80, 334);        //---------DUEDATE COMBOBOX---------//

                lbl8.Location = new Point(12, 370);         //---------TAX LABEL---------//
                cmbbox3.Location = new Point(80, 375);       //---------TAX COMBOBOX---------//

                lbl9.Location = new Point(7, 414);         //---------NON-VENDOR LABEL---------//
                cmbbox4.Location = new Point(80, 411);       //---------NON-VENDOR COMBOBOX---------//

                lbl10.Location = new Point(12, 453);        //---------CURRENCY LABEL---------//
                cmbbox5.Location = new Point(80, 445);      //---------CURRENCY COMBOBOX---------//

                lbl14.Location = new Point(474, 375);       //---------TOTAL LABEL---------//
                txtbox4.Location = new Point(542, 368);     //---------TOTAL TEXTBOX---------//

                lbl15.Location = new Point(477, 406);       //---------PAID LABEL---------//
                txtbox5.Location = new Point(542, 399);     //---------PAID TEXTBOX---------//

                lblPaging.Location = new Point(477, 441);       //---------Paging LABEL---------//
                Paying.Location = new Point(544, 434);

                lbl16.Location = new Point(477, 478);       //---------BALANCE LABEL---------//
                txtbox6.Location = new Point(544, 475);     //---------BALANCE TEXTBOX---------//

                this.Cursor = Cursors.Default;
            }

            else
            {
                lblSTax.Visible = true;
                lblCTax.Visible = true;

                txtCTax.Visible = true;
                txtSTax.Visible = true;

                lblSTax.Location = new Point(477, 375);
                lblSTax.Size = new Size(53, 13);
                lblSTax.Text = "STAX";
                tabPage1.Controls.Add(lblSTax);

                txtSTax.Location = new Point(542, 368);
                txtSTax.Size = new Size(86, 13);
                //txtSTax.BackColor = Color.Black;
                tabPage1.Controls.Add(txtSTax);

                lblCTax.Location = new Point(477, 406);
                //lblCTax.BackColor = Color.Black;
                lblCTax.Size = new Size(53, 13);
                lblCTax.Text = "CTAX";
                tabPage1.Controls.Add(lblCTax);

                txtCTax.Location = new Point(542, 399);
                txtCTax.Size = new Size(86, 13);
                tabPage1.Controls.Add(txtCTax);

                //lblSTax.Location = new Point(474, 375);
                //txtSTax.Location = new Point(542, 368);

                //lblCTax.Location = new Point(477, 406);
                //txtCTax.Location = new Point(542, 399);

                lbl14.Location = new Point(474, 441);       //---------TOTAL LABEL---------//
                txtbox4.Location = new Point(542, 434);     //---------TOTAL TEXTBOX---------//

                lbl15.Location = new Point(477, 478);       //---------PAID LABEL---------//
                txtbox5.Location = new Point(542, 475);     //---------PAID TEXTBOX---------//

                lblPaging.Location = new Point(477, 515);       //---------Paying LABEL---------//
                Paying.Location = new Point(544, 516);

                lbl16.Location = new Point(477, 552);       //---------BALANCE LABEL---------//
                txtbox6.Location = new Point(544, 557);     //---------BALANCE TEXTBOX---------//

                lbl30.Location = new Point(213, 11);          //---------LOCATION LABEL---------//
                cmbbox12.Location = new Point(278, 8);       //---------LOCATION TEXTBOX---------//

                lbl7.Location = new Point(12, 342);           //---------DUEDATE LABEL---------//
                cmbbox2.Location = new Point(80, 334);        //---------DUEDATE COMBOBOX---------//

                lbl8.Location = new Point(12, 370);         //---------TAX LABEL---------//
                cmbbox3.Location = new Point(80, 375);       //---------TAX COMBOBOX---------//

                lbl9.Location = new Point(7, 414);         //---------NON-VENDOR LABEL---------//
                cmbbox4.Location = new Point(80, 411);       //---------NON-VENDOR COMBOBOX---------//

                lbl10.Location = new Point(12, 453);        //---------CURRENCY LABEL---------//
                cmbbox5.Location = new Point(80, 445);      //---------CURRENCY COMBOBOX---------//
            }
        }

        public void cmbTerms_Click(object sender, EventArgs e) //  PAYMENT TERMS
        {
            pnlPay.Visible = true;
            dgvPay.Visible = true;
            pnlPay.Location = new Point(280, 30);
            pnlPay.BackColor = Color.White;
            tabPage1.Controls.Add(pnlPay);
            pnlPay.Size = new Size(180, 140);
            pnlPay.BorderStyle = BorderStyle.FixedSingle;

            pnlPay.Controls.Add(dgvPay);
            pnlPay.BringToFront();
            dgvPay.Size = new Size(180, 100);
            dgvPay.DataSource = d.Selectpay();
            dgvPay.ReadOnly = true;
            DataGridViewColumn col = dgvPay.Columns[0];
            col.Width = 120;

            this.Cursor = Cursors.Hand;

            dgvPay.CellContentClick -= new DataGridViewCellEventHandler(dgvPay_CellContentClick);
            dgvPay.CellContentClick += new DataGridViewCellEventHandler(dgvPay_CellContentClick);
            lblPay.Click -= new EventHandler(lblPay_Click);
            lblPay.Click += new EventHandler(lblPay_Click);

            lblPay.Location = new Point(25, 110);
            lblPay.Size = new Size(150, 13);
            lblPay.Text = "ADD NEW PAY TERMS...";
            pnlPay.Controls.Add(lblPay);
        }

        private void dgvPay_CellContentClick(object sender, DataGridViewCellEventArgs e) // BINDING TABLE TO PAYMENT TERMS
        {
            foreach (DataGridViewRow row in dgvPay.Rows)
            {

                DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
                if (clk.Selected == true)
                {
                    cmbTerms.Text = dgvPay.CurrentRow.Cells[0].Value.ToString();
                }
            }

            pnlPay.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void lblPay_Click(object sender, EventArgs e) // DIRECTING TO PAYMENT TERMS
        {
            this.Cursor = Cursors.Default;
            //BAL.Povname = cmbbox9.Text;
            //BAL.Pocname = txtbox14.Text;
            //BAL.Poph = txtbox15.Text;
            //BAL.Poaddr = txtbox16.Text;
            //BAL.Poloc = cmbbox12.Text;
            PaymentTerms pt = new PaymentTerms();
           // this.Hide();
            pnlPay.Visible = false;
            pt.Show();
        }

        private void txtshp_Click(object sender, EventArgs e)   // SHIPPING ADDRESS
        {
            if (MessageBox.Show("You Want To Change The Address ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtshp.Text = String.Empty;
                Address ad = new Address();
                ad.Show();
                ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked);
            }
        }

        private void txtFreight_Leave(object sender,EventArgs e)
        {
            float total;
   
            if (txtFreight.Text != "")
            {
                float freight = float.Parse(txtFreight.Text);
                if (cmbbox3.Text == "NO TAX")
                {
                    total = float.Parse(txtbox4.Text) + freight;
                }
                else
                {
                    float stax = float.Parse(txtSTax.Text);
                    float ctax = float.Parse(txtCTax.Text);
                    total = float.Parse(txtbox4.Text) + stax + ctax + freight;
                    txtbox4.Text = total.ToString();
                    txtbox6.Text = total.ToString();
                }
            }

            else if (txtFreight.Text == "")
            {
                if (cmbbox3.Text == "NO TAX")
                {
                    float a = float.Parse(txtbox4.Text);
                }
                else
                {
                    float stax = float.Parse(txtSTax.Text);
                    float ctax = float.Parse(txtCTax.Text);
                    total = float.Parse(txtbox4.Text) + stax + ctax;
                    txtbox4.Text = total.ToString();
                    txtbox6.Text = total.ToString();
                }
            }

        }

        //--------------------------NEW PRODUCT(ITEMS)---------------------------//

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                pnlItem.Visible = true;
                dgvItem.Visible = true;
                DataTable dt = new DataTable();
                tabPage1.Controls.Add(pnlItem);

                pnlItem.Location = dataGridView3.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                int x = pnlItem.Location.X;
                int y = pnlItem.Location.Y;
                int nx = x + 2;
                int ny = y + 200;
                pnlItem.Location = new Point(nx, ny);
                pnlItem.Visible = true;
                pnlItem.BringToFront();

                //pnlItem.Location = new Point(3, 178);
                pnlItem.BackColor = Color.White;
                //tabPage1.Controls.Add(pnlItem);
                pnlItem.Size = new Size(340, 152);
                pnlItem.BorderStyle = BorderStyle.FixedSingle;

                pnlItem.Controls.Add(dgvItem);
                pnlItem.BringToFront();
                dgvItem.Size = new Size(340, 100);
                dgvItem.ReadOnly = true;
                //dataGridView3.AutoGenerateColumns = true;
                dgvItem.DataSource = null;
                dgvItem.Columns.Clear();
                dgvItem.DataSource = d.items();
                dgvItem.Columns[0].Visible = false;

                if (dgvItem.ColumnCount == 3)
                {
                    DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                    dgvItem.Columns.Add(lnk);
                    lnk.Name = "View";
                    lnk.HeaderText = "Details";
                    lnk.Text = "View";
                    lnk.UseColumnTextForLinkValue = true;
                }

                this.Cursor = Cursors.Hand;
                dgvItem.CellClick -= new DataGridViewCellEventHandler(dgvItem_CellClick);
                dgvItem.CellClick += new DataGridViewCellEventHandler(dgvItem_CellClick);
                btnItem.Click -= new EventHandler(btnItem_Click);
                btnItem.Click += new EventHandler(btnItem_Click);

                //if (dgvItem.Columns.Count == 2)
                //{
                //    DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                //    dgvItem.AutoGenerateColumns = false;
                //    dgvItem.Columns.Add(lnk);
                //    lnk.HeaderText = "Details";
                //    lnk.Name = "View Details";
                //    lnk.Text = "View Details";
                //    lnk.ActiveLinkColor = Color.Blue;
                //    lnk.LinkBehavior = LinkBehavior.SystemDefault;
                //    lnk.UseColumnTextForLinkValue = true;
                //}

                lblItem.Location = new Point(5, 110);
                lblItem.Size = new Size(53, 13);
                lblItem.Text = "Add New Item";
                pnlItem.Controls.Add(lblItem);

                txtItem.Location = new Point(60, 110);
                txtItem.Size = new Size(121, 21);
                pnlItem.Controls.Add(txtItem);

                btnItem.Location = new Point(200, 110);
                btnItem.Size = new Size(75, 23);
                btnItem.Text = "ADD NEW";
                pnlItem.Controls.Add(btnItem);
            }
        }

        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnlItem.Visible = false;
                DialogResult r = MessageBox.Show("Delete Selected Row", "", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
                }
            }
        }

        private void dataGridView3_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            BAL bal = new BAL();
            DAL dal = new DAL();

            if (e.ColumnIndex == dataGridView3.CurrentRow.Cells[4].ColumnIndex)
            {
                int a;
                bal.Sno1 = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                bal.Itemname = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                bal.OrderNo = txtbox18.Text;
                dal.select_qunatityinhand(bal);

                a = Convert.ToInt32(bal.Quantityonhand);
                //dal.quantity_orders(bal);
                //if (bal.Sno1 == Convert.ToInt32(dgvSaleItem.CurrentRow.Cells[1].Value.ToString()))
                //{
                //    if (a < Convert.ToInt32(dgvSaleItem.CurrentRow.Cells[4].Value.ToString()) - Convert.ToInt32(bal.Quantityafter))
                //    {
                //        MessageBox.Show("Sorry InSufficient Stock");
                //        dgvSaleItem.CurrentRow.Cells[4].Value = null;
                //    }
                //}

                //else
                //{

                if (a < Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value))
                {
                    MessageBox.Show("Sorry InSufficient Stock" + "\r\n" + "You Can Order till " + a);
                    dataGridView3.CurrentRow.Cells[4].Value = null;
                }


            }
            if (dataGridView3.CurrentRow.Cells[5].Value != "" || dataGridView3.CurrentRow.Cells[6].Value != "")
            {
                int a = 0;
                int paid = 0;
                int page = 0;
                int qtotal = 0;
                //foreach (DataGridViewRow row in dataGridView3.Rows)
                //{
                //DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)row.Cells[4];
                //DataGridViewTextBoxCell cel1 = (DataGridViewTextBoxCell)row.Cells[5];
                if (e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
                {
                    int Quant;
                    int UPrice;
                    int discount = 0;
                    int Stotal;
                    Quant = int.Parse(dataGridView3.CurrentRow.Cells[4].Value.ToString());
                    UPrice = int.Parse(dataGridView3.CurrentRow.Cells[5].Value.ToString());
                    if (dataGridView3.CurrentRow.Cells[6].Value == null)
                    {
                        dataGridView3.CurrentRow.Cells[6].Value = discount;

                        Stotal = (Quant * UPrice) - ((Quant * UPrice * discount) / 100);
                        dataGridView3.CurrentRow.Cells[7].Value = Stotal.ToString();

                        if (dataGridView3.Rows.Count > 2)
                        {
                            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                            {

                                a = int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                                qtotal = qtotal + a;
                                txtbox3.Text = qtotal.ToString();
                                txtbox4.Text = qtotal.ToString();
                                txtbox6.Text = qtotal.ToString();

                                txtbox5.Text = paid.ToString();
                                Paying.Text = page.ToString(); ;
                            }
                        }

                        else
                        {
                            txtbox3.Text = Stotal.ToString();
                            txtbox4.Text = Stotal.ToString();
                            txtbox6.Text = Stotal.ToString();

                            txtbox5.Text = paid.ToString();
                            Paying.Text = page.ToString();

                        }
                    }
                    else if (dataGridView3.CurrentRow.Cells[6].Value != null)
                    {
                        discount = int.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString());
                        Stotal = (Quant * UPrice) - ((Quant * UPrice * discount) / 100);
                        dataGridView3.CurrentRow.Cells[7].Value = Stotal.ToString();

                        if (dataGridView3.Rows.Count > 2)
                        {
                            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                            {

                                a = int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                                qtotal = qtotal + a;
                                txtbox3.Text = qtotal.ToString();
                                txtbox4.Text = qtotal.ToString();
                                txtbox6.Text = qtotal.ToString();

                                txtbox5.Text = paid.ToString();
                                Paying.Text = page.ToString(); ;
                            }
                        }

                        else
                        {
                            txtbox3.Text = Stotal.ToString();
                            txtbox4.Text = Stotal.ToString();
                            txtbox6.Text = Stotal.ToString();

                            txtbox5.Text = paid.ToString();
                            Paying.Text = page.ToString();
                        }
                    }

                    pnlItem.Visible = false;

                }
            }
        }
        

        private void Paying_Leave(object sender, EventArgs e)
        {
            //float bal;
            //float total;
            //float paid;
            //float paging;
            //float t;
            //total = float.Parse(txtbox4.Text);
            //paid = float.Parse(txtbox5.Text);
            //paging = float.Parse(Paying.Text);

            //float pa = paid + paging;
            //txtbox5.Text = pa.ToString();
            //bal = total - pa;
            //t = float.Parse(Paying.Text);
            //txtbox6.Text = bal.ToString();

            btnPay_Click(null, null);
            //Paying.Text = "0";
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BAL bal = new BAL();
            DAL dal = new DAL();
            ProductInfoorNewProduct p = new ProductInfoorNewProduct();
            if (dgvItem.CurrentCell is DataGridViewLinkCell)
            {
               
                bal.Itemname = dgvItem.CurrentRow.Cells["itemnameorcode"].Value.ToString();
                bal.Sno1 = Convert.ToInt32(dgvItem.CurrentRow.Cells["productid"].Value.ToString());
                dal.select_products(bal);
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
                pnlItem.Visible = false;
                p.btnOk.Visible = true;
                p.Show();
            }
            //if(this.dataGridView3.Rows[0].Cells[0].Value==null)
            //{

            if (e.ColumnIndex < 2)
            {
                int dg = dataGridView3.Rows.Add();
                dataGridView3.Rows[dg].Cells[0].Value = dgvItem.CurrentRow.Cells[0].Value.ToString();
                dataGridView3.Rows[dg].Cells[1].Value = dgvItem.CurrentRow.Cells[1].Value.ToString();
                dataGridView3.Rows[dg].Cells[2].Value = dgvItem.CurrentRow.Cells[2].Value.ToString();

                pnlItem.Visible = false;
                dgvItem.Visible = false;
            }


            DataTable dt = new DataTable();
            BAL.Nam = dgvItem.CurrentRow.Cells[1].Value.ToString();
            dt = d.SelectItemForm();
            string text = dgvItem.CurrentRow.Cells[1].Value.ToString();
            if (e.ColumnIndex == 3)
            {
               // ProductInfoorNewProduct np = new ProductInfoorNewProduct();
                BAL.Nam = text;
                p.Show();
            }
            pnlItem.Visible = false;
            this.Cursor = Cursors.Default;

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            ProductInfoorNewProduct np = new ProductInfoorNewProduct();
            dgvItem.Visible = false;
            np.txtItemname.Text = txtItem.Text;
            txtItem.Text = String.Empty;
            np.Show();

            pnlVendor.Visible = false;
        }

        private void cmbbox2_Click(object sender, EventArgs e)
        {
            if (lnklbl2.Text == "Add Shipping")
            {
                mcd.Location = new Point(79, 354);
                tabPage1.Controls.Add(mcd);
                mcd.Size = new Size(150, 50);
                mcd.BringToFront();

                mcd.DateSelected -= new DateRangeEventHandler(mcd_DateSelected);
                mcd.DateSelected += new DateRangeEventHandler(mcd_DateSelected);
                mcd.Visible = true;
            }
            else
            {
                mcd.Location = new Point(79, 400);
                tabPage1.Controls.Add(mcd);
                mcd.Size = new Size(150, 50);
                mcd.BringToFront();

                mcd.DateSelected -= new DateRangeEventHandler(mcd_DateSelected);
                mcd.DateSelected += new DateRangeEventHandler(mcd_DateSelected);
                mcd.Visible = true;

                //mcd.Location = new Point(80, 398);
            }


        }

        private void mcd_DateSelected(object sender, DateRangeEventArgs e)
        {
            //cmbbox2.Text = mc.SelectionStart.ToString();
            cmbbox2.Text = e.Start.ToShortDateString();
            //string a = DateTime.ParseExact(cmbbox2.Text);
            //DateTime to = DateTime.ParseExact(cmbbox2.Text); 
            BAL.Datepoduedate = Convert.ToDateTime(cmbbox2.Text);

            mcd.Visible = false;
        }


        //---------------------------------------------------Taxing Scheme-----------------------------------------------------------------//

        private void cmbbox3_Click(object sender, EventArgs e)
        {
            dgvTax.ReadOnly = true;
            pnlTax.Visible = true;
            dgvTax.Visible = true;
            pnlTax.Location = new Point(80, 396);
            pnlTax.BackColor = Color.White;
            tabPage1.Controls.Add(pnlTax);
            pnlTax.Size = new Size(180, 140);
            pnlTax.BorderStyle = BorderStyle.FixedSingle;

            pnlTax.Controls.Add(dgvTax);
            pnlTax.BringToFront();
            dgvTax.Size = new Size(180, 100);
            dgvTax.DataSource = d.taxing();

            this.Cursor = Cursors.Hand;

            dgvTax.CellClick -= new DataGridViewCellEventHandler(dgvTax_Click);
            lblTax.Click -= new EventHandler(lblTax_Click);
            dgvTax.CellClick += new DataGridViewCellEventHandler(dgvTax_Click);
            lblTax.Click += new EventHandler(lblTax_Click);

            lblTax.Location = new Point(25, 110);
            lblTax.Size = new Size(150, 13);
            lblTax.Text = "ADD NEW TAXING SCHEME";
            pnlTax.Controls.Add(lblTax);

            if (lnklbl2.Text != "Add Shipping")
            {
                pnlTax.Location = new Point(80, 432);
            }

        }

        private void dgvTax_Click(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dgvTax.Rows)
            {

                DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
                if (clk.Selected == true)
                {
                    cmbbox3.Text = dgvTax.CurrentRow.Cells[0].Value.ToString();
                }
            }



            if (cmbbox3.Text == "NO TAX")
            {
                //lblSTax.Visible = false;
                //txtSTax.Visible = false;
                //lblCTax.Visible = false;
                //txtCTax.Visible = false;
                pnlTax.Visible = false;

                lbl14.Location = new Point(474, 375);       //---------TOTAL LABEL---------//
                txtbox4.Location = new Point(542, 368);     //---------TOTAL TEXTBOX---------//

                lbl15.Location = new Point(477, 406);       //---------PAID LABEL---------//
                txtbox5.Location = new Point(542, 399);     //---------PAID TEXTBOX---------//

                lblPaging.Location = new Point(477, 441);       //---------Paging LABEL---------//
                Paying.Location = new Point(544, 434);

                lbl16.Location = new Point(474, 486);       //---------BALANCE LABEL---------//
                txtbox6.Location = new Point(544, 475);     //---------BALANCE TEXTBOX---------//

            }
            else if (cmbbox3.Text != "NO TAX" && lnklbl2.Text != "Add Shipping")
            {
                //lblFreight.Visible = true;
                //txtFreight.Visible = true;
                ////lblSTax.Visible = true;
                //txtSTax.Visible = true;
                //lblCTax.Visible = true;
                //txtCTax.Visible = true;
                p.Potaxscheme = cmbbox3.Text;
                DataTable dt = new DataTable();
                dt = d.Selecttaxshp(p);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count; i++)
                    {
                        lblSTax.Location = new Point(477, 406);
                        lblSTax.Size = new Size(53, 13);
                        lblSTax.Text = "STAX";
                        tabPage1.Controls.Add(lblSTax);

                        txtSTax.Location = new Point(542, 399);
                        txtSTax.Size = new Size(86, 13);
                        tabPage1.Controls.Add(txtSTax);

                        lblCTax.Location = new Point(477, 441);
                        //lblCTax.BackColor = Color.Black;
                        lblCTax.Size = new Size(53, 13);
                        lblCTax.Text = "CTAX";
                        tabPage1.Controls.Add(lblCTax);

                        txtCTax.Location = new Point(542, 434);
                        txtCTax.Size = new Size(86, 13);
                        tabPage1.Controls.Add(txtCTax);

                        lbl14.Location = new Point(477, 475);
                        txtbox4.Location = new Point(542, 475);

                        lbl15.Location = new Point(477, 515);
                        txtbox5.Location = new Point(542, 512);

                        lblPaging.Location = new Point(477, 555);
                        Paying.Location = new Point(542, 547);

                        lbl16.Location = new Point(477, 589);
                        txtbox6.Location = new Point(542, 582);
                            
                        if ((dt.Rows[i]["taxonshipping"].ToString() == "True") && (dt.Rows[i]["secondarytaxon"].ToString() == "True"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = dt.Rows[i]["taxrate"].ToString();
                                    txtCTax.Text = dt.Rows[i]["secondarytaxrate"].ToString();
                                    break;
                                }
                            }
                            break;
                        }
                        else if ((dt.Rows[i]["taxonshipping"].ToString() == "True") && (dt.Rows[i]["secondarytaxon"].ToString() == "False"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = dt.Rows[i]["taxrate"].ToString();
                                    txtCTax.Text = "0";
                                    break;
                                }
                            }
                            break;
                        }
                        else if ((dt.Rows[i]["taxonshipping"].ToString() == "False") && (dt.Rows[i]["secondarytaxon"].ToString() == "True"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = "0";
                                    txtCTax.Text = dt.Rows[i]["secondarytaxrate"].ToString();
                                    break;
                                }
                            }
                            break;
                        }

                        else if ((dt.Rows[i]["taxonshipping"].ToString() == "False") && (dt.Rows[i]["secondarytaxon"].ToString() == "False"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = "0";
                                    txtCTax.Text = "0";
                                    break;
                                }
                            }
                            break;
                        }
                        break;
                    }
                }
                pnlTax.Visible = false;

            }
            else if (cmbbox3.Text != "NO TAX" && lnklbl2.Text == "Add Shipping")
            {
                //lblSTax.Visible = true;
                //txtSTax.Visible = true;
                //lblCTax.Visible = true;
                //txtCTax.Visible = true;
                p.Potaxscheme = cmbbox3.Text;
                DataTable dt = new DataTable();
                dt = d.Selecttaxshp(p);

                lblSTax.Visible = true;
                lblSTax.Location = new Point(477, 375);
                lblSTax.Size = new Size(53, 13);
                lblSTax.Text = "STAX";
                //lblSTax.ForeColor = Color.Black;
                tabPage1.Controls.Add(lblSTax);

                txtSTax.Location = new Point(542, 368);
                txtSTax.Size = new Size(86, 13);
                tabPage1.Controls.Add(txtSTax);

                lblCTax.Location = new Point(477, 406);
                //lblCTax.BackColor = Color.Black;
                lblCTax.Size = new Size(53, 13);
                lblCTax.Text = "CTAX";
                tabPage1.Controls.Add(lblCTax);

                txtCTax.Location = new Point(542, 399);
                txtCTax.Size = new Size(86, 13);
                tabPage1.Controls.Add(txtCTax);

                lbl14.Location = new Point(477, 441);
                txtbox4.Location = new Point(542, 434);

                lbl15.Location = new Point(477, 475);
                txtbox5.Location = new Point(542, 475);

                lblPaging.Location = new Point(477, 515);
                Paying.Location = new Point(542, 512);

                lbl16.Location = new Point(477, 555);
                txtbox6.Location = new Point(542, 547);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count; i++)
                    {
                        if ((dt.Rows[i]["taxonshipping"].ToString() == "True") && (dt.Rows[i]["secondarytaxon"].ToString() == "True"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = dt.Rows[i]["taxrate"].ToString();
                                    txtCTax.Text = dt.Rows[i]["secondarytaxrate"].ToString();
                                    break;
                                }
                            }
                            break;
                        }
                        else if ((dt.Rows[i]["taxonshipping"].ToString() == "True") && (dt.Rows[i]["secondarytaxon"].ToString() == "False"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = dt.Rows[i]["taxrate"].ToString();
                                    txtCTax.Text = "0";
                                    break;
                                }
                            }
                            break;
                        }
                        else if ((dt.Rows[i]["taxonshipping"].ToString() == "False") && (dt.Rows[i]["secondarytaxon"].ToString() == "True"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = "0";
                                    txtCTax.Text = dt.Rows[i]["secondarytaxrate"].ToString();
                                    break;
                                }
                            }
                            break;
                        }

                        else if ((dt.Rows[i]["taxonshipping"].ToString() == "False") && (dt.Rows[i]["secondarytaxon"].ToString() == "False"))
                        {
                            dt = d.Selecttaxrate();
                            if (dt.Rows.Count > 0)
                            {
                                for (i = e.RowIndex; i < dt.Rows.Count; i++)
                                {
                                    txtSTax.Text = "0";
                                    txtCTax.Text = "0";
                                    break;
                                }
                            }
                            break;
                        }
                        break;
                    }
                }
                float total;
                //txtbox4.Text = txtbox3.Text;
                //

                if (txtFreight.Text != "")
                {
                    float freight = float.Parse(txtFreight.Text);
                    if (cmbbox3.Text == "NO TAX")
                    {
                        total = float.Parse(txtbox4.Text) + freight;
                    }
                    else
                    {
                        float stax = float.Parse(txtSTax.Text);
                        float ctax = float.Parse(txtCTax.Text);
                        total = float.Parse(txtbox4.Text) + stax + ctax + freight;
                        txtbox4.Text = total.ToString();
                        txtbox6.Text = total.ToString();

                    }
                }

                else if (txtFreight.Text == "")
                {
                    if (cmbbox3.Text == "NO TAX")
                    {
                        float a = float.Parse(txtbox4.Text);
                    }
                    else
                    {
                        float stax = float.Parse(txtSTax.Text);
                        float ctax = float.Parse(txtCTax.Text);
                        total = float.Parse(txtbox4.Text) + stax + ctax;
                        txtbox4.Text = total.ToString();
                        txtbox6.Text = total.ToString();
                    }
                }

                pnlTax.Visible = false;
            }
        }

        private void lblTax_Click(object sender, EventArgs e)
        {
            Taxing t = new Taxing();
            DataTable dt = d.select_taxing();
            foreach (DataRow dr in dt.Rows)
            {
                int n = t.dgvAddTaxing.Rows.Add();
                t.dgvAddTaxing.Rows[n].Cells[0].Value = dr["taxschemename"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[1].Value = dr["taxname"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[2].Value = dr["taxrate"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[3].Value = dr["taxonshipping"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[4].Value = dr["secondarytax"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[5].Value = dr["secondarytaxrate"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[6].Value = dr["secondarytaxon"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[7].Value = dr["compoundsceondary"].ToString();

            }

           
            t.Show();
            //Taxing ts = new Taxing();
            //ts.Show();
            pnlTax.Visible = false;
            //ts.dgvAddTaxing.DataSource = d.taxing();
            ////this.Dispose();
        }

        private void cmbbox6_Click(object sender, EventArgs e)
        {
            mcsd.Location = new Point(303, 365);
            tabPage1.Controls.Add(mcsd);
            mcsd.Size = new Size(150, 50);
            mcsd.BringToFront();

            mcsd.DateSelected -= new DateRangeEventHandler(mcsd_DateSelected);
            mcsd.DateSelected += new DateRangeEventHandler(mcsd_DateSelected);
            mcsd.Visible = true;
        }

        private void mcsd_DateSelected(object sender, DateRangeEventArgs e)
        {
            //cmbbox6.Text = mc.SelectionStart.ToString();
            cmbbox6.Text = e.Start.ToShortDateString();
            //cmbbox6.Text = e.Start.ToShortDateString();
            BAL.Dateporeqdate = Convert.ToDateTime(cmbbox6.Text);

            mcsd.Visible = false;
        }

        //----------------------------------BOTTOM SAVE------------------------------//

        public void fulpay()
        {
            btnFul.Location = new Point(262, 476);
            btnFul.Size = new Size(75, 23);
            btnFul.Text = "Fullfilled";
            btnFul.BackColor = Color.AliceBlue;
            tabPage1.Controls.Add(btnFul);

            btnPay.Location = new Point(355, 476);
            btnPay.Size = new Size(75, 23);
            btnPay.Text = "Paid";
            btnPay.BackColor = Color.AliceBlue;
            tabPage1.Controls.Add(btnPay);

            btnFul.Visible = true;
            btnPay.Visible = true;

            btn2.Visible = false;

            btnFul.Click -= new EventHandler(btnFul_Click);
            btnFul.Click += new EventHandler(btnFul_Click);
            btnPay.Click -= new EventHandler(btnPay_Click);
            btnPay.Click += new EventHandler(btnPay_Click);
        }

        public void fulpaysave()
        {
            btn2.Visible = false;

            btnFul.Location = new Point(262, 476);
            btnFul.Size = new Size(75, 23);
            btnFul.Text = "Unfullfilled";
            btnFul.BackColor = Color.AliceBlue;
            tabPage1.Controls.Add(btnFul);


            btnPay.Location = new Point(355, 476);
            btnPay.Size = new Size(75, 23);
            btnPay.Text = "Paid";
            btnPay.BackColor = Color.AliceBlue;
            tabPage1.Controls.Add(btnPay);

            btnFul.Visible = true;
            btnPay.Visible = true;

            btnPay.Click -= new EventHandler(btnPay_Click);
            btnFul.Click -= new EventHandler(btnFul_Click); 
            btnPay.Click += new EventHandler(btnPay_Click);
            btnFul.Click += new EventHandler(btnFul_Click);
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //btn2.Visible = false;
            //btnFul.Visible = true;
            //btnPay.Visible = true;

            
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                //p.Isno = 0;
                p.Povid = "";
                BAL.Povname = cmbbox9.Text;
                BAL.Poorderno = txtbox18.Text;
                p.Iid = dataGridView3.Rows[i].Cells[0].Value.ToString();
                p.Iiname = dataGridView3.Rows[i].Cells[1].Value.ToString();
                if (dataGridView3.Rows[i].Cells[2].Value == null)
                    p.Ides = null;
                else
                    p.Ides = dataGridView3.Rows[i].Cells[2].Value.ToString();

                if (dataGridView3.Rows[i].Cells[3].Value == null)
                    p.Icode = "0";
                else
                    p.Icode = dataGridView3.Rows[i].Cells[3].Value.ToString();
                p.Iquantity = dataGridView3.Rows[i].Cells[4].Value.ToString();
                p.Iuprice = dataGridView3.Rows[i].Cells[5].Value.ToString();
                p.Idiscount = dataGridView3.Rows[i].Cells[6].Value.ToString();
                p.Isubtotal = dataGridView3.Rows[i].Cells[7].Value.ToString();
                d.Insertitemorder(p);

                DataTable dt = new DataTable();
                 d.selectQOH(p);
                int qoh = int.Parse(p.QuanOnHand1);
                p.QuanOnHand1 = (Convert.ToInt32(qoh) - Convert.ToInt32(p.Iquantity)).ToString();
                d.updateQOH(p);
                p.Type = "Purchase Order";
                //Prop.Poorderno = txtbox18.Text;
                //Prop.Povname = cmbbox9.Text;

                string MyStringOh = cmbbox13.Text;
                DateTime MyDateTimeOh = DateTime.ParseExact(MyStringOh, "dd-MM-yyyy", null);
                BAL.Datepoorderdate = Convert.ToDateTime(MyDateTimeOh);
                BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                p.Iid = dataGridView3.Rows[i].Cells[0].Value.ToString();
                //p.Iiname = dataGridView3.Rows[i].Cells[1].Value.ToString();
                //p.Iquantity = dataGridView3.Rows[i].Cells[4].Value.ToString();
                //p.Isubtotal = dataGridView3.Rows[i].Cells[7].Value.ToString();
                d.OrderHistoryInsert(p);
            }


            //for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            //{
            //    //p.Isno = 0;
            //    p.Povid = "";
            //    BAL.Povname = cmbbox9.Text;
            //    BAL.Poorderno = txtbox18.Text;
            //    p.Iiname = dataGridView3.Rows[i].Cells[0].Value.ToString();
            //    if (dataGridView3.Rows[i].Cells[1].Value == null)
            //        p.Ides = null;
            //    else
            //        p.Ides = dataGridView3.Rows[i].Cells[1].Value.ToString();

            //    if (dataGridView3.Rows[i].Cells[2].Value == null)
            //        p.Icode = "0";
            //    else
            //        p.Icode = dataGridView3.Rows[i].Cells[2].Value.ToString();
            //    p.Iquantity = dataGridView3.Rows[i].Cells[3].Value.ToString();
            //    p.Iuprice = dataGridView3.Rows[i].Cells[4].Value.ToString();
            //    p.Idiscount = dataGridView3.Rows[i].Cells[5].Value.ToString();
            //    p.Isubtotal = dataGridView3.Rows[i].Cells[6].Value.ToString();
            //    d.Insertitemorder(p);
            //}
            txtboxPay.Text = "Unpaid";

            p.Povid = "";
            BAL.Povname = cmbbox9.Text;
            BAL.Poorderdate = cmbbox13.Text;
            p.Poddate = cmbbox2.Text;
            p.Trans = "Payment Order " + txtbox18.Text;
            p.Pototal = txtbox4.Text;
            p.Cbal = "0";
            p.Balph = txtbox4.Text;
            d.Insertphistory(p);

            p.Povid = "";
            //p.Povid = txtVOrder.Text;
            BAL.Povname = cmbbox9.Text;
            BAL.Pocname = txtbox14.Text;
            BAL.Poph = txtbox15.Text;
            BAL.Poaddr = txtbox16.Text;
            BAL.Poterms = cmbTerms.Text;
            BAL.Poloc = cmbbox12.Text;
            BAL.Poorderno = txtbox18.Text;

            //cmbbox13.Text = Convert.ToString(DateTime.Today);

            //string MyStringO = cmbbox13.Text;
            //DateTime MyDateTimeO = new DateTime();
            //MyDateTimeO = DateTime.Parse(MyStringO);
            //string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");

            //cmbbox13.Text = formattedO.ToString();

            //DateTime date = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null);

            string MyStringO = cmbbox13.Text;
            DateTime MyDateTimeO = DateTime.ParseExact(MyStringO, "dd-MM-yyyy", null);
            //string formattedO = MyDateTimeO.ToString("MM-dd-yyyy");
            //string formattedO = DateTime.ParseExact(cmbbox13.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();

            //string MyStringO = cmbbox13.Text;
            //DateTime MyDateTimeO = new DateTime();
            //MyDateTimeO = DateTime.ParseExact(MyStringO,"dd-MM-yyyy",null);
            //string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");

            BAL.Datepoorderdate = Convert.ToDateTime(MyDateTimeO);

            BAL.Poistatus = txtbox19.Text;
            BAL.Popstatus = "Unpaid";
            p.Poshpaddr = txtSaddr.Text;
            p.Pocarrier = cmbCarrier.Text;

            string MyStringD = cmbbox2.Text;
            DateTime MyDateTimeD = DateTime.ParseExact(MyStringD, "dd-MM-yyyy", null);

            BAL.Datepoduedate = Convert.ToDateTime(MyDateTimeD);

            p.Potaxscheme = cmbbox3.Text;
            p.Pononvendor = cmbbox4.Text;
            p.Pocurrency = cmbbox5.Text;

            string MyStringR = cmbbox6.Text;
            DateTime MyDateTimeR = DateTime.ParseExact(MyStringD, "dd-MM-yyyy", null);
            
            BAL.Dateporeqdate = Convert.ToDateTime(MyDateTimeR);

            p.Porshpdate = cmbbox6.Text;
            p.Poremarks = txtbox2.Text;
            p.Postotal = txtbox3.Text;
            p.Pofreight = txtFreight.Text;
            //p.Stax=textBox4.Text;
            //p.Ctax=textBox5.Text;
            p.Postax = txtSTax.Text;
            p.Poctax = txtCTax.Text;
            p.Pototal = txtbox4.Text;
            p.Popaid = txtbox5.Text;
            p.Pobalance = txtbox6.Text;
            p.Paging = Paying.Text;
            d.InsertPO(p);
            MessageBox.Show("Data Inserted Successfully");
            btn11_Click_1(null,null);

            //dataGridView1.DataSource = d.SelectOrder();
        }

        private void btnFul_Click(object sender, EventArgs e)
        {
            if (btnFul.Text == "Fullfilled")
            {
                txtbox19.Text = "Fullfilled";
                btnFul.Text = "Unfullfilled";

                pb.Image = Image.FromFile("D:\\Gowtham\\projectIntegration\\Images\\images.jpg");
                tabPage1.Controls.Add(pb);
                pb.Location = new Point(150, 190);
                pb.Size = new Size(215, 83);
                tabPage1.Controls.Add(pb);
                pb.BringToFront();

                pb1.Image = Image.FromFile("D:\\Gowtham\\projectIntegration\\Images\\images.jpg");
                tabPage2.Controls.Add(pb1);
                pb1.Location = new Point(150, 190);
                pb1.Size = new Size(215, 83);
                tabPage2.Controls.Add(pb1);
                pb1.BringToFront();

                pb.Visible = true;
                pb1.Visible = true;
                if (lnklbl2.Text != "Add Shipping")
                {
                    lnkRshp_LinkClicked(null, null);
                    linkLabel2_LinkClicked(null, null);
                }
                cmbbox19.Text = cmbbox9.Text;
                txtbox21.Text = txtbox14.Text;
                txtbox20.Text = txtbox15.Text;
                txtbox17.Text = txtbox16.Text;
                cmbTerms.Text = cmbTerms.Text;
                cmbbox18.Text = cmbbox12.Text;
                txtbox13.Text = txtbox18.Text;
                cmbbox17.Text = cmbbox13.Text;
                txtbox12.Text = txtbox19.Text;
                txtboxps.Text = txtboxPay.Text;
                txtRshp.Text = txtSaddr.Text;
                txtbox11.Text = txtbox2.Text;

                for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                {
                    i = dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    dataGridView2.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value.ToString();

                    dataGridView2.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    if (dataGridView3.Rows[i].Cells[3].Value == "0")
                        dataGridView2.Rows[i].Cells[3].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
                    else
                        dataGridView2.Rows[i].Cells[3].Value = "0";
                    dataGridView2.Rows[i].Cells[4].Value = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    dataGridView2.Rows[i].Cells[5].Value = cmbbox12.Text;

                    dataGridView2.Rows[i].Cells[6].Value = Convert.ToString(DateTime.Today);
                    string MyStringO = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    DateTime MyDateTimeO = new DateTime();
                    MyDateTimeO = DateTime.Parse(MyStringO);
                    string formattedO = MyDateTimeO.ToString("dd/MM/yyyy");
                    cmbbox13.Text = formattedO.ToString();

                    //dataGridView2.Rows[i].Cells[6].Value = cmbbox13.Text;

                    p.Iid = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    p.Iiname = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    p.Ides = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    p.Trans = "Purchase Order Receive";
                    string MyStringOh = cmbbox13.Text;
                    DateTime MyDateTimeOh = DateTime.ParseExact(MyStringOh, "dd-MM-yyyy", null);
                    BAL.Datepoorderdate = Convert.ToDateTime(MyDateTimeOh);
                    BAL.Poloc = cmbbox12.Text;
                    BAL.Poorderno = txtbox18.Text;
                    DataTable dt = new DataTable();
                    d.selectQOH(p);
                    int qoh = int.Parse(p.QuanOnHand1);
                    p.QuanOnHand1 = (Convert.ToInt32(qoh) + Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value.ToString())).ToString();
                    p.Iquantity = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    p.QAfter1 = (Convert.ToInt32(p.QuanOnHand1) - Convert.ToInt32(p.Iquantity)).ToString();
                    d.MovementHistoryInsert(p);

                }
                BAL.Poorderno = txtbox18.Text;
                BAL.Poistatus = txtbox19.Text;
                BAL.Popstatus = txtboxPay.Text;
            
                d.updateistatus(p);

                BAL.Poorderno = txtbox18.Text;
                BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                d.OrderHistoryUpdate(p);


                //if (lnklbl2.Text == "No Shipping")
                //{
                //    lnkRshp_LinkClicked(null, null);
                //}
                //cmbbox19.Text = cmbbox9.Text;
                //txtbox21.Text = txtbox14.Text;
                //txtbox20.Text = txtbox15.Text;
                //txtbox17.Text = txtbox16.Text;
                //cmbTerms.Text = cmbTerms.Text;
                //cmbbox18.Text = cmbbox12.Text;
                //txtbox13.Text = txtbox18.Text;
                //cmbbox17.Text = cmbbox13.Text;
                //txtbox12.Text = txtbox19.Text;
                //txtboxps.Text = txtboxPay.Text;
                //txtRshp.Text = txtSaddr.Text;
                //txtbox11.Text = txtbox2.Text;

                //for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                //{
                //    i = dataGridView2.Rows.Add();
                //    dataGridView2.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                //    dataGridView2.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
                //    dataGridView2.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                //    dataGridView2.Rows[i].Cells[3].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
                //    dataGridView2.Rows[i].Cells[4].Value = cmbbox12.Text;
                //    dataGridView2.Rows[i].Cells[5].Value = cmbbox13.Text;
                //}
                


            }
            else
            {
                txtbox19.Text = "Unfullfilled";
                btnFul.Text = "Fullfilled";

                //pb.Hide();
                //pb1.Hide();

                pb.Visible = false;
                pb1.Visible = false;
                pb2.Visible = false;

                BAL.Poorderno = txtbox18.Text;
                BAL.Poistatus = txtbox19.Text;
                BAL.Popstatus = txtboxPay.Text;
                d.updateistatus(p);
            }
        }

        byte[] Readfile(string sPath)
        {
            byte[] data = null;
            FileInfo fi = new FileInfo(sPath);
            FileStream fs = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            long numBytes = fi.Length;
            BinaryReader br = new BinaryReader(fs);
            data = br.ReadBytes((int)numBytes);
            return data;

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (btnPay.Text == "Paid")
            {
                //txtboxPay.Text = "Paid";
                float bal;
                float total;
                float paid;
                float paging;
                float t;
                total = float.Parse(txtbox4.Text);
                paid = float.Parse(txtbox5.Text);
                paging = float.Parse(Paying.Text);

                float pa = paid + float.Parse(Paying.Text);
                txtbox5.Text = pa.ToString();
                bal = total - pa;
                t = float.Parse(Paying.Text);
                txtbox6.Text = bal.ToString();

                //Paging.Text = "0";
                //btnPay_Click(null, null);

                //if(bal>t)
                //{
                //}

                if ((bal < (total / 2)) && (bal != 0))
                {
                    txtboxPay.Text = "Partial";

                    p.Povid = "";
                    BAL.Povname = cmbbox9.Text;
                    BAL.Poorderdate = cmbbox13.Text;
                    p.Poddate = "";
                    p.Trans = "Payment for " + txtbox18.Text;
                    p.Pototal = Paying.Text;
                    p.Cbal = "0";
                    p.Balph = txtbox6.Text;
                    d.Insertphistory(p);


                    BAL.Povname = cmbbox9.Text;
                    BAL.Pocname = txtbox14.Text;
                    BAL.Poph = txtbox15.Text;
                    BAL.Poaddr = txtbox16.Text;
                    BAL.Poterms = cmbTerms.Text;
                    BAL.Poloc = cmbbox12.Text;

                    BAL.Poorderno = txtbox18.Text;

                    string MyStringO = cmbbox13.Text;
                    DateTime MyDateTimeO = new DateTime();
                    MyDateTimeO = DateTime.Parse(MyStringO);
                    string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");

                    BAL.Datepoorderdate = Convert.ToDateTime(formattedO);


                    //string MyStringO = cmbbox13.Text;
                    ////DateTime MyDateTimeO = new DateTime();
                    //DateTime dt1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    //dt1 = DateTime.Parse(MyStringO);
                    //string formattedO = dt1.ToString("dd-MM-yyyy");
                    //BAL.Datepoorderdate = Convert.ToDateTime(formattedO);

                    BAL.Poistatus = txtbox19.Text;
                    BAL.Popstatus = txtboxPay.Text;

                    p.Poshpaddr = txtshp.Text;
                    p.Pocarrier = cmbCarrier.Text;

                    string MyStringd = cmbbox2.Text;
                    DateTime MyDateTimed = new DateTime();
                    MyDateTimed = DateTime.Parse(MyStringd);
                    string formattedd = MyDateTimed.ToString("dd-MM-yyyy");

                    BAL.Datepoduedate = Convert.ToDateTime(formattedd);

                    p.Potaxscheme = cmbbox3.Text;
                    p.Pononvendor = cmbbox4.Text;
                    p.Pocurrency = cmbbox5.Text;

                    string MyStringr = cmbbox6.Text;
                    DateTime MyDateTimer = new DateTime();
                    MyDateTimer = DateTime.Parse(MyStringO);
                    string formattedr = MyDateTimer.ToString("dd-MM-yyyy");

                    BAL.Dateporeqdate = Convert.ToDateTime(formattedr);

                    p.Poremarks = txtbox2.Text;

                    p.Postotal = txtbox3.Text;
                    p.Pofreight = txtFreight.Text;
                    p.Postax = txtSTax.Text;
                    p.Poctax = txtCTax.Text;
                    p.Pototal = txtbox4.Text;
                    p.Popaid = txtbox5.Text;
                    p.Pobalance = txtbox6.Text;
                    p.Paging = Paying.Text;
                    p.Paging = "0";
                    d.UpdatePO1(p);

                    Paying.Text = "0";

                    BAL.Poorderno = txtbox18.Text;
                    BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                    d.OrderHistoryUpdate(p);
                }
                else if (bal > (total / 2))
                {
                    txtboxPay.Text = "Unpaid";

                    p.Povid = "";
                    BAL.Povname = cmbbox9.Text;
                    BAL.Poorderdate = cmbbox13.Text;
                    p.Poddate = "";
                    p.Trans = "Payment for " + txtbox18.Text;
                    p.Pototal = txtbox4.Text;
                    p.Cbal = "0";
                    p.Balph = txtbox6.Text;
                    d.Insertphistory(p);


                    BAL.Povname = cmbbox9.Text;
                    BAL.Pocname = txtbox14.Text;
                    BAL.Poph = txtbox15.Text;
                    BAL.Poaddr = txtbox16.Text;
                    BAL.Poterms = cmbTerms.Text;
                    BAL.Poloc = cmbbox12.Text;

                    BAL.Poorderno = txtbox18.Text;

                    string MyStringO = cmbbox13.Text;
                    DateTime MyDateTimeO = new DateTime();
                    MyDateTimeO = DateTime.Parse(MyStringO);
                    string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");

                    BAL.Datepoorderdate = Convert.ToDateTime(formattedO);


                    //string MyStringO = cmbbox13.Text;
                    ////DateTime MyDateTimeO = new DateTime();
                    //DateTime dt1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    //dt1 = DateTime.Parse(MyStringO);
                    //string formattedO = dt1.ToString("dd-MM-yyyy");
                    //BAL.Datepoorderdate = Convert.ToDateTime(formattedO);

                    BAL.Poistatus = txtbox19.Text;
                    BAL.Popstatus = txtboxPay.Text;

                    p.Poshpaddr = txtshp.Text;
                    p.Pocarrier = cmbCarrier.Text;

                    string MyStringd = cmbbox2.Text;
                    DateTime MyDateTimed = new DateTime();
                    MyDateTimed = DateTime.Parse(MyStringd);
                    string formattedd = MyDateTimed.ToString("dd-MM-yyyy");

                    BAL.Datepoduedate = Convert.ToDateTime(formattedd);

                    p.Potaxscheme = cmbbox3.Text;
                    p.Pononvendor = cmbbox4.Text;
                    p.Pocurrency = cmbbox5.Text;

                    string MyStringr = cmbbox6.Text;
                    DateTime MyDateTimer = new DateTime();
                    MyDateTimer = DateTime.Parse(MyStringO);
                    string formattedr = MyDateTimer.ToString("dd-MM-yyyy");

                    BAL.Dateporeqdate = Convert.ToDateTime(formattedr);

                    p.Poremarks = txtbox2.Text;

                    p.Postotal = txtbox3.Text;
                    p.Pofreight = txtFreight.Text;
                    p.Postax = txtSTax.Text;
                    p.Poctax = txtCTax.Text;
                    p.Pototal = txtbox4.Text;
                    p.Popaid = txtbox5.Text;
                    p.Pobalance = txtbox6.Text;
                    //p.Paging = Paying.Text;
                    p.Paging = "0";
                    d.UpdatePO1(p);
                    //btnPay.Text = "Unpaid";

                    Paying.Text = "0";

                    BAL.Poorderno = txtbox18.Text;
                    BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                    d.OrderHistoryUpdate(p);
                }
                else
                {
                    txtboxPay.Text = "Paid";

                    p.Povid = "";
                    BAL.Povname = cmbbox9.Text;
                    BAL.Poorderdate = cmbbox13.Text;
                    p.Poddate = "";
                    p.Trans = "Payment for " + txtbox18.Text;
                    p.Pototal = txtbox4.Text;
                    p.Cbal = "0";
                    p.Balph = txtbox6.Text;
                    d.Insertphistory(p);

                    BAL.Povname = cmbbox9.Text;
                    BAL.Pocname = txtbox14.Text;
                    BAL.Poph = txtbox15.Text;
                    BAL.Poaddr = txtbox16.Text;
                    BAL.Poterms = cmbTerms.Text;
                    BAL.Poloc = cmbbox12.Text;

                    BAL.Poorderno = txtbox18.Text;

                    string MyStringO = cmbbox13.Text;
                    DateTime MyDateTimeO = new DateTime();
                    MyDateTimeO = DateTime.Parse(MyStringO);
                    string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");

                    BAL.Datepoorderdate = Convert.ToDateTime(formattedO);


                    //string MyStringO = cmbbox13.Text;
                    ////DateTime MyDateTimeO = new DateTime();
                    //DateTime dt1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    //dt1 = DateTime.Parse(MyStringO);
                    //string formattedO = dt1.ToString("dd-MM-yyyy");
                    //BAL.Datepoorderdate = Convert.ToDateTime(formattedO);

                    BAL.Poistatus = txtbox19.Text;
                    BAL.Popstatus = txtboxPay.Text;

                    p.Poshpaddr = txtshp.Text;
                    p.Pocarrier = cmbCarrier.Text;

                    string MyStringd = cmbbox2.Text;
                    DateTime MyDateTimed = new DateTime();
                    MyDateTimed = DateTime.Parse(MyStringd);
                    string formattedd = MyDateTimed.ToString("dd-MM-yyyy");

                    BAL.Datepoduedate = Convert.ToDateTime(formattedd);

                    p.Potaxscheme = cmbbox3.Text;
                    p.Pononvendor = cmbbox4.Text;
                    p.Pocurrency = cmbbox5.Text;

                    string MyStringr = cmbbox6.Text;
                    DateTime MyDateTimer = new DateTime();
                    MyDateTimer = DateTime.Parse(MyStringO);
                    string formattedr = MyDateTimer.ToString("dd-MM-yyyy");

                    BAL.Dateporeqdate = Convert.ToDateTime(formattedr);

                    p.Poremarks = txtbox2.Text;

                    p.Postotal = txtbox3.Text;
                    p.Pofreight = txtFreight.Text;
                    p.Postax = txtSTax.Text;
                    p.Poctax = txtCTax.Text;
                    p.Pototal = txtbox4.Text;
                    p.Popaid = txtbox5.Text;
                    p.Pobalance = txtbox6.Text;
                    //p.Paging = Paying.Text;
                    p.Paging = "0";
                    d.UpdatePO1(p);
                    btnPay.Text = "Unpaid";

                    Paying.Text = "0";

                    BAL.Poorderno = txtbox18.Text;
                    BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                    d.OrderHistoryUpdate(p);
                }

            }
            else if (btnPay.Text == "Unpaid")
            {
                txtboxPay.Text = "Unpaid";
                btnPay.Text = "Paid";

                p.Povid = "";
                BAL.Povname = cmbbox9.Text;
                BAL.Poorderdate = cmbbox13.Text;
                p.Poddate = "";
                p.Trans = "Refund for " + txtbox18.Text;
                p.Pototal = txtbox4.Text;
                p.Cbal = "0";
                p.Balph = txtbox4.Text;
                d.Insertphistory(p);

                txtbox4.ReadOnly = false;
                txtbox5.ReadOnly = false;
                Paying.ReadOnly = false;
                txtbox6.ReadOnly = false;

                BAL.Povname = cmbbox9.Text;
                BAL.Pocname = txtbox14.Text;
                BAL.Poph = txtbox15.Text;
                BAL.Poaddr = txtbox16.Text;
                BAL.Poterms = cmbTerms.Text;
                BAL.Poloc = cmbbox12.Text;

                BAL.Poorderno = txtbox18.Text;

                string MyStringO = cmbbox13.Text;
                DateTime MyDateTimeO = new DateTime();
                MyDateTimeO = DateTime.Parse(MyStringO);
                string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");

                BAL.Datepoorderdate = Convert.ToDateTime(formattedO);


                //string MyStringO = cmbbox13.Text;
                ////DateTime MyDateTimeO = new DateTime();
                //DateTime dt1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                //dt1 = DateTime.Parse(MyStringO);
                //string formattedO = dt1.ToString("dd-MM-yyyy");
                //BAL.Datepoorderdate = Convert.ToDateTime(formattedO);

                BAL.Poistatus = txtbox19.Text;
                BAL.Popstatus = txtboxPay.Text;

                p.Poshpaddr = txtshp.Text;
                p.Pocarrier = cmbCarrier.Text;

                string MyStringd = cmbbox2.Text;
                DateTime MyDateTimed = new DateTime();
                MyDateTimed = DateTime.Parse(MyStringd);
                string formattedd = MyDateTimed.ToString("dd-MM-yyyy");

                BAL.Datepoduedate = Convert.ToDateTime(formattedd);

                p.Potaxscheme = cmbbox3.Text;
                p.Pononvendor = cmbbox4.Text;
                p.Pocurrency = cmbbox5.Text;

                string MyStringr = cmbbox6.Text;
                DateTime MyDateTimer = new DateTime();
                MyDateTimer = DateTime.Parse(MyStringO);
                string formattedr = MyDateTimer.ToString("dd-MM-yyyy");

                BAL.Dateporeqdate = Convert.ToDateTime(formattedr);

                p.Poremarks = txtbox2.Text;


                p.Postotal = txtbox3.Text;
                p.Pofreight = txtFreight.Text;
                p.Postax = txtSTax.Text;
                p.Poctax = txtCTax.Text;
                p.Pototal = txtbox4.Text;
                p.Popaid = "0";
                p.Pobalance = txtbox4.Text;
                //p.Paging = Paying.Text;
                p.Paging = "0";
                d.UpdatePO1(p);
                //btnPay.Text = "Unpaid";

                txtbox6.Text = txtbox4.Text;
                txtbox5.Text = Paying.Text = "0";
                
                //BAL.Poorderno = txtbox18.Text;
                //BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                //d.OrderHistoryUpdate(p);
            }
        }

        private void cmbbox13_Click(object sender, EventArgs e)
        {
            mc.Location = new Point(403, 54);
            tabPage1.Controls.Add(mc);
            mc.Size = new Size(150, 50);
            mc.BringToFront();

            mc.DateSelected -= new DateRangeEventHandler(mc_DateSelected);
            mc.DateSelected += new DateRangeEventHandler(mc_DateSelected);
            mc.Visible = true;
        }
        private void mc_DateSelected(object sender, DateRangeEventArgs e)
        {
            //cmbbox13.Text = mc.SelectionStart.ToString();
            cmbbox13.Text = e.Start.ToShortDateString();
            //cmbbox13.Text = e.Start.ToShortDateString();
            //string dte = cmbbox13.Text;
            //DateTime dt = DateTime.ParseExact(dte.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            //string date = dt.ToString();
            BAL.Datepoorderdate = DateTime.Parse(cmbbox13.Text);
            mc.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmbbox19.Text = cmbbox9.Text;
            txtbox21.Text = txtbox14.Text;
            txtbox20.Text = txtbox15.Text;
            txtbox17.Text = txtbox16.Text;
            cmbbox18.Text = cmbbox12.Text;
            txtbox13.Text = txtbox18.Text;
            cmbbox17.Text = cmbbox13.Text;
            txtbox12.Text = txtbox19.Text;
            txtboxps.Text = txtboxPay.Text;

            string item, des, code, quantity, location, rdate;
            item = p.Iiname;
            des = p.Ides;
            code = p.Icode;
            quantity = p.Iquantity;
            location = cmbbox12.Text;
            rdate = cmbbox13.Text;
            //dataGridView2.DataSource = d.SelectItemForm();
            int i = dataGridView2.Rows.Add();
            dataGridView2.Rows[i].Cells[0].Value = item.ToString();
            dataGridView2.Rows[i].Cells[1].Value = des.ToString();
            dataGridView2.Rows[i].Cells[2].Value = code.ToString();
            dataGridView2.Rows[i].Cells[3].Value = quantity.ToString();
            dataGridView2.Rows[i].Cells[4].Value = cmbbox12.Text;
            dataGridView2.Rows[i].Cells[5].Value = cmbbox13.Text;
        }

        private void PurhcaseOrder_Click(object sender, EventArgs e)
        {
            //pnlPay.Visible = false;
        }

        //---------------------------------------------SEARCH--------------------------------------------//
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();

            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();

            dataGridView5.DataSource = null;
            dataGridView5.Rows.Clear();

            dataGridView1.ReadOnly = true;

            txtbox4.ReadOnly = false;
            txtbox5.ReadOnly = false;
            Paying.ReadOnly = false;
            txtbox6.ReadOnly = false;

           // pb2.Visible = false;
           
            BAL.Poorderno = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            BAL.Popstatus = cmbbox15.Text;

            DataTable dt = new DataTable();
            dt = d.POIStatusAllVOI();

            if (e.RowIndex >= 0)
            {

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count; i++)
                    {

                        cmbbox19.Text = cmbbox22.Text = cmbbox25.Text = cmbbox9.Text = dt.Rows[i]["vendorname"].ToString();
                        txtbox21.Text = txtbox27.Text = txtbox36.Text = txtbox14.Text = dt.Rows[i]["contactname"].ToString();
                        txtbox20.Text = txtbox26.Text = txtbox35.Text = txtbox15.Text = dt.Rows[i]["phone"].ToString();
                        txtbox17.Text = txtbox25.Text = txtbox34.Text = txtbox16.Text = dt.Rows[i]["address"].ToString();
                        cmbTermsR.Text = cmbTermsReturn.Text = cmbTermsU.Text = cmbTerms.Text = dt.Rows[i]["terms"].ToString();
                        //txtVOrderR.Text = txtVOrderReturn.Text = txtVOrderU.Text = txtVOrder.Text = dt.Rows[i]["vendorid"].ToString();
                        cmbbox18.Text = cmbbox21.Text = cmbbox24.Text = cmbbox12.Text = dt.Rows[i]["location"].ToString();
                        txtbox13.Text = txtbox24.Text = txtbox33.Text = txtbox18.Text = dt.Rows[i]["poorderno"].ToString();

                        string MyStringO = dt.Rows[i]["orderdate"].ToString();
                        DateTime MyDateTimeO = new DateTime();
                        MyDateTimeO = DateTime.Parse(MyStringO);
                        string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");

                        cmbbox17.Text = cmbbox20.Text = cmbbox23.Text = cmbbox13.Text = formattedO.ToString();
                        txtbox12.Text = txtbox23.Text = txtbox32.Text = txtbox19.Text = dt.Rows[i]["inventorystatus"].ToString();
                        txtboxps.Text = txtReturnPay.Text = txtboxUPay.Text = txtboxPay.Text = dt.Rows[i]["paymentstatus"].ToString();
                        
                        if (txtbox19.Text == "Fullfilled")
                        {
                            pb.Image = Image.FromFile("D:\\Gowtham\\projectIntegration\\Images\\images.jpg");
                            pb.Location = new Point(150, 200);
                            pb.Size = new Size(225, 83);
                            tabPage1.Controls.Add(pb);
                            pb.BringToFront();
                            pb.Visible = true;

                            pb1.Image = Image.FromFile("D:\\Gowtham\\projectIntegration\\Images\\images.jpg");
                            pb1.Location = new Point(150, 220);
                            pb1.Size = new Size(225, 83);
                            tabPage2.Controls.Add(pb1);
                            pb1.BringToFront();
                            pb1.Visible = true;

                            pb3.Image = Image.FromFile("D:\\Gowtham\\projectIntegration\\Images\\images.jpg");
                            pb3.Location = new Point(150, 220);
                            pb3.Size = new Size(225, 83);
                            tabPage4.Controls.Add(pb3);
                            pb3.BringToFront();
                            pb3.Visible = true;

                            btnFul.Text = "Unfullfilled";
                            btnFul.Visible = true;

                            //btnFul_Click(null, null);
                            btn8.Text = "Cancel Order";
                            pb3.Visible = true;
                            
                            fulpaysave();
                            
                            Enable(this);
                        }

                        else if (txtbox19.Text == "Cancelled")
                        {
                            btnCancel();
                        }

                        else
                        {
                            btn8.Text = "Cancel Order";
                            pb.Visible = false;
                            pb1.Visible = false;
                            pb3.Visible = false;
                            Enable(this);
                            fulpay();
                        }

                        if (txtboxPay.Text == "Paid")
                        {
                            btnPay.Text = "Unpaid";
                        }

                        txtRshp.Text = txtReturnShp.Text = txtboxUShp.Text = txtshp.Text = dt.Rows[i]["shippingaddress"].ToString();
                        cmbCarrier.Text = dt.Rows[i]["carrier"].ToString();

                        string MyStringd = dt.Rows[i]["duedate"].ToString();
                        DateTime MyDateTimed = new DateTime();
                        MyDateTimed = DateTime.Parse(MyStringO);
                        string formattedd = MyDateTimed.ToString("dd-MM-yyyy");

                        cmbbox2.Text = formattedd.ToString();
                        cmbbox3.Text = dt.Rows[i]["taxingscheme"].ToString();
                        if ((cmbbox3.Text != "NO TAX" || cmbbox3.Text != "No Tax") && (cmbTerms.Text != ""))
                        {
                            no_shp();
                        }
                        cmbbox4.Text = dt.Rows[i]["nonvendorcosts"].ToString();
                        cmbbox5.Text = dt.Rows[i]["currency"].ToString();

                        string MyStringr = dt.Rows[i]["reqshipdate"].ToString();
                        DateTime MyDateTimer = new DateTime();
                        MyDateTimer = DateTime.Parse(MyStringr);
                        string formattedr = MyDateTimer.ToString("dd-MM-yyyy");

                        cmbbox6.Text = formattedr.ToString();
                        txtbox2.Text = dt.Rows[i]["remarks"].ToString();
                        txtbox10.Text = txtbox3.Text = dt.Rows[i]["subtotal"].ToString();
                        txtReturnF.Text = txtFreight.Text = dt.Rows[i]["freight"].ToString();
                        txtReturnSTax.Text = txtSTax.Text = dt.Rows[i]["statetax"].ToString();
                        txtReturnCTax.Text = txtCTax.Text = dt.Rows[i]["citytax"].ToString();
                        txtbox9.Text = txtbox4.Text = dt.Rows[i]["total"].ToString();
                        txtbox8.Text = txtbox5.Text = dt.Rows[i]["paid"].ToString();
                        Paying.Text = "0";
                        txtbox6.Text = dt.Rows[i]["balance"].ToString();

                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            int j = dataGridView3.Rows.Add();
                            dataGridView3.Rows[j].Cells[0].Value = dt.Rows[i]["productid"].ToString();
                            dataGridView3.Rows[j].Cells[1].Value = dt.Rows[i]["itemname"].ToString();
                            dataGridView3.Rows[j].Cells[2].Value = dt.Rows[i]["description"].ToString();
                            dataGridView3.Rows[j].Cells[3].Value = dt.Rows[i]["vendorproductcode"].ToString();
                            dataGridView3.Rows[j].Cells[4].Value = dt.Rows[i]["quantity"].ToString();
                            dataGridView3.Rows[j].Cells[5].Value = dt.Rows[i]["unitprice"].ToString();
                            dataGridView3.Rows[j].Cells[6].Value = dt.Rows[i]["discount"].ToString();
                            dataGridView3.Rows[j].Cells[7].Value = dt.Rows[i]["subtotalI"].ToString();
                            //break;
                        }

                        if (txtbox19.Text == "Fullfilled" && (txtboxPay.Text == "Paid" || txtboxPay.Text == "Unpaid" || txtboxPay.Text == "Partial"))
                        {
                            dt = d.SelectReceived(p);
                            for (i = 0; i < dt.Rows.Count; i++)
                            {
                                int j = dataGridView2.Rows.Add();
                                //dataGridView3.Rows.Clear();
                                dataGridView2.Rows[j].Cells[0].Value = dt.Rows[i]["itemname"].ToString();
                                dataGridView2.Rows[j].Cells[1].Value = dt.Rows[i]["description"].ToString();
                                dataGridView2.Rows[j].Cells[2].Value = dt.Rows[i]["vendorproductcode"].ToString();
                                dataGridView2.Rows[j].Cells[3].Value = dt.Rows[i]["quantity"].ToString();
                                dataGridView2.Rows[j].Cells[4].Value = dt.Rows[i]["location"].ToString(); 
                                dataGridView2.Rows[j].Cells[5].Value = dt.Rows[i]["recieveddate"].ToString();
                                //fulpaysave();
                            }
                        }

                        else if (txtbox19.Text == "Started" && (txtboxPay.Text == "Owing"))
                        {
                            dt = d.SOwing(p);
                            for (i = 0; i < dt.Rows.Count; i++)
                            {
                                int j = dataGridView4.Rows.Add();
                                dataGridView4.Rows[j].Cells[0].Value = dt.Rows[i]["productid"].ToString();
                                dataGridView4.Rows[j].Cells[1].Value = dt.Rows[i]["itemname"].ToString();
                                dataGridView4.Rows[j].Cells[2].Value = dt.Rows[i]["description"].ToString();
                                dataGridView4.Rows[j].Cells[3].Value = dt.Rows[i]["vendorproductcode"].ToString();
                                dataGridView4.Rows[j].Cells[4].Value = dt.Rows[i]["quantity"].ToString();
                                dataGridView4.Rows[j].Cells[5].Value = dt.Rows[i]["returndate"].ToString();
                                dataGridView4.Rows[j].Cells[6].Value = dt.Rows[i]["unitprice"].ToString();
                                dataGridView4.Rows[j].Cells[7].Value = dt.Rows[i]["discount"].ToString();
                                dataGridView4.Rows[j].Cells[8].Value = dt.Rows[i]["subtotal"].ToString();
                                //fulpaysave();
                                //break;
                            }
                        }


                        else if (txtbox19.Text == "Fullfilled" && (txtboxPay.Text == "Owing"))
                        {
                            dt = d.FOwing(p);
                            for (i = 0; i < dt.Rows.Count; i++)
                            {
                                int j = dataGridView5.Rows.Add();
                                //dataGridView3.Rows.Clear();
                                dataGridView5.Rows[j].Cells[0].Value = dt.Rows[i]["productid"].ToString();
                                dataGridView5.Rows[j].Cells[1].Value = dt.Rows[i]["itemname"].ToString();
                                dataGridView5.Rows[j].Cells[2].Value = dt.Rows[i]["description"].ToString();
                                dataGridView5.Rows[j].Cells[3].Value = dt.Rows[i]["quantity"].ToString();
                                dataGridView5.Rows[j].Cells[4].Value = dt.Rows[i]["unstockdate"].ToString();
                                dataGridView5.Rows[j].Cells[5].Value = dt.Rows[i]["location"].ToString();
                                //fulpaysave();
                                //break;
                            }
                        }

                        if (txtFreight.Text != "")
                        {
                            add_shp();

                            lnkRshp_LinkClicked(null, null);
                            linkLabel3_LinkClicked(null, null);
                            linkLabel4_LinkClicked(null, null);
                        }

                        else
                        {
                            no_shp();
                            
                            lblTermsR.Visible = lblTermsReturn.Visible = lblTermsU.Visible = false;
                            cmbTermsR.Visible = cmbTermsReturn.Visible = cmbTermsU.Visible = false;

                            lblVOrderR.Visible = lblVOrderReturn.Visible = lblVOrderU.Visible = false;
                            txtVOrderR.Visible = txtVOrderReturn.Visible = txtVOrderU.Visible = false;

                            lblShp.Visible = lblRshp.Visible = lblReturnShp.Visible = lblUSAddr.Visible = false;
                            txtshp.Visible = txtRshp.Visible = txtReturnShp.Visible = txtboxUShp.Visible = false;
                        }
                    }
                }
            }

            if (txtbox6.Text == "0" && txtbox4.Text == txtbox5.Text)
            {
                MessageBox.Show("Payment Successful", "");
                BAL.Popstatus = "Paid";
                txtbox4.ReadOnly = true;
                txtbox5.ReadOnly = true;
                Paying.ReadOnly = true;
                txtbox6.ReadOnly = true;
            }
        }

        

        //-------------------------------------------------VENDOR SEARCH-------------------------------------------//

        private void cmbbox1_Click(object sender, EventArgs e)
        {

            cmbbox1.ResetText();
            cmbbox14.ResetText();
            cmbbox15.ResetText();
            txtbox1.Clear();
            cmbLocation.ResetText();
            cmbRsdate.ResetText();
            cmbScancelled.ResetText();
            //dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();

            btn2.Visible = true;
            btnFul.Visible = false;
            btnPay.Visible = false;

            //btn11_Click_1(null, null);
            pnlVendorSearch.Visible = true;
            dgvVendorSearch.Visible = true;
            pnlVendorSearch.Location = new Point(154, 155);
            pnlVendorSearch.BackColor = Color.White;
            this.Controls.Add(pnlVendorSearch);
            //pnl3.Controls.Add(pnlVendorSearch);
            pnlVendorSearch.Size = new Size(250, 150);
            pnlVendorSearch.BorderStyle = BorderStyle.FixedSingle;

            pnlVendorSearch.Controls.Add(dgvVendorSearch);
            pnlVendorSearch.BringToFront();
            dgvVendorSearch.Size = new Size(249, 100);
            dgvVendorSearch.DataSource = d.SelectVdetails();
            dgvVendorSearch.ReadOnly = true;
            //dgvVendorSearch.AutoResizeColumns();

            this.Cursor = Cursors.Hand;

            dgvVendorSearch.CellClick -= new DataGridViewCellEventHandler(dgvVendorSearch_CellClick);
            btnAddSearch.Click -= new EventHandler(btnAdd_Click);
            dgvVendorSearch.CellClick += new DataGridViewCellEventHandler(dgvVendorSearch_CellClick);
            btnAddSearch.Click += new EventHandler(btnAdd_Click);

            if (dgvVendorSearch.Columns.Count == 2)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvVendorSearch.AutoGenerateColumns = false;
                dgvVendorSearch.Columns.Add(lnk);
                lnk.HeaderText = "Details";
                lnk.Name = "View Details";
                lnk.Text = "View Details";
                lnk.ActiveLinkColor = Color.Blue;
                lnk.LinkBehavior = LinkBehavior.SystemDefault;
                lnk.UseColumnTextForLinkValue = true;
            }


            lblAddSearch.Location = new Point(5, 110);
            lblAddSearch.Size = new Size(43, 13);
            //lblAddSearch.BackColor = Color.Black;
            lblAddSearch.Text = "Terms";
            //pnlLocation.Controls.Add(lblAddSearch);
            pnlVendorSearch.Controls.Add(lblAddSearch);


            txtAddSearch.Location = new Point(50, 110);
            txtAddSearch.Size = new Size(101, 21);
            pnlVendorSearch.Controls.Add(txtAddSearch);


            btnAddSearch.Location = new Point(160, 110);
            btnAddSearch.Size = new Size(75, 23);
            //btnAdd.BackColor = Color.Black;
            btnAddSearch.Text = "ADD NEW";
            //pnlLocation.Controls.Add(btnAdd);
            pnlVendorSearch.Controls.Add(btnAddSearch);
        }

        private void dgvVendorSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dgvVendorSearch.Rows)
            {

                DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
                if (clk.Selected == true)
                {
                    cmbbox1.Text = dgvVendorSearch.CurrentRow.Cells[0].Value.ToString();
                }
            }

            DataTable dt = new DataTable();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            BAL.Povname = cmbbox1.Text;
            dt = d.vendsearch();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            pnlLocSearch.Visible = false;


            this.Cursor = Cursors.Default;
            //foreach (DataGridViewRow row in dgvVendorSearch.Rows)
            //{

            //    DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
            //    if (clk.Selected == true)
            //    {
            //        cmbbox1.Text = dgvVendorSearch.CurrentRow.Cells[0].Value.ToString();
            //    }
            //}

            //DataTable dt = new DataTable();
            //dt = d.SelectVFdetails();                  //          USED TO FILL THE COMMON DETAILS   &&   Procedure is------"spFillVDetails"      /// 
            //if (e.ColumnIndex < 2)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = e.RowIndex; i < dt.Rows.Count; i++)
            //        {
            //            cmbbox1.Text = dt.Rows[i]["vendorname"].ToString();
            //            cmbbox9.Text = dt.Rows[i]["vendorname"].ToString();
            //            txtbox14.Text = dt.Rows[i]["contactname"].ToString();
            //            txtbox15.Text = dt.Rows[i]["phone"].ToString();
            //            txtbox16.Text = dt.Rows[i]["address"].ToString();
            //            cmbbox2.Text = dt.Rows[i]["paymentterms"].ToString();
            //            cmbbox3.Text = dt.Rows[i]["taxingscheme"].ToString();
            //            cmbbox5.Text = dt.Rows[i]["currency"].ToString();
            //            txtbox2.Text = dt.Rows[i]["remarks"].ToString();
            //            txtshp.Text = dt.Rows[i]["address"].ToString();
            //            break;
            //        }
            //    }
            //}

            BAL.Nam = cmbbox1.Text;
            dt = d.SelectVname(p);              //      VIEW DETAILS IN VENDOR FORM  & Procedure is----- "SelectVname"     //
            if (e.ColumnIndex == 2)
            {
                string text = dgvVendorSearch.CurrentRow.Cells[0].Value.ToString();
                if (e.ColumnIndex == 2)
                {
                    VendorInfo vend = new VendorInfo();
                    BAL.Nam = text;
                    vend.Show();

                }
            }

            dgvVendorSearch.Visible = false;
            pnlVendorSearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            VendorInfo vend = new VendorInfo();
            vend.textBox4.Text = txtAddSearch.Text;
            vend.Show();
        }

        //---------------------------------------INVENTORY SEARCH---------------------------------------------//
        private void cmbbox14_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            txtbox1.Clear();
            cmbbox15.ResetText();
            cmbbox1.ResetText();
            cmbLocation.ResetText();
            cmbRsdate.ResetText();
            cmbScancelled.ResetText();
            //dataGridView1.DataSource = null;
            //dataGridView1.Refresh();

            dataGridView3.Rows.Clear();

            btn2.Visible = true;
            btnFul.Visible = false;
            btnPay.Visible = false;

            pnlISearch.Visible = true;
            pnlISearch.Location = new Point(147, 76);
            pnlISearch.BackColor = Color.White;
            pnl3.Controls.Add(pnlISearch);
            pnlISearch.Size = new Size(128, 130);
            pnlISearch.BringToFront();
            pnlISearch.BorderStyle = BorderStyle.FixedSingle;

            chkISearchA.Location = new Point(10, 10);
            chkISearchA.Text = "All";
            pnlISearch.Controls.Add(chkISearchA);

            chkISearchU.Location = new Point(10, 30);
            chkISearchU.Text = "Unfullfilled";
            pnlISearch.Controls.Add(chkISearchU);

            chkISearchS.Location = new Point(10, 50);
            chkISearchS.Text = "Started";
            pnlISearch.Controls.Add(chkISearchS);

            chkISearchF.Location = new Point(10, 70);
            chkISearchF.Text = "Fullfilled";
            pnlISearch.Controls.Add(chkISearchF);

            chkISearchA.CheckedChanged -= new EventHandler(chkISearchA_CheckedChanged);
            chkISearchU.CheckedChanged -= new EventHandler(chkISearchU_CheckedChanged);
            chkISearchS.CheckedChanged -= new EventHandler(chkISearchS_CheckedChanged);
            chkISearchF.CheckedChanged -= new EventHandler(chkISearchF_CheckedChanged);
            chkISearchA.CheckedChanged += new EventHandler(chkISearchA_CheckedChanged);
            chkISearchU.CheckedChanged += new EventHandler(chkISearchU_CheckedChanged);
            chkISearchS.CheckedChanged += new EventHandler(chkISearchS_CheckedChanged);
            chkISearchF.CheckedChanged += new EventHandler(chkISearchF_CheckedChanged);

            chkISearchA.Click -= new EventHandler(chkISearchA_Click);
            chkISearchA.Click += new EventHandler(chkISearchA_Click);
        }

        private void chkISearchA_Click(object sender, EventArgs e)
        {
            if (chkISearchA.Checked == true)
            {
                //btn11_Click_1(null, null);
                cmbbox14.Text += chkISearchA.Text;
                chkISearchF.Checked = false;
                chkISearchU.Checked = false;
                chkISearchS.Checked = false;
                cmbbox14.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                //dataGridView1.Refresh();
                DataTable dt = new DataTable();
                cmbbox14.Text += chkISearchA.Text;
                BAL.Poistatus = cmbbox14.Text;
                //dt = d.POIStatusAll();
                dt = d.Orderall();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    int i = dataGridView1.Rows.Add();
                //    //int j = dataGridView1.Columns.Add();
                //    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                //}

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            pnlISearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void chkISearchA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkISearchA.Checked == true)
            {
                //btn11_Click_1(null, null);
                cmbbox14.Text += chkISearchA.Text;
                chkISearchF.Checked = false;
                chkISearchU.Checked = false;
                chkISearchS.Checked = false;
                cmbbox14.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                cmbbox14.Text += chkISearchA.Text;
                BAL.Poistatus = cmbbox14.Text;
                //dt = d.POIStatusAll();
                dt = d.Orderall();
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                }
            }
            pnlISearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void chkISearchU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkISearchU.Checked == true)
            {
                //btn11_Click_1(null, null);
                chkISearchA.Checked = false;
                chkISearchF.Checked = false;
                chkISearchS.Checked = false;
                cmbbox14.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                cmbbox14.Text += chkISearchU.Text;
                BAL.Poistatus = cmbbox14.Text;
                dt = d.POIStatus(p);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    int i = dataGridView1.Rows.Add();
                //    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                //}

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            pnlISearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void chkISearchS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkISearchS.Checked == true)
            {
                //btn11_Click_1(null, null);
                cmbbox14.Text += chkISearchS.Text;

                chkISearchA.Checked = false;
                chkISearchU.Checked = false;
                chkISearchF.Checked = false;
                cmbbox14.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                cmbbox14.Text += chkISearchS.Text;
                BAL.Poistatus = cmbbox14.Text;
                dt = d.POIStatus(p);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    int i = dataGridView1.Rows.Add();
                //    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                //}

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }

            }
            pnlISearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void chkISearchF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkISearchF.Checked == true)
            {
                //btn11_Click_1(null, null);
                chkISearchA.Checked = false;
                chkISearchU.Checked = false;
                chkISearchS.Checked = false;
                cmbbox14.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                cmbbox14.Text += chkISearchF.Text;
                BAL.Poistatus = cmbbox14.Text;
                dt = d.POIStatus(p);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    int i = dataGridView1.Rows.Add();
                //    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                //}

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            pnlISearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        //--------------------------------------PAYMENT SEARCH---------------------------------------//
        private void cmbbox15_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            //btn11_Click_1(null, null);

            cmbbox14.ResetText();
            txtbox1.Clear();
            cmbbox1.ResetText();
            cmbLocation.ResetText();
            cmbRsdate.ResetText();
            cmbScancelled.ResetText();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            btn2.Visible = true;
            btnFul.Visible = false;
            btnPay.Visible = false;

            pnlPSearch.Visible = true;
            pnlPSearch.Location = new Point(147, 102);
            pnlPSearch.BackColor = Color.White;
            pnl3.Controls.Add(pnlPSearch);
            pnlPSearch.Size = new Size(130, 130);
            pnlPSearch.BringToFront();
            pnlPSearch.BorderStyle = BorderStyle.FixedSingle;

            chkPSearchA.Location = new Point(10, 10);
            chkPSearchA.Text = "All";
            pnlPSearch.Controls.Add(chkPSearchA);

            chkPSearchU.Location = new Point(10, 30);
            chkPSearchU.Text = "Unpaid";
            pnlPSearch.Controls.Add(chkPSearchU);

            chkPSearchP.Location = new Point(10, 50);
            chkPSearchP.Text = "Partial";
            pnlPSearch.Controls.Add(chkPSearchP);

            chkPSearch.Location = new Point(10, 70);
            chkPSearch.Text = "Paid";
            pnlPSearch.Controls.Add(chkPSearch);

            chkPSearchO.Location = new Point(10, 90);
            chkPSearchO.Text = "Owing";
            pnlPSearch.Controls.Add(chkPSearchO);

            chkPSearchA.CheckedChanged -= new EventHandler(chkPSearchA_CheckedChanged);
            chkPSearchU.CheckedChanged -= new EventHandler(chkPSearchU_CheckedChanged);
            chkPSearchP.CheckedChanged -= new EventHandler(chkPSearchP_CheckedChanged);
            chkPSearch.CheckedChanged -= new EventHandler(chkPSearch_CheckedChanged);
            chkPSearchO.CheckedChanged -= new EventHandler(chkPSearchO_CheckedChanged);

            chkPSearchA.CheckedChanged += new EventHandler(chkPSearchA_CheckedChanged);
            chkPSearchU.CheckedChanged += new EventHandler(chkPSearchU_CheckedChanged);
            chkPSearchP.CheckedChanged += new EventHandler(chkPSearchP_CheckedChanged);
            chkPSearch.CheckedChanged += new EventHandler(chkPSearch_CheckedChanged);
            chkPSearchO.CheckedChanged += new EventHandler(chkPSearchO_CheckedChanged);
        }
        private void chkPSearchA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSearchA.Checked == true)
            {
                //btn11_Click_1(null, null);
                chkPSearchU.Checked = false;
                chkPSearchP.Checked = false;
                chkPSearch.Checked = false;
                chkPSearchO.Checked = false;
                cmbbox15.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                cmbbox15.Text += chkPSearchA.Text;
                BAL.Popstatus = cmbbox14.Text;
                //dt = d.POIStatusAll();
                dt = d.Orderall();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }

            }
            pnlPSearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void chkPSearchU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSearchU.Checked == true)
            {
                //btn11_Click_1(null, null);
                chkPSearchA.Checked = false;
                chkPSearchP.Checked = false;
                chkPSearch.Checked = false;
                chkPSearchO.Checked = false;
                cmbbox15.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                cmbbox15.Text += chkPSearchU.Text;
                DataTable dt = new DataTable();
                BAL.Popstatus = cmbbox15.Text;
                dt = d.POPStatus(p);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }


            }

            pnlPSearch.Visible = false;

            this.Cursor = Cursors.Default;

        }

        private void chkPSearchP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSearchP.Checked == true)
            {
                //btn11_Click_1(null, null);
                chkPSearchU.Checked = false;
                chkPSearchA.Checked = false;
                chkPSearch.Checked = false;
                chkPSearchO.Checked = false;
                cmbbox15.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                cmbbox15.Text += chkPSearchP.Text;
                BAL.Popstatus = cmbbox15.Text;
                dt = d.POPStatus(p);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            pnlPSearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void chkPSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSearch.Checked == true)
            {
                //btn11_Click_1(null, null);
                chkPSearchU.Checked = false;
                chkPSearchP.Checked = false;
                chkPSearchA.Checked = false;
                chkPSearchO.Checked = false;
                cmbbox15.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                cmbbox15.Text += chkPSearch.Text;

                BAL.Popstatus = cmbbox15.Text;
                dt = d.POPStatus(p);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            pnlPSearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void chkPSearchO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSearchO.Checked == true)
            {
                //btn11_Click_1(null, null);
                chkPSearchU.Checked = false;
                chkPSearchP.Checked = false;
                chkPSearch.Checked = false;
                chkPSearchA.Checked = false;
                cmbbox15.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                cmbbox15.Text += chkPSearchO.Text;
                BAL.Popstatus = cmbbox15.Text;
                DataTable dt = new DataTable();
                dt = d.POPStatus(p);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            pnlPSearch.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void txtbox1_TextChanged(object sender, EventArgs e)
        {
            cmbbox14.ResetText();
            cmbbox15.ResetText();
            cmbbox1.ResetText();
            cmbLocation.ResetText();
            cmbRsdate.ResetText();
            cmbScancelled.ResetText();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            dataGridView3.Rows.Clear();

            btn2.Visible = true;
            btnFul.Visible = false;
            btnPay.Visible = false;

            BAL.Poorderno = txtbox1.Text;
            DataTable dt = new DataTable();
            dt = d.SelectOrder1();
            //btn11_Click_1(null, null);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = d.SelectOrder1();
         
        }

        private void lnkRshp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                lblTermsR.Visible = true;
                cmbTermsR.Visible = true;

                lblVOrderR.Visible = true;
                txtVOrderR.Visible = true;

                lblRshp.Visible = true;
                txtRshp.Visible = true;

                lnkRshp.Text = "No Shipping";

                //lblTerms.Location = new Point(213, 11);
                //lblTerms.Size = new Size(48, 26);
                //lblTerms.Text = "Terms";
                //tabPage2.Controls.Add(lblTerms);


                //cmbTerms.Location = new Point(278, 8);
                //cmbTerms.Size = new Size(104, 21);
                //tabPage2.Controls.Add(cmbTerms);
                //cmbTerms.Click -= new EventHandler(cmbTerms_Click);
                //cmbTerms.Click += new EventHandler(cmbTerms_Click);



                //lblVOrder.Location = new Point(214, 44);
                //lblVOrder.Size = new Size(48, 26);
                //lblVOrder.Text = "V.Order";
                //tabPage2.Controls.Add(lblVOrder);

                //txtVOrder.Location = new Point(279, 41);
                //txtVOrder.Size = new Size(104, 20);
                //tabPage2.Controls.Add(txtVOrder);

                lnkRshp.Location = new Point(559, 204);      //---------LINK---------//

                //lbl38.Location = new Point(214, 81);        //---------LOCATION LABEL---------//
                //cmbbox18.Location = new Point(279, 78);
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                lblTermsReturn.Visible = true;
                cmbTermsReturn.Visible = true;

                lblVOrderReturn.Visible = true;
                txtVOrderReturn.Visible = true;

                lblReturnShp.Visible = true;
                txtReturnShp.Visible = true;
                lnkReturnShp.Text = "No Shipping";

                //lblTerms.Location = new Point(213, 11);
                //lblTerms.Size = new Size(48, 26);
                //lblTerms.Text = "Terms";
                //tabPage3.Controls.Add(lblTerms);


                //cmbTerms.Location = new Point(278, 8);
                //cmbTerms.Size = new Size(104, 21);
                //tabPage3.Controls.Add(cmbTerms);
                cmbTerms.Click -= new EventHandler(cmbTerms_Click);
                cmbTerms.Click += new EventHandler(cmbTerms_Click);

                //lblVOrder.Location = new Point(214, 44);
                //lblVOrder.Size = new Size(48, 26);
                //lblVOrder.Text = "V.Order";
                //tabPage3.Controls.Add(lblVOrder);

                //txtVOrder.Location = new Point(279, 41);
                //txtVOrder.Size = new Size(104, 20);
                //tabPage3.Controls.Add(txtVOrder);

                lnkReturnShp.Location = new Point(541, 162);      //---------LINK---------//

                //lbl51.Location = new Point(214, 81);        //---------LOCATION LABEL---------//
                //cmbbox21.Location = new Point(279, 78);
            
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                lblTermsU.Visible = true;
                cmbTermsU.Visible = true;

                lblVOrderU.Visible = true;
                txtVOrderU.Visible = true;

                lblUSAddr.Visible = true;
                txtboxUShp.Visible = true;

                linkLabel4.Text = "No Shipping";

                //lblTerms.Location = new Point(213, 11);
                //lblTerms.Size = new Size(48, 26);
                //lblTerms.Text = "Terms";
                //tabPage4.Controls.Add(lblTerms);


                //cmbTerms.Location = new Point(278, 8);
                //cmbTerms.Size = new Size(104, 21);
                //tabPage4.Controls.Add(cmbTerms);
                cmbTerms.Click -= new EventHandler(cmbTerms_Click);
                cmbTerms.Click += new EventHandler(cmbTerms_Click);

                //lblVOrder.Location = new Point(214, 44);
                //lblVOrder.Size = new Size(48, 26);
                //lblVOrder.Text = "V.Order";
                //tabPage4.Controls.Add(lblVOrder);

                //txtVOrder.Location = new Point(279, 41);
                //txtVOrder.Size = new Size(104, 20);
                //tabPage4.Controls.Add(txtVOrder);

                linkLabel4.Location = new Point(541, 162);      //---------LINK---------//

                lbl63.Location = new Point(214, 81);        //---------LOCATION LABEL---------//
                cmbbox24.Location = new Point(279, 78);
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                string VProductCode;
                int Quantity;
                string RDate;
                int b = 0;
                VProductCode = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                Quantity = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
                b = Quantity + b;
                RDate = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                //lbl18.Text = b.ToString();

            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void lbl18_Click(object sender, EventArgs e)
        {

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {
            pnlVendor.Visible = false;

            pnlLoc.Visible = false;

            pnlPay.Visible = false;

            pnlTax.Visible = false;

            pnlItem.Visible = false;
            dgvItem.Visible = false;

            pnlPSearch.Visible = false;
            pnlISearch.Visible = false;

            dgvVendor.Visible = false;
            pnlVendor.Visible = false;

            dgvVendorSearch.Visible = false;
            pnlVendorSearch.Visible = false;

            pnlLocSearch.Visible = false;
            pnlLoc.Visible = false;

            pnlDate.Visible = false;

            //btnPay.Visible = false;
            //btnFul.Visible = false;
            //btn2.Visible = true;

            //pb.Visible = true;
            //pb1.Visible = true;

            //dataGridView1.Rows.Clear();

            mc.Visible = false;
            mcd.Visible = false;
            mcsd.Visible = false;

            this.Cursor = Cursors.Default;
        }

        //------------------------------------------RETURN---------------------------------------------//
        private void button4_Click(object sender, EventArgs e)
        {
            if (lnklbl2.Text == "No Shipping")
            {
                linkLabel3_LinkClicked(null, null);
            }
            cmbbox22.Text = cmbbox9.Text;
            txtbox27.Text = txtbox14.Text;
            txtbox26.Text = txtbox15.Text;
            txtbox25.Text = txtbox16.Text;
            cmbTerms.Text = cmbTerms.Text;
            cmbbox21.Text = cmbbox12.Text;
            txtbox24.Text = txtbox18.Text;
            cmbbox20.Text = cmbbox13.Text;
            txtbox23.Text = "Started";
            txtReturnPay.Text = "Owing";
            txtbox19.Text = "Started";
            txtboxPay.Text = "Owing";
            txtReturnShp.Text = txtSaddr.Text;
            txtbox22.Text = txtbox2.Text;
            txtbox10.Text = txtbox3.Text;
            txtReturnF.Text = txtFreight.Text;
            txtReturnSTax.Text = txtSTax.Text;
            txtReturnCTax.Text = txtCTax.Text;
            txtbox8.Text = "0";
            txtbox9.Text = txtbox4.Text;
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                txtReturnCTax.Visible = true;
                txtReturnSTax.Visible = true;
                txtReturnF.Visible = true;
                i = dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                dataGridView4.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
                dataGridView4.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                if (dataGridView3.Rows[i].Cells[3].Value == null)
                    dataGridView4.Rows[i].Cells[3].Value = "0";
                else
                    dataGridView4.Rows[i].Cells[3].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
                dataGridView4.Rows[i].Cells[4].Value = dataGridView3.Rows[i].Cells[4].Value.ToString();
                dataGridView4.Rows[i].Cells[6].Value = dataGridView3.Rows[i].Cells[5].Value.ToString();
                dataGridView4.Rows[i].Cells[7].Value = dataGridView3.Rows[i].Cells[6].Value.ToString();
                dataGridView4.Rows[i].Cells[8].Value = dataGridView3.Rows[i].Cells[7].Value.ToString();
                dataGridView4.Rows[i].Cells[5].Value = Convert.ToString(DateTime.Today);
                string MyStringO = dataGridView4.Rows[i].Cells[5].Value.ToString();
                DateTime MyDateTimeO = new DateTime();
                MyDateTimeO = DateTime.Parse(MyStringO);
                string formattedO = MyDateTimeO.ToString("dd/MM/yyyy");
                cmbbox13.Text = formattedO.ToString();
                txtReturnF.Text = txtFreight.Text;
                txtReturnSTax.Text = txtSTax.Text;
                txtReturnCTax.Text = txtCTax.Text;
                txtbox10.Text = txtbox3.Text;
                txtbox9.Text = txtbox4.Text;
                
            }

            //for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            //{
            //    txtReturnCTax.Visible = true;
            //    txtReturnSTax.Visible = true;
            //    txtReturnF.Visible = true;
            //    i = dataGridView4.Rows.Add();
            //    dataGridView4.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
            //    dataGridView4.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
            //    dataGridView4.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
            //    dataGridView4.Rows[i].Cells[3].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
            //    dataGridView4.Rows[i].Cells[5].Value = dataGridView3.Rows[i].Cells[4].Value.ToString();
            //    dataGridView4.Rows[i].Cells[6].Value = dataGridView3.Rows[i].Cells[5].Value.ToString();
            //    dataGridView4.Rows[i].Cells[7].Value = dataGridView3.Rows[i].Cells[6].Value.ToString();
            //    txtReturnF.Text = txtFreight.Text;
            //    txtReturnSTax.Text = txtSTax.Text;
            //    txtReturnCTax.Text = txtCTax.Text;
            //    txtbox10.Text = txtbox3.Text;
            //    txtbox9.Text = txtbox4.Text;
            //}
            BAL.Poorderno = txtbox24.Text;
            BAL.Popstatus = txtReturnPay.Text;
            BAL.Poistatus = txtbox23.Text;
            d.Updatestatus(p);
            linkLabel2_LinkClicked(null, null);
        }

        //--------------------------------------UNSTOCK---------------------------------//
        private void btn5_Click(object sender, EventArgs e)
        {
            if (lnklbl2.Text == "No Shipping")
            {
                linkLabel4_LinkClicked(null, null);

            }
            cmbTerms.Visible = true;
            lblTerms.Visible = true;
            lblCarrier.Visible = true;
            cmbCarrier.Visible = true;
            lblShp.Visible = true;
            txtSaddr.Visible = true;

            cmbbox22.Text = cmbbox9.Text;
            txtbox36.Text = txtbox14.Text;
            txtbox35.Text = txtbox15.Text;
            txtbox34.Text = txtbox16.Text;
            cmbTerms.Text = cmbTerms.Text;
            cmbbox24.Text = cmbbox12.Text;
            txtbox33.Text = txtbox18.Text;
            cmbbox23.Text = cmbbox13.Text;
            txtbox32.Text = "Fullfilled";
            txtboxUPay.Text = "Owing";
            txtbox19.Text = "Fullfilled";
            txtboxPay.Text = "Owing";
            txtboxUShp.Text = txtSaddr.Text;
            txtbox31.Text = txtbox2.Text;

            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                i = dataGridView5.Rows.Add();
                dataGridView5.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
                dataGridView5.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
                dataGridView5.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
                if (dataGridView3.Rows[i].Cells[4].Value == null)
                    dataGridView5.Rows[i].Cells[3].Value = "0";
                else
                    dataGridView5.Rows[i].Cells[3].Value = dataGridView3.Rows[i].Cells[4].Value.ToString();
                dataGridView5.Rows[i].Cells[5].Value = cmbbox12.Text;
                dataGridView5.Rows[i].Cells[4].Value = Convert.ToString(DateTime.Today);
                string MyStringO = dataGridView5.Rows[i].Cells[4].Value.ToString();
                DateTime MyDateTimeO = new DateTime();
                MyDateTimeO = DateTime.Parse(MyStringO);
                string formattedO = MyDateTimeO.ToString("dd/MM/yyyy");
                cmbbox13.Text = formattedO.ToString();

            }

            //for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            //{
            //    i = dataGridView5.Rows.Add();
            //    dataGridView5.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
            //    dataGridView5.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
            //    dataGridView5.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
            //    dataGridView5.Rows[i].Cells[4].Value = cmbbox12.Text;
            //}
            BAL.Poorderno = txtbox33.Text;
            BAL.Popstatus = txtboxUPay.Text;
            BAL.Poistatus = txtbox32.Text;
            d.Updatestatus(p);

            linkLabel2_LinkClicked(null, null);
        }



        //private void button3_Click(object sender, EventArgs e)
        //{

        //    cmbTerms.Visible = true;
        //    lblTerms.Visible = true;
        //    lblCarrier.Visible = true;
        //    cmbCarrier.Visible = true;
        //    lblShp.Visible = true;
        //    txtSaddr.Visible = true; 
        //    cmbbox19.Text = cmbbox9.Text;
        //                txtbox21.Text = txtbox14.Text;
        //                txtbox20.Text = txtbox15.Text;
        //                txtbox17.Text = txtbox16.Text;
        //                cmbTerms.Text = cmbTerms.Text;
        //                cmbbox18.Text = cmbbox12.Text;
        //                txtbox13.Text = txtbox18.Text;
        //                cmbbox17.Text = cmbbox13.Text;
        //                txtbox12.Text = txtbox19.Text;
        //                txtboxps.Text = txtboxPay.Text;
        //                txtRshp.Text = txtSaddr.Text;
        //                txtbox11.Text=txtbox2.Text;

        //                for (int i = 0; i < dataGridView3.RowCount - 1; i++)
        //                {
        //                    i = dataGridView2.Rows.Add();
        //                    dataGridView2.Rows[i].Cells[0].Value = dataGridView3.Rows[i].Cells[0].Value.ToString();
        //                    dataGridView2.Rows[i].Cells[1].Value = dataGridView3.Rows[i].Cells[1].Value.ToString();
        //                    dataGridView2.Rows[i].Cells[2].Value = dataGridView3.Rows[i].Cells[2].Value.ToString();
        //                    dataGridView2.Rows[i].Cells[3].Value = dataGridView3.Rows[i].Cells[3].Value.ToString();
        //                    dataGridView2.Rows[i].Cells[4].Value = cmbbox12.Text;
        //                    dataGridView2.Rows[i].Cells[5].Value = cmbbox13.Text;
        //                }
        //}



        private void cmbLocation_Click(object sender, EventArgs e)
        {
            cmbbox14.ResetText();
            cmbbox15.ResetText();
            cmbbox1.ResetText();
            txtbox1.Clear();
            cmbRsdate.ResetText();
            cmbScancelled.ResetText();
           // dataGridView1.DataSource = null;
           // dataGridView1.Rows.Clear();

            btn2.Visible = true;
            btnFul.Visible = false;
            btnPay.Visible = false;

            pnlLocSearch.Visible = true;
            dgvLocSearch.Visible = true;
            pnlLocSearch.Location = new Point(154, 182);
            pnlLocSearch.BackColor = Color.White;
            this.Controls.Add(pnlLocSearch);
            pnlLocSearch.Size = new Size(150, 150);
            pnlLocSearch.BringToFront();
            pnlLocSearch.BorderStyle = BorderStyle.FixedSingle;

            pnlLocSearch.Controls.Add(dgvLocSearch);
            dgvLocSearch.Size = new Size(150, 100);
            dgvLocSearch.DataSource = d.Selectloc();
            dgvLocSearch.ReadOnly = true;

            this.Cursor = Cursors.Hand;

            dgvLocSearch.CellClick -= new DataGridViewCellEventHandler(dgvLocSearch_CellClick);
            lblLocSearch.Click -= new EventHandler(lblLocSearch_Click);
            dgvLocSearch.CellClick += new DataGridViewCellEventHandler(dgvLocSearch_CellClick);
            lblLocSearch.Click += new EventHandler(lblLocSearch_Click);

            lblLocSearch.Location = new Point(8, 110);
            lblLocSearch.Size = new Size(150, 13);
            lblLocSearch.Text = "ADD NEW LOCATION...";
            pnlLocSearch.Controls.Add(lblLocSearch);
        }

        private void dgvLocSearch_CellClick(object sender, DataGridViewCellEventArgs e) // Binding Location table to the grid 
        {

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dgvLocSearch.Rows)
            {

                DataGridViewTextBoxCell clk = (DataGridViewTextBoxCell)row.Cells[0];
                if (clk.Selected == true)
                {
                    cmbLocation.Text = dgvLocSearch.CurrentRow.Cells[0].Value.ToString();
                }
            }
            DataTable dt = new DataTable();
            BAL.Poloc = cmbLocation.Text;
            dt = d.locsearch();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            pnlLocSearch.Visible = false;


            this.Cursor = Cursors.Default;
        }

        private void lblLocSearch_Click(object sender, EventArgs e)  // Directing to location table
        {
            this.Cursor = Cursors.Default;
            //PurhcaseOrder po = new PurhcaseOrder();
            //BAL.Povname = cmbbox9.Text;
            //BAL.Pocname = txtbox14.Text;
            //BAL.Poph = txtbox15.Text;
            //BAL.Poaddr = txtbox16.Text;
            Location loc = new Location();
            loc.Show();
            pnlLocSearch.Visible = false;
        }

        private void cmbRsdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            cmbbox14.ResetText();
            cmbbox15.ResetText();
            cmbbox1.ResetText();
            cmbLocation.ResetText();
            txtbox1.Clear();
            cmbScancelled.ResetText();
           // dataGridView1.DataSource = null;
          //  dataGridView1.Rows.Clear();

            txtfrom.ResetText();
            txtto.ResetText();

            btn2.Visible = true;
            btnFul.Visible = false;
            btnPay.Visible = false;

            pnlDate.Visible = true;
          //  dataGridView1.DataSource = null;
           // dataGridView1.Rows.Clear();
            pnlDate.Location = new Point(154, 207);
            pnlDate.BackColor = Color.White;
            this.Controls.Add(pnlDate);
            //PurhcaseOrder.Controls.Add(pnlDate);
            pnlDate.Size = new Size(175, 525);
            pnlDate.BringToFront();
            pnlDate.BorderStyle = BorderStyle.FixedSingle;

            all.Location = new Point(10, 10);
            all.Text = "All";
            pnlDate.Controls.Add(all);
            all.Click -= new EventHandler(all_Click);
            all.Click += new EventHandler(all_Click);

            today.Location = new Point(10, 35);
            today.Text = "Today";
            pnlDate.Controls.Add(today);
            today.Click -= new EventHandler(today_Click);
            today.Click += new EventHandler(today_Click);

            thisweek.Location = new Point(10, 56);
            thisweek.Text = "This Week";
            pnlDate.Controls.Add(thisweek);
            thisweek.Click -= new EventHandler(thisweek_Click);
            thisweek.Click += new EventHandler(thisweek_Click);

            thismonth.Location = new Point(10, 77);
            thismonth.Text = "This Month";
            pnlDate.Controls.Add(thismonth);
            thismonth.Click -= new EventHandler(thismonth_Click);
            thismonth.Click += new EventHandler(thismonth_Click);

            thisquarter.Location = new Point(10, 99);
            thisquarter.Text = "This Quarter";
            pnlDate.Controls.Add(thisquarter);
            thisquarter.Click -= new EventHandler(thisquarter_Click);
            thisquarter.Click += new EventHandler(thisquarter_Click);

            thisyear.Location = new Point(10, 120);
            thisyear.Text = "This Year";
            pnlDate.Controls.Add(thisyear);
            thisyear.Click -= new EventHandler(thisyear_Click);
            thisyear.Click += new EventHandler(thisyear_Click);

            yesterday.Location = new Point(10, 141);
            yesterday.Text = "Yesterday";
            pnlDate.Controls.Add(yesterday);
            yesterday.Click -= new EventHandler(yesterday_Click);
            yesterday.Click += new EventHandler(yesterday_Click);

            lastweek.Location = new Point(10, 160);
            lastweek.Text = "Last Week";
            pnlDate.Controls.Add(lastweek);
            lastweek.Click -= new EventHandler(lastweek_Click);
            lastweek.Click += new EventHandler(lastweek_Click);

            lastmonth.Location = new Point(10, 180);
            lastmonth.Text = "Last Month";
            pnlDate.Controls.Add(lastmonth);
            lastmonth.Click -= new EventHandler(lastmonth_Click);
            lastmonth.Click += new EventHandler(lastmonth_Click);

            lastquarter.Location = new Point(10, 200);
            lastquarter.Text = "Last Quarter";
            pnlDate.Controls.Add(lastquarter);
            lastquarter.Click -= new EventHandler(lastquarter_Click);
            lastquarter.Click += new EventHandler(lastquarter_Click);

            lastyear.Location = new Point(10, 222);
            lastyear.Text = "Last Year";
            pnlDate.Controls.Add(lastyear);
            lastyear.Click -= new EventHandler(lastyear_Click);
            lastyear.Click += new EventHandler(lastyear_Click);

            last7days.Location = new Point(10, 243);
            last7days.Text = "Last 7 Days";
            pnlDate.Controls.Add(last7days);
            last7days.Click -= new EventHandler(last7days_Click);
            last7days.Click += new EventHandler(last7days_Click);

            last30days.Location = new Point(10, 264);
            last30days.Text = "Last 30 Days";
            pnlDate.Controls.Add(last30days);
            last30days.Click -= new EventHandler(last30days_Click);
            last30days.Click += new EventHandler(last30days_Click);

            last90days.Location = new Point(10, 285);
            last90days.Text = "Last 90 Days";
            pnlDate.Controls.Add(last90days);
            last90days.Click -= new EventHandler(last90days_Click);
            last90days.Click += new EventHandler(last90days_Click);

            last365days.Location = new Point(10, 306);
            last365days.Text = "Last 365 Days";
            pnlDate.Controls.Add(last365days);
            last365days.Click -= new EventHandler(last365days_Click);
            last365days.Click += new EventHandler(last365days_Click);

            tomorrow.Location = new Point(10, 328);
            tomorrow.Text = "Tomorrow";
            pnlDate.Controls.Add(tomorrow);
            tomorrow.Click -= new EventHandler(tomorrow_Click);
            tomorrow.Click += new EventHandler(tomorrow_Click);

            nextweek.Location = new Point(10, 348);
            nextweek.Text = "Next Week";
            pnlDate.Controls.Add(nextweek);
            nextweek.Click -= new EventHandler(nextweek_Click);
            nextweek.Click += new EventHandler(nextweek_Click);

            nextmonth.Location = new Point(10, 369);
            nextmonth.Text = "Next Month";
            pnlDate.Controls.Add(nextmonth);
            nextmonth.Click -= new EventHandler(nextmonth_Click);
            nextmonth.Click += new EventHandler(nextmonth_Click);

            nextquarter.Location = new Point(10, 390);
            nextquarter.Text = "Next Quarter";
            pnlDate.Controls.Add(nextquarter);
            nextquarter.Click -= new EventHandler(nextquarter_Click);
            nextquarter.Click += new EventHandler(nextquarter_Click);

            nextyear.Location = new Point(10, 415);
            nextyear.Text = "Next Year";
            pnlDate.Controls.Add(nextyear);
            nextyear.Click -= new EventHandler(nextyear_Click);
            nextyear.Click += new EventHandler(nextyear_Click);

            Cdrange.Location = new Point(10, 440);
            Cdrange.Size = new Size(103, 13);
            Cdrange.Text = "Custom Date Range";
            pnlDate.Controls.Add(Cdrange);
            //Cdrange.Click += new EventHandler(Cdrange_Click);

            from.Location = new Point(10, 465);
            from.Text = "From";
            from.Size = new Size(31, 13);
            pnlDate.Controls.Add(from);
            //from.Click += new EventHandler(from_Click);

            txtfrom.Location = new Point(45, 465);
            //txtfrom.BackColor= Color.Black;
            txtfrom.Size = new Size(84, 20);
            pnlDate.Controls.Add(txtfrom);
            txtfrom.DropDownHeight = 1;
            txtfrom.DropDownWidth = 1;
            txtfrom.Click -= new EventHandler(txtfrom_Click);
            txtfrom.Click += new EventHandler(txtfrom_Click);
            //txtfrom.SelectedIndexChanged += new EventHandler(txtfrom_SelectedIndexChanged);

            to.Location = new Point(10, 488);
            to.Text = "To";
            to.Size = new Size(31, 13);
            pnlDate.Controls.Add(to);
            //to.Click += new EventHandler(to_Click);

            txtto.Location = new Point(45, 488);
            txtto.Size = new Size(84, 20);
            txtto.DropDownHeight = 1;
            txtto.DropDownWidth = 1;
            pnlDate.Controls.Add(txtto);
            txtto.Click -= new EventHandler(txtto_Click);
            txtto.Click += new EventHandler(txtto_Click);
            //txtto.TextChanged += new EventHandler(txtto_TextChanged);

        }

        private void all_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderall();
            cmbRsdate.Text = all.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void today_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Ordertoday();
            cmbRsdate.Text = today.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void thisweek_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderthisweek();
            cmbRsdate.Text = thisweek.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void thismonth_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderthismonth();
            cmbRsdate.Text = thismonth.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void thisquarter_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderthisquarter();
            cmbRsdate.Text = thisquarter.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void thisyear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderthisyear();
            cmbRsdate.Text = thisyear.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void yesterday_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderyesterday();
            cmbRsdate.Text = yesterday.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
        }
        private void lastweek_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlastweek();
            cmbRsdate.Text = lastweek.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void lastmonth_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlastmonth();
            cmbRsdate.Text = lastmonth.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void lastquarter_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlastquarter();
            cmbRsdate.Text = lastquarter.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void lastyear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlastyear();
            cmbRsdate.Text = lastyear.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void last7days_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlast7days();
            cmbRsdate.Text = last7days.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void last30days_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlast30days();
            cmbRsdate.Text = last30days.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void last90days_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlast90days();
            cmbRsdate.Text = last90days.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void last365days_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Orderlast365days();
            cmbRsdate.Text = last365days.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void tomorrow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Ordertmrw();
            cmbRsdate.Text = tomorrow.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
        }
        private void nextweek_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Ordernextweek();
            cmbRsdate.Text = nextweek.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void nextmonth_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Ordernextmonth();
            cmbRsdate.Text = nextmonth.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void nextquarter_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Ordernextquarter();
            cmbRsdate.Text = nextquarter.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void nextyear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = d.Ordernextyear();
            cmbRsdate.Text = nextyear.Text;
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
            }
            //btn11_Click_1(null, null);
            pnlDate.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void txtfrom_Click(object sender, EventArgs e)
        {
            cmbRsdate.ResetText();
            mcfrom.Location = new Point(5, 465);
            tabPage1.Controls.Add(mcfrom);
            mcfrom.Size = new Size(150, 50);
            mcfrom.BringToFront();
            mcfrom.Visible = true;
            mcfrom.DateSelected -= new DateRangeEventHandler(mcfrom_DateSelected);
            mcfrom.DateSelected += new DateRangeEventHandler(mcfrom_DateSelected);

            mcfrom.Visible = true;

            //txtfrom_TextChanged(null, null);
        }


        private void mcfrom_DateSelected(object sender, DateRangeEventArgs e)
        {

            txtfrom.Text = e.Start.ToShortDateString();
            //BAL.Dateporeqdate = Convert.ToDateTime(txtfrom.Text);

            if (txtfrom.Text != "" && txtto.Text != "")
            {
                p.Fdate = Convert.ToDateTime(txtfrom.Text);
                p.Tdate = Convert.ToDateTime(txtto.Text);
                DataTable dt = new DataTable();
                dt = d.Orderfromto(p);
                //cmbRsdate.Text = nextyear.Text;
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                }
                //btn11_Click_1(null, null);
                pnlDate.Visible = false;

            }

            mcfrom.Visible = false;
            this.Cursor = Cursors.Default;
        }


        private void txtto_Click(object sender, EventArgs e)
        {
            cmbRsdate.ResetText();
            mcto.Location = new Point(5, 465);
            tabPage1.Controls.Add(mcto);
            mcto.Size = new Size(150, 50);
            mcto.BringToFront();
            mcto.Visible = true;
            mcto.DateSelected -= new DateRangeEventHandler(mcto_DateSelected);
            mcto.DateSelected += new DateRangeEventHandler(mcto_DateSelected);
            mcto.Visible = true;

        }

        private void mcto_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtto.Text = e.Start.ToShortDateString();
            dataGridView1.Rows.Clear();


            if (txtfrom.Text != "" && txtto.Text != "")
            {
                p.Fdate = Convert.ToDateTime(txtfrom.Text);
                p.Tdate = Convert.ToDateTime(txtto.Text);
                DataTable dt = new DataTable();
                dt = d.Orderfromto(p);
                //cmbRsdate.Text = nextyear.Text;
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                }
                //btn11_Click_1(null, null);
                pnlDate.Visible = false;

            }
            mcto.Visible = false;
            this.Cursor = Cursors.Default;

        }

        private void cmbScancelled_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbox14.ResetText();
            cmbbox15.ResetText();
            cmbbox1.ResetText();
            cmbLocation.ResetText();
            cmbRsdate.ResetText();
            txtbox1.Clear();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            btn2.Visible = true;
            btnFul.Visible = false;
            btnPay.Visible = false;

            if (cmbScancelled.Text == "Active Only")
            {
                DataTable dt = new DataTable();
                dataGridView1.Rows.Clear();
                p.Status1 = cmbScancelled.Text;
                dt = d.SsearchA();
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                }
                pnlLocSearch.Visible = false;
            }
            else if (cmbScancelled.Text == "Active and Cancelled")
            {
                DataTable dt = new DataTable();
                dataGridView1.Rows.Clear();
                p.Status1 = cmbScancelled.Text;
                dt = d.Ssearch();
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                }
                pnlLocSearch.Visible = false;
            }
            else if (cmbScancelled.Text == "Cancelled Only")
            {
                DataTable dt = new DataTable();
                dataGridView1.Rows.Clear();
                p.Status1 = cmbScancelled.Text;
                dt = d.SsearchC(p);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["poorderno"].ToString();
                }
                pnlLocSearch.Visible = false;
            }
        }

        private void btn11_Click_1(object sender, EventArgs e)
        {
            PurhcaseOrder p = new PurhcaseOrder();
            this.Hide();
            p.Show();
        //    DataTable dt = new DataTable();
        //    dt = d.UpdateOrder();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        txtbox18.Text = dr["poorderno"].ToString();
        //    }

        //    cmbbox13.Text = Convert.ToString(DateTime.Today);
        //    string MyStringO = cmbbox13.Text;
        //    DateTime MyDateTimeO = new DateTime();
        //    MyDateTimeO = DateTime.Parse(MyStringO);
        //    string formattedO = MyDateTimeO.ToString("dd/MM/yyyy");
        //    cmbbox13.Text = formattedO.ToString();

        //    cmbbox19.ResetText();
        //    cmbbox22.ResetText();
        //    cmbbox25.ResetText();
        //    cmbbox9.ResetText();
        //    txtbox21.Clear();
        //    txtbox27.Clear();
        //    txtbox36.Clear();
        //    txtbox14.Clear();
        //    txtbox20.Clear();
        //    txtbox26.Clear();
        //    txtbox35.Clear();
        //    txtbox15.Clear();
        //    txtbox17.Clear();
        //    txtbox25.Clear();
        //    txtbox34.Clear();
        //    txtbox16.Clear();
        //    cmbTerms.ResetText();
        //    cmbbox18.ResetText();
        //    cmbbox21.ResetText();
        //    cmbbox24.ResetText();
        //    cmbbox12.ResetText();
        //    txtbox13.Clear();
        //    txtbox24.Clear();
        //    txtbox33.Clear();
        //    //txtbox18.Clear();
        //    cmbbox17.ResetText();
        //    cmbbox20.ResetText();
        //    cmbbox23.ResetText();
        //    //cmbbox13.ResetText();
        //    txtbox12.Clear();
        //    txtbox23.Clear();
        //    txtbox32.Clear();
        //    //txtbox19.Clear();
        //    txtboxps.Clear();
        //    txtReturnPay.Clear();
        //    txtboxUPay.Clear();
        //    //txtboxPay.Clear();
        //    txtRshp.Clear();
        //    txtReturnShp.Clear();
        //    txtboxUShp.Clear();
        //    txtSaddr.Clear();
        //    cmbCarrier.ResetText();
        //    cmbbox2.ResetText();
        //    cmbbox3.ResetText();
        //    cmbbox4.ResetText();
        //    cmbbox5.ResetText();
        //    cmbbox6.ResetText();
        //    txtbox2.Clear();
        //    txtbox10.Clear();
        //    txtbox3.Clear();
        //    txtReturnF.Clear();
        //    txtFreight.Clear();
        //    txtReturnSTax.Clear();
        //    txtSTax.Clear();
        //    txtReturnCTax.Clear();
        //    txtCTax.Clear();
        //    txtbox9.Clear();
        //    txtbox4.Clear();
        //    txtbox5.Clear();
        //    txtbox6.Clear();

        //    dataGridView3.Rows.Clear();
        //    //dataGridView1.Rows.Clear();
        //    pb.Hide();
        //    pb1.Hide();
        //    btn2.Visible = true;
        //    btnFul.Visible = false;
        //    btnPay.Visible = false;

        }



        private void button10_Click(object sender, EventArgs e)
        {
            p.Povid = "";
            BAL.Povname = cmbbox9.Text;
            BAL.Pocname = txtbox14.Text;
            BAL.Poph = txtbox15.Text;
            BAL.Poaddr = txtbox16.Text;
            BAL.Poterms = cmbTerms.Text;
            BAL.Poloc = cmbbox12.Text;

            BAL.Poorderno = txtbox18.Text;

            string MyStringO = cmbbox13.Text;
            DateTime MyDateTimeO = new DateTime();
            MyDateTimeO = DateTime.Parse(MyStringO);
            string formattedO = MyDateTimeO.ToString("dd-MM-yyyy");
            BAL.Datepoorderdate = Convert.ToDateTime(formattedO);

            BAL.Poistatus = txtbox19.Text;
            BAL.Popstatus = txtboxPay.Text;

            p.Poshpaddr = txtshp.Text;
            p.Pocarrier = cmbCarrier.Text;

            string MyStringd = cmbbox2.Text;
            DateTime MyDateTimed = new DateTime();
            MyDateTimed = DateTime.Parse(MyStringd);
            string formattedd = MyDateTimed.ToString("dd-MM-yyyy");
            BAL.Datepoduedate = Convert.ToDateTime(formattedd);

            p.Potaxscheme = cmbbox3.Text;
            p.Pononvendor = cmbbox4.Text;
            p.Pocurrency = cmbbox5.Text;

            string MyStringr = cmbbox6.Text;
            DateTime MyDateTimer = new DateTime();
            MyDateTimer = DateTime.Parse(MyStringO);
            string formattedr = MyDateTimer.ToString("dd-MM-yyyy");

            BAL.Dateporeqdate = Convert.ToDateTime(formattedr);

            p.Poremarks = txtbox2.Text;

            //BAL.Poorderdate = cmbbox13.Text;
            //p.Poddate = cmbbox2.Text;
            //p.Porshpdate = cmbbox6.Text;
            p.Postotal = txtbox3.Text;
            p.Pofreight = txtFreight.Text;
            p.Postax = txtSTax.Text;
            p.Poctax = txtCTax.Text;
            p.Pototal = txtbox4.Text;
            p.Popaid = txtbox5.Text;
            p.Pobalance = txtbox6.Text;
            p.Paging = Paying.Text;
            p.Paging = "0";
            d.UpdatePO(p);

            int count = 0;
            int count1 = 0;

            if (dataGridView2.Rows.Count != 0)
            {
                DataTable dt1 = d.SelectReceive();
                foreach (DataRow dt in dt1.Rows)
                {
                    if (txtbox13.Text == dt["poorderno"].ToString())
                    {
                        for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                        {

                            p.Povid = "";
                            BAL.Povname = cmbbox9.Text;
                            BAL.Poorderno = txtbox18.Text;
                            p.Iiname = dataGridView2.Rows[i].Cells[0].Value.ToString();
                            p.Ides = dataGridView2.Rows[i].Cells[1].Value.ToString();
                            p.Icode = dataGridView2.Rows[i].Cells[2].Value.ToString();
                            p.Iquantity = dataGridView2.Rows[i].Cells[3].Value.ToString();
                            BAL.Poloc = dataGridView2.Rows[i].Cells[4].Value.ToString();
                            if (dataGridView2.Rows[i].Cells[5].Value == null)
                                MessageBox.Show("Enter Received Date", "", MessageBoxButtons.YesNo);
                            else
                            {
                                p.Receiveddate1 = dataGridView2.Rows[i].Cells[5].Value.ToString();
                                p.Poremarks = txtbox11.Text;
                                p.Tordered1 = lbl18.Text;
                                p.Treceived1 = lbl20.Text;
                                d.UpdateReceive(p);
                            }
                        }

                        count1++;
                        break;
                    }
                }
                if (count1 == 0)
                {
                    for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                    {

                        p.Povid = "";
                        BAL.Povname = cmbbox9.Text;
                        BAL.Poorderno = txtbox18.Text;
                        p.Iiname = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        p.Ides = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        p.Icode = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        p.Iquantity = dataGridView2.Rows[i].Cells[3].Value.ToString();
                        BAL.Poloc = dataGridView2.Rows[i].Cells[4].Value.ToString();
                        if (dataGridView2.Rows[i].Cells[5].Value == null)
                            MessageBox.Show("Enter Received Date", "", MessageBoxButtons.YesNo);
                        else
                        {
                            p.Receiveddate1 = dataGridView2.Rows[i].Cells[5].Value.ToString();
                            p.Poremarks = txtbox11.Text;
                            p.Tordered1 = lbl18.Text;
                            p.Treceived1 = lbl20.Text;
                            d.InsertRVOItems(p);
                        }
                    }
                }
                count1 = 0;
            }

            if (dataGridView4.Rows.Count != 0)
            {
                DataTable dt1 = d.SelectReturn();
                foreach (DataRow dt in dt1.Rows)
                {
                    if (txtbox24.Text == dt["rtpoorderno"].ToString())
                    {
                        for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                        {

                            p.Povid = "";
                            BAL.Povname = cmbbox9.Text;
                            BAL.Poorderno = txtbox18.Text;
                            p.Iiname = dataGridView4.Rows[i].Cells[1].Value.ToString();
                            p.Ides = dataGridView4.Rows[i].Cells[2].Value.ToString();
                            p.Icode = dataGridView4.Rows[i].Cells[3].Value.ToString();
                            p.Iquantity = dataGridView4.Rows[i].Cells[4].Value.ToString();
                            //if (dataGridView4.Rows[i].Cells[5].Value == null)
                            //    MessageBox.Show("Enter Returned Date", "", MessageBoxButtons.YesNo);
                            //else
                            //{
                            p.Returndate1 = dataGridView4.Rows[i].Cells[5].Value.ToString();
                            p.Iuprice = dataGridView4.Rows[i].Cells[6].Value.ToString();
                            p.Idiscount = dataGridView4.Rows[i].Cells[7].Value.ToString();
                            p.Isubtotal = txtbox10.Text;
                            p.Poremarks = txtbox22.Text;
                            p.Itotal = dataGridView4.Rows[i].Cells[8].Value.ToString();
                            p.Fee = txtbox8.Text;
                            p.Returntotal1 = txtbox9.Text;
                            p.Iid = dataGridView4.Rows[i].Cells[0].Value.ToString();
                            d.UpdateReturn(p);
                        }

                        count1++;
                        break;
                    }
                }
                if (count1 == 0)
                {
                    for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                    {
                        p.Povid = "";
                        BAL.Povname = cmbbox9.Text;
                        BAL.Poorderno = txtbox18.Text;
                        p.Iiname = dataGridView4.Rows[i].Cells[1].Value.ToString();
                        p.Ides = dataGridView4.Rows[i].Cells[2].Value.ToString();
                        p.Icode = dataGridView4.Rows[i].Cells[3].Value.ToString();
                        p.Iquantity = dataGridView4.Rows[i].Cells[4].Value.ToString();
                        //if (dataGridView4.Rows[i].Cells[5].Value == null)
                        //    MessageBox.Show("Enter Returned Date", "", MessageBoxButtons.YesNo);
                        //else
                        //{
                        p.Returndate1 = dataGridView4.Rows[i].Cells[5].Value.ToString();
                        p.Iuprice = dataGridView4.Rows[i].Cells[6].Value.ToString();
                        p.Idiscount = dataGridView4.Rows[i].Cells[7].Value.ToString();
                        p.Isubtotal = txtbox10.Text;
                        p.Poremarks = txtbox22.Text;
                        p.Itotal = dataGridView4.Rows[i].Cells[8].Value.ToString();
                        p.Fee = txtbox8.Text;
                        p.Returntotal1 = txtbox9.Text;
                        p.Iid = dataGridView4.Rows[i].Cells[0].Value.ToString();
                        d.InsertReturnVOItems(p);
                        //}

                        BAL.Poorderno = txtbox18.Text;
                        BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                        d.OrderHistoryUpdate(p);

                        p.Iid = dataGridView4.Rows[i].Cells[0].Value.ToString();
                        BAL.Poloc = cmbbox12.Text;
                        BAL.Poorderno = txtbox18.Text;
                        DataTable dt = new DataTable();
                        d.selectQOH(p);
                        //int qoh = int.Parse(dt.Rows[i]["quantityonhand"].ToString());
                        p.QuanOnHand1 = (Convert.ToInt32(p.QuanOnHand1) + Convert.ToInt32(dataGridView4.Rows[i].Cells[4].Value.ToString())).ToString();
                        d.updateQOH(p);

                        p.Type = "Purchase Return";

                        string MyStringOh = cmbbox13.Text;
                        DateTime MyDateTimeOh = DateTime.ParseExact(MyStringOh, "dd-MM-yyyy", null);
                        BAL.Datepoorderdate = Convert.ToDateTime(MyDateTimeOh);
                        BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                        p.Iid = dataGridView4.Rows[i].Cells[0].Value.ToString();
                        p.Iiname = dataGridView4.Rows[i].Cells[1].Value.ToString();
                        p.Iquantity = dataGridView4.Rows[i].Cells[4].Value.ToString();
                        p.Isubtotal = dataGridView4.Rows[i].Cells[8].Value.ToString();
                        d.OrderHistoryInsert(p);
                    }
                }
                count1 = 0;
            }

            if (dataGridView5.Rows.Count != 0)
            {
                DataTable dt1 = d.SelectUnstock();
                foreach (DataRow dt in dt1.Rows)
                {
                    if (txtbox33.Text == dt["poorderno"].ToString())
                    {
                        for (int i = 0; i < dataGridView5.RowCount - 1; i++)
                        {

                            p.Povid = "";
                            BAL.Povname = cmbbox9.Text;
                            BAL.Poorderno = txtbox18.Text;
                            p.Iiname = dataGridView5.Rows[i].Cells[1].Value.ToString();
                            p.Ides = dataGridView5.Rows[i].Cells[2].Value.ToString();
                            p.Iquantity = dataGridView5.Rows[i].Cells[3].Value.ToString();
                            //if (dataGridView5.Rows[i].Cells[3].Value == null)
                            //    MessageBox.Show("Enter Unstock Date", "", MessageBoxButtons.YesNo);
                            //else
                            //{
                            p.Unstock = dataGridView5.Rows[i].Cells[4].Value.ToString();
                            BAL.Poloc = dataGridView5.Rows[i].Cells[5].Value.ToString();
                            p.Poremarks = txtbox11.Text;
                            p.Iid = dataGridView5.Rows[i].Cells[0].Value.ToString();
                            d.UpdateUnstock(p);
                        }

                        count1++;
                        break;
                    }
                }
                if (count1 == 0)
                {
                    for (int i = 0; i < dataGridView5.RowCount - 1; i++)
                    {

                        p.Povid = "";
                        BAL.Povname = cmbbox9.Text;
                        BAL.Poorderno = txtbox18.Text;
                        p.Iiname = dataGridView5.Rows[i].Cells[1].Value.ToString();
                        p.Ides = dataGridView5.Rows[i].Cells[2].Value.ToString();
                        p.Iquantity = dataGridView5.Rows[i].Cells[3].Value.ToString();
                        //if (dataGridView5.Rows[i].Cells[3].Value == null)
                        //    MessageBox.Show("Enter Unstock Date", "", MessageBoxButtons.YesNo);
                        //else
                        //{
                        p.Unstock = dataGridView5.Rows[i].Cells[4].Value.ToString();
                        BAL.Poloc = dataGridView5.Rows[i].Cells[5].Value.ToString();
                        p.Poremarks = txtbox11.Text;
                        p.Iid = dataGridView5.Rows[i].Cells[0].Value.ToString();
                        d.InsertUVOItems(p);
                        //}

                        BAL.Poorderno = txtbox18.Text;
                        BAL.Poistatus = txtbox19.Text + "," + txtboxPay.Text;
                        d.OrderHistoryUpdate(p);

                        //p.Iid = dataGridView3.Rows[i].Cells[0].Value.ToString();
                        BAL.Poloc = cmbbox12.Text;
                        BAL.Poorderno = txtbox18.Text;
                        DataTable dt = new DataTable();
                        //dt = d.selectQOH(p);
                        //int qoh = int.Parse(dt.Rows[i]["quantityonhand"].ToString());
                        p.QuanOnHand1 = (Convert.ToInt32(p.QuanOnHand1) + Convert.ToInt32(dataGridView5.Rows[i].Cells[3].Value.ToString())).ToString();
                        d.updateQOH(p);

                        p.Iiname = dataGridView5.Rows[i].Cells[1].Value.ToString();
                        p.Ides = dataGridView5.Rows[i].Cells[2].Value.ToString();
                        p.Trans = "Purchase Order Unstock";
                        string MyStringOh = cmbbox13.Text;
                        DateTime MyDateTimeOh = DateTime.ParseExact(MyStringOh, "dd-MM-yyyy", null);
                        BAL.Datepoorderdate = Convert.ToDateTime(MyDateTimeOh);
                        //Prop.Poloc = cmbbox12.Text;
                        //Prop.Poorderno = txtbox18.Text;
                        //DataTable dt = new DataTable();
                        d.selectQOH(p);
                        //int qoh = int.Parse(dt.Rows[i]["quantityonhand"].ToString());
                        p.QuanOnHand1 = p.QuanOnHand1.ToString();
                        p.Iquantity = dataGridView5.Rows[i].Cells[3].Value.ToString();
                        p.QAfter1 = (Convert.ToInt32(p.QuanOnHand1) + Convert.ToInt32(dataGridView5.Rows[i].Cells[3].Value.ToString())).ToString();
                        d.MovementHistoryInsert(p);
                    }
                }
                count1 = 0;
            }
            MessageBox.Show("Data Inserted Successfully");
            btn11_Click_1(null, null);

        }


        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text == "Cancel Order")
            {
                btnCancel();

                BAL.Poorderno = txtbox18.Text;
                BAL.Poistatus = txtbox19.Text;
                BAL.Popstatus = txtboxPay.Text;
                d.updateistatus(p);
            }
            else
            {
                //Enable(tabPage1);
                Enable(this);
                //btn11_Click_1(null, null);

                btn8.Text = "Cancel Order";
                btn8.BackColor = Color.Honeydew;
                txtbox19.Text = "Unfullfilled";
                txtboxPay.Text = "Unpaid";

                btnFul.Visible = false;
                btnPay.Visible = false;
                pb2.Visible = true;

                BAL.Poorderno = txtbox18.Text;
                BAL.Poistatus = txtbox19.Text;
                BAL.Popstatus = txtboxPay.Text;
                d.updateistatus(p);
            }

            
        }

        private void btnCancel()
        {
            DisableControls(tabPage1);
            EnableControls(btn8);

            btn8.Text = "Re-open Order";
            btn8.BackColor = Color.Honeydew;

            txtbox19.Text = "Cancelled";
            txtboxPay.Text = "Cancelled";

            pb2.Image = Image.FromFile("D:\\Gowtham\\projectIntegration\\Images\\cancelled.jpg");
            tabPage1.Controls.Add(pb2);
            pb2.Location = new Point(130, 130);
            pb2.Size = new Size(280, 139);
            tabPage1.Controls.Add(pb2);
            pb2.BringToFront();
            pb2.Visible = true;
            //Blur();
        }

        private void PurhcaseOrder_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = d.UpdateOrder();
            foreach (DataRow dr in dt.Rows)
            {
                //if (dr.RowIndex == GridView1.SelectedIndex)
                //{
                //    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                //}
                txtbox18.Text = dr["poorderno"].ToString();
            }

            cmbbox13.Text = Convert.ToString(DateTime.Today);
            string MyStringO = cmbbox13.Text;
            DateTime MyDateTimeO = new DateTime();
            MyDateTimeO = DateTime.Parse(MyStringO);
            string formattedO = MyDateTimeO.ToString("dd/MM/yyyy");
            cmbbox13.Text = formattedO.ToString();

            //OrderNo.Width = 245;

            panel1.BackColor = ColorTranslator.FromHtml("#ffc800");

            pnl3.BackColor = ColorTranslator.FromHtml("#ffee88");

            dataGridView1.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffc800");
            //dataGridView1.RowDefaultCellStyleChanged.BackColor = ColorTranslator.FromHtml("#ffc800");
            dataGridView1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff48d");
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff5b0");
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ffe471");
            
            //pnl3.BackColor = Color.PaleGoldenrod;
            //dataGridView1.RowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;
            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite;

            tabPage1.BackColor = Color.White;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView3.Font,FontStyle.Regular);
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e0e0e0");
            dataGridView3.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");

            tabPage2.BackColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Regular);
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e0e0e0");
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");

            tabPage3.BackColor = Color.White;
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView4.Font, FontStyle.Regular);
            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e0e0e0");
            dataGridView4.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");

            tabPage4.BackColor = Color.White;
            dataGridView5.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView5.Font, FontStyle.Regular);
            dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e0e0e0");
            dataGridView5.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView5.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f5f5f5");

            //dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Orange;
            ////dataGridView1.GridColor = Color.Orange;
            //dataGridView1.BackgroundColor = Color.Orange;
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            //dataGridView1.EnableHeadersVisualStyles = false;

            if (BAL.NamL == null || BAL.NamL == "")
            {

            }
            else
            {
                string name = BAL.NamL;
                //DataTable dt = new DataTable();
                dt = d.loadvendname1(p);
                if (dt.Rows.Count > 0)
                {
                    cmbbox9.Text = dt.Rows[0]["vendorname"].ToString();
                    txtbox14.Text = dt.Rows[0]["contactname"].ToString();
                    txtbox15.Text = dt.Rows[0]["phone"].ToString();
                    txtbox16.Text = dt.Rows[0]["address"].ToString();
                    cmbTerms.Text = dt.Rows[0]["terms"].ToString();
                    cmbbox12.Text = dt.Rows[0]["location"].ToString();
                    txtbox18.Text = dt.Rows[0]["poorderno"].ToString();
                    cmbbox13.Text = dt.Rows[0]["orderdate"].ToString();
                    txtbox19.Text = dt.Rows[0]["inventorystatus"].ToString();
                    txtboxPay.Text = dt.Rows[0]["paymentstatus"].ToString();
                    txtshp.Text = dt.Rows[0]["shippingaddress"].ToString();
                    cmbCarrier.Text = dt.Rows[0]["carrier"].ToString();
                    cmbbox2.Text = dt.Rows[0]["duedate"].ToString();
                    cmbbox3.Text = dt.Rows[0]["taxingscheme"].ToString();
                    cmbbox4.Text = dt.Rows[0]["nonvendorcosts"].ToString();
                    cmbbox5.Text = dt.Rows[0]["currency"].ToString();
                    cmbbox6.Text = dt.Rows[0]["reqshipdate"].ToString();
                    txtbox2.Text = dt.Rows[0]["remarks"].ToString();
                    txtbox3.Text = dt.Rows[0]["subtotal"].ToString();
                    txtFreight.Text = dt.Rows[0]["freight"].ToString();
                    txtSTax.Text = dt.Rows[0]["statetax"].ToString();
                    txtCTax.Text = dt.Rows[0]["citytax"].ToString();
                    txtbox4.Text = dt.Rows[0]["total"].ToString();
                    txtbox5.Text = dt.Rows[0]["paid"].ToString();
                    txtbox6.Text = dt.Rows[0]["balance"].ToString();
                    //comboBox10.Text = dt.Rows[0]["showcancelled"].ToString();
                    BAL.NamL = "";
                }
            }
        }

        private void pnl3_Click(object sender, EventArgs e)
        {
            pnlLoc.Visible = false;

            pnlPay.Visible = false;

            pnlTax.Visible = false;

            pnlItem.Visible = false;
            dgvItem.Visible = false;

            pnlPSearch.Visible = false;
            pnlISearch.Visible = false;

            dgvVendor.Visible = false;
            pnlVendor.Visible = false;

            dgvVendorSearch.Visible = false;
            pnlVendorSearch.Visible = false;

            pnlLocSearch.Visible = false;
            pnlLoc.Visible = false;

            pnlDate.Visible = false;

            //btnPay.Visible = false;
            //btnFul.Visible = false;
            //btn2.Visible = true;

            //pb.Visible = true;
            //pb1.Visible = true;

            //dataGridView1.Rows.Clear();

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        //private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridView4.CurrentRow.Cells[3].Value != null && dataGridView4.CurrentRow.Cells[4].Value != null)
        //    {
        //        int a = 0;
        //        //int paid = 0;
        //        //int page = 0;
        //        int qtotal = 0;
        //        foreach (DataGridViewRow row in dataGridView4.Rows)
        //        {
        //            DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)row.Cells[3];
        //            DataGridViewTextBoxCell cel1 = (DataGridViewTextBoxCell)row.Cells[4];
        //            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
        //            {
        //                int Quant;
        //                int UPrice;
        //                int discount = 0;
        //                int Stotal;
        //                int total;
        //                Quant = int.Parse(dataGridView4.CurrentRow.Cells[3].Value.ToString());
        //                UPrice = int.Parse(dataGridView4.CurrentRow.Cells[5].Value.ToString());
        //                discount = int.Parse(dataGridView4.CurrentRow.Cells[6].Value.ToString());
        //                Stotal = (Quant * UPrice) - (discount / 100);
        //                dataGridView4.CurrentRow.Cells[7].Value = Stotal.ToString();

        //                if (txtReturnF.Text == "")
        //                {

        //                    txtReturnF.Text = a.ToString();

        //                }

        //                if (dataGridView4.Rows.Count > 2)
        //                {
        //                    for (int i = 0; i < dataGridView4.RowCount - 1; i++)
        //                    {

        //                        a = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
        //                        qtotal = qtotal + a;

        //                        txtbox10.Text = qtotal.ToString();
        //                        total = qtotal + (int.Parse(txtReturnF.Text)) + (int.Parse(txtReturnSTax.Text)) + (int.Parse(txtReturnCTax.Text));
        //                        txtbox9.Text = total.ToString();

        //                    }
        //                }

        //                else
        //                {
        //                    txtbox10.Text = Stotal.ToString();
        //                    total = qtotal + (int.Parse(txtReturnF.Text)) + (int.Parse(txtReturnSTax.Text)) + (int.Parse(txtReturnCTax.Text));
        //                    txtbox9.Text = total.ToString();
        //                }
        //            }

        //            pnlItem.Visible = false;

        //        }
        //    }
       // }
    }
}
