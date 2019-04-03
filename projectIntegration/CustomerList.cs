using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryTools;
using System.Drawing.Drawing2D;

namespace InventoryTools
{
    public partial class CustomerList : Form
    {
        BAL B = new BAL();
        DAL D = new DAL();
        // int count = 0;
        public CustomerList()
        {
            InitializeComponent();
        }

        //----------------------------------------------Adding colors to the Form----------------------------------------//
       

        private void CustomerList_Load(object sender, EventArgs e)
        {
            
            dgvdisplay.AutoGenerateColumns = false;
            panel1.BackColor = Color.LightGreen;
            panel3.BackColor = Color.LimeGreen;
            dgvdisplay.DefaultCellStyle.BackColor = Color.LightGreen;
            dgvdisplay.AlternatingRowsDefaultCellStyle.BackColor = Color.LimeGreen;
            bindata();
            panel2.Visible = false;
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Active";
            checkBoxColumn.Width = 40;
            checkBoxColumn.Name = "checkBoxColumn";
            dgvdisplay.Columns.Insert(0, checkBoxColumn);
            dgvdisplay.Columns[0].Visible = false;
            dgvdisplay.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dgvdisplay.RowHeadersVisible = true;
        }
        public void bindata()
        {
            DataTable dt = D.select1(B);
            if (dt.Rows.Count > 0)
            {
                dgvdisplay.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           txtname.Text=string.Empty;
            txtphone.Text = String.Empty;
            txtcontact.Text = string.Empty;
            txtemail.Text = string.Empty;
            bindata();
            
            
        }
            //----------------------------SEARCHING WITH NAME IN DATAGRIDVIEW---------------------------//


        private void txtname_TextChanged(object sender, EventArgs e)
        {
           

            txtphone.Text = String.Empty;
            txtcontact.Text = string.Empty;
            txtemail.Text = string.Empty;
                   B.Customername = txtname.Text;
                    DataTable dt = D.select98(B);
                 
                        dgvdisplay.DataSource = dt;
                   
         
            
        }

        //--------------------------SEARCHING WITH PHONE NUMBER IN DATAGRIDVIEW-----------------------------//

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

            txtname.Text = String.Empty;
            txtcontact.Text = string.Empty;
            txtemail.Text = string.Empty;
            B.Phone = txtphone.Text;
            DataTable dt = D.select2(B);
          
                dgvdisplay.DataSource = dt;
           
        }

        //--------------------------SEARCHING WITH CONTACT NAME IN DATAGRIDVIEW-----------------------------//


        private void txtcontact_TextChanged_1(object sender, EventArgs e)
        {

            txtphone.Text = String.Empty;
            txtname.Text = string.Empty;
            txtemail.Text = string.Empty;
            B.Contactname = txtcontact.Text;
            DataTable dt = D.select13(B);
          
                dgvdisplay.DataSource = dt;
           
        }

        //---------------------------SEARCHIG WITH EMAIL IN DATAGRIDVIEW -------------------------------------//

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

            txtphone.Text = String.Empty;
            txtcontact.Text = string.Empty;
            txtname.Text = string.Empty;
         
                B.Email = txtemail.Text;
                DataTable dt = D.select3(B);
             
                    dgvdisplay.DataSource = dt;
               
        }


        //----------------------------SHOWING ACTIVE,INACTIVE,SHOWALL DETAILS IN DATAGRIDVIEW---------------------------//


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        //---------------------------------Selecting CheckBox in Inactive list And Redirect To Customer Form-------------------// 

        private void dgvdisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dgvdisplay.Rows[e.RowIndex].Cells[0].Value) == false)
                {
                    for (int i = 0; i <= dgvdisplay.Rows.Count - 1; i++)
                    {
                        dgvdisplay.Rows[i].Cells[0].Value = false;
                    }

                }
                foreach (DataGridViewRow row in dgvdisplay.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if(chk.Selected==true)
                    {
                        Customer obj=new Customer();
                        obj.Show();
                        B.Customername=dgvdisplay.CurrentRow.Cells[1].Value.ToString();
                        DataTable dt=new DataTable();
                        dt=D.select16(B);
                        foreach (DataRow d in dt.Rows)
                        {
                            obj.txtcustomername.Text = d["customername"].ToString();
                            obj.txtcontactname.Text = d["contactname"].ToString();
                            obj.txtphone.Text = d["phone"].ToString();
                            obj.txtemail.Text = d["email"].ToString();
                            obj.txtwebsite.Text = d["website"].ToString();
                            obj.txtaddress.Text = d["address"].ToString();
                          
                            obj.txtdiscount.Text = d["discount"].ToString();
                            string status = d["status"].ToString();
                            if (status == "Active")
                            {
                                obj.btndeactivate.Text = "Deactivate";
                                
obj.btndeactivate.BackColor = Color.Red;
                            }
                            else if (status == "Inactive")
                            {
                                obj.btndeactivate.Text = "Reactivate";
                                obj.btndeactivate.BackColor = Color.Green;
                            }
                        }
                   
                        DataTable dt3 = D.select15(B);
                        foreach (DataRow dr in dt3.Rows)
                        {
                            int i = obj.dgvname.Rows.Add();
                            obj.dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
                        }
                    }

                    }

                }
                foreach (DataGridViewRow row1 in dgvdisplay.Rows)
                {
                    DataGridViewTextBoxCell ctb = (DataGridViewTextBoxCell)row1.Cells[1];
                    if (ctb.Selected == true)
                    {
                        if (e.ColumnIndex >= 0)
                        {
                            B.Customername = dgvdisplay.CurrentRow.Cells[1].Value.ToString();
                            Customer c = new Customer();
                            c.Show();
                            DataTable dn = new DataTable();
                            dn = D.select16(B);
                            foreach (DataRow d in dn.Rows)
                            {
                                c.txtcustomername.Text = d["customername"].ToString();
                                c.txtcontactname.Text = d["contactname"].ToString();
                                c.txtphone.Text = d["phone"].ToString();
                                c.txtemail.Text = d["email"].ToString();
                                c.txtwebsite.Text = d["website"].ToString();
                                c.txtaddress.Text = d["address"].ToString();
                                //c.txtcity.Text = d["city"].ToString();
                                //c.txtstate.Text = d["state"].ToString();
                                //c.txtzipcode.Text = d["zipcode"].ToString();
                                //c.txtcountry.Text = d["country"].ToString();
                                //c.cmbpricing.Text = d["pricingorcurrency"].ToString();
                                c.txtdiscount.Text = d["discount"].ToString();
                            }
                            DataTable dt3 = D.select178(B);
                            foreach (DataRow dr in dt3.Rows)
                            {
                                int i = c.dgvname.Rows.Add();
                                c.dgvname.Rows[i].Cells[1].Value = dr["customername"].ToString();
                            }
                            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                            for (int i = 0; i < c.dgvname.Rows.Count; i++)
                            {
                                chk.TrueValue = CheckState.Unchecked;
                                chk.FalseValue = CheckState.Checked;
                                BAL.Stat = Convert.ToString(c.dgvname.Rows[i].Cells[2].Value);
                                if (BAL.Stat == "Active")
                                {
                                    c.dgvname.Rows[i].Cells[0].Value = chk.TrueValue;
                                    c.btndeactivate.Text = "Deactivate";
                                    c.btndeactivate.BackColor = Color.Red;
                                   
                                }
                                else if (BAL.Stat == "Inactive")
                                {
                                    c.dgvname.Rows[i].Cells[0].Value = chk.FalseValue;
                                    c.btndeactivate.Text = "Reactivate";
                                    c.btndeactivate.BackColor = Color.Green;
                                   
                                }
                              

                                
                            }
                        }
                    }
                }
            
        }

        //-------------------------------SHOWING ACTIVE,INACTIVE,SHOWALL DETAILS IN DATAGRIDVIEW---------------------------------//

        private void cmbboxshow_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            B.Status1 = cmbboxshow.Text;
            if (checkBox1.Checked==true)                 
            {
               
                DataTable dt = D.select99(B);
                cmbboxshow.Text = "Active";
                checkBox2.Checked= false;
                checkBox3.Checked= false;
                panel2.Visible = false;

                if (dt.Rows.Count > 0)
                {
                    dgvdisplay.DataSource = dt;
                    dgvdisplay.Columns[0].Visible = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            B.Status1 = cmbboxshow.Text;
            if (checkBox2.Checked == true)
            {
            
                DataTable dt = D.select10(B);
                cmbboxshow.Text = "InActive";
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                panel2.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    dgvdisplay.DataSource = dt;
                    dgvdisplay.Columns[0].Visible = true;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            B.Status1 = cmbboxshow.Text;
            if (checkBox3.Checked == true)
            {
                DataTable dt = D.select11(B);
                cmbboxshow.Text = "Show All";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                panel2.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    dgvdisplay.DataSource = dt;
                    dgvdisplay.Columns[0].Visible = true;
                }
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                for (int i = 0; i < dgvdisplay.Rows.Count; i++)
                {
                    chk.TrueValue = CheckState.Unchecked;
                    chk.FalseValue = CheckState.Checked;
                    BAL.Stat=Convert.ToString(dgvdisplay.Rows[i].Cells[13].Value);
                    if (BAL.Stat == "Inactive")
                    {
                        dgvdisplay.Rows[i].Cells[0].Value = chk.TrueValue;
                    }
                    else if(BAL.Stat=="Active")
                    {
                        dgvdisplay.Rows[i].Cells[0].Value = chk.FalseValue;
                    }
                    panel2.Hide();
                }
            }
        }

        private void CustomerList_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void CustomerList_MouseClick(object sender, MouseEventArgs e)
        {
          

        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Visible = false;
           

        }

        private void CustomerList_Click(object sender, EventArgs e)
        {
         

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

       
        }

    }


