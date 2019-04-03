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
    public partial class movementhistory : Form
    {
        BAL b = new BAL();
        DAL d = new DAL();
        public movementhistory()
        {
            InitializeComponent();
        }
        public void binddata()
        {
            DataTable dt = d.selectall(b);
            dgvdisplay.DataSource = dt;
        }

        private void movementhistory_Load(object sender, EventArgs e)
        {
            binddata();
            paneltranc.Visible = false;
            dgvproduct.Visible = false;
            dgvlocation.Visible = false;
            paneldate.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            panel2.Visible = false;
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            dgvproduct.Columns.Add(link);
            link.HeaderText = "details";
            link.Name = "sitename";
            link.Text = "view";
            link.UseColumnTextForLinkValue = true;
            DataTable dt = d.selectprod(b);
            dgvproduct.DataSource = dt;
            DataTable dtt = d.selectloc(b);
            dgvlocation.DataSource = d.location();

        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            b.Trans = cmbtrans.Text;
            if (chkall.Checked == true)
            {
                DataTable dt = d.selecttranc(b);
                cmbtrans.Text = "All";
                chkpick.Checked = false;
                chkrecive.Checked = false;
                chkrestock.Checked = false;
                chkunstock.Checked = false;
                chkful.Checked = false;
                paneltranc.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    dgvdisplay.DataSource = dt;
                }

            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            paneltranc.Visible = true;
            paneltranc.BringToFront();
            paneldate.Visible = false;
            panel2.Visible = false;
            dgvlocation.Visible = false;
        }

        private void chkrecive_CheckedChanged(object sender, EventArgs e)
        {
            b.Trans = cmbtrans.Text;
            if (chkrecive.Checked == true)
            {
                DataTable dt = d.selectreciv(b);
                cmbtrans.Text = "Purchase Order Recive";
                chkpick.Checked = false;
                chkall.Checked = false;
                chkrestock.Checked = false;
                chkunstock.Checked = false;
                chkful.Checked = false;
                paneltranc.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    dgvdisplay.DataSource = dt;
                }

            }
        }

        private void chkunstock_CheckedChanged(object sender, EventArgs e)
        {
            b.Trans = cmbtrans.Text;
            if (chkunstock.Checked == true)
            {
                DataTable dt = d.selectunst(b);
                cmbtrans.Text = "Purchase Order Unstock";
                chkpick.Checked = false;
                chkall.Checked = false;
                chkrestock.Checked = false;
                chkrecive.Checked = false;
                chkful.Checked = false;
                paneltranc.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    dgvdisplay.DataSource = dt;
                }

            }
        }

        private void chkpick_CheckedChanged(object sender, EventArgs e)
        {
            b.Trans = cmbtrans.Text;
            if (chkpick.Checked == true)
            {
                DataTable dt = d.selectpick(b);
                cmbtrans.Text = "Sales Order Picking";
                chkrecive.Checked = false;
                chkall.Checked = false;
                chkrestock.Checked = false;
                chkunstock.Checked = false;
                chkful.Checked = false;
                paneltranc.Visible = false;
          
                    dgvdisplay.DataSource = dt;
              
            }


        }

        private void chkful_CheckedChanged(object sender, EventArgs e)
        {
            b.Trans = cmbtrans.Text;
            if (chkful.Checked == true)
            {
                DataTable dt = d.selectfulls(b);
                cmbtrans.Text = "Sales Order Fulfillment";
                chkrecive.Checked = false;
                chkall.Checked = false;
                chkrestock.Checked = false;
                chkunstock.Checked = false;
                chkpick.Checked = false;
                paneltranc.Visible = false;
                //if (dt.Rows.Count > 0)
                //{
                    dgvdisplay.DataSource = dt;
               // }
            }
        }

        private void chkrestock_CheckedChanged(object sender, EventArgs e)
        {
            b.Trans = cmbtrans.Text;
            if (chkrestock.Checked == true)
            {
                DataTable dt = d.selectrest(b);
                cmbtrans.Text = "Sales Order Restock";
                chkrecive.Checked = false;
                chkall.Checked = false;
                chkpick.Checked = false;
                chkunstock.Checked = false;
                chkful.Checked = false;
                paneltranc.Visible = false;
            
                    dgvdisplay.DataSource = dt;
              
            }
        }

        private void cmbitem_Click(object sender, EventArgs e)
        {
            dgvproduct.Visible = true;
            panel2.Visible = true;
            paneltranc.Visible = false;
            paneldate.Visible = false;
            dgvlocation.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbloc_Click(object sender, EventArgs e)
        {
            dgvlocation.Visible = true;
            panel2.Visible = false;
            paneldate.Visible = false;
            paneltranc.Visible = false;
        }

        private void dgvlocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbloc.Text = dgvlocation.CurrentRow.Cells[0].Value.ToString();
            b.Location = cmbloc.Text;
            DataTable dt = d.selectlocsch(b);
            dgvdisplay.DataSource = dt;
            dgvlocation.Visible = false;
        }

        private void laball_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "All";
            DataTable dt = d.selectdateall(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            paneldate.Visible = true;
            panel2.Visible = false;
            dgvlocation.Visible = false;
            paneltranc.Visible = false;

        }

        private void labtoday_Click(object sender, EventArgs e)
        {
          
            cmbdate.Text = "Today";
            DataTable dt = d.selecttoday(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;

        }

        private void dgvproduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbitem.Text = dgvproduct.CurrentRow.Cells[1].Value.ToString();
            b.Itemname = cmbitem.Text;
            DataTable dt = d.selectpro(b);
            dgvdisplay.DataSource = dt;
            panel2.Visible = false;
        }

        private void labthmonth_Click(object sender, EventArgs e)
        {
            
            cmbdate.Text = "This Month";
            DataTable dt = d.selectthismonth(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void labthweek_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "This Week";
            DataTable dt = d.selectthisweek(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void labthquarter_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "Quartor";
            DataTable dt = d.selectquartor(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void labthyear_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "This Year";
            DataTable dt = d.selectthisyear(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;

        }

        private void labyesterday_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "Yesterday";
            DataTable dt = d.selectyesterday(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void lablsweek_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "Last Week";
            DataTable dt = d.selectlastweek(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void lablstmonth_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "Last Month";
            DataTable dt = d.selectlastmonth(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void lablstqut_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "Last Quartor";
            DataTable dt = d.selectlastquartor(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void lablstyear_Click(object sender, EventArgs e)
        {
            cmbdate.Text = "Last Year";
            DataTable dt = d.selectlastyear(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cmbfrom.Text = dateTimePicker1.Value.Date.ToString();
            dateTimePicker1.Visible = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            cmbdate.Text = String.Empty;
            cmbto.Text = dateTimePicker2.Value.Date.ToString();
            dateTimePicker2.Visible = false;
        }

        private void cmbfrom_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            dateTimePicker1.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void cmbto_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = true;
            dateTimePicker2.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void cmbto_TextChanged(object sender, EventArgs e)
        {
            b.Date11 = Convert.ToDateTime(cmbfrom.Text);
            b.Date22 = Convert.ToDateTime(cmbto.Text);
            DataTable dt = d.selectdatefrom(b);
            dgvdisplay.DataSource = dt;
            paneldate.Visible = false;

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            dgvlocation.Hide();
            paneldate.Hide();
       
            panel2.Hide();
            paneltranc.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            dgvlocation.Hide();
            paneldate.Hide();
        
            paneltranc.Hide();
            panel2.Hide();
        }

        private void dgvdisplay_Click(object sender, EventArgs e)
        {
            dgvlocation.Hide();
            paneldate.Hide();
         
            paneltranc.Hide();
            panel2.Hide();
        }

        private void dgvproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbitem.Text = dgvproduct.CurrentRow.Cells[1].Value.ToString();
            if(e.ColumnIndex==0)
            {
            ProductInfoorNewProduct obj = new ProductInfoorNewProduct();
            obj.Show();
            b.Itemname = cmbitem.Text;
            DataTable dt = d.selectview(b);
            foreach (DataRow dd in dt.Rows)
            {
                obj.txtItemname.Text = dd["itemnameorcode"].ToString();
                obj.cboProductType.Text = dd["type"].ToString();
                obj.cboProdctCategry.Text = dd["category"].ToString();
                obj.txtPrdctDescptn.Text = dd["description"].ToString();
                obj.txtPrdctNrmalPrice.Text = dd["normalprice"].ToString();
                obj.txtPrdctRetailPrice.Text = dd["retailpreice"].ToString();
                obj.txtPrdctWhlsale.Text = dd["wholesaleprice"].ToString();
                obj.txtPrdctCost.Text = dd["cost"].ToString();
                obj.txtPrdctYear.Text = dd["year"].ToString();
                obj.txtPrdctModl.Text = dd["model"].ToString();
            
                byte[] imagedata = (byte[]) dd["picture"];
                Image image;
                using (MemoryStream ms = new MemoryStream(imagedata))
                {
                    ms.Write(imagedata, 0, imagedata.Length);
                    image = Image.FromStream(ms);
                }
                obj.pictureBox1.Image = image;
                obj.txtPrdctBarcode.Text = dd["barcode"].ToString();
                obj.txtPrdctReordrPoint.Text = dd["reorderpoint"].ToString();
                obj.txtPrdctReordrQuant.Text = dd["reorderquantity"].ToString();
                obj.cboPrdctDefLoc.Text = dd["location"].ToString();
                obj.cboPrdctLastVen.Text = dd["lastvendor"].ToString();
                obj.cboPrdctStateUOM.Text = dd["standarduom"].ToString();
                obj.cboPrdctStateUOM.Text = dd["salesuom"].ToString();
                obj.cboPrdctPurchUOM.Text = dd["purchasinguom"].ToString();
                obj.txtPrdctManufactur.Text = dd["manufacturer"].ToString();
                obj.txtPrdctMadein.Text = dd["madein"].ToString();
                obj.txtPrdctLenght.Text = dd["length"].ToString();
                obj.txtPrdctHight.Text = dd["height"].ToString();
                obj.txtPrdctWidth.Text = dd["width"].ToString();
                obj.txtPrdctWeight.Text = dd["weight"].ToString();
                obj.txtPrdctRemarks.Text = dd["remarks"].ToString();
            }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            ProductInfoorNewProduct obj1 = new ProductInfoorNewProduct();
            obj1.Show();
            
        }
           
        
    }
}
