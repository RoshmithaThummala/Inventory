using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;


namespace InventoryTools
{
    public partial class salesquote : Form
    {
        public salesquote()
        {
            InitializeComponent();
        }

        BAL bal = new BAL();
        DAL dal = new DAL();



        private void salesquote_Load(object sender, EventArgs e)
        {



            dgvCustomer.Visible = false;
            
            
            txtstatetax.Visible = false;
            txtcitytax.Visible = false;
            lblstatetax.Visible = false;
            lblcitytax.Visible = false;
            lbltax.Visible = false;

            lblterms.Visible = false;
            lbllocation.Visible = false;
            btnquotetoorder.Visible = false;
            panelitem.Visible = false;
            lblsalesrep.Visible = false;
            lblcancel.Visible = false;
            lnklbladdshipping.Visible = false;
            pnlcustomerquote.Visible = false;
            pnlsearchcustomer.Visible = false;
            pnlitemsearch.Visible = false;
            btncancelorder.Text = "Deactive";
            btncancelorder.BackColor = Color.Green;




            dgvsearch.AllowUserToResizeRows = false;
            dal.quonum(bal);
            txtquote.Text = bal.Quotenumber;
            cmbquotedate.Text = Convert.ToString(System.DateTime.Now);
            txtstatus.Text = "Active";


            DataTable dt = dal.quotenumber1(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }

            dgvsearch.Columns[0].Visible = false;


          



            pnlCustomr.Visible = false;
            panellocation.Visible = false;
            pnlpricing.Visible = false;
            panelsales.Visible = false;
            paneltax.Visible = false;
            panelterms.Visible = false;
            panelbydatesearch.Visible = false;



            dgvsearch.ColumnHeadersDefaultCellStyle.BackColor = Color.LawnGreen;
            dgvsearch.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dgvsearch.DefaultCellStyle.BackColor = Color.LightYellow;
            dgvsearch.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
            dgvsearch.BorderStyle = BorderStyle.FixedSingle;

            dgvitems.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvitems.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvitems.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;


            dgvcustomersearch.RowsDefaultCellStyle.BackColor = Color.White;
            dgvcustomersearch.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;


            dgvCustomer.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;


            dgvlocation.RowsDefaultCellStyle.BackColor = Color.White;
            dgvlocation.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;


            dgvpricing.RowsDefaultCellStyle.BackColor = Color.White;
            dgvpricing.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgvTaxing.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTaxing.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;


            dgvterms.RowsDefaultCellStyle.BackColor = Color.White;
            dgvterms.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;


            dgvsalesrep.RowsDefaultCellStyle.BackColor = Color.White;
            dgvsalesrep.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgvforselectitems.RowsDefaultCellStyle.BackColor = Color.White;
            dgvforselectitems.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;


          

        }



        private void cmbtax_Click(object sender, EventArgs e)
        {

            paneltax.Visible = true;
            DataTable dt = dal.taxing();
            dgvTaxing.Visible = true;

            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvTaxing.Rows.Add();
                dgvTaxing.Rows[n].Cells[0].Value = dr["taxschemename"].ToString();
                dgvTaxing.Rows[n].Cells[1].Value = dr["taxrate"].ToString();
                dgvTaxing.Rows[n].Cells[2].Value = dr["secondarytaxrate"].ToString();

            }
            lbltax.Visible = true;

        }



        private void cmbcustomer_Click(object sender, EventArgs e)
        {
            pnlCustomr.Visible = true;
            dgvCustomer.Visible = true;

            pnlCustomr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvCustomer.DataSource = dal.cusomer();
            if (dgvCustomer.ColumnCount == 2)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvCustomer.Columns.Add(lnk);
                lnk.Name = "View";
                lnk.Text = "View";
                lnk.HeaderText = "Details";
                lnk.UseColumnTextForLinkValue = true;
            }
        }



        private void dgvcustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomer.CurrentRow.Cells["customername"].ColumnIndex)
            {
                cmbcustomer.Text = dgvCustomer.CurrentRow.Cells["customername"].Value.ToString();
                bal.CustomerName = dgvCustomer.CurrentRow.Cells["customername"].Value.ToString();
                bal.Phone = dgvCustomer.CurrentRow.Cells["phone"].Value.ToString();
                dal.select_customer(bal);
                cmbcustomer.Text = bal.CustomerName;
                txtcontact.Text = bal.Contact;
                txtphone.Text = bal.Phone;
                txtshippingadd.Text = bal.ShippingAddress;
                cmbterms.Text = bal.PaymenStatus;
                cmbsalesrep.Text = bal.DefaultSalesRep;
                cmblocation.Text = bal.DefaultLoc;

                pnlCustomr.Visible = false;
            }
        }





        private void lklTaxing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

            paneltax.Visible = false;
            t.Show();



        }





        private void btnsave_Click(object sender, EventArgs e)
        {
            BAL bal = new BAL();
            bal.Quotenumber = txtquote.Text;
            DataTable dt = dal.duplication(bal);

            if (dt.Rows.Count == 0)
            {


                bal.Customername = cmbcustomer.Text;
               
                bal.Contactname = txtcontact.Text;
                bal.Phone = txtphone.Text;
                bal.Billingaddress = txtbillingaddress.Text;
                bal.Terms = cmbterms.Text;
                bal.Po = txtpo.Text;
                bal.salesrep = cmbsalesrep.Text;
                bal.Location = cmblocation.Text;
                bal.Quotenumber = txtquote.Text;
                bal.Quotedate = Convert.ToDateTime(cmbquotedate.Text);
                bal.Quotestatus = txtstatus.Text;
                bal.Shippingaddress = txtshippingadd.Text;
                bal.Noncustomer = Convert.ToDecimal(cmbnoncustomer.Text);
                bal.Pricingname = cmbpricing.Text;
                bal.Shippingdate = txtshipdate.Text;
                bal.Remarks = txtremarks.Text;
                bal.Freight = Convert.ToInt64(txtfrieght.Text);
                bal.Total = Convert.ToString(txttotal.Text);
                bal.Taxingschema = cmbtax.Text;
                bal.Statetax = Convert.ToDecimal(txtstatetax.Text);
                bal.Citytax = Convert.ToDecimal(txtcitytax.Text);
                bal.Total = Convert.ToString(txttotal.Text);
                bal.Duedate = cmbduedate.Text;

                int sum = 0;
                for (int i = 0; i < dgvitems.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgvitems.Rows[i].Cells[4].Value);
                }

                bal.Subtotal = Convert.ToDecimal(sum);
                bal.Itemamount = Convert.ToDecimal(txtsubtotal.Text);


                for (int i = 0; i < dgvitems.Rows.Count - 1; i++)
                {
                    bal.Quotenumber = txtquote.Text;

                    if (dt.Rows.Count == 0)
                    {
                       
                        bal.Customername = cmbcustomer.Text;
                 
                        bal.Quotenumber = txtquote.Text;
                        bal.Itemname = Convert.ToString(dgvitems.Rows[i].Cells[0].Value);
                        bal.Description = Convert.ToString(dgvitems.Rows[i].Cells[1].Value);
                        bal.Quantity = Convert.ToString(dgvitems.Rows[i].Cells[2].Value);
                        bal.Unitprice = Convert.ToString(dgvitems.Rows[i].Cells[3].Value);
                        bal.Discount = Convert.ToString(dgvitems.Rows[i].Cells[4].Value);
                        bal.Subtotal = Convert.ToDecimal(dgvitems.Rows[i].Cells[5].Value);
                      
                       
                        dal.itemsinsert(bal);
                    }
                    else
                    {
                        MessageBox.Show("Quote number Already Exists");

                    }

                }


                dal.proinsert(bal);
                MessageBox.Show("Data is created");

                dgvsearch.Rows.Clear();
                DataTable dt1 = dal.updatedquote(bal);

                foreach (DataRow dr in dt1.Rows)
                {
                    int n = dgvsearch.Rows.Add();
                    dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();

                }
                dgvsearch.Columns[0].Visible = false;
                dgvsearch.Columns[2].Visible = false;


                btnsave.Visible = false;
                btnquotetoorder.Visible = true;
            }

            else
            {
                MessageBox.Show("This Quote Number Already Exists");

            }

            salesquote sq = new salesquote();
        }




        private void dgvtax_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            lbltax.Visible = false;
            paneltax.Visible = false;


            Decimal saletot = 0;


            bal.Taxname = dgvTaxing.CurrentRow.Cells[0].Value.ToString();
            bal.Taxonshipping = dgvTaxing.CurrentRow.Cells[0].Value.ToString();
            dal.select_statetax(bal);
            dal.select_citytax(bal);




            cmbtax.Text = dgvTaxing.CurrentRow.Cells[0].Value.ToString();
            int c = 0;
            if (bal.TaxingScheme == "True")
            {
                txtstatetax.Visible = true;
                lblstatetax.Visible = true;
                txtstatetax.Text = (Convert.ToDecimal(txtsubtotal.Text) * Convert.ToDecimal(dgvTaxing.CurrentRow.Cells[1].Value) / 100).ToString();
                saletot += (Convert.ToDecimal(txtsubtotal.Text) + Convert.ToDecimal(txtstatetax.Text));
                c++;
            }
            else
                txtstatetax.Text = "0";
            if (bal.Taxschemename == "True")
            {
                lblcitytax.Visible = true;
                txtcitytax.Visible = true;
                txtcitytax.Text = (Convert.ToDecimal(txtsubtotal.Text) * Convert.ToDecimal(dgvTaxing.CurrentRow.Cells[2].Value) / 100).ToString();
                if (c == 0)
                {
                    saletot += (Convert.ToDecimal(txtsubtotal.Text) + Convert.ToDecimal(txtcitytax.Text));
                }
                else
                {
                    saletot += Convert.ToDecimal(txtcitytax.Text);
                }
                c++;
            }
            else
                txtcitytax.Text = "0";



        }





        private void cmbpricing_Click(object sender, EventArgs e)
        {

            pnlpricing.Visible = true;

            pnlpricing.Visible = true;
            pnlpricing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvpricing.DataSource = dal.pricing();
            pnlpricing.BringToFront();

        }


        private void dgvpricing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlpricing.Visible = false;

            bal.Pricingname = dgvpricing.CurrentRow.Cells[1].Value.ToString();
            cmbpricing.Text = bal.Pricingname;
            pnlpricing.Visible = false;
        }


        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            txtshipdate.Text = dtp.CustomFormat;
            txtshipdate.Text = dtp.Value.ToString("yyyy - MM - dd");
        }


        private void dgvitems_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dgvforselectitems.Columns.Clear();
                if (e.ColumnIndex == 0)
                {
                    dgvforselectitems.Visible = true;
                    this.panelitem.Location = this.dgvitems.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    int x = panelitem.Location.X;
                    int y = panelitem.Location.Y;
                    int nx = x + 0;
                    int ny = y + 190;
                    this.panelitem.Location = new Point(nx, ny);
                    this.panelitem.Visible = true;
                    panelitem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panelitem.BringToFront();
                    dgvforselectitems.Visible = true;
                    this.pnlitemsearch.Location = this.dgvitems.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                    int x1 = panelitem.Location.X;
                    int y1 = panelitem.Location.Y;
                    int nx1 = x1 + 0;
                    int ny1 = y1 + 180;
                    this.pnlitemsearch.Location = new Point(nx1, ny1);
                    pnlitemsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.pnlitemsearch.BringToFront();

                 
                    dgvforselectitems.Refresh();
                    dgvforselectitems.DataSource = dal.items();
                    dgvforselectitems.Columns[0].Visible = false;
                    if (dgvforselectitems.ColumnCount == 3)
                    {
                        DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                        dgvforselectitems.Columns.Add(lnk);
                        lnk.Name = "View";
                        lnk.HeaderText = "Details";
                        lnk.Text = "View";
                        lnk.UseColumnTextForLinkValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }






        private void dgvitems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bal.Quotequantity = Convert.ToInt32(dgvitems.CurrentRow.Cells[2].Value);
            bal.Quoteunitprice = Convert.ToInt64(dgvitems.CurrentRow.Cells[3].Value);
            bal.Quotediscount = Convert.ToDecimal(dgvitems.CurrentRow.Cells[4].Value);
            dgvitems.CurrentRow.Cells[5].Value = ((bal.Quotequantity * bal.Quoteunitprice) - (bal.Quotediscount * bal.Quotequantity * bal.Quoteunitprice) / 100);
            bal.Subtotal = Convert.ToDecimal(dgvitems.CurrentRow.Cells[5].Value);

            int sum = 0;
            for (int i = 0; i < dgvitems.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvitems.Rows[i].Cells[5].Value);
            }


            txtsubtotal.Text = Convert.ToString(sum);
        }


        private void txttotal_Click(object sender, EventArgs e)
        {

        }



        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbterms_Click(object sender, EventArgs e)
        {
            panelterms.Visible = true;
            dgvterms.Visible = true;
            lblterms.Visible = true;


            dgvterms.DataSource = dal.select_payterms();



        }


        private void cmblocation_Click(object sender, EventArgs e)
        {
            panellocation.Visible = true;

            dgvlocation.Visible = true;
            lbllocation.Visible = true;

         
            dgvlocation.DataSource = dal.location();
        }



        private void dgvlocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bal.Location = Convert.ToString(dgvlocation.CurrentRow.Cells[0].Value);

            cmblocation.Text = bal.Location;

            panellocation.Visible = false;


        }


        private void btncustomergridexit_Click(object sender, EventArgs e)
        {
            dgvCustomer.Visible = false;
            btnaddnew.Visible = false;
            txtaddnew.Visible = false;
        }


        private void txtbillingaddress_Click(object sender, EventArgs e)
        {
            Address ad = new Address();
            ad.Show();
            ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked);
        
        }




        private void address_ButtonClicked(object sender, InventoryTools.Address.AddressUpdateEventArgs e)
        {

            txtbillingaddress.Text += e.Street + "\r\n";
            txtbillingaddress.Text += e.City + "\r\n";
            txtbillingaddress.Text += e.State + "\r\n";
            txtbillingaddress.Text += e.Country + "\r\n";
            txtbillingaddress.Text += e.Postalcode + "\r\n";
            txtbillingaddress.Text += e.Remarks + "\r\n";
            txtbillingaddress.Text += e.Type + "\r\n";

        }



        private void txtshippingadd_Click(object sender, EventArgs e)
        {

            Address ad = new Address();
            ad.Show();
            ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked1);
            txtshippingadd.Text = string.Empty;
        }

        private void address_ButtonClicked1(object sender, InventoryTools.Address.AddressUpdateEventArgs e)
        {

            txtshippingadd.Text += e.Street + "\r\n";
            txtshippingadd.Text += e.City + "\r\n";
            txtshippingadd.Text += e.State + "\r\n";
            txtshippingadd.Text += e.Country + "\r\n";
            txtshippingadd.Text += e.Postalcode + "\r\n";
            txtshippingadd.Text += e.Remarks + "\r\n";
            txtshippingadd.Text += e.Type + "\r\n";

        }




        private void lnklblnoshipping_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtshippingadd.Visible = false;
            label17.Visible = false;
            lnklbladdshipping.Visible = true;
            lnklblnoshipping.Visible = false;
            txtshippingadd.Text = string.Empty;
        }

        private void lnklbladdshipping_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtshippingadd.Visible = true;

            label17.Visible = true;
            lnklblnoshipping.Visible = true;
            lnklbladdshipping.Visible = false;
        }



        private void txtsearchorder_TextChanged(object sender, EventArgs e)
        {
            bal.Quotenumber = txtsearchorder.Text;
            DataTable dt = dal.showquote(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }

            dgvsearch.Columns[0].Visible = false;
        }



        private void cmbsearchinventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            bal.Quotestatus = cmbsearchinventory.Text;

            if (cmbsearchinventory.Text == "Active")
            {

                DataTable dt = dal.showquote1(bal);
                dgvsearch.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgvsearch.Rows.Add();
                    dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                    dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();
                }
                dgvsearch.Columns[0].Visible = false;
                btncancelorder.Text = "Deactive";



            }
            else if (cmbsearchinventory.Text == "Deactive")
            {

                DataTable dt = dal.showquote2(bal);
                dgvsearch.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgvsearch.Rows.Add();
                    dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                    dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();
                }

                dgvsearch.Columns[0].Visible = false;

                btncancelorder.Text = "Active";
                dgvsearch.Refresh();

            }
            else if (cmbsearchinventory.Text == "All")
            {
                DataTable dt = dal.quotenumber1(bal);
                dgvsearch.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgvsearch.Rows.Add();
                    dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                    dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();
                }
                dgvsearch.Columns[0].Visible = true;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                for (int i = 0; i < dgvsearch.Rows.Count; i++)
                {


                    chk.TrueValue = CheckState.Checked;
                    chk.FalseValue = CheckState.Unchecked;
                    bal.PaymenStatus = Convert.ToString(dgvsearch.Rows[i].Cells[2].Value);
                    if (bal.PaymenStatus == "Deactive")
                    {

                        dgvsearch.Rows[i].Cells[0].Value = chk.TrueValue;

                    }
                    else if (bal.PaymenStatus == "Active")
                    {

                        dgvsearch.Rows[i].Cells[0].Value = chk.FalseValue;
                    }
                }

                salesquote sq = new salesquote();

            }
        }


        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtsearchorder.Text = string.Empty;
            cmbsearchinventory.Text = string.Empty;
            cmbquotedatesearch.Text = string.Empty;
            cmbcustomersearch.Text = string.Empty;
            salesquote sq = new salesquote();
            sq.Show();
            this.Hide();

        }





        private void txtshippingadd_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtbillingaddress.Text))
            {
                Address ad = new Address();
                ad.Show();
                ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked1);
            }
            else
            {

                Address ad = new Address();
                ad.Show();
                ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked1);
                ad.txtstreet.Text = txtshippingadd.Lines[0];
                ad.cmbcity.Text = txtshippingadd.Lines[1];
                ad.cmbstateprovine.Text = txtshippingadd.Lines[2];
                ad.cmbcountry.Text = txtshippingadd.Lines[3];
                ad.txtzippostalcode.Text = txtshippingadd.Lines[4];
                ad.txtremarks.Text = txtshippingadd.Lines[5];
                ad.cmbtype.Text = txtshippingadd.Lines[6];
                txtshippingadd.Text = txtbillingaddress.Text;

                txtshippingadd.Text = string.Empty;
                ad.btncancel.Visible = false;
            }
        }


        private void dgvsearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                bal.Quotenumber = dgvsearch.CurrentRow.Cells[1].Value.ToString();

                bal.Customername = dgvsearch.CurrentRow.Cells[1].Value.ToString();

                dal.showquotedata(bal);

                cmbcustomer.Text = bal.Customername;
                txtphone.Text = bal.Phone;
                txtcontact.Text = bal.Contactname;
                txtbillingaddress.Text = bal.Billingaddress;
                cmbterms.Text = bal.Terms;
                cmbsalesrep.Text = bal.salesrep;
                cmblocation.Text = bal.Location;
                txtquote.Text = bal.Quotenumber;
                cmbquotedate.Text = Convert.ToString(bal.Quotedate);
                txtstatus.Text = bal.Quotestatus;
                txtshippingadd.Text = bal.Shippingaddress;
                cmbnoncustomer.Text = Convert.ToString(bal.Noncustomer);
                cmbtax.Text = bal.Taxingschema;
                cmbpricing.Text = bal.Pricingname;
                txtshipdate.Text = bal.Shippingdate;
                txtremarks.Text = bal.Remarks;
                txtsubtotal.Text = Convert.ToString(bal.Subtotal);
                txtfrieght.Text = Convert.ToString(bal.Freight);
                txtstatetax.Text = Convert.ToString(bal.Statetax);
                txtcitytax.Text = Convert.ToString(bal.Citytax);
                txttotal.Text = Convert.ToString(bal.Total);
                cmbduedate.Text = bal.Duedate;

                bal.Quotenumber = dgvsearch.CurrentRow.Cells[1].Value.ToString();
                DataTable dt2 = dal.itemsearchquote(bal);
                dgvitems.Rows.Clear();
                foreach (DataRow dr in dt2.Rows)
                {


                    int i = dgvitems.Rows.Add();

                    dgvitems.Rows[i].Cells[0].Value = dr["itemname"].ToString();
                    dgvitems.Rows[i].Cells[1].Value = dr["description"].ToString();
                    dgvitems.Rows[i].Cells[2].Value = dr["quantity"].ToString();
                    dgvitems.Rows[i].Cells[3].Value = dr["unitprice"].ToString();
                    dgvitems.Rows[i].Cells[4].Value = dr["discount"].ToString();
                    dgvitems.Rows[i].Cells[5].Value = dr["subtotal"].ToString();


                }

                if (txtstatus.Text == "Deactive")
                {
                    btncancelorder.BackColor = Color.Red;
                    panel2.Enabled = false;
                    lblcancel.Visible = true;
                    btncancelorder.Text = "Active";

                }
                else if (txtstatus.Text == "Active")
                {
                    btncancelorder.BackColor = Color.Green;
                    panel2.Enabled = true;
                    lblcancel.Visible = false;
                    btncancelorder.Text = "Deactive";
                }

                btnsave.Visible = false;
                btnquotetoorder.Visible = true;
                panelbydatesearch.Visible = false;
                pnlcustomerquote.Visible = false;

            }

        }




        private void btnnew_Click(object sender, EventArgs e)
        {
            salesquote sq = new salesquote();
            sq.Show();
            this.Hide();
        }

        private void btnquotetoorder_Click(object sender, EventArgs e)
        {

            SaleOrderWith_shipping_details so = new SaleOrderWith_shipping_details();
            so.Show();

            bal.Quotenumber = txtquote.Text;
            bal.Customername = cmbcustomer.Text;
            DataTable dt = dal.showquotedata(bal);

            {

                so.cboSaleCustmr.Text = bal.Customername;
                so.txtSaleCntct.Text = bal.Contactname;
                so.txtSalePhn.Text = bal.Phone;
                so.txtSaleBillAdrs.Text = bal.Billingaddress;

                so.cboSaleTrms.Text = bal.Terms;
                so.cboSaleRep.Text = bal.salesrep;
                so.cboSaleLocatn.Text = bal.Location;
           
                so.dtpSaleDate.Text = Convert.ToString(bal.Quotedate);
                so.cboInventryStatus.Text = bal.Quotestatus;
                so.txtSaleShpngAdrs.Text = bal.Shippingaddress;
                so.cboSaleNonCustmr.Text = Convert.ToString(bal.Noncustomer);
                so.cboSaleTaxng.Text = bal.Taxingschema;
                so.cboSaleCurrency.Text = bal.Pricingname;
                so.dtpShipDate.Text = bal.Shippingdate;
                so.txtSaleRemrks.Text = bal.Remarks;
                so.txtSaleSubTot.Text = Convert.ToString(bal.Subtotal);
                so.txtSaleTot.Text = Convert.ToString(bal.Total);
                so.txtSaleFright.Text = Convert.ToString(bal.Freight);
                so.dtpDuedate.Text = bal.Duedate;


                bal.Quotenumber = txtquote.Text;
                DataTable dt2 = dal.itemsearchquote(bal);
                so.dgvSaleItem.Rows.Clear();

                foreach (DataRow dr in dt2.Rows)
                {

                    int i = so.dgvSaleItem.Rows.Add();

                    so.dgvSaleItem.Rows[i].Cells[2].Value = dr["itemname"].ToString();
                    so.dgvSaleItem.Rows[i].Cells[3].Value = dr["description"].ToString();
                    so.dgvSaleItem.Rows[i].Cells[4].Value = dr["quantity"].ToString();
                    so.dgvSaleItem.Rows[i].Cells[5].Value = dr["unitprice"].ToString();
                    so.dgvSaleItem.Rows[i].Cells[6].Value = dr["discount"].ToString();
                    so.dgvSaleItem.Rows[i].Cells[7].Value = dr["subtotal"].ToString();

                }
            }
        }


        private void cmbsalesrep_Click(object sender, EventArgs e)
        {

            dgvsalesrep.DataSource = dal.salesrepr();
            dgvsalesrep.Visible = true;
            dgvsalesrep.BringToFront();

        }


        private void dgvforselectitems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvforselectitems.CurrentRow.Cells[1].ColumnIndex || e.ColumnIndex == dgvforselectitems.CurrentRow.Cells[2].ColumnIndex)
            {
                dgvitems.CurrentRow.Cells[0].Value = dgvforselectitems.CurrentRow.Cells["itemnameorcode"].Value;
                dgvitems.CurrentRow.Cells[1].Value = dgvforselectitems.CurrentRow.Cells["description"].Value;
           
                panelitem.Visible = false;
                pnlitemsearch.Visible = false;
            }
        
            else
                panelitem.Visible = false;
        }




        private void btncancelorder_Click(object sender, EventArgs e)
        {
            if (btncancelorder.Text == "Active")
            {

                btncancelorder.Text = "Deactive";
                txtstatus.Text = "Active";
                lblcancel.Visible = false;
                bal.Quotestatus = txtstatus.Text;
                bal.Quotenumber = txtquote.Text;
                panel2.Enabled = true;
                dal.cancelorder(bal);

                btncancelorder.BackColor = Color.Green;

                DataTable dt = dal.quotenumber1(bal);

                dgvsearch.Rows.Clear();
                dgvsearch.Columns[0].Visible = true;
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgvsearch.Rows.Add();
                    dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                    dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

                }

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                for (int i = 0; i < dgvsearch.Rows.Count; i++)
                {


                    chk.TrueValue = CheckState.Checked;
                    chk.FalseValue = CheckState.Unchecked;
                    bal.Quotestatus = Convert.ToString(dgvsearch.Rows[i].Cells[2].Value);
                    if (bal.Quotestatus == "Deactive")
                    {

                        dgvsearch.Rows[i].Cells[0].Value = chk.TrueValue;


                    }
                    else if (bal.Quotestatus == "Active")
                    {

                        dgvsearch.Rows[i].Cells[0].Value = chk.FalseValue;
                    }
                }



            }
            else if (btncancelorder.Text == "Deactive")
            {

                btncancelorder.Text = "Active";
                txtstatus.Text = "Deactive";
                bal.Quotestatus = txtstatus.Text;
                bal.Quotenumber = txtquote.Text;
                panel2.Enabled = false;
                lblcancel.Visible = true;
                dal.cancelorder(bal);

                btncancelorder.BackColor = Color.Red;

                DataTable dt = dal.quotenumber1(bal);
                dgvsearch.Rows.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgvsearch.Rows.Add();
                    dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                    dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

                }
                dgvsearch.Columns[0].Visible = true;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                for (int i = 0; i < dgvsearch.Rows.Count; i++)
                {


                    chk.TrueValue = CheckState.Checked;
                    chk.FalseValue = CheckState.Unchecked;
                    bal.Quotestatus = Convert.ToString(dgvsearch.Rows[i].Cells[2].Value);
                    if (bal.Quotestatus == "Deactive")
                    {

                        dgvsearch.Rows[i].Cells[0].Value = chk.TrueValue;


                    }
                    else if (bal.Quotestatus == "Active")
                    {

                        dgvsearch.Rows[i].Cells[0].Value = chk.FalseValue;
                    }
                }

            }

        }

   


        private void txtbillingaddress_Leave(object sender, EventArgs e)
        {
            txtshippingadd.Text = txtbillingaddress.Text;
        }


        private void txtstatus_TextChanged(object sender, EventArgs e)
        {

        }



        private void panel2_Click(object sender, EventArgs e)
        {
            dgvCustomer.Visible = false;
            pnlCustomr.Visible = false;
            panellocation.Visible = false;
            pnlpricing.Visible = false;
            panelsales.Visible = false;
            paneltax.Visible = false;
            panelterms.Visible = false;
            panelitem.Visible = false;
            pnlcustomerquote.Visible = false;
            panelbydatesearch.Visible = false;


        }


        private void cmbcustomersearch_Click(object sender, EventArgs e)
        {

            pnlcustomerquote.Visible = true;
            pnlcustomerquote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlcustomerquote.BringToFront();
            dgvcustomersearch.DataSource = dal.customer_names();
            if (dgvcustomersearch.ColumnCount == 2)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvcustomersearch.Columns.Add(lnk);
                lnk.Name = "View";
                lnk.Text = "View";
                lnk.HeaderText = "Details";
                lnk.UseColumnTextForLinkValue = true;
            }
            dgvcustomersearch.Visible = true;

          


        }

        private void panel3_Click(object sender, EventArgs e)
        {
            dgvCustomer.Visible = false;
            pnlCustomr.Visible = false;
            panellocation.Visible = false;
            pnlpricing.Visible = false;
            panelsales.Visible = false;
            paneltax.Visible = false;
            panelterms.Visible = false;
            panelitem.Visible = false;
            pnlcustomerquote.Visible = false;
            panelbydatesearch.Visible = false;
        }



        private void txtgridcustomersearch_TextChanged(object sender, EventArgs e)
        {
            bal.Customername = txtgridcustomersearch.Text;
            DataTable dt = dal.searchcustomer(bal);
            dgvcustomersearch.DataSource = dt;
        }



        private void cmbquotedatesearch_Click(object sender, EventArgs e)
        {
            panelbydatesearch.Visible = true;
            pnlcustomerquote.Visible = false;
        }

        private void lbltoday_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.today(bal);

            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }

            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lbltoday.Text;
        }

        private void lblthisweek_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.thisweek(bal);

            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }

            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lblthisweek.Text;
        }

        private void panelbydatesearch_Click(object sender, EventArgs e)
        {
            panelbydatesearch.Visible = false;

        }

        private void dtpquotedate_ValueChanged(object sender, EventArgs e)
        {
            cmbquotedate.Text = dtpquotedate.CustomFormat;
            cmbquotedate.Text = dtpquotedate.Value.ToString("yyyy - MM - dd");
        }

        private void lblthismonth_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.thismonth(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }

            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lblthismonth.Text;
        }

        private void lblthisquarter_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.thisquarter(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();


                dgvsearch.Columns[0].Visible = false;
                panelbydatesearch.Visible = false;
                cmbquotedatesearch.Text = lblthisquarter.Text;
            }
        }
        private void lblthisyear_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.thisyear(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }

            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lblthisyear.Text;
        }

        private void lbllastweek_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.lastweek(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lbllastweek.Text;
        }

        private void lbllastmonth_Click(object sender, EventArgs e)
        {

            DataTable dt = dal.lastmonth(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lbllastmonth.Text;
        }

        private void lbllastquarter_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.lastquarter(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lbllastquarter.Text;
        }

        private void lbllastyear_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.lastyear(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lbllastyear.Text;
        }

        private void lblall_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.alldates(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lblall.Text;
        }

        private void lbllastseven_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.lastsevendays(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            for (int i = 0; i < dgvsearch.Rows.Count; i++)
            {


                chk.TrueValue = CheckState.Checked;
                chk.FalseValue = CheckState.Unchecked;
                bal.Quotestatus = Convert.ToString(dgvsearch.Rows[i].Cells[2].Value);
                if (bal.Quotestatus == "Deactive")
                {

                    dgvsearch.Rows[i].Cells[0].Value = chk.TrueValue;


                }
                else if (bal.Quotestatus == "Active")
                {

                    dgvsearch.Rows[i].Cells[0].Value = chk.FalseValue;
                }
            }
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lbllastseven.Text;
        }

        private void lastthirty_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.lastthirtydays(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }

            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lastthirty.Text;
        }

        private void lastninety_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.lastnintydays(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lastninety.Text;
        }

        private void Lastyeardays_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.lastyeardays(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = Lastyeardays.Text;
        }


        private void dtpstartdate_ValueChanged(object sender, EventArgs e)
        {
            txtstartdate.Text = dtpstartdate.CustomFormat;
            txtstartdate.Text = dtpstartdate.Value.ToString("yyyy-MM-dd");
        }

        private void dtpenddate_ValueChanged(object sender, EventArgs e)
        {
            txtendate.Text = dtpenddate.CustomFormat;
            txtendate.Text = dtpenddate.Value.ToString("yyyy-MM-dd");
        }

        private void lblyesterday_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.yesterday(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            dgvsearch.Columns[0].Visible = false;
            panelbydatesearch.Visible = false;
            cmbquotedatesearch.Text = lblyesterday.Text;
        }

        private void dtpduedate_ValueChanged(object sender, EventArgs e)
        {
            cmbduedate.Text = dtpduedate.CustomFormat;
            cmbduedate.Text = dtpduedate.Value.ToString("yyyy-MM-dd");
        }




        private void dgvcustomersearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bal.Customername = dgvcustomersearch.CurrentRow.Cells[0].Value.ToString();

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            for (int i = 0; i < dgvsearch.Rows.Count; i++)
            {


                chk.TrueValue = CheckState.Checked;
                chk.FalseValue = CheckState.Unchecked;
                bal.Quotestatus = Convert.ToString(dgvsearch.Rows[i].Cells[2].Value);

                if (bal.Quotestatus == "Deactive")
                {

                    dgvsearch.Rows[i].Cells[0].Value = chk.TrueValue;


                }
                else if (bal.Quotestatus == "Active")
                {

                    dgvsearch.Rows[i].Cells[0].Value = chk.FalseValue;
                }
            }

            cmbcustomersearch.Text = bal.Customername;
            pnlcustomerquote.Visible = false;
            

            cmbcustomersearch.Text = bal.Customername;
            pnlcustomerquote.Visible = false;

        }



        private void txtendate_TextChanged(object sender, EventArgs e)
        {


            bal.Startdate = txtstartdate.Text;
            bal.Enddate = txtendate.Text;
            DataTable dt = dal.betweendates(bal);
            dgvsearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            for (int i = 0; i < dgvsearch.Rows.Count; i++)
            {
                chk.TrueValue = CheckState.Checked;
                chk.FalseValue = CheckState.Unchecked;
                bal.Quotestatus = Convert.ToString(dgvsearch.Rows[i].Cells[2].Value);
                if (bal.Quotestatus == "Deactive")
                {
                    dgvsearch.Rows[i].Cells[0].Value = chk.TrueValue;
                }
                else if (bal.Quotestatus == "Active")
                {
                    dgvsearch.Rows[i].Cells[0].Value = chk.FalseValue;
                }
            }
            cmbquotedatesearch.Text = "manual date";
            panelbydatesearch.Visible = false;
        }


        private void txtsearchname_TextChanged_1(object sender, EventArgs e)
        {
            bal.Customername = txtsearchname.Text;
            DataTable dt = dal.search_customers(bal);
            dgvCustomer.DataSource = dt;
        }

        private void txtsearchcontact_TextChanged_1(object sender, EventArgs e)
        {
            pnlCustomr.Visible = true;
            bal.Contactname = txtsearchcontact.Text;
            DataTable dt = dal.searchbycontact(bal);
            dgvCustomer.DataSource = dt;
        }

        private void txtsearchphone_TextChanged_1(object sender, EventArgs e)
        {

            bal.Phone = txtsearchphone.Text;
            DataTable dt = dal.customers_phone(bal);
            dgvCustomer.DataSource = dt;
        }

        private void btnaddnew_Click_1(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            cus.txtcustomername.Text = txtaddnew.Text;
            dgvCustomer.Visible = false;
            pnlCustomr.Visible = false;
        }

        private void pnlcustomerquote_Click(object sender, EventArgs e)
        {
            pnlcustomerquote.Visible = false;
            panelbydatesearch.Visible = false;
        }



        private void dgvterms_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cmbterms.Text = dgvterms.CurrentRow.Cells[0].Value.ToString();
            panelterms.Visible = false;
        }

        private void dgvsalesrep_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cmbsalesrep.Text = dgvsalesrep.CurrentRow.Cells[0].Value.ToString();
            dgvsalesrep.Visible = false;
        }

      


        private void lblterms_Click_1(object sender, EventArgs e)
        {

        }

        private void txtfrieght_Leave(object sender, EventArgs e)
        {

            txttotal.Text = (Convert.ToDecimal(txtsubtotal.Text) + Convert.ToDecimal(cmbnoncustomer.Text) + Convert.ToDecimal(txtfrieght.Text) + Convert.ToDecimal(txtstatetax.Text) + Convert.ToDecimal(txtcitytax.Text)).ToString();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlitemsearch.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            pnlitemsearch.Visible = false;
        }

        private void txtitemsearch_TextChanged(object sender, EventArgs e)
        {
            bal.Itemname = txtitemsearch.Text;

         
            dgvforselectitems.Rows.Clear();
      
            {
                int k = dgvforselectitems.Rows.Add();

           
            }
        }

       

        private void lblsalesrep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void lblterms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentTerms pt = new PaymentTerms();
            pt.Show();
            panelterms.Visible = false;
        }

        private void lbllocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Location lc = new Location();
            lc.Show();
            panellocation.Visible = false;
        }

        private void lblPricing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pricing pr = new Pricing();
            pr.Show();
            pnlpricing.Visible = false;
        }

        private void lbltax_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Taxing ts = new Taxing();
            ts.Show();
            paneltax.Visible = false;

         
        }

        private void SearchBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlsearchcustomer.Visible = true;
        }

        private void HideSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlsearchcustomer.Visible = false;
        }

        private void btnsearchrefresh_Click_1(object sender, EventArgs e)
        {
            txtsearchcontact.Text = string.Empty;
            txtsearchname.Text = string.Empty;
            txtsearchphone.Text = string.Empty;
        }

        private void dgvCustomer_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentCell is DataGridViewLinkCell)
            {
                Customer c = new Customer();
              
                bal.CustomerName = dgvCustomer.CurrentRow.Cells["customername"].Value.ToString();
                bal.Phone = dgvCustomer.CurrentRow.Cells["phone"].Value.ToString();
                dal.select_customer(bal);
                c.txtcustomername.Text = bal.CustomerName;
                c.txtbalance.Text = bal.Balance;
                c.txtcredit.Text = bal.Credit;
                c.txtcontactname.Text = bal.Contact;
                c.txtphone.Text = bal.Phone;
                c.txtfax.Text = bal.Fax;
                c.txtemail.Text = bal.Email;
                c.txtwebsite.Text = bal.Website;
                c.txtremarks.Text = bal.Remarks;
                c.cmbaddress.Text = bal.Addresstype;
                c.txtaddress.Text = bal.ShippingAddress;

                c.cmbpricingorcurrency.Text = bal.Currency;
                c.txtdiscount.Text = bal.Discount;
                c.cmbpaymentterms.Text = bal.PaymenStatus;
                c.cmbtaxingschema.Text = bal.TaxingScheme;
                c.txttaxexempt.Text = bal.TaxExcemp;
                c.cmbdefaultlocation.Text = bal.DefaultLoc;
                c.cmbdefaultsalesrep.Text = bal.DefaultSalesRep;
                c.cmbcarrier.Text = bal.Carrier;
                c.cmbpaymentmethod.Text = bal.PaymentMeth;
                c.cmbcardtype.Text = bal.CardType;
                c.txtcardnumber.Text = bal.CardNum;
                c.txtexpirationdate.Text = bal.ExpiryDate;
                c.txtcardsecuritycode.Text = bal.CardCode;
                c.txtalternatecontact.Text = bal.Alternatecon;
                c.txtemergencyphone.Text = bal.Emergencycon;
                c.dateTimePicker1.Text = bal.Dob1;
                c.txtresidence.Text = bal.Residence;
                c.dgvorderhistory.DataSource = null;
                c.dgvpaymenthistory.DataSource = null;
                c.dgvorderhistory.DataSource = dal.selectorders();
                c.dgvpaymenthistory.DataSource = dal.selectpaymenthistory1();
            
                pnlCustomr.Visible = false;
                c.Show();

            }


        }

        private void dgvcustomersearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Customer c = new Customer();
            if (dgvcustomersearch.CurrentCell is DataGridViewLinkCell)
            {
                bal.CustomerName = dgvcustomersearch.CurrentRow.Cells["customername"].Value.ToString();
                bal.Phone = dgvcustomersearch.CurrentRow.Cells["phone"].Value.ToString();
                dal.select_customer(bal);
                c.txtcustomername.Text = bal.CustomerName;
                c.txtbalance.Text = bal.Balance;
                c.txtcredit.Text = bal.Credit;
                c.txtcontact.Text = bal.Contact;
                c.txtphone.Text = bal.Phone;
                c.txtfax.Text = bal.Fax;
                c.txtemail.Text = bal.Email;
                c.txtwebsite.Text = bal.Website;
                c.txtremarks.Text = bal.Remarks;
                c.txtaddress.Text = bal.ShippingAddress;
                c.cmbpricingorcurrency.Text = bal.Currency;
                c.txtdiscount.Text = bal.Discount;
                c.cmbpaymentterms.Text = bal.PaymenStatus;
                c.cmbtaxingschema.Text = bal.TaxingScheme;
                c.txttaxexempt.Text = bal.TaxExcemp;
                c.cmbdefaultlocation.Text = bal.DefaultLoc;
                c.cmbdefaultsalesrep.Text = bal.DefaultSalesRep;
                c.cmbcarrier.Text = bal.Carrier;
                c.cmbpaymentmethod.Text = bal.PaymentMeth;
                c.cmbcardtype.Text = bal.CardType;
                c.txtcardnumber.Text = bal.CardNum;
                c.txtexpirationdate.Text = bal.ExpiryDate;
                c.txtcardsecuritycode.Text = bal.CardCode;

                c.dgvorderhistory.DataSource = null;
                c.dgvpaymenthistory.DataSource = null;
                c.dgvorderhistory.DataSource = dal.select_phn_orders(bal);
                c.dgvpaymenthistory.DataSource = dal.select_phn_orders1(bal);
              
            
                pnlcustomerquote.Visible = false;
                c.Show();
            }

        }

        private void cmbcustomersearch_TextChanged(object sender, EventArgs e)
        {
            bal.Customername = cmbcustomersearch.Text;
            DataTable dt = dal.searchnamesgrid(bal);
            dgvsearch.Rows.Clear();
            dgvsearch.Columns[0].Visible = false;
            foreach (DataRow dr in dt.Rows)
            {
                int n = dgvsearch.Rows.Add();
                dgvsearch.Rows[n].Cells[1].Value = dr["quoteno"].ToString();
                dgvsearch.Rows[n].Cells[2].Value = dr["status"].ToString();

            }
        }

        private void dgvforselectitems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvforselectitems.CurrentCell is DataGridViewLinkCell)
            {
                ProductInfoorNewProduct p = new ProductInfoorNewProduct();
                bal.Itemname = dgvforselectitems.CurrentRow.Cells["itemnameorcode"].Value.ToString();
                bal.Sno1 = Convert.ToInt32(dgvforselectitems.CurrentRow.Cells["productid"].Value.ToString());
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
                panelitem.Visible = false;
                p.btnOk.Visible = true;
                p.Show();
            }
        }
    }
}