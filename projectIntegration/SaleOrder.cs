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

namespace InventoryTools
{
    public partial class SaleOrderWith_shipping_details : Form
    {
        public SaleOrderWith_shipping_details()
        {
            InitializeComponent();
        }
       
        DAL dal = new DAL();
        BAL bal = new BAL();
        Customer c = new Customer();
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
      

        private void cboSaleCustmr_Click(object sender, EventArgs e)
        {

            pnlCustomr.Visible = true;

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

        private void btnSaleAdnew_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            int i=0;
            DataTable dt = dal.customer_names();
            foreach (DataRow d in dt.Rows)
            {
                if (d["customername"].ToString() == txtAddNew.Text)
                {
                    MessageBox.Show("CustomerName already exist");
                    i++;
                    break;
                }
            }
            if (i == 0)
            {
                c.txtcustomername.Text = txtAddNew.Text;

                c.Show();
                pnlCustomr.Visible = false;
            }
        }

        private void btnSaleSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSaleOrdr.Text != String.Empty && txtSaleFright.Text != String.Empty)
                {
                    bal.CustometId = txtSaleOrdr.Text;
                    bal.CustomerName = cboSaleCustmr.Text;
                    bal.Phone = txtSalePhn.Text;
                    bal.Contact = txtSaleCntct.Text;
                    bal.BillingAddress = txtSaleBillAdrs.Text;
                    bal.Terms = cboSaleTrms.Text;
                    bal.SalesRepr = cboSaleRep.Text;
                    bal.Location = cboSaleLocatn.Text;
                    bal.OrderNo = txtSaleOrdr.Text;
                    bal.OrderDate = Convert.ToDateTime(cboSaleDate.Text);
                    bal.InventoryStatus = cboInventryStatus.Text;
                    bal.PaymenStatus = cboPaymentStatus.Text;
                    bal.ShippingAddress = txtSaleShpngAdrs.Text;
                    bal.NonCustomer = cboSaleNonCustmr.Text;
                    bal.TaxingScheme = cboSaleTaxng.Text;
                    bal.Currency = cboSaleCurrency.Text;
                    bal.ShipDate = txtRegShpDate.Text;
                    bal.Remarks = txtSaleRemrks.Text;
                    bal.SubTotal = txtSaleSubTot.Text;
                    bal.Frieght = txtSaleFright.Text;
                    bal.Total = txtSaleTot.Text;
                    bal.Paid = txtSalePaid.Text;
                    bal.Balance = txtSaleBlnc.Text;
                    bal.StateTax = txtSatetax.Text;
                    bal.CityTax = txtCitytax.Text;
                    bal.Duedate = cboSaleDueDate.Text;
                    bal.Paying = txtPaying.Text;
                    for (int i = 0; i < dgvSaleItem.Rows.Count - 1; i++)
                    {
                        bal.Id = Convert.ToInt32(dgvSaleItem.Rows[i].Cells[1].Value);
                        bal.Itemname = dgvSaleItem.Rows[i].Cells[2].Value.ToString();
                        bal.Description = dgvSaleItem.Rows[i].Cells[3].Value.ToString();
                        bal.Quantity = dgvSaleItem.Rows[i].Cells[4].Value.ToString();
                        bal.Unitprice = dgvSaleItem.Rows[i].Cells[5].Value.ToString();
                        bal.Discount = dgvSaleItem.Rows[i].Cells[6].Value.ToString();
                        bal.SubTotal = dgvSaleItem.Rows[i].Cells[7].Value.ToString();
                        dal.orderitemInsert(bal);
                       
                        dal.select_qunatityinhand(bal);
                        bal.Quantityonhand = (Convert.ToInt32(bal.Quantityonhand) - Convert.ToInt32(bal.Quantity)).ToString();
                        dal.update_quantityonhand(bal);
                        bal.Type = "Sale Order";
                        bal.InventoryStatus = cboInventryStatus.Text + "," + cboPaymentStatus.Text;
                        dal.insert_orderhistory(bal);


                    }
                    bal.InventoryStatus = cboInventryStatus.Text;
                    dal.Insertorders(bal);

                  

                    MessageBox.Show("Details Saved Successfully");
                    SaleOrderWith_shipping_details sd = new SaleOrderWith_shipping_details();
                    sd.Show();
                    this.Dispose(false);
                }
                else
                {

                    MessageBox.Show("Please Enter Required Fileds");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Error While Saving Data");
            }
        
        }
        private void dgvSaleItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvitems.Columns.Clear();
                if (e.ColumnIndex == dgvSaleItem.CurrentRow.Cells[2].ColumnIndex)
                {
                    dgvitems.Visible = true;
                    this.pnlItems.Location = this.dgvSaleItem.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    int x = pnlItems.Location.X;
                    int y = pnlItems.Location.Y;
                    int nx = x + 0;
                    int ny = y + 170;
                    this.pnlItems.Location = new Point(nx, ny);
                    this.pnlItems.Visible = true;
                    pnlItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.pnlItems.BringToFront();
                    dgvitems.Visible = true;
                    this.pnlSrchPrdct.Location = this.dgvSaleItem.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                    int x1 = pnlItems.Location.X;
                    int y1 = pnlItems.Location.Y;
                    int nx1 = x1 + 245;
                    int ny1 = y1 + 265;
                    this.pnlSrchPrdct.Location = new Point(nx1, ny1);
                    pnlSrchPrdct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.pnlSrchPrdct.BringToFront();
                  
                    dgvitems.Refresh();
                    dgvitems.DataSource = dal.items();
                    dgvitems.Columns[0].Visible = false;
                    if (dgvitems.ColumnCount == 3)
                    {
                        DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                        dgvitems.Columns.Add(lnk);
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

        private void dgvitems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
            if (e.ColumnIndex == dgvitems.CurrentRow.Cells[1].ColumnIndex || e.ColumnIndex == dgvitems.CurrentRow.Cells[2].ColumnIndex)
            {
                dgvSaleItem.CurrentRow.Cells[1].Value = dgvitems.CurrentRow.Cells[0].Value;
                dgvSaleItem.CurrentRow.Cells[2].Value = dgvitems.CurrentRow.Cells["itemnameorcode"].Value;
                dgvSaleItem.CurrentRow.Cells[3].Value = dgvitems.CurrentRow.Cells["description"].Value;
                pnlItems.Visible = false;
            }
          
        }

        private void SaleOrderWith_shipping_details_Load(object sender, EventArgs e)
        {
            cboSaleDate.Text = Convert.ToString(DateTime.Now);
            panel3.BackColor = ColorTranslator.FromHtml("#d4f962");
            panel1.BackColor = ColorTranslator.FromHtml("#87cc02");
            DataTable dt = dal.autogenerate();
            foreach (DataRow d in dt.Rows)
            {
                txtSaleOrdr.Text = d["saleorderno"].ToString();
            }

            dgvOrder.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f4ffb6");
            dgvOrder.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e4fc81");
            dgvOrder.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#79bf00");
            dgvSaleItem.DefaultCellStyle.BackColor = Color.White;
            dgvSaleItem.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvSaleItem.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
     
         
            cboInventryStatus.Enabled = false;
            panel3.SendToBack();
            pnlSrchCust.BringToFront();
            cboSaleNonCustmr.SelectedItem = "0";
            panel2.BringToFront();
           
            cboSaleDate.DropDownHeight = 1;
            cboSaleRep.DropDownHeight = 1;
            cboSaleCustmr.DropDownHeight = 1;
            cboSaleCurrency.DropDownHeight = 1;
           dgvOrder.DataSource = dal.ordersNo();
       
        }


        private void cboSaleRep_Click(object sender, EventArgs e)
        {
            dgvSalesRepr.DataSource = dal.salesrepr();
            dgvSalesRepr.Visible = true;
            dgvSalesRepr.BringToFront();

        }

        private void dgvSalesRepr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboSaleRep.Text = dgvSalesRepr.CurrentRow.Cells[0].Value.ToString();
            dgvSalesRepr.Visible = false;
        }

        private void dtpSaleDate_ValueChanged(object sender, EventArgs e)
        {
            cboSaleDate.Text = dtpSaleDate.Value.ToShortDateString();
            dtpSaleDate.Visible = false;
        }

        private void cboSaleDate_Click(object sender, EventArgs e)
        {
            dtpSaleDate.Visible = true;
            dtpSaleDate.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void cboSaleTaxng_Click(object sender, EventArgs e)
        {
            dgvTaxing.DataSource = dal.taxing();
            pnlTaxngScheme.Visible = true;
            pnlTaxngScheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlTaxngScheme.BringToFront();
        }

        private void dgvTaxing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Decimal saletot = 0;
                try
            {

                bal.Taxname = dgvTaxing.CurrentRow.Cells[0].Value.ToString();
                bal.Taxonshipping = dgvTaxing.CurrentRow.Cells[0].Value.ToString();
                dal.select_statetax(bal);
                dal.select_citytax(bal);
               
               
              
              
                cboSaleTaxng.Text = dgvTaxing.CurrentRow.Cells[0].Value.ToString();
                int c = 0;
                if (bal.TaxingScheme == "True")
                {
                    txtSatetax.Visible = true;
                    lblStax.Visible = true;
                    txtSatetax.Text = (Convert.ToDecimal(txtSaleSubTot.Text) * Convert.ToDecimal(dgvTaxing.CurrentRow.Cells[1].Value) / 100).ToString();
                    saletot+= (Convert.ToDecimal(txtSaleSubTot.Text) + Convert.ToDecimal(txtSatetax.Text));
                    c++;
                }
                if (bal.Taxschemename == "True")
                {
                    lblCtax.Visible = true;
                    txtCitytax.Visible = true;
                    txtCitytax.Text = (Convert.ToDecimal(txtSaleSubTot.Text) * Convert.ToDecimal(dgvTaxing.CurrentRow.Cells[2].Value) / 100).ToString();
                    if (c == 0)
                    {
                        saletot += (Convert.ToDecimal(txtSaleSubTot.Text) + Convert.ToDecimal(txtCitytax.Text));
                    }
                    else
                    {
                        saletot += Convert.ToDecimal(txtCitytax.Text);
                    }
                        c++;
                }
                if (c != 0)
                {
                    txtSaleTot.Text = saletot.ToString();
                }
                else
                {
                    txtSaleTot.Text = txtSaleSubTot.Text;
                }
                        txtSaleBlnc.Text = txtSaleTot.Text;
                pnlTaxngScheme.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Invalid Input Please Enter Correct Values");
            }
        }

        private void cboSaleCurrency_Click(object sender, EventArgs e)
        {
            pnlPricing.Visible = true;
            pnlPricing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvPricing.DataSource = dal.pricing();
            pnlPricing.BringToFront();

        }

        private void txtRegShpDate_Click(object sender, EventArgs e)
        {
            dtpShipDate.Visible = true;
            dtpShipDate.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void dtpShipDate_ValueChanged(object sender, EventArgs e)
        {
            txtRegShpDate.Text = dtpShipDate.Value.ToShortDateString();
            dtpShipDate.Visible = false;
        }

        private void cboSaleDueDate_Click(object sender, EventArgs e)
        {
            dtpDuedate.Visible = true;
            dtpDuedate.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void dtpDuedate_ValueChanged(object sender, EventArgs e)
        {
            cboSaleDueDate.Text = dtpDuedate.Value.ToShortDateString();
            dtpDuedate.Visible = false;
        }

        private void dgvPricing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboSaleCurrency.Text = dgvPricing.CurrentRow.Cells[1].Value.ToString();
            pnlPricing.Visible = false;
        }

        Decimal subtot;
        private void dgvSaleItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvSaleItem.CurrentRow.Cells[4].ColumnIndex)
                {
                    int a;
                    bal.Sno1 = Convert.ToInt32(dgvSaleItem.CurrentRow.Cells[1].Value);
                    bal.Itemname = dgvSaleItem.CurrentRow.Cells[2].Value.ToString();
                    bal.OrderNo = txtSaleOrdr.Text;
                    dal.select_qunatityinhand(bal);
                    
                    a = Convert.ToInt32(bal.Quantityonhand);
               

                        if (a < Convert.ToInt32(dgvSaleItem.CurrentRow.Cells[4].Value))
                        {
                            MessageBox.Show("Sorry InSufficient Stock"+"\r\n"+"You Can Order till "+a);
                            dgvSaleItem.CurrentRow.Cells[4].Value = null;
                        }
                    

                }
  
                if (e.ColumnIndex == dgvSaleItem.CurrentRow.Cells[5].ColumnIndex)
                {
                    dgvSaleItem.CurrentRow.Cells[7].Value = (Convert.ToInt32(dgvSaleItem.CurrentRow.Cells[4].Value) * Convert.ToDecimal(dgvSaleItem.CurrentRow.Cells[5].Value)).ToString();
                }
                if (e.ColumnIndex == dgvSaleItem.CurrentRow.Cells[6].ColumnIndex)
                {
                    dgvSaleItem.CurrentRow.Cells[7].Value = Convert.ToDecimal(Convert.ToInt32(dgvSaleItem.CurrentRow.Cells[4].Value) * Convert.ToDecimal(dgvSaleItem.CurrentRow.Cells[5].Value)) - (Convert.ToDecimal(Convert.ToInt32(dgvSaleItem.CurrentRow.Cells[4].Value) * Convert.ToDecimal(dgvSaleItem.CurrentRow.Cells[5].Value)) * Convert.ToDecimal(dgvSaleItem.CurrentRow.Cells[6].Value)) / 100;
                    subtot += Convert.ToDecimal(dgvSaleItem.CurrentRow.Cells[7].Value.ToString());
                }
                txtSaleSubTot.Text = subtot.ToString();
             
                txtSaleBlnc.Text = txtSaleSubTot.Text;
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("please enter the details in the correct format");
            }
        }

        private void txtSaleFright_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSaleTot.Text = (Convert.ToDecimal(txtSaleTot.Text) + Convert.ToDecimal(txtSaleFright.Text)).ToString();
                txtSaleBlnc.Text = txtSaleTot.Text;
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("please enter the details in the correct format");
            }
        }

       

        private void cboSaleLocatn_Click(object sender, EventArgs e)
        {
            pnlLocation.Visible = true;
            pnlLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvLocation.DataSource = dal.location();

        }

        private void dgvLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboSaleLocatn.Text = dgvLocation.CurrentRow.Cells[0].Value.ToString();
            pnlLocation.Visible = false;
        }
       
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvSaleItem.Rows.Clear();
                dgvPickItem.Rows.Clear();
                dgvShpDetails.Rows.Clear();
                btnFullfill.Visible = true;
                btnPaid.Location = new Point(250,472);
                btnSaleSave.Visible = false;

                bal.OrderNo = dgvOrder.CurrentRow.Cells[0].Value.ToString();
                dal.select(bal);
                cboSaleCustmr.Text = bal.CustomerName;
                txtSaleCntct.Text = bal.Contact;
                txtSalePhn.Text = bal.Phone;
                txtSaleBillAdrs.Text = bal.BillingAddress;
                cboSaleTrms.Text = bal.Terms;
                cboSaleRep.Text = bal.SalesRepr;
                cboSaleLocatn.Text = bal.Location;
                txtSaleOrdr.Text = bal.OrderNo;
                cboSaleDate.Text = bal.OrderDate.ToString();
                cboInventryStatus.Text = bal.InventoryStatus;
                cboPaymentStatus.Text = bal.PaymenStatus;
                txtSaleShpngAdrs.Text = bal.ShippingAddress;
                if (bal.ShippingAddress != String.Empty)
                {
                    label17.Visible = false;
                    txtSaleShpngAdrs.Visible = false;
                    lnkAddShpng.Text = "Add Shipping";
                    
                }
               
                cboSaleNonCustmr.Text = bal.NonCustomer;
                cboSaleTaxng.Text = bal.TaxingScheme;
                cboSaleCurrency.Text = bal.Currency;
                txtRegShpDate.Text = bal.ShipDate;
                txtSaleRemrks.Text = bal.Remarks;
                txtSaleSubTot.Text = bal.SubTotal;
                txtSaleFright.Text = bal.Frieght;
                if (bal.StateTax != null)
                {
                    txtSatetax.Visible = true;
                    lblStax.Visible = true;
                    txtSatetax.Text = bal.StateTax;
                }
                else
                {
                    lblStax.Visible = false;
                    txtSatetax.Visible = false;
                }
                if (bal.CityTax != null)
                {
                    txtCitytax.Visible = true;
                    lblCtax.Visible = true;
                    txtCitytax.Text = bal.CityTax;
                }
                else
                {
                    txtCitytax.Visible = false;
                    lblCtax.Visible = false;
                }
                    txtSaleTot.Text = bal.Total;
                    if (bal.Paid == String.Empty)
                    {
                        txtSalePaid.Text = "0";
                    }
                    else
                    {
                        txtSalePaid.Text = bal.Paid;
                    }
                        txtSaleBlnc.Text = bal.Balance;
                cboSaleDueDate.Text = bal.Duedate;
             
                if (cboInventryStatus.Text == "Cancelled")
                {
                    DisableControls(this);
                    EnableControls(btnCancelOrder);
                    EnableControls(dgvOrder);
                    EnableControls(lblCancelledSale);
                    EnableControls(txtSrchOrder);
                    EnableControls(cboSrchInvenStatus);
                    EnableControls(cboSrchPayStatus);
                    EnableControls(cboSrchCustmr);
                    lblCancelledRestck.Visible = true;
                    lblCancelledSale.Visible = true;
                    lblCancldRetrn.Visible = true;
                    btnCancelOrder.Text = "Re-Open";
                }
                else
                {
                    Enable(this);
                    DisableControls(dgvSaleItem);
                    btnCancelOrder.Text = "Cancel Order";
                    lblCancelledSale.Visible = false;
                    lblCancldRetrn.Visible = false;
                    lblCancelledRestck.Visible = false;
                }

               
               
                DataTable dt = dal.select_items(bal);
                foreach (DataRow d in dt.Rows)
                {
                    int n = dgvSaleItem.Rows.Add();
                    dgvSaleItem.Rows[n].Cells[0].Value = d["sno"].ToString();
                    dgvSaleItem.Rows[n].Cells[1].Value = d["itemid"].ToString();
                    dgvSaleItem.Rows[n].Cells[2].Value = d["itemname"].ToString();
                    dgvSaleItem.Rows[n].Cells[3].Value = d["description"].ToString();
                    dgvSaleItem.Rows[n].Cells[4].Value = d["quantity"].ToString();
                    dgvSaleItem.Rows[n].Cells[5].Value = d["unitprice"].ToString();
                    dgvSaleItem.Rows[n].Cells[6].Value = d["discount"].ToString();
                    dgvSaleItem.Rows[n].Cells[7].Value = d["subtotal"].ToString();
                }
                if (cboInventryStatus.Text == "Fullfilled" || cboInventryStatus.Text == "Fullfilled&Returned")
                {
                    cboPickCustmr.Text = cboSaleCustmr.Text;
                    txtPickCntct.Text = txtSaleCntct.Text;
                    txtPickPhn.Text = txtSalePhn.Text;
                    txtPickBilAdrs.Text = txtSaleBillAdrs.Text;
                    cboPickTerms.Text = cboSaleTrms.Text;
                    cboPickSaleRep.Text = cboSaleRep.Text;
                    cboPickLocatn.Text = cboSaleLocatn.Text;
                    txtPickOrder.Text = txtSaleOrdr.Text;
                    cboPicakDate.Text = cboSaleDate.Text;
                    cboPickInven.Text = cboInventryStatus.Text;
                    cboPickPay.Text = cboPaymentStatus.Text;
                    txtPickShpngAdrs.Text = txtSaleShpngAdrs.Text;
                    txtPickRemrks.Text = txtSaleRemrks.Text;
                    for (int i = 0; i < dgvSaleItem.Rows.Count - 1; i++)
                    {
                        dgvPickItem.Rows.Add();
                        dgvPickItem.Rows[i].Cells[0].Value = dgvSaleItem.Rows[i].Cells[2].Value.ToString();
                        dgvPickItem.Rows[i].Cells[1].Value = dgvSaleItem.Rows[i].Cells[4].Value.ToString();
                        dgvPickItem.Rows[i].Cells[2].Value = cboSaleLocatn.Text;

                    }
                    cboShipCustmr.Text = cboSaleCustmr.Text;
                    txtShpCntct.Text = txtSaleCntct.Text;
                    txtShipPhn.Text = txtSalePhn.Text;
                    txtShpBillngAdrs.Text = txtSaleBillAdrs.Text;
                    cboShpTrms.Text = cboSaleTrms.Text;
                    cboShpSalesrep.Text = cboSaleRep.Text;
                    cboShpLoc.Text = cboSaleLocatn.Text;
                    txtShpOrdr.Text = txtSaleOrdr.Text;
                    cboShpDate.Text = cboSaleDate.Text;
                    cboShpInven.Text = cboInventryStatus.Text;
                    cboShpPay.Text = cboPaymentStatus.Text;
                    txtShpShpng.Text = txtSaleShpngAdrs.Text;
                    txtShpRemarks.Text = txtSaleRemrks.Text;
                    for (int i = 0; i < dgvSaleItem.Rows.Count - 1; i++)
                    {
                        dgvShpDetails.Rows.Add();
                        dgvShpDetails.Rows[i].Cells[0].Value = dgvSaleItem.Rows[i].Cells[2].Value.ToString();
                        dgvShpDetails.Rows[i].Cells[1].Value = dgvSaleItem.Rows[i].Cells[4].Value.ToString();
                        dgvShpDetails.Rows[i].Cells[2].Value = true;

                    }
                    btnFullfill.Text = "UnFullfill";
                    lblFulfilled.Visible = true;
                    lblPickFulfill.Visible = true;
                    lblShpFullfill.Visible = true;
                }
                else
                {
                    dgvShpDetails.Rows.Clear();
                    dgvPickItem.Rows.Clear();
                    btnFullfill.Text = "Fullfill";
                    lblFulfilled.Visible = false;
                    lblPickFulfill.Visible = false;
                    lblShpFullfill.Visible = false;
                }
                dgvRetrnItem.Rows.Clear();
                cboRetrnCustmr.Text = cboSaleCustmr.Text;
                txtRetrnCntct.Text = txtSaleCntct.Text;
                txtRetrnPhn.Text = txtSalePhn.Text;
                txtRetrnBilAdrs.Text = txtSaleBillAdrs.Text;
                cboRetrnTerms.Text = cboSaleTrms.Text;
                cboRetrnSaleRep.Text = cboSaleRep.Text;
                cboRetrnLocatn.Text = cboSaleLocatn.Text;
                txtRetrnOrder.Text = txtSaleOrdr.Text;
                cboRetrnDate.Text = cboSaleDate.Text;
                cboretrnInvnstus.Text = cboInventryStatus.Text;
                cboretrnpaystus.Text = cboPaymentStatus.Text;
                cboRestckInvenStuts.Text = cboInventryStatus.Text;
                cboRstckPayStutus.Text = cboPaymentStatus.Text;
                txtRetrnShpAdrs.Text = txtSaleShpngAdrs.Text;
                txtRetrnSubTot.Text = txtSaleSubTot.Text;
                txtRetrnFright.Text = txtSaleFright.Text;
                txtRetrnTot.Text = txtSaleTot.Text;
                bal.OrderNo = txtRetrnOrder.Text;
                if (cboInventryStatus.SelectedItem.ToString() == "Fullfilled&Returned" || cboInventryStatus.SelectedItem.ToString() == "UnFullfilled&Returned")
                {
                    DataTable dt1 = dal.select_return(bal);
                    foreach (DataRow d in dt1.Rows)
                    {
                        int n = dgvRetrnItem.Rows.Add();
                        dgvRetrnItem.Rows[n].Cells[0].Value = d["itemname"].ToString();
                        dgvRetrnItem.Rows[n].Cells[1].Value = d["quantity"].ToString();
                        dgvRetrnItem.Rows[n].Cells[2].Value = d["returndate"].ToString();
                        if (d["discarded"].ToString() == "Accepted")
                        {
                            dgvRetrnItem.Rows[n].Cells[3].Value = true;
                        }
                        else
                        {

                            dgvRetrnItem.Rows[n].Cells[3].Value = false;
                        }
                        dgvRetrnItem.Rows[n].Cells[4].Value = d["unitprice"].ToString();
                        dgvRetrnItem.Rows[n].Cells[5].Value = d["discount"].ToString();
                        dgvRetrnItem.Rows[n].Cells[6].Value = d["subtotal"].ToString();
                        dgvRetrnItem.Rows[n].Cells[7].Value = d["sno"].ToString();
                        dgvRetrnItem.Rows[n].Cells[8].Value=d["itemid"].ToString();
                        txtRetrnRemarks.Text = d["remarks"].ToString();



                    }


                }
                if (dgvRetrnItem.Rows.Count == 0)
                {  
                    if (cboInventryStatus.SelectedItem.ToString() == "Fullfilled&Returned")
                    {
                        cboInventryStatus.Text = "Fullfilled";
                        cboretrnInvnstus.Text = cboretrnInvnstus.Text;
                        cboRestckInvenStuts.Text = cboInventryStatus.Text;
                    }
                    if (cboInventryStatus.SelectedItem.ToString() == "UnFullfilled&Returned")
                    {
                        cboInventryStatus.SelectedItem = "UnFullfilled";
                        cboretrnInvnstus.Text = cboretrnInvnstus.Text;
                        cboRestckInvenStuts.Text = cboInventryStatus.Text;
                    }
                }
                int j = 0;
                DataTable dt2 = dal.select_orderno_restck();
                dgvRestckItem.Rows.Clear();
                foreach (DataRow d1 in dt2.Rows)
                {

                    if (txtSaleOrdr.Text == d1["orderno"].ToString())
                    {

                        dgvRestckItem.AllowUserToAddRows = true;
                        dgvRestckItem.Rows.Clear();
                        cboRestckCustmr.Text = cboSaleCustmr.Text;
                        txt.Text = txtSaleCntct.Text;
                        txtRestckPhn.Text = txtSalePhn.Text;
                        txtRestckBillAdrs.Text = txtSaleBillAdrs.Text;
                        cboRestckTerms.Text = cboSaleTrms.Text;
                        cboRestckSaleRep.Text = cboSaleRep.Text;
                        cboRestckLoc.Text = cboSaleLocatn.Text;
                        txtRestckOrder.Text = txtSaleOrdr.Text;
                        cboRestckDate.Text = cboSaleDate.Text;

                        txtRestckShpAdrs.Text = txtSaleShpngAdrs.Text;
                        txtRetrnSubTot.Text = txtSaleSubTot.Text;
                        bal.OrderNo = txtRestckOrder.Text;
                        DataTable dt3 = dal.select_restck(bal);
                        foreach (DataRow d in dt3.Rows)
                        {
                            int i = dgvRestckItem.Rows.Add();

                            dgvRestckItem.Rows[i].Cells[0].Value = d["itemname"].ToString();
                            dgvRestckItem.Rows[i].Cells[1].Value = d["description"].ToString();
                            dgvRestckItem.Rows[i].Cells[2].Value = d["quantity"].ToString();
                            dgvRestckItem.Rows[i].Cells[3].Value = d["restockdate"].ToString();
                            dgvRestckItem.Rows[i].Cells[4].Value = d["location"].ToString();
                            dgvRestckItem.Rows[i].Cells[5].Value = d["sno"].ToString();
                            txtRestckRemarks.Text = d["remarks"].ToString();

                        }
                        j++;
                        break;

                    }
                }

                    if(j==0)
                    {
                        dgvRestckItem.AllowUserToAddRows = false;
                        dgvRestckItem.Rows.Clear();
                        txtRestckRemarks.Text = String.Empty;
                        cboRestckCustmr.Text = cboSaleCustmr.Text;
                        txt.Text = txtSaleCntct.Text;
                        txtRestckPhn.Text = txtSalePhn.Text;
                        txtRestckBillAdrs.Text = txtSaleBillAdrs.Text;
                        cboRestckTerms.Text = cboSaleTrms.Text;
                        cboRestckSaleRep.Text = cboSaleRep.Text;
                        cboRestckLoc.Text = cboSaleLocatn.Text;
                        txtRestckOrder.Text = txtSaleOrdr.Text;
                        cboRestckDate.Text = cboSaleDate.Text;

                        txtRestckShpAdrs.Text = txtSaleShpngAdrs.Text;
                        txtRetrnSubTot.Text = txtSaleSubTot.Text;
                        j = 0;
                    }
                
               
                this.Hide();
                this.Show();
            }






            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Error While Getting Data");
            }
        }

        private void btnFullfill_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnFullfill.Text == "Fullfill")
                {
                    cboPickCustmr.Text = cboSaleCustmr.Text;
                    txtPickCntct.Text = txtSaleCntct.Text;
                    txtPickPhn.Text = txtSalePhn.Text;
                    txtPickBilAdrs.Text = txtSaleBillAdrs.Text;
                    cboPickTerms.Text = cboSaleTrms.Text;
                    cboRestckSaleRep.Text = cboSaleRep.Text;
                    cboPickLocatn.Text = cboSaleLocatn.Text;
                    txtPickOrder.Text = txtSaleOrdr.Text;
                    cboPicakDate.Text = cboSaleDate.Text;
                    cboPickInven.Text = cboInventryStatus.Text;
                    cboPickPay.Text = cboPaymentStatus.Text;
                    txtPickShpngAdrs.Text = txtSaleShpngAdrs.Text;
                    txtPickRemrks.Text = txtSaleRemrks.Text;
                    bal.OrderNo = txtSaleOrdr.Text;
                    bal.Location = cboSaleLocatn.Text;
                    bal.OrderDate = Convert.ToDateTime(cboSaleDate.Text);
                    for (int i = 0; i < dgvSaleItem.Rows.Count - 1; i++)
                    {
                        dgvPickItem.Rows.Add();
                        bal.Sno1 = Convert.ToInt32(dgvSaleItem.Rows[i].Cells[1].Value);
                        dgvPickItem.Rows[i].Cells[0].Value = dgvSaleItem.Rows[i].Cells[2].Value.ToString();
                        bal.Itemname = dgvSaleItem.Rows[i].Cells[2].Value.ToString();
                        bal.Description = dgvSaleItem.Rows[i].Cells[3].Value.ToString();
                        dgvPickItem.Rows[i].Cells[1].Value = dgvSaleItem.Rows[i].Cells[4].Value.ToString();
                        bal.Quantity = dgvSaleItem.Rows[i].Cells[4].Value.ToString();
                        dal.select_qunatityinhand(bal);
                        bal.Quantityonhand = (Convert.ToInt32(bal.Quantityonhand) + Convert.ToInt32(bal.Quantity)).ToString();
                        bal.Quantityafter = (Convert.ToInt32(bal.Quantityonhand) - Convert.ToInt32(bal.Quantity)).ToString();
                        dgvPickItem.Rows[i].Cells[2].Value = cboSaleLocatn.Text;
                        bal.Trans = "Sales Order Picking";
                        dal.insert_movementhistory(bal);


                    }
                    cboShipCustmr.Text = cboSaleCustmr.Text;
                    txtShpCntct.Text = txtSaleCntct.Text;
                    txtShipPhn.Text = txtSalePhn.Text;
                    txtShpBillngAdrs.Text = txtSaleBillAdrs.Text;
                    cboShpTrms.Text = cboSaleTrms.Text;
                    cboShpSalesrep.Text = cboSaleRep.Text;
                    cboShpLoc.Text = cboSaleLocatn.Text;
                    txtShpOrdr.Text = txtSaleOrdr.Text;
                    cboShpDate.Text = cboSaleDate.Text;
                    cboShpInven.Text = cboInventryStatus.Text;
                    cboShpPay.Text = cboPaymentStatus.Text;
                    txtShpShpng.Text = txtSaleShpngAdrs.Text;
                    txtShpRemarks.Text = txtSaleRemrks.Text;
                    for (int i = 0; i < dgvSaleItem.Rows.Count - 1; i++)
                    {
                        dgvShpDetails.Rows.Add();
                        dgvShpDetails.Rows[i].Cells[0].Value = dgvSaleItem.Rows[i].Cells[2].Value.ToString();
                        dgvShpDetails.Rows[i].Cells[1].Value = dgvSaleItem.Rows[i].Cells[4].Value.ToString();
                        dgvShpDetails.Rows[i].Cells[2].Value = true;

                    }

                    if (cboInventryStatus.SelectedItem.ToString() == "UnFullfilled&Returned")
                    {
                        cboInventryStatus.SelectedItem = "Fullfilled&Returned";
                    }
                    else
                    {
                        cboInventryStatus.SelectedItem = "Fullfilled";
                    }
                    btnFullfill.Text = "UnFullfill";
                    lblFulfilled.Visible = true;
                    lblPickFulfill.Visible = true;
                    lblShpFullfill.Visible = true;
                    dgvSaleItem.AllowUserToAddRows = false;

                   




                }
                else if (btnFullfill.Text == "UnFullfill")
                {
                    dgvShpDetails.Rows.Clear();
                    dgvPickItem.Rows.Clear();
                    if (cboInventryStatus.SelectedItem.ToString() == "Fullfilled&Returned")
                    {
                        cboInventryStatus.SelectedItem = "UnFullfilled&Returned";
                    }
                    else
                    {
                        cboInventryStatus.SelectedItem = "UnFullfilled";
                    }

                    btnFullfill.Text = "Fullfill";
                    lblFulfilled.Visible = false;
                    dgvSaleItem.AllowUserToAddRows = true;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show(" We Can't Fullfill it");
            }


        }

        private void cboInvoice_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void btnRetrrnAFill_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dal.select_items(bal);
                foreach (DataRow d in dt.Rows)
                {
                    int n = dgvRetrnItem.Rows.Add();
                    dgvRetrnItem.Rows[n].Cells[0].Value = d["itemname"].ToString();
                   dgvRetrnItem.Rows[n].Cells[1].Value = d["quantity"].ToString();
                    dgvRetrnItem.Rows[n].Cells[2].Value = DateTime.Now;
                    dgvRetrnItem.Rows[n].Cells[4].Value = d["unitprice"].ToString();
                    dgvRetrnItem.Rows[n].Cells[5].Value = d["discount"].ToString();
                    dgvRetrnItem.Rows[n].Cells[6].Value = d["subtotal"].ToString();
                    dgvRetrnItem.Rows[n].Cells[8].Value = d["itemid"].ToString();

                }
                for(int i=0;i<dgvRetrnItem.Rows.Count;i++)
                {
                    bal.Type = "Sales Return";
                    bal.OrderNo = txtRetrnOrder.Text;
                    bal.CustomerName = cboRetrnCustmr.Text;
                    bal.OrderDate = Convert.ToDateTime(cboSaleDate.Text);
                    bal.InventoryStatus = cboInventryStatus.Text + "&" + cboPaymentStatus.Text;
                    bal.Itemname = dgvRetrnItem.Rows[i].Cells[0].Value.ToString();
                    bal.Quantity = dgvRetrnItem.Rows[i].Cells[1].Value.ToString();
                    bal.SubTotal = dgvRetrnItem.Rows[i].Cells[6].Value.ToString();
                    bal.Id=Convert.ToInt32(dgvRetrnItem.Rows[i].Cells[8].Value.ToString());
                    dal.insert_orderhistory(bal);
                    dgvRetrnItem.Rows[i].Cells[1].Value = null;

                }



                if (cboInventryStatus.Text == "UnFullfilled")
                {
                    cboretrnInvnstus.Text = "UnFullfilled&Returned";
                }
                else
                    if (cboInventryStatus.Text == "Fullfilled")
                {
                    cboretrnInvnstus.Text = "Fullfilled&Returned";
                } 
                
                MessageBox.Show("Plese Enter Quantity to Return");
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show(" We Can't Fullfill it");
            }
        }

       

      

        private void cboSrchInvenStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvOrder.DataSource = null;
                bal.InventoryStatus = cboSrchInvenStatus.Text;
                dgvOrder.DataSource= dal.inven_select(bal);
             
                cboSrchCustmr.Text = String.Empty;
                cboSrchPayStatus.Text = String.Empty;
                txtSrchOrder.Text = String.Empty;
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Cann't Perform this Operation");
            }
        }


        private void cboSrchPayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvOrder.DataSource = null;
                bal.PaymenStatus = cboSrchPayStatus.Text;
                dgvOrder.DataSource= dal.payment_select(bal);
            
                cboSrchCustmr.Text = String.Empty;
                cboSrchInvenStatus.Text = String.Empty;
                txtSrchOrder.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Cann't Perform this Operation");
            }
        }

        private void txtSrchOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cboSrchCustmr.Text = string.Empty;
                cboSrchInvenStatus.Text = String.Empty;
                cboSrchPayStatus.Text = string.Empty;
                dgvOrder.DataSource = null;
                bal.OrderNo = txtSrchOrder.Text;
                dgvOrder.DataSource= dal.orderno(bal);
            
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Cann't Perform this Operation");
            }
        }
        int count = 0;
        int count1 = 0;

        private void btnSaleOrdrSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                bal.CustometId = txtSaleOrdr.Text;
                bal.CustomerName = cboSaleCustmr.Text;
                bal.Phone = txtSalePhn.Text;
                bal.Contact = txtSaleCntct.Text;
                bal.BillingAddress = txtSaleBillAdrs.Text;
                bal.Terms = cboSaleTrms.Text;
                bal.SalesRepr = cboSaleRep.Text;
                bal.Location = cboSaleLocatn.Text;
                bal.OrderNo = txtSaleOrdr.Text;
                bal.OrderDate = Convert.ToDateTime(cboSaleDate.Text);
                bal.InventoryStatus = cboInventryStatus.SelectedItem.ToString();
                bal.PaymenStatus = cboPaymentStatus.Text;
                bal.ShippingAddress = txtSaleShpngAdrs.Text;
              


                bal.NonCustomer = cboSaleNonCustmr.Text;
                bal.TaxingScheme = cboSaleTaxng.Text;
                bal.Currency = cboSaleCurrency.Text;
                bal.ShipDate = txtRegShpDate.Text;
                bal.Remarks = txtSaleRemrks.Text;
                bal.SubTotal = txtSaleSubTot.Text;
                bal.Frieght = txtSaleFright.Text;
                bal.Total = txtSaleTot.Text;
                bal.Paid = txtSalePaid.Text;
                bal.Balance = txtSaleBlnc.Text;
                bal.Duedate = cboSaleDueDate.Text;
                bal.Paying = txtPaying.Text;
                bal.StateTax = txtSatetax.Text;
                bal.CityTax = txtCitytax.Text;





                dal.update_orders(bal);
                if (dgvRetrnItem.Rows.Count != 0)
                {
                    DataTable dt1 = dal.select_orderno_return();
                    foreach (DataRow d in dt1.Rows)
                    {
                        if (txtRetrnOrder.Text == d["orderno"].ToString())
                        {
                           
                            bal.CustometId = txtRetrnOrder.Text;
                            bal.CustomerName = cboRetrnCustmr.Text;
                            bal.OrderNo = txtRetrnOrder.Text;
                            bal.Description = txtRetrnRemarks.Text;
                            bal.Remarks = txtRetrnRemarks.Text;
                            bal.Total = txtRetrnTot.Text;
                            bal.StateTax = txtSatetax.Text;
                            bal.CityTax = txtCitytax.Text;
                            bal.Fee = txtSalePaid.Text;
                            for (int i = 0; i <= dgvRetrnItem.Rows.Count - 1; i++)
                            {
                                bal.Sno1 = Convert.ToInt32(dgvRetrnItem.Rows[i].Cells[7].Value);
                                bal.Itemname = dgvRetrnItem.Rows[i].Cells[0].Value.ToString();
                                bal.Quantity = dgvRetrnItem.Rows[i].Cells[1].Value.ToString();
                                bal.Retrndate = dgvRetrnItem.Rows[i].Cells[2].Value.ToString();

                                var cbx = (DataGridViewCheckBoxCell)dgvRetrnItem.Rows[i].Cells[3];
                                if (cbx.Value != null && (bool)cbx.Value)
                                {

                                    bal.Discarded = "Accepted";
                                }
                                else
                                {
                                    bal.Discarded = "Rejected";
                                }

                                bal.Unitprice = dgvRetrnItem.Rows[i].Cells[4].Value.ToString();
                                bal.Discount = dgvRetrnItem.Rows[i].Cells[5].Value.ToString();
                                bal.SubTotal = dgvRetrnItem.Rows[i].Cells[6].Value.ToString();
                                bal.Id=Convert.ToInt32(dgvRetrnItem.Rows[i].Cells[8].Value.ToString());
                              
                                    dal.update_returns(bal);
                               
                            } 
                                count1++;
                            break;
                        }
                    }
                    if (count1 == 0)
                    {
                        bal.CustometId = txtRetrnOrder.Text;
                        bal.CustomerName = cboRetrnCustmr.Text;
                        bal.OrderNo = txtRetrnOrder.Text;
                        bal.Description = txtRetrnRemarks.Text;
                        bal.Remarks = txtRetrnRemarks.Text;
                        bal.Total = txtRetrnTot.Text;
                        bal.StateTax = txtSatetax.Text;
                        bal.CityTax = txtCitytax.Text;
                        bal.Fee = txtSalePaid.Text;
                        for (int i = 0; i <= dgvRetrnItem.Rows.Count - 1; i++)
                        {
                            bal.Itemname = dgvRetrnItem.Rows[i].Cells[0].Value.ToString();
                            bal.Quantity = dgvRetrnItem.Rows[i].Cells[1].Value.ToString();
                            bal.Retrndate = dgvRetrnItem.Rows[i].Cells[2].Value.ToString();

                            var cbx = (DataGridViewCheckBoxCell)dgvRetrnItem.Rows[i].Cells[3];
                            if (cbx.Value != null && (bool)cbx.Value)
                            {

                                bal.Discarded = "Accepted";
                            }
                            else
                            {
                                bal.Discarded = "Rejected";
                            }

                            bal.Unitprice = dgvRetrnItem.Rows[i].Cells[4].Value.ToString();
                            bal.Discount = dgvRetrnItem.Rows[i].Cells[5].Value.ToString();
                            bal.SubTotal = dgvRetrnItem.Rows[i].Cells[6].Value.ToString();
                            bal.Id = Convert.ToInt32(dgvRetrnItem.Rows[i].Cells[8].Value.ToString());

                            dal.insert_returned(bal);
                        }
                       
                        if (lblFulfilled.Visible == true)
                        {
                            cboInventryStatus.Text = "Fullfilled&Returned";
                        }
                        else
                        {
                            cboInventryStatus.Text = "UnFullfilled&Returned";
                        }
                        bal.InventoryStatus = cboInventryStatus.Text;
                        dal.update_orders(bal);



                    }
                    count1 = 0;

                   


                }
                if (dgvRestckItem.Rows.Count != 0)
                {
                    DataTable dt = dal.select_orderno_restck();
                    foreach (DataRow d1 in dt.Rows)
                    {
                        if (txtRestckOrder.Text == d1["orderno"].ToString())
                        {
                            bal.CustometId = txtRestckOrder.Text;
                            bal.CustomerName = cboRestckCustmr.Text;
                            bal.Remarks = txtRestckRemarks.Text;
                            bal.OrderNo = txtRestckOrder.Text;
                            for (int i = 0; i < dgvRestckItem.Rows.Count - 1; i++)
                            {
                                bal.Id = Convert.ToInt32(dgvRestckItem.Rows[i].Cells[5].Value.ToString());
                                bal.Itemname = dgvRestckItem.Rows[i].Cells[0].Value.ToString();
                                bal.Description = dgvRestckItem.Rows[i].Cells[1].Value.ToString();
                                bal.Quantity = dgvRestckItem.Rows[i].Cells[2].Value.ToString();
                                bal.RestockDate = dgvRestckItem.Rows[i].Cells[3].Value.ToString();
                                bal.Location = dgvRestckItem.Rows[i].Cells[4].Value.ToString();
                                dal.update_restck(bal);
                            }
                            count++;
                            break;
                        }
                    }
                    if (count == 0)
                    {
                        bal.CustometId = txtRestckOrder.Text;
                        bal.CustomerName = cboRestckCustmr.Text;
                        bal.Remarks = txtRestckRemarks.Text;
                        bal.OrderNo = txtRestckOrder.Text;
                        for (int i = 0; i < dgvRestckItem.Rows.Count - 1; i++)
                        {
                            
                            bal.Itemname = dgvRestckItem.Rows[i].Cells[0].Value.ToString();
                            bal.Description = dgvRestckItem.Rows[i].Cells[1].Value.ToString();
                            bal.Quantity = dgvRestckItem.Rows[i].Cells[2].Value.ToString();
                            bal.RestockDate = dgvRestckItem.Rows[i].Cells[3].Value.ToString();
                            bal.Location = dgvRestckItem.Rows[i].Cells[4].Value.ToString();
                            dal.insert_restck(bal);
                        }

                    }
                    count = 0;
                }
                if (dgvRetrnItem.Rows.Count != 0)
                {
                    bal.OrderNo = txtSaleOrdr.Text;
                    DataTable dts = dal.select_return(bal);
                    for (int i = 0; i < dts.Rows.Count - 1; i++)
                    {
                        bal.Id = Convert.ToInt32(dgvRetrnItem.Rows[i].Cells[8].Value.ToString());
                        BAL.Status = cboInventryStatus.Text + "," + cboPaymentStatus.Text;
                        bal.Quantity = dgvRetrnItem.Rows[i].Cells[1].Value.ToString();
                        dal.update_orderhistory(bal);
                    }
                }








                MessageBox.Show("Data Saved Successfully");
                SaleOrderWith_shipping_details sd = new SaleOrderWith_shipping_details();
                sd.Show();
                this.Dispose(false);


            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("please check the details once");
            }


        }

        private void btnRestckAFill_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRestckItem.AllowUserToAddRows = true;
                dgvRestckItem.Rows.Clear();
                cboRestckCustmr.Text = cboSaleCustmr.Text;
                txt.Text = txtSaleCntct.Text;
                txtRestckPhn.Text = txtSalePhn.Text;
                txtRestckBillAdrs.Text = txtSaleBillAdrs.Text;
                cboRestckTerms.Text = cboSaleTrms.Text;
                cboRestckSaleRep.Text = cboSaleRep.Text;
                cboRestckLoc.Text = cboSaleLocatn.Text;
                txtRestckOrder.Text = txtSaleOrdr.Text;
                cboRestckDate.Text = cboSaleDate.Text;
                cboRestckInvenStuts.Text = cboretrnInvnstus.Text;
                cboRstckPayStutus.Text = cboretrnpaystus.Text;
                txtRestckShpAdrs.Text = txtSaleShpngAdrs.Text;
                txtRetrnSubTot.Text = txtSaleSubTot.Text;
                bal.OrderNo = txtRestckOrder.Text;
                for(int i=0;i<dgvSaleItem.Rows.Count-1;i++)
                {
                    String a;
                    dgvRestckItem.Rows.Add();
                    dgvRestckItem.Rows[i].Cells[0].Value = dgvSaleItem.Rows[i].Cells[2].Value;
                    dgvRestckItem.Rows[i].Cells[1].Value = dgvSaleItem.Rows[i].Cells[3].Value;
                    dgvRestckItem.Rows[i].Cells[2].Value =dgvSaleItem.Rows[i].Cells[4].Value;
                    dgvRestckItem.Rows[i].Cells[3].Value = DateTime.Now;
                    dgvRestckItem.Rows[i].Cells[4].Value = cboSaleLocatn.Text;
                    dgvRestckItem.Rows[i].Cells[6].Value = dgvSaleItem.Rows[i].Cells[1].Value;
                    bal.Itemname = dgvRestckItem.Rows[i].Cells[0].Value.ToString();
                    bal.Description = dgvRestckItem.Rows[i].Cells[1].Value.ToString();
                    bal.Trans = "Sales Order Restock";
                    bal.OrderDate = Convert.ToDateTime(cboSaleDate.Text);
                    bal.Location = cboSaleLocatn.Text;
                    bal.OrderNo = txtRestckOrder.Text;
                    bal.Sno1 = Convert.ToInt32(dgvRestckItem.Rows[i].Cells[6].Value);
                    bal.Itemname = dgvRestckItem.Rows[i].Cells[0].Value.ToString();
                    dal.select_qunatityinhand(bal);
                    a = bal.Quantityonhand;
                    bal.Quantity=dgvRestckItem.Rows[i].Cells[2].Value.ToString();
                    bal.Quantityonhand = (Convert.ToInt32(bal.Quantityonhand).ToString());
                    bal.Quantityafter = (Convert.ToInt32(bal.Quantityonhand) + Convert.ToInt32(bal.Quantity)).ToString();
                    dal.insert_movementhistory(bal);
                   
                 //   dal.update_quantityonhand(bal);

                  
                }
                        //DataTable dt2 = dal.select_restck(bal);
                //foreach (DataRow d in dt2.Rows)
                //{
                //    int i = dgvRestckItem.Rows.Add();
                //    dgvRestckItem.Rows[i].Cells[0].Value = d["itemname"].ToString();
                //    dgvRestckItem.Rows[i].Cells[1].Value = d["quantity"].ToString();
                //    dgvRestckItem.Rows[i].Cells[2].Value = d["restockdate"].ToString();
                //    dgvRestckItem.Rows[i].Cells[3].Value = d["location"].ToString();

                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show(" We Can't Fullfill it");
            }
        }

        private void dgvRestckItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvRestckItem.CurrentRow.Cells[0].ColumnIndex)
            {
                dgvRestckItems.Visible = true;
                dgvRestckItem.Controls.Add(dgvRestckItems);
                Rectangle dgvRec = dgvRestckItem.GetCellDisplayRectangle(e.ColumnIndex + 1, e.RowIndex - 1, true);
                dgvRestckItems.Location = new Point(dgvRec.X, dgvRec.Y + 20);

                dgvRestckItems.DataSource = dal.items();
                dgvRestckItems.Columns[0].Visible = false;

            }
        }

        private void dgvRestckItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRestckItem.CurrentRow.Cells[6].Value = dgvRestckItems.CurrentRow.Cells[0].Value;
            dgvRestckItem.CurrentRow.Cells[0].Value = dgvRestckItems.CurrentRow.Cells[1].Value;
            dgvRestckItem.CurrentRow.Cells[1].Value = dgvRestckItems.CurrentRow.Cells[2].Value;
            dgvRestckItems.Hide();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnCancelOrder.Text == "Cancel Order")
                {
                    DisableControls(this);
                    EnableControls(btnCancelOrder);
                    EnableControls(btnSaleOrdrSave);

                    EnableControls(dgvOrder);
                    EnableControls(txtSrchOrder);
                    EnableControls(cboSrchInvenStatus);
                    EnableControls(cboSrchPayStatus);
                    EnableControls(cboSrchCustmr);

                    cboInventryStatus.Text = "Cancelled";
                    cboretrnInvnstus.Text = "Cancelled";
                    cboRestckInvenStuts.Text = "Cancelled";
                    cboPaymentStatus.Text = "Cancelled";
                    cboretrnpaystus.Text = "Cancelled";
                    bal.InventoryStatus = cboInventryStatus.Text;
                    bal.OrderNo = txtSaleOrdr.Text;
                    dal.update_status(bal);
                    lblCancelledRestck.Visible = true;
                    lblCancelledSale.Visible = true;
                    lblCancldRetrn.Visible = true;

                    btnCancelOrder.Text = "Re-Open";
                }
                else
                {
                    Enable(this);
                    DataTable dt1 = dal.select_orderno_return();
                    if (dt1.Rows.Count == 0)
                    {

                        if (lblFulfilled.Visible == true)
                        {
                            cboInventryStatus.Text = "Fullfilled";
                            btnFullfill.Text = "UnFullfill";
                        }
                        else
                        {
                            cboInventryStatus.Text = "UnFullfilled";
                            btnFullfill.Text = "Fullfill";
                        }
                        if (txtSalePaid.Text != String.Empty)
                        {
                            if (decimal.Floor(Convert.ToDecimal(txtSaleTot.Text)) == decimal.Floor(Convert.ToDecimal(txtSalePaid.Text)))
                            {
                                cboPaymentStatus.Text = "Paid";
                            }
                            else if (decimal.Floor(Convert.ToDecimal(txtSalePaid.Text)) < (decimal.Floor(Convert.ToDecimal(txtSaleTot.Text)) / 2))
                            {
                                cboPaymentStatus.Text = "Unpaid";
                            }
                            else if (decimal.Floor(Convert.ToDecimal(txtSalePaid.Text)) >= (decimal.Floor(Convert.ToDecimal(txtSaleTot.Text)) / 2))
                            {
                                cboPaymentStatus.Text = "Partial";
                            }
                        }
                        else
                        {
                            cboPaymentStatus.Text = "Unpaid";
                        }
                       
                        bal.InventoryStatus = cboInventryStatus.Text;
                        bal.OrderNo = txtSaleOrdr.Text;
                        dal.update_status(bal);
                        lblCancelledRestck.Visible = false;
                        lblCancelledSale.Visible = false;
                        lblCancldRetrn.Visible = false;
                        btnCancelOrder.Text = "Cancel Order";
                    }
                    else
                    {
                        int count2 = 0;
                        foreach (DataRow d in dt1.Rows)
                        {
                            if (txtSaleOrdr.Text == d["orderno"].ToString())
                            {
                                if (lblFulfilled.Visible == true)
                                {
                                    cboInventryStatus.Text = "Fullfilled&Returned";

                                    cboretrnInvnstus.Text = "Fullfilled&Returned";
                                    cboRestckInvenStuts.Text = "Fullfilled&Returned";
                                    btnFullfill.Text = "UnFullfill";
                                }
                                else
                                {
                                    cboInventryStatus.Text = "UnFullfilled&Returned";

                                    cboretrnInvnstus.Text = "UnFullfilled&Returned";
                                    cboRestckInvenStuts.Text = "UnFullfilled&Returned";
                                    btnFullfill.Text = "Fullfill";
                                }
                                     cboPaymentStatus.Text = "UnPaid";
                                bal.InventoryStatus = cboInventryStatus.Text;
                                bal.OrderNo = txtSaleOrdr.Text;
                                dal.update_status(bal);
                                lblCancelledRestck.Visible = false;
                                lblCancelledSale.Visible = false;
                                lblCancldRetrn.Visible = false;
                                btnCancelOrder.Text = "Cancel Order";
                                count2++;
                                break;
                            }
                        }
                        if (count2 == 0)
                        {
                            cboInventryStatus.Text = "UnFullfilled";
                            cboPaymentStatus.Text = "UnPaid";
                            bal.InventoryStatus = cboInventryStatus.Text;
                            bal.OrderNo = txtSaleOrdr.Text;
                            dal.update_status(bal);
                            lblCancelledRestck.Visible = false;
                            lblCancelledSale.Visible = false;
                            lblCancldRetrn.Visible = false;
                            btnCancelOrder.Text = "Cancel Order";
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Cann't Perform this Operation");
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentCell is DataGridViewLinkCell)
            {
                Customer c = new Customer();
                BAL.Customnam = dgvCustomer.CurrentRow.Cells["customername"].Value.ToString();
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

            pnlTaxngScheme.Visible = false;
            t.Show();

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlPricing.Visible = false;
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlTaxngScheme.Visible = false;
        }

        private void dgvTaxing_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Pricing p = new Pricing();
        private void lklpricing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            p.dgvPricingAdd.DataSource = dal.pricing();
            pnlPricing.Visible = false;
            p.Show();
        }

        private void cboInventryStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboretrnInvnstus.Text = cboInventryStatus.Text;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            txtSrchOrder.Text = String.Empty;
            cboSrchInvenStatus.Text = String.Empty;
            cboSrchPayStatus.Text = String.Empty;
            cboSrchCustmr.Text = String.Empty;
            dgvOrder.DataSource = null;
            dgvOrder.DataSource = dal.ordersNo();
        
        }

        private void btnSaleOrdrNew_Click(object sender, EventArgs e)
        {
            SaleOrderWith_shipping_details sd = new SaleOrderWith_shipping_details();
            sd.Show();
            this.Dispose(false);
        }

        private void dgvSaleItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void cboPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboretrnpaystus.Text = cboPaymentStatus.Text;
        }

        private void cboSrchCustmr_Click(object sender, EventArgs e)
        {
            pnlSrchCust.Visible = true;
            pnlSrchCust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlSrchCust.BringToFront();
            dgvCustomerName.DataSource = dal.customer_names();
            if (dgvCustomerName.ColumnCount == 2)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvCustomerName.Columns.Add(lnk);
                lnk.Name = "View";
                lnk.Text = "View";
                lnk.HeaderText = "Details";
                lnk.UseColumnTextForLinkValue = true;
            }
         
        }

        private void txtSaleFright_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar)&&(e.KeyChar!='.'))
            {
                e.Handled = true;
            }
        }

        private void txtSalePaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgvCustomerName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomerName.CurrentRow.Cells["customername"].ColumnIndex)
            {
                cboSrchCustmr.Text = dgvCustomerName.CurrentRow.Cells["customername"].Value.ToString();
                pnlSrchCust.Visible = false;
                bal.CustomerName = dgvCustomerName.CurrentRow.Cells["customername"].Value.ToString();
                dgvOrder.DataSource = dal.customer_id(bal);
            }
            
      

            pnlSrchCust.Visible = false;
        }

      

        private void cboSaleTrms_Click(object sender, EventArgs e)
        {
            pnlPaymentterms.Visible = true;
            dgvTerms.DataSource = dal.select_payterms();
        
        }

        private void dgvTerms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboSaleTrms.Text = dgvTerms.CurrentRow.Cells[0].Value.ToString();
            pnlPaymentterms.Visible = false;
        }

        private void dgvRetrnItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
              
                pnlDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.pnlDelete.BringToFront();
                pnlDelete.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvRetrnItem.Rows.RemoveAt(this.dgvRetrnItem.CurrentRow.Index);
            bal.OrderNo = txtRetrnOrder.Text;
            bal.Id = Convert.ToInt32(dgvRetrnItem.CurrentRow.Cells[8].Value.ToString());
            dal.delete_return(bal);
            pnlDelete.Visible = false;
        }




        String a;
        private void txtPaying_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSalePaid.Text == String.Empty)
                {
                    txtSalePaid.Text = "0";
                    a = txtSalePaid.Text;
                }
                else
                {
                    a = txtSalePaid.Text;
                }
                if (txtPaying.Text == String.Empty)
                {
                    txtPaying.Text = "0";
                }
                if (txtSaleTot.Text == String.Empty)
                {
                    txtSaleTot.Text = "0";
                }
                if (txtSalePaid.Text == String.Empty)
                {
                    txtSalePaid.Text = "0";
                }
                if (txtSaleBlnc.Text == String.Empty)
                {
                    txtSaleBlnc.Text = "0";
                }
                txtSalePaid.Text = (Convert.ToDecimal(txtSalePaid.Text) + Convert.ToDecimal(txtPaying.Text)).ToString();
                if (Convert.ToDecimal(txtSalePaid.Text) > Convert.ToDecimal(txtSaleTot.Text))
                {
                    MessageBox.Show("You Are Payiing More Amount Than Price");
                    txtSalePaid.Text = a;
                }
                else
                {
                    txtSaleBlnc.Text = (Convert.ToDecimal(txtSaleBlnc.Text) - Convert.ToDecimal(txtPaying.Text)).ToString();
                }
               
               
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("please enter the details in the correct format");
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                
                int i = 0;
                bal.CustometId = txtSaleOrdr.Text;

                DataTable dt = dal.select_paymenthistory(bal);
                foreach (DataRow d in dt.Rows)
                {
                    decimal k = decimal.Floor(Convert.ToDecimal(d["balance"]));
                    if (k == 0)
                    {
                        MessageBox.Show("You Have Already Paid the Bill");
                        i++;
                    }
                }

                if (i == 0)
                {

                    bal.CustomerName = cboSaleCustmr.Text;
                    bal.Phone = txtSalePhn.Text;
                    bal.OrderDate =(DateTime.Now);
                    bal.Duedate = cboSaleDueDate.Text;
                    if (txtSaleTot.Text == txtSaleBlnc.Text)
                    {
                        bal.Trans = "Purchase Order " + txtSaleOrdr.Text;
                        bal.Amount = txtSaleBlnc.Text;
                    }
                    else
                    {
                        bal.Trans = "Payment for " + txtSaleOrdr.Text;
                        bal.Amount = txtPaying.Text;
                    }
                  
                    bal.CBal1 = "0.0";
                    bal.Balance = txtSaleBlnc.Text;

                    if (txtSalePaid.Text == String.Empty)
                    {
                        txtSalePaid.Text="0";
                    }

                        if (decimal.Floor(Convert.ToDecimal(txtSaleTot.Text)) == decimal.Floor(Convert.ToDecimal(txtSalePaid.Text)))
                        {
                            dal.insert_paymenthistory(bal);
                            MessageBox.Show("You Have Paid the Total Bill Successfully");
                            MessageBox.Show("Press Save to Store Payment Details");
                            cboPaymentStatus.Text = "Paid";
                        }
                        else
                        {
                            dal.insert_paymenthistory(bal);
                            MessageBox.Show("Paid Successfully");
                            MessageBox.Show("Press Save to Store Payment Details");
                            if (txtSalePaid.Text != String.Empty)
                            {
                                if (decimal.Floor(Convert.ToDecimal(txtSalePaid.Text)) < (decimal.Floor(Convert.ToDecimal(txtSaleTot.Text)) / 2))
                                {
                                    cboPaymentStatus.Text = "Unpaid";
                                }
                                else if (decimal.Floor(Convert.ToDecimal(txtSalePaid.Text)) >= (decimal.Floor(Convert.ToDecimal(txtSaleTot.Text)) / 2))
                                {
                                    cboPaymentStatus.Text = "Partial";
                                }
                            }
                            else
                            {
                                cboPaymentStatus.Text = "Unpaid";
                            }
                        }
                    }
                }
            
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Please Check the Details and Try Again");
            }

        }

        private void dgvitems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvitems.CurrentCell is DataGridViewLinkCell)
            {
                ProductInfoorNewProduct p = new ProductInfoorNewProduct();
                bal.Itemname = dgvitems.CurrentRow.Cells["itemnameorcode"].Value.ToString();
                bal.Sno1 = Convert.ToInt32(dgvitems.CurrentRow.Cells["productid"].Value.ToString());
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
                p.dgvPrdct.Rows.Clear();
                p.dgvPrdct.Rows[0].Cells[0].Value = bal.DefaultLoc;
                p.dgvPrdct.Rows[0].Cells[1].Value = bal.Quantityonhand;
                p.dgvPrdct.Enabled = false;
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
                pnlItems.Visible = false;
                p.btnOk.Visible = true;
                p.Show();
            }
        }

        private void tabSaleOrder_Click(object sender, EventArgs e)
        {
            pnlItems.Visible = false;
            pnlLocation.Visible = false;
            pnlTaxngScheme.Visible = false;
            pnlPricing.Visible = false;
            dgvSalesRepr.Visible = false;
            pnlCustomr.Visible = false;
            pnlSrchCust.Visible = false;
            pnlPaymentterms.Visible = false;
            panel2.Visible = false;
            pnlSrchPrdct.Visible = false;
        }

        private void cboSaleRep_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bal.SalesRepr = cboSaleRep.Text;
                dal.insert_salesrep(bal);
            }
            dgvSalesRepr.Visible = false;
        }

        private void dgvSalesRepr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSaleItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 3)
            {
              

            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomer.CurrentRow.Cells["customername"].ColumnIndex)
            {
                cboSaleCustmr.Text = dgvCustomer.CurrentRow.Cells["customername"].Value.ToString();
                bal.CustomerName = dgvCustomer.CurrentRow.Cells["customername"].Value.ToString();
                bal.Phone = dgvCustomer.CurrentRow.Cells["phone"].Value.ToString();
                dal.select_customer(bal);
                cboSaleCustmr.Text = bal.CustomerName;
                txtSaleCntct.Text = bal.Contact;
                txtSalePhn.Text = bal.Phone;
                txtSaleBillAdrs.Text = bal.ShippingAddress;
                cboSaleTrms.Text = bal.PaymenStatus;
                cboSaleRep.Text = bal.DefaultSalesRep;
                cboSaleLocatn.Text = bal.DefaultLoc;
                cboInventryStatus.Text = "UnFullfilled";
                cboPaymentStatus.Text = "UnPaid";
                pnlCustomr.Visible = false;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            pnlSrchCust.Visible = false;
        }

        private void btnPrdctAdd_Click(object sender, EventArgs e)
        {
            ProductInfoorNewProduct p = new ProductInfoorNewProduct();
            p.txtItemname.Text = txtPrdctAdd.Text;
            pnlItems.Visible = false;
            p.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlItems.Visible = false;
            pnlSrchPrdct.Visible = false;
        }

        private void btnSrchNamAdd_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.txtcustomername.Text = txtSrchAdd.Text;
            pnlSrchCust.Visible = false;
            c.Show();

        }

        private void dgvCustomerName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Customer c = new Customer();
            if (dgvCustomerName.CurrentCell is DataGridViewLinkCell)
            {
                bal.CustomerName = dgvCustomerName.CurrentRow.Cells["customername"].Value.ToString();
                bal.Phone = dgvCustomerName.CurrentRow.Cells["phone"].Value.ToString();
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
            
                pnlSrchCust.Visible = false;
                c.Show();
            }


        }

        private void btnSrchPrdct_Click(object sender, EventArgs e)
        {
           
       
            txtSrchPrdctid.Text = String.Empty;
            txtSrchPrdctName.Text = String.Empty;
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlSrchPrdct.Visible = true;
            pnlSrchPrdct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void btnSrchCust_Click(object sender, EventArgs e)
        {
            txtCustSrchPhn.Text = String.Empty;
            txtCustSrch.Text = String.Empty;
     
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = true;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = false;
            pnlSrchCust.Visible = false;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            dgvRestckItems.Visible = false;
        }

        private void lnkAddShpng_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkAddShpng.Text == "Add Shipping")
            {
                label17.Visible = true;
                txtSaleShpngAdrs.Visible = true;
                txtSaleShpngAdrs.Text = txtSaleBillAdrs.Text;
                lnkAddShpng.Text = "No Shipping";
            }
            else
            {
                label17.Visible = false;
                txtSaleShpngAdrs.Visible = false;
                txtSaleShpngAdrs.Text = String.Empty;
                txtRetrnShpAdrs.Text = String.Empty;
                txtRestckShpAdrs.Text = String.Empty;
                lnkAddShpng.Text = "Add Shipping";
            }
        }

        private void txtSaleShpngAdrs_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("You Want To Change The Address ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                 txtSaleShpngAdrs.Text = String.Empty;
            //Address ad = new Address();
            //ad.Show();
            //ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked);
            }
           

        }
        //private void address_ButtonClicked(object sender, InventoryTools.Address.AddressUpdateEventArgs e)
        //{
        //    txtSaleShpngAdrs.Text = "";
        //    txtSaleShpngAdrs.Text += e.Street + "\r\n";
        //    txtSaleShpngAdrs.Text += e.City + "\r\n";
        //    txtSaleShpngAdrs.Text += e.State + "\r\n";
        //    txtSaleShpngAdrs.Text += e.Country + "\r\n";
        //    txtSaleShpngAdrs.Text += e.Postalcode + "\r\n";
        //    txtSaleShpngAdrs.Text += e.Remarks + "\r\n";
        //    txtSaleShpngAdrs.Text += e.Type;

        //}

        private void lnkAddLoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Location loc = new Location();
            loc.Show();
            pnlLocation.Visible = false;
        }

        private void pnlSrchCust_Click(object sender, EventArgs e)
        {
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlDelete.Visible = false;
        }

        private void pnlSrchCust_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        private void dgvSaleItem_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSaleItem.CurrentRow.Cells[6].ColumnIndex)
            {
                if (dgvSaleItem.IsCurrentCellInEditMode==false)
                {
                    MessageBox.Show("Please Enter Discount");
             
                }
            }
        }

        private void dgvRestckItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                pnlRestkDel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.pnlRestkDel.BringToFront();
                pnlRestkDel.Visible = true;
            }
        }

        private void btnRestckDel_Click(object sender, EventArgs e)
        {
            dgvRestckItem.Rows.RemoveAt(this.dgvRestckItem.CurrentRow.Index);
            bal.OrderNo = txtRestckOrder.Text;
            bal.Itemname = dgvRestckItem.CurrentRow.Cells[0].Value.ToString();
            dal.delete_restock(bal);
            
            pnlRestkDel.Visible = false;
        }

        private void btnRestkCncl_Click(object sender, EventArgs e)
        {
            pnlRestkDel.Visible = false;
        }

        private void lnkHideSrch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = false;
            txtCustSrch.Text = String.Empty;
            txtCustSrchPhn.Text = String.Empty;
        }

        private void dgvSaleItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                pnlSaleordrDel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.pnlSaleordrDel.BringToFront();
                pnlSaleordrDel.Visible = true;
            }
        }

        private void btnSaleordrDel_Click(object sender, EventArgs e)
        {
            dgvSaleItem.Rows.RemoveAt(this.dgvSaleItem.CurrentRow.Index);
            pnlSaleordrDel.Visible = false;
        }

        private void txtCustSrch_TextChanged(object sender, EventArgs e)
        {

            txtCustSrchPhn.Text = String.Empty;
            dgvCustomerName.Columns.Clear();
            bal.CustomerName = txtCustSrch.Text;
            dgvCustomerName.DataSource = dal.search_customers(bal);
            if (dgvCustomerName.ColumnCount == 2)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvCustomerName.Columns.Add(lnk);
                lnk.Name = "View";
                lnk.Text = "View";
                lnk.HeaderText = "Details";
                lnk.UseColumnTextForLinkValue = true;
            }
        }

        private void txtCustSrchPhn_TextChanged(object sender, EventArgs e)
        {
            txtCustSrch.Text = String.Empty;
            dgvCustomerName.Columns.Clear();
            bal.Phone = txtCustSrchPhn.Text;
            dgvCustomerName.DataSource = dal.customers_phone(bal);
            if (dgvCustomerName.ColumnCount == 2)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvCustomerName.Columns.Add(lnk);
                lnk.Name = "View";
                lnk.Text = "View";
                lnk.HeaderText = "Details";
                lnk.UseColumnTextForLinkValue = true;
            }
        }

        private void txtSrchPrdctName_TextChanged(object sender, EventArgs e)
        {

            txtSrchPrdctid.Text = String.Empty;
            dgvitems.Columns.Clear();
            bal.Itemname = txtSrchPrdctName.Text;
            dgvitems.DataSource = dal.srch_products(bal);
            dgvitems.Columns[0].Visible = false;
            if (dgvitems.ColumnCount == 3)
            {
                DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                dgvitems.Columns.Add(lnk);
                lnk.Name = "View";
                lnk.Text = "View";
                lnk.HeaderText = "Details";
                lnk.UseColumnTextForLinkValue = true;
            }
           }

        private void txtSrchPrdctid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSrchPrdctName.Text = String.Empty;
                dgvitems.Columns.Clear();
                if (txtSrchPrdctid.Text == String.Empty)
                {
                    dgvitems.DataSource = dal.items();
                }
                else
                {
                    bal.Sno1 = Convert.ToInt32(txtSrchPrdctid.Text);
                    dgvitems.DataSource = dal.srch_products1(bal);
                }
                dgvitems.Columns[0].Visible = false;
                if (dgvitems.ColumnCount == 3)
                {
                    DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                    dgvitems.Columns.Add(lnk);
                    lnk.Name = "View";
                    lnk.Text = "View";
                    lnk.HeaderText = "Details";
                    lnk.UseColumnTextForLinkValue = true;
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlSrchPrdct.Visible = false;
        }

        private void pnlSrchCust_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvRetrnItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvRetrnItem.CurrentRow.Cells[1].ColumnIndex)
            {

                bal.Id = Convert.ToInt32(dgvRetrnItem.CurrentRow.Cells[8].Value.ToString());
                bal.OrderNo = txtRetrnOrder.Text;
                bal.Itemname = dgvRetrnItem.CurrentRow.Cells[0].Value.ToString();
                dal.quantity_orders(bal);
                if (Convert.ToInt32(bal.Quantityafter) >= Convert.ToInt32(dgvRetrnItem.CurrentRow.Cells[1].Value.ToString()))
                {
                    dal.select_qunatityinhand(bal);
                    bal.Quantityonhand = (Convert.ToInt32(bal.Quantityonhand) + Convert.ToInt32(dgvRetrnItem.CurrentRow.Cells[1].Value.ToString())).ToString();
                    dal.update_quantityonhand(bal);
                }
                else
                {
                    dgvRetrnItem.CurrentRow.Cells[1].Value = null;
                    MessageBox.Show("You are Returning More than you Have");

                }
            }
        }

        private void lblPayterms_Click(object sender, EventArgs e)
        {
            PaymentTerms p = new PaymentTerms();
            pnlPaymentterms.Visible = false;
            p.Show();
        }

        private void txtSrchAdd_TextChanged(object sender, EventArgs e)
        {

        }
        }
}
    

