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
    public partial class Customer : Form
    {
        DAL dal = new DAL();
        BAL bal = new BAL();
        public Customer()
        {
            InitializeComponent();
            cmbaddress.Items.Add("Business Address");
            cmbaddress.Items.Add("Residential Address");
            cmbshow.Items.Add("Active");
            cmbshow.Items.Add("Inactive");
            cmbshow.Items.Add("Show All");
            cmbcardtype.Items.Add("VISA");
            cmbcardtype.Items.Add("Master card");
            cmbcardtype.Items.Add("American Express");
            cmbcardtype.Items.Add("Discover");
            cmbcardtype.Items.Add("Diners Club");

            ///----------------------groupbox click events---------------------------///

            this.groupBox4.Click += new System.EventHandler(this.groupBox4_Click);
            this.groupBox6.Click += new System.EventHandler(this.groupBox6_Click);
        }

        ///-------------------------------page load-----------------------------------///

        private void Customer_Load(object sender, EventArgs e)
        {
            ///-------------------Adding Colors to the Panels------------------------///

            panel1.BackColor = Color.YellowGreen;
            panel9.BackColor = Color.YellowGreen;
            panel3.BackColor = Color.GreenYellow;
            panel2.BackColor = Color.White;
            panel6.BackColor = Color.White;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            btndeactivate.BackColor = Color.Red;

            ///----------------Adding Colors to the datagridview--------------------///

            dgvname.ColumnHeadersDefaultCellStyle.BackColor = Color.Chartreuse;
            dgvname.EnableHeadersVisualStyles = false;
            dgvname.DefaultCellStyle.BackColor = Color.LightYellow;
            dgvname.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dgvname.RowHeadersVisible = false;
            dgvname.DefaultCellStyle.SelectionBackColor = Color.Green;

            dgvorderhistory.RowHeadersVisible = false;
            dgvorderhistory.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvorderhistory.EnableHeadersVisualStyles = false;
            dgvorderhistory.DefaultCellStyle.BackColor = Color.White;
            dgvorderhistory.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
           // dgvorderhistory.DataSource = cdal.selectorderhistory();

            dgvpaymenthistory.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvpaymenthistory.EnableHeadersVisualStyles = false;
            dgvpaymenthistory.RowHeadersVisible = false;
            dgvpaymenthistory.DefaultCellStyle.BackColor = Color.White;
            dgvpaymenthistory.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;                                  


            ///------------------Setting Datetime picker Date format short-----------------------///

            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker3.Format = DateTimePickerFormat.Short;

            ///------------------Panels Visibility false in page load---------------------------///
       
            panelpricingcurrency.Visible = false;
            panelpaymentterms.Visible = false;
            paneltaxingscheme.Visible = false;
            panellocations.Visible = false;
            panelstartdate.Visible = false;
            label41.Visible = false;

            ///--------------------Adding customers names to the datagridview in page load--------------///

            DataTable dt3 = dal.selectall2();
            foreach (DataRow dr in dt3.Rows)
            {
                int i=dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
            }
            dgvname.Columns[0].Visible = false;
        }

        ///----------------------Adding updated active customers to the datagridview---------------------///

        public void getdata()
        {
            DataTable dt = dal.selectall();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
            }
        }

        ///-----------------------Adding updated inactive customers to the datagridview------------------///

        public void get()
        {
            DataTable dt = dal.selectall1();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
            }
        }

        ///----------------------Redirecting to the address form by clicking on Address box-----------------///

        private void txtaddress_Click(object sender, EventArgs e)
        {
            Address ad = new Address();
            ad.Show();
            ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked);
          
        }
        private void address_ButtonClicked(object sender, InventoryTools.Address.AddressUpdateEventArgs e)
        {
            txtaddress.Text = "";
            txtaddress.Text += e.Street + "\r\n";
            txtaddress.Text += e.City + "\r\n";
            txtaddress.Text += e.State + "\r\n";
            txtaddress.Text += e.Country + "\r\n";
            txtaddress.Text += e.Postalcode + "\r\n";
            txtaddress.Text += e.Remarks + "\r\n";
            txtaddress.Text += e.Type;
        }
        ///---------------Saving customers Details in to the database on clicking save button----------------///

        private void btnsvae_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbdefaultsalesrep.Text == string.Empty)
                {
                    MessageBox.Show("Need to enter extra info");
                }
                else
                {
                    BAL.Customer = txtcustomername.Text;
                    DataTable dt = dal.selectcustomername();
                    if (dt.Rows.Count == 0)
                    {
                        bal.Customername = txtcustomername.Text;
                        bal.Balance = txtbalance.Text;
                        bal.Credit = txtcredit.Text;
                        bal.Contactname = txtcontactname.Text;
                        bal.Phone = txtphone.Text;
                        bal.Fax = txtfax.Text;
                        bal.Email = txtemail.Text;
                        bal.Website = txtwebsite.Text;
                        bal.Remarks = txtremarks.Text;
                        bal.Addresstype = cmbaddress.Text;
                        bal.Address = txtaddress.Text;
                        bal.Pricingorcurrency = cmbpricingorcurrency.Text;
                        bal.Discount = txtdiscount.Text;
                        bal.Paymentterms = cmbpaymentterms.Text;
                        bal.Taxingscheme = cmbtaxingschema.Text;
                        bal.Taxexempt = txttaxexempt.Text;
                        bal.Alternatecontact = int.Parse(txtalternatecontact.Text);
                        bal.Emergencyphone = int.Parse(txtemergencyphone.Text);
                        bal.Defaultlocation = cmbdefaultlocation.Text;
                        bal.Defaultsalesrep = cmbdefaultsalesrep.Text;
                        bal.Carrier = cmbcarrier.Text;
                        bal.Paymentmethod = cmbpaymentmethod.Text;
                        bal.Cardtype = cmbcardtype.Text;
                        bal.Cardnumber = txtcardnumber.Text;

                        bal.Expiredate = txtexpirationdate.Text;
                        bal.Cardsecuritycode = txtcardsecuritycode.Text;
                        bal.Dob = DateTime.Parse(dateTimePicker1.Text);
                        bal.Residence = txtresidence.Text;
                        BAL.Status = "Active";
                        BAL.City.ToString();
                        BAL.State.ToString();
                        BAL.Country.ToString();
                        BAL.Zip.ToString();
                        dal.insert(bal);
                        MessageBox.Show("Inserted Successfully");
                        SaleOrderWith_shipping_details sd = new SaleOrderWith_shipping_details();
                        this.Hide();
                        sd.Show();
                    }
                    else
                    {
                        MessageBox.Show("Existing Customername");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Insertion Failed");
            }
        }

        ///----------------combobox click event to show datagridview in combobox dropdown--------------///

        private void cmbpricingorcurrency_Click(object sender, EventArgs e)
        {
            panelpricingcurrency.Visible = true;
            dgvpricingcurrency.DataSource = dal.pricing();
           // dgvpricingcurrency.DataSource = dal.selectprice();

            dgvpricingcurrency.RowHeadersVisible = false;
            dgvpricingcurrency.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvpricingcurrency.EnableHeadersVisualStyles = false;
            dgvpricingcurrency.DefaultCellStyle.BackColor = Color.White;
            dgvpricingcurrency.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

        }

        ///----------------combobox click event to show datagridview in combobox dropdown---------------///

        private void cmbpaymentterms_Click(object sender, EventArgs e)
        {
            panelpaymentterms.Visible = true;
            dgvpaymentterms.DataSource = dal.selectpayment();
            DataGridViewColumn column = dgvpaymentterms.Columns[0];
            column.Width = 150;

            dgvpaymentterms.RowHeadersVisible = false;
            dgvpaymentterms.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvpaymentterms.EnableHeadersVisualStyles = false;
            dgvpaymentterms.DefaultCellStyle.BackColor = Color.White;
            dgvpaymentterms.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        ///-------------combobox click event to show datagridview in combobox dropdown-----------------///

        private void cmbtaxingschema_Click(object sender, EventArgs e)
        {
            paneltaxingscheme.Visible = true;
           // dgvtaxingscheme.DataSource = cdal.selecttaxing1();
            dgvtaxingscheme.DataSource = dal.taxing();
            dgvtaxingscheme.RowHeadersVisible = false;
            dgvtaxingscheme.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvtaxingscheme.EnableHeadersVisualStyles = false;
            dgvtaxingscheme.DefaultCellStyle.BackColor = Color.White;
            dgvtaxingscheme.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        ///--------------------Buton click event to redirect to pricing/currency form---------------------///

        private void btnpricing_Click(object sender, EventArgs e)
        {
            Pricing price = new Pricing();
            price.Show();
            price.dgvPricingAdd.DataSource = dal.pricing();
            panelpricingcurrency.Visible = false;
        }

        ///------------------Button click event to redirect to paymentterms form------------------///

        private void btnpayment_Click(object sender, EventArgs e)
        {
            PaymentTerms pay = new PaymentTerms();
            pay.dgvPayterms.AllowUserToAddRows = true;
            pay.Show();
            panelpaymentterms.Visible = false;
        }

        ///-----------------Button click evento to redirect to taxingschemes form------------------///

        private void btntaxing_Click(object sender, EventArgs e)
        {
            Taxing t = new Taxing();
            DataTable dt = dal.select_taxing();
            foreach (DataRow d in dt.Rows)
            {
                int n = t.dgvAddTaxing.Rows.Add();
                t.dgvAddTaxing.Rows[n].Cells[0].Value = d["taxschemename"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[1].Value = d["taxname"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[2].Value = d["taxrate"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[3].Value = d["taxonshipping"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[4].Value = d["secondarytax"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[5].Value = d["secondarytaxrate"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[6].Value = d["secondarytaxon"].ToString();
                t.dgvAddTaxing.Rows[n].Cells[7].Value = d["compoundsceondary"].ToString();

            }

            t.Show();
            paneltaxingscheme.Visible = false;
        }

        ///---------------datagridview cell click event to add gridview data to combobox---------------/// 

        private void dgvpricingcurrency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string pricing = dgvpricingcurrency.CurrentRow.Cells[1].Value.ToString();
            cmbpricingorcurrency.Text = pricing;
            panelpricingcurrency.Visible = false;
            dgvpricingcurrency.ReadOnly = true;
        }

        ///--------------datagridview cell click event to add gridview data to combobox----------------///

        private void dgvpaymentterms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string payment = dgvpaymentterms.CurrentRow.Cells[0].Value.ToString();
            cmbpaymentterms.Text = payment;
            panelpaymentterms.Visible = false;
            dgvpaymentterms.ReadOnly = true;
        }

        ///------------------datagridview cell click event to add gridivew data to combobox---------------///

        private void dgvtaxingscheme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string taxing = dgvtaxingscheme.CurrentRow.Cells[0].Value.ToString();
            cmbtaxingschema.Text = taxing;
            paneltaxingscheme.Visible = false;
            dgvtaxingscheme.ReadOnly = true;
        }

        ///-----------------combobox click event to show datagridview in combobox dropdown-------------------///

        private void cmbdefaultlocation_Click(object sender, EventArgs e)
        {
            panellocations.Visible = true;
            dgvlocations.DataSource = dal.selectloc();
            DataGridViewColumn column = dgvlocations.Columns[0];
            column.Width = 220;

            dgvlocations.RowHeadersVisible = false;
            dgvlocations.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvlocations.EnableHeadersVisualStyles = false;
            dgvlocations.DefaultCellStyle.BackColor = Color.White;
            dgvlocations.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        ///-----------------datagridivew cell click event to add gridview locations to combobox dropdown-------------------///

        private void dgvlocations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string location = dgvlocations.CurrentRow.Cells[0].Value.ToString();
            cmbdefaultlocation.Text = location;
            panellocations.Visible = false;
            dgvlocations.ReadOnly = true;
        }

        ///---------------------Button click event to redirect to locations form----------------------------///

        private void btnlocation_Click(object sender, EventArgs e)
        {
            Location loc = new Location();
            loc.Show();
            panellocations.Visible = false;
        }

        ///----------------combobox click event to add salesrepresentatative table data to combobox dropdown------------------///

        private void cmbdefaultsalesrep_Click(object sender, EventArgs e)
        {
            cmbdefaultsalesrep.Items.Clear();
            DataTable dt = dal.selectsalesrep();
            foreach (DataRow dr in dt.Rows)
            {
                cmbdefaultsalesrep.Items.Add(dr["salesrepresentative"].ToString());
            }
        }

        ///---------------------combobox click event to add carrier table data to combobox dropdown-----------------///

        private void cmbcarrier_Click(object sender, EventArgs e)
        {
            cmbcarrier.Items.Clear();
            DataTable dt = dal.selectcarrier();
            foreach (DataRow dr in dt.Rows)
            {
                cmbcarrier.Items.Add(dr["carrier"].ToString());
            }
        }

        ///---------------------combobox click event to add paymentmethod table data to combobox dropdown-----------------///

        private void cmbpaymentmethod_Click(object sender, EventArgs e)
        {
            cmbpaymentmethod.Items.Clear();
            DataTable dt = dal.selectpaymentmethod();
            foreach (DataRow dr in dt.Rows)
            {
                cmbpaymentmethod.Items.Add(dr["paymentmethod"].ToString());
            }
        }
        
        ///-----------------textbox keypress event to enter digits & controls in textbox----------------------------///

        private void txtcardnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        ///---------------------Textbox keypress event to enter digits,controls &punctuations to textbox----------------///

        private void txtexpirationdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar)) && !(char.IsPunctuation(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled=true;
            }
        }

        ///----------------Textbox Keypress event to enter digits & controls to textbox-----------------------///

        private void txtcardsecuritycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtfax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        ///----------------- Button click event to activate and inactivate customers------------------------///

        private void btndeactivate_Click(object sender, EventArgs e)
        {
            label41.Visible = true;
            dgvname.Rows.Clear();
            if (btndeactivate.Text == "Deactivate")
            {
                BAL.Contact_name = txtcustomername.Text;
                dal.updatestatus();
                if (cmbshow.Text == "Active")
                {
                    getdata();
                }
                else if(cmbshow.Text == "Inactive")
                {
                    get();
                }
                panel2.Enabled = false;
                panel6.Enabled = false;
                label41.Text = "Customer Deactivated!";
            }
            else if (btndeactivate.Text == "Reactivate")
            {
                BAL.Conname = txtcustomername.Text;
                dal.updatestat();
                if (cmbshow.Text == "Active")
                {
                    getdata();
                }
                else if (cmbshow.Text == "Inactive")
                {
                    get();
                }
                panel2.Enabled = true;
                panel6.Enabled = true;
                label41.Text = "Customer Acivated!";
            }
        }

        ///-----------------------Combobox selectedindexchanged event to show active,inactive & showall customers in datagridivew-----------///

        private void cmbshow_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvname.Rows.Clear();
            panel2.Enabled = true;
            panel6.Enabled = true;
           BAL.Stat = cmbshow.Text;
            DataTable dt= dal.selectstatus();

          
            foreach (DataRow dr in dt.Rows)
            {
                int i = dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
            }
          dgvname.Columns[0].Visible = false;
            if (cmbshow.Text == "Show All")
            {
                DataTable dt1 = dal.selectnamestatus();
                foreach (DataRow dr in dt1.Rows)
                {
                    int i = dgvname.Rows.Add();
                    dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
                    dgvname.Rows[i].Cells[2].Value = dr["status"].ToString();
                }
                dgvname.Columns[0].Visible = true;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                for (int i = 0; i < dgvname.Rows.Count; i++)
                {
                    chk.TrueValue = CheckState.Checked;
                    chk.FalseValue = CheckState.Unchecked;
                   BAL.St = Convert.ToString(dgvname.Rows[i].Cells[2].Value);
                    if (BAL.St == "Active")
                    {
                        dgvname.Rows[i].Cells[0].Value = chk.FalseValue;
                    }
                    else if (BAL.St == "Inactive")
                    {
                        dgvname.Rows[i].Cells[0].Value = chk.TrueValue;
                    }
                }

            }
            if (cmbshow.Text == "Inactive")
            {
                btndeactivate.Text = "Reactivate";
                btndeactivate.BackColor = Color.Green;
            }
            else
            {
                btndeactivate.Text = "Deactivate";
                btndeactivate.BackColor = Color.Red;
            }
            txtname.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtphone1.Text = string.Empty;
        }

        ///----------------------------datagridivew cell click event to bind data to textboxes and orderhistory gridview,orderpaymenthistory gridview based on cell click-------------///

        private void dgvname_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvname.Rows[e.RowIndex].ReadOnly = true;
                BAL.Customnam = dgvname.CurrentRow.Cells[1].Value.ToString();
                BAL.Con_name = dgvname.CurrentRow.Cells[1].Value.ToString();
                DataTable dt = dal.selectcustomers();
                foreach (DataRow dr in dt.Rows)
                {
                    txtcustomername.Text = dr["customername"].ToString();
                    txtbalance.Text = dr["balance"].ToString();
                    txtcredit.Text = dr["credit"].ToString();
                    txtcontactname.Text = dr["contactname"].ToString();
                    txtphone.Text = dr["phone"].ToString();
                    txtfax.Text = dr["fax"].ToString();
                    txtemail.Text = dr["email"].ToString();
                    txtwebsite.Text = dr["website"].ToString();
                    txtremarks.Text = dr["remarks"].ToString();
                    cmbaddress.Text = dr["addresstype"].ToString();
                    txtaddress.Text = dr["address"].ToString();
                    cmbpricingorcurrency.Text = dr["pricingorcurrency"].ToString();
                    txtdiscount.Text = dr["discount"].ToString();
                    cmbpaymentterms.Text = dr["paymentterms"].ToString();
                    cmbtaxingschema.Text = dr["taxingscheme"].ToString();
                    txttaxexempt.Text = dr["taxexempt"].ToString();
                    txtalternatecontact.Text = dr["alternatecontact"].ToString();
                    txtemergencyphone.Text = dr["emergencyphone"].ToString();
                    cmbdefaultlocation.Text = dr["defaultlocation"].ToString();
                    cmbdefaultsalesrep.Text = dr["defaultsalesrep"].ToString();
                    cmbcarrier.Text = dr["carrier"].ToString();
                    cmbpaymentmethod.Text = dr["paymentmethod"].ToString();
                    cmbcardtype.Text = dr["cardtype"].ToString();
                    txtcardnumber.Text = dr["cardnumber"].ToString();
                    txtexpirationdate.Text = dr["expiredate"].ToString();
                    txtcardsecuritycode.Text = dr["cardsecuritycode"].ToString();
                    dateTimePicker1.Text = dr["dob"].ToString();
                    txtresidence.Text = dr["residence"].ToString();

                    String some = dr["status"].ToString();
                    if (some == "Active")
                    {
                        btndeactivate.Text = "Deactivate";
                        btndeactivate.BackColor = Color.Red;
                    }
                    else if (some == "Inactive")
                    {
                        btndeactivate.Text = "Reactivate";
                        btndeactivate.BackColor = Color.Green;
                    }

                    dgvorderhistory.DataSource = dal.selectorders();
                    dgvpaymenthistory.DataSource = dal.selectpaymenthistory1();

                    label37.Text = "0.0";
                    label39.Text = "0.0";

                    panel2.Enabled = true;
                    panel6.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        ///-----------------------Binding data to datagridview by entering customername--------------------///

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel6.Enabled = true;
            dgvname.Rows.Clear();
            dgvname.Columns[0].Visible = false;
            BAL.Customname = txtname.Text;
            DataTable dt = dal.selectcustomer1();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
            }
            txtcontact.Text = string.Empty;
            txtphone1.Text = string.Empty;
            cmbshow.Text = string.Empty;
        }

        ///------------------------Binding data to datagridview by entering contactname--------------------///

        private void txtcontact_TextChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel6.Enabled = true;
            dgvname.Rows.Clear();
            dgvname.Columns[0].Visible = false;
            BAL.Contactnam = txtcontact.Text;
            DataTable dt = dal.selectcustomer();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["contactname"].ToString();
            }
            txtname.Text = string.Empty;
            txtphone1.Text = string.Empty;
            cmbshow.Text = string.Empty;
        }

        ///-----------------------Binding data to datagridview by entering phone numbers of customers----------------------///

        private void txtphone1_TextChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel6.Enabled = true;
            dgvname.Rows.Clear();
            dgvname.Columns[0].Visible = false;
            BAL.Phoneno = txtphone1.Text;
            DataTable dt = dal.customer();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
            }
            txtname.Text = string.Empty;
            txtcontact.Text = string.Empty;
            cmbshow.Text = string.Empty;
        }

        ///----------------------------Textbox keypress event to enter digits & controls in textbox------------------------------///

        private void txtphone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        ///--------------------------Button click event to clear all textboxes,comboboxes z7 datetimepicker------------------------///

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel6.Enabled = true;

            txtname.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtphone1.Text = string.Empty;
            cmbshow.Text = string.Empty;
            txtcustomername.Text = string.Empty;
            txtbalance.Text = string.Empty;
            txtcredit.Text = string.Empty;
            txtcontactname.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtfax.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtwebsite.Text = string.Empty;
            txtremarks.Text = string.Empty;
            cmbaddress.Text = string.Empty;
            txtaddress.Text = string.Empty;
            cmbpricingorcurrency.Text = string.Empty;
            txtdiscount.Text = string.Empty;
            cmbpaymentterms.Text = string.Empty;
            cmbtaxingschema.Text = string.Empty;
            txttaxexempt.Text = string.Empty;
            txtalternatecontact.Text = string.Empty;
            txtemergencyphone.Text = string.Empty;
            cmbdefaultlocation.Text = string.Empty;
            cmbdefaultsalesrep.Text = string.Empty;
            cmbcarrier.Text = string.Empty;
            cmbpaymentmethod.Text = string.Empty;
            cmbcardtype.Text = string.Empty;
            txtcardnumber.Text = string.Empty;
            txtexpirationdate.Text = string.Empty;
            txtcardsecuritycode.Text = string.Empty;
            dateTimePicker1.ResetText();
            txtresidence.Text = string.Empty;
            dgvorderhistory.DataSource = null;
            dgvpaymenthistory.DataSource = null;
            dgvname.Rows.Clear();
            DataTable dt3 = dal.selectall2();
            foreach (DataRow dr in dt3.Rows)
            {
                int i = dgvname.Rows.Add();
                dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
            }
            dgvname.Columns[0].Visible = false;
        }

        private void cmbstartdate_Click(object sender, EventArgs e)
        {
            panelstartdate.Visible = true;
            dateTimePicker2.ResetText();
            dateTimePicker3.ResetText();
        }

        ///----------------------Label click event to bind all orders payment history to gridview--------------------///

        private void lblall_Click(object sender, EventArgs e)
        {
            cmbstartdate.Text = lblall.Text;
            dgvpaymenthistory.DataSource = dal.selectpaymenthistory();
            panelstartdate.Hide();
        }

        ///--------------------Label click event to bind last orderpayment history to gridview------------------------///

        private void lblsincelast_Click(object sender, EventArgs e)
        {
            cmbstartdate.Text = lblsincelast.Text;
            dgvpaymenthistory.DataSource = dal.selectpaymentdate();
            panelstartdate.Hide();
        }

        ///------------------Label click event to bind this month orderpayment history to gridview----------------------/// 

        private void lblthismonth_Click(object sender, EventArgs e)
        {
            cmbstartdate.Text = lblthismonth.Text;
            dgvpaymenthistory.DataSource = dal.paydate();
            panelstartdate.Hide();
        }

        ///--------------------Label click event to bind last 30 days orderpayment history to gridview------------------///

        private void lbllast30days_Click(object sender, EventArgs e)
        {
            cmbstartdate.Text = lbllast30days.Text;
            dgvpaymenthistory.DataSource = dal.paymentdate();
            panelstartdate.Hide();
        }

        ///------------------------Datetimepicker keydown event to get orderpayment history between two dates---------------///

         private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BAL.Fromdate = DateTime.Parse(dateTimePicker2.Text);
                BAL.Todate = DateTime.Parse(dateTimePicker3.Text);
                dgvpaymenthistory.DataSource = dal.datefrom();
                panelstartdate.Hide();
                cmbstartdate.Text = dateTimePicker2.Text + " ";
                cmbstartdate.Text += dateTimePicker3.Text;
                if (dgvpaymenthistory.Rows.Count == 0)
                {
                    MessageBox.Show("No records found");
                }
            }
        }

        ///---------------------- gridview cell click event to bind orderpayment history credit & balance in lablels---------------------///

        private void dgvpaymenthistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvpaymenthistory.ReadOnly = true;
            label39.Text = dgvpaymenthistory.CurrentRow.Cells[4].Value.ToString();
            label37.Text = dgvpaymenthistory.CurrentRow.Cells[5].Value.ToString();
        }

        private void dgvorderhistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvorderhistory.ReadOnly = true;
        }

        ///-----------------button click event to redirect to new form on clicking new button-------------------///

        private void btnnew_Click(object sender, EventArgs e)
        {
            Customer obj = new Customer();
            obj.Show();
            this.Hide();
        }

        ///--------------------------- groupbox click event to disable panels--------------------------------------///

        private void groupBox4_Click(object sender, System.EventArgs e)
        {
            panelpricingcurrency.Visible = false;
            panelpaymentterms.Visible = false;
            paneltaxingscheme.Visible = false;
        }

        ///---------------- group box click event to insert carrier,salesrep,paymentmethod on clicking groupbox--------------------///
        private void groupBox6_Click(object sender, System.EventArgs e)
        {
            panellocations.Visible = false;
            if (cmbdefaultsalesrep.Focused == true)
            {
                if (cmbdefaultsalesrep.Text != String.Empty)
                {
                    bal.DefaultSalesRep = cmbdefaultsalesrep.Text;
                    DataTable dt = dal.selectsalesrep1(bal);
                    if (dt.Rows.Count == 0)
                    {
                        bal.SalesRepr = cmbdefaultsalesrep.Text;
                        dal.insertsalesrep(bal);
                    }
                    else
                    {
                        MessageBox.Show("Already Existing Salesrep");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Something to Insert");
                }
            }
           
            if (cmbcarrier.Focused == true)
            {
                if (cmbcarrier.Text != String.Empty)
                {
                    BAL.Carry = cmbcarrier.Text;
                    DataTable dt = dal.selectcarrier1();
                    if (dt.Rows.Count == 0)
                    {
                        bal.Carriertype = cmbcarrier.Text;
                        dal.insertcarrier(bal);
                    }
                    else
                    {
                        MessageBox.Show("Already Existing Carrier");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Something to Insert");
                }
                }
            if (cmbpaymentmethod.Focused == true)
            {
                if (cmbpaymentmethod.Text != String.Empty)
                {
                    BAL.Paymethod = cmbpaymentmethod.Text;
                    DataTable dt = dal.selectpaymentmethod1();
                    if (dt.Rows.Count == 0)
                    {
                        bal.PaymentMeth = cmbpaymentmethod.Text;
                        dal.insertpay(bal);
                    }
                    else
                    {
                        MessageBox.Show("Already Existing Paymentmethod");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Something to Insert");
                }
            }
        }

        private void dgvpaymenthistory_Click(object sender, EventArgs e)
        {
            panelstartdate.Visible = false;
        }
    }
}
