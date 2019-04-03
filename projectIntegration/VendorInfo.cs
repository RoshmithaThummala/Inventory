using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace InventoryTools
{
    public partial class VendorInfo : Form
    {
        BAL cs = new BAL();
        DAL cs1 = new DAL();
        public VendorInfo()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            
            panel9.Visible = false;
            
            textBox18.Visible = false;
            textBox19.Visible = false;
            textBox20.Visible = false;
            textBox21.Visible = false;

            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;

            dataGridView1.Columns[0].Visible = false;
           
            panel12.Visible = false;
            panel11.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            dt = cs1.select20();
            dataGridView1.DataSource = dt;
            dt = cs1.select21();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox5.Items.Add(dr["currency"]).ToString();
            }
            
            dt = cs1.select11();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr["carrier"]).ToString();
            }
        
            dt = cs1.select23();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = dr["item"].ToString();
                dataGridView2.Rows[i].Cells[1].Value = dr["description"].ToString();
                dataGridView2.Rows[i].Cells[2].Value = dr["vendorproductcode"].ToString();
                dataGridView2.Rows[i].Cells[3].Value = dr["unitprice"].ToString();
            }               
        }

        //-----------------Datagridview cell click-------------------------------//

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        //------------------------------------ Panels Paint code ----------------------------------------//

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                              Color.Orange,
                                                              Color.Gold,
                                                              250F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                            Color.Orange,
                                                            Color.Gold,
                                                            100F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                             Color.White,
                                                             Color.Gold,
                                                             100F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                           Color.Cornsilk,
                                                           Color.CornflowerBlue,
                                                           100F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        //---------------------------- Insertion code for main Form -----------------------------------//

        private void button3_Click(object sender, EventArgs e)
        {
            cs.Vendorname = textBox4.Text;
            cs.BalanceV = textBox5.Text;
            cs.CreditV =textBox6.Text;
            cs.ContactnameV =textBox7.Text;
            cs.PhoneV =textBox8.Text;
            cs.FaxV =textBox9.Text;
            cs.EmailV =textBox11.Text;
            cs.WebsiteV =textBox10.Text;
            cs.RemarksV =textBox15.Text;
            cs.AddressV =textBox13.Text;
            cs.PaymenttermsV =comboBox2.Text;
            cs.TaxingschemeV =comboBox3.Text;
            cs.CarrierV =comboBox4.Text;
            cs.CurrencyV =comboBox5.Text;
            cs.AlternatecontactV =textBox16.Text;
            cs.EmergencyphoneV =textBox17.Text;
            cs.DobV =textBox12.Text;
            cs.ResidenceV =textBox14.Text;
            cs.CityV =textBox18.Text;
            cs.StateV =textBox19.Text;
            cs.CountryV =textBox20.Text;
            cs.ZipcodeV =textBox21.Text;
            cs.StatusV = "Active";
            cs1.insertvendors(cs);
            dataGridView1.DataSource = cs1.select20();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox15.Clear();
            textBox13.Clear();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();
            comboBox5.ResetText();
            textBox16.Clear();
            textBox17.Clear();
            textBox12.Clear();
            textBox14.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            comboBox7.ResetText();
        }      
        private void comboBox2_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            dataGridView5.Visible = true;
            dataGridView5.DataSource = cs1.select_payterms();
        }
        private void comboBox3_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
            dataGridView6.DataSource = cs1.select40();
        }
        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();
            panel12.Visible = false;         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void comboBox7_Click(object sender, EventArgs e)
        {
           
        }

        //------------------------- Combobox Active,Inactive and ShowAll vendors code ----------------------//

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            cs.StatusV = comboBox7.Text;
            DataTable dt = new DataTable();
            dt = cs1.select9(cs);
            if (comboBox7.Text == "Active")
            {
                dataGridView1.Columns[0].Visible = false;
              
                    dataGridView1.DataSource = dt;
               
            }

            else if (comboBox7.Text == "Inactive")
            {
                dataGridView1.Columns[0].Visible = false;
               
                    dataGridView1.DataSource = dt;
               
            }

            else 
            {
               
                dataGridView1.Columns[0].Visible = true;
                
                dt = cs1.select20(); 
               
                    dataGridView1.DataSource = dt; 
               
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    chk.TrueValue = CheckState.Unchecked;
                    chk.FalseValue = CheckState.Checked;
                    dataGridView1.Columns[2].Visible = false;
                    BAL.Stat = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    if (BAL.Stat == "Active")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = chk.TrueValue;
                    }
                    else if (BAL.Stat == "Inactive")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = chk.FalseValue;
                    }
                }
            }
            
        }

        //---------------------------- Deactivate and Reactivate button code ----------------------------------//

        private void button8_Click(object sender, EventArgs e)
        {
            if (btndeactive.Text == "Deactivate")
            {
                DisableControls(tabPage1);
                EnableControls(btndeactive);
                btndeactive.Text = "Reactivate";
                cs.StatusV = "Inactive";
                cs.Vendorname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cs1.update1(cs);
            
            }                            
            else if (btndeactive.Text == "Reactivate")
            {
                btndeactive.Text = "Deactivate";
                Enable(tabPage1);
                cs.StatusV = "Active";
                cs.Vendorname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cs1.update1(cs);
              
            }                    
        }        
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }       
        private void comboBox6_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            panel9.Hide();
            panel12.Hide();
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       private void txtto_TextChanged(object sender, EventArgs e)
        {
            TextBox txtfrom = new TextBox();
            TextBox txtto = new TextBox();
            BAL.Date1 = Convert.ToDateTime(txtfrom.Text);
            BAL.Date2 = Convert.ToDateTime(txtto.Text);
            DataTable dt = new DataTable();
            dt = cs1.select30();          
            dataGridView4.DataSource = dt;
        }

        //-------------------------- payment terms linklabel code----------------------------------------------------//

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PaymentTerms pt = new PaymentTerms();
            pt.Show();
            panel9.Hide();
        }     

        private void VendorInfo_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string name = BAL.Nam;

            if (BAL.Nam == null || BAL.Nam == "")
            {
            }
            else
            {
             

                dt = cs1.SelectVname(cs);

                if (dt.Rows.Count > 0)
                {
                    textBox4.Text = dt.Rows[0]["vendorname"].ToString();
                    textBox5.Text = dt.Rows[0]["balance"].ToString();
                    textBox6.Text = dt.Rows[0]["credit"].ToString();
                    textBox7.Text = dt.Rows[0]["contactname"].ToString();
                    textBox8.Text = dt.Rows[0]["phone"].ToString();
                    textBox9.Text = dt.Rows[0]["fax"].ToString();
                    textBox11.Text = dt.Rows[0]["email"].ToString();
                    textBox10.Text = dt.Rows[0]["website"].ToString();
                    textBox15.Text = dt.Rows[0]["remarks"].ToString();
                    textBox13.Text = dt.Rows[0]["address"].ToString();
                    comboBox2.Text = dt.Rows[0]["paymentterms"].ToString();
                    comboBox3.Text = dt.Rows[0]["taxingscheme"].ToString();
                    comboBox4.Text = dt.Rows[0]["carrier"].ToString();
                    comboBox5.Text = dt.Rows[0]["currency"].ToString();
                    textBox16.Text = dt.Rows[0]["alternatecontact"].ToString();
                    textBox17.Text = dt.Rows[0]["emergencyphone"].ToString();
                    textBox12.Text = dt.Rows[0]["dob"].ToString();
                    textBox14.Text = dt.Rows[0]["residence"].ToString();
                    textBox18.Text = dt.Rows[0]["city"].ToString();
                    textBox19.Text = dt.Rows[0]["state"].ToString();
                    textBox20.Text = dt.Rows[0]["country"].ToString();
                    textBox21.Text = dt.Rows[0]["zipcode"].ToString();
                    String a = dt.Rows[0]["status"].ToString();
                    if (a == "Active")
                    {

                        btndeactive.Text = "Deactivate";
                    }
                    else
                    {

                        btndeactive.Text = "Reactivate";
                    }

                    BAL.Nam = "";
                }
            }

            BAL.Povname = name;
            dt = cs1.selectph(cs);
            foreach (DataRow dr in dt.Rows)
            {

                int i = dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells[0].Value = dt.Rows[i]["date"].ToString();
                dataGridView4.Rows[i].Cells[1].Value = dt.Rows[i]["duedate"].ToString();
                dataGridView4.Rows[i].Cells[2].Value = dt.Rows[i]["trans"].ToString();
                dataGridView4.Rows[i].Cells[3].Value = dt.Rows[i]["amount"].ToString();
                dataGridView4.Rows[i].Cells[4].Value = dt.Rows[i]["creditbalance"].ToString();
                dataGridView4.Rows[i].Cells[5].Value = dt.Rows[i]["balance"].ToString();
            }

            dt = cs1.SelectVOrderhis(cs);
            foreach (DataRow dr in dt.Rows)
            {

                int i = dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = dt.Rows[i]["poorderno"].ToString();
                dataGridView3.Rows[i].Cells[1].Value = dt.Rows[i]["orderdate"].ToString();
                dataGridView3.Rows[i].Cells[2].Value = dt.Rows[i]["inventorystatus"].ToString() + "," + dt.Rows[i]["paymentstatus"].ToString();
                dataGridView3.Rows[i].Cells[3].Value = dt.Rows[i]["total"].ToString();
                dataGridView3.Rows[i].Cells[4].Value = dt.Rows[i]["paid"].ToString();
                dataGridView3.Rows[i].Cells[5].Value = dt.Rows[i]["balance"].ToString();
            }
                
            
        
        }

        //------------------------- Taxing scheme linklabel code----------------------------------------------//

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Taxing t = new Taxing();
            DataTable dt = cs1.select_taxing();
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
            panel12.Hide();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            panel9.Visible = false;
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            panel9.Hide();
            panel12.Hide();
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            panel9.Hide();
            panel12.Hide();
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            panel9.Hide();
            panel12.Hide();
        }

        //---------------------------------- Vendor name textchanged code ------------------------------------// 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;

            dataGridView1.Columns[0].Visible = false;
            textBox3.Clear();
            comboBox7.ResetText();
            BAL.Vendorname1 = textBox1.Text;
            cs.Vendorname = textBox1.Text;
            DataTable dt = new DataTable();
            dt = cs1.select36(cs);          
                   
                dataGridView1.DataSource = dt; 
          
          
            
        }
       
        //---------------------------------- Email text changed --------------------------------------------//

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            dataGridView1.Columns[0].Visible = false;
            textBox2.Clear();
            cs.Email = textBox3.Text;
            DataTable dt = new DataTable();
            dt = cs1.select39(cs);
            comboBox7.ResetText();
                dataGridView1.DataSource = dt;
           
           
            
           
        }

        //----------------------------------- contact textchanged ----------------------------------------//

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox3.Text = String.Empty;
            dataGridView1.Columns[0].Visible = false;
            comboBox7.ResetText();
            cs.Contactname = textBox2.Text;
            DataTable dt = new DataTable();
            dt = cs1.select38(cs);
                     
                dataGridView1.DataSource = dt;
                            
            
        }  
        private void panel8_Click(object sender, EventArgs e)
        {
            panel11.Hide();
        }
        

        //---------------------------Dates methods----------------------------//

        private void label28_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            comboBox6.Text = "All";

            dt = cs1.select25();
            dataGridView4.DataSource = dt;
            panel11.Hide();
        }

        private void label29_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            comboBox6.Text = "Since Last Statement";
            dt = cs1.select26();
            dataGridView4.DataSource = dt;
            panel11.Hide();          
        }

        private void label30_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            comboBox6.Text = "This month";
            dt = cs1.select28();
            dataGridView4.DataSource = dt;
            panel11.Hide();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            comboBox6.Text = "Last 30 days";
            dt = cs1.select27();
            dataGridView4.DataSource = dt;
            panel11.Hide();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            comboBox6.Text = "Last 31 days";
            dt = cs1.select29();
            dataGridView4.DataSource = dt;
            panel11.Hide();
        }

        private void comboBox8_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
        }

        private void comboBox9_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox8.Text = dateTimePicker1.Value.Date.ToString();
            dateTimePicker1.Hide();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            comboBox9.Text = dateTimePicker2.Value.Date.ToString();
            dateTimePicker2.Hide();
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
        }

        //-----------------------------------between date----------------------//

        private void comboBox9_TextChanged(object sender, EventArgs e)
        {
            BAL.Date1 = Convert.ToDateTime(comboBox8.Text);
            BAL.Date2 = Convert.ToDateTime(comboBox9.Text);
            DataTable dt = new DataTable();
            comboBox6.Text = "From";
            dt = cs1.select30();
            dataGridView4.DataSource = dt;
            panel11.Hide();
        }


        //-------------------------------- Enable and Disable codes-----------------------------//

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

        private void panel5_Click(object sender, EventArgs e)
        {
            panel9.Hide();
            panel12.Hide();
        }

        //----------------------- New button code----------------------------------------//

        private void button2_Click(object sender, EventArgs e)
        {
            VendorInfo v = new VendorInfo();

            v.Show();
            this.Hide();
            //textBox1.Clear();
            //textBox2.Clear();
            //textBox3.Clear();
            //textBox4.Clear();
            //textBox5.Clear();
            //textBox6.Clear();
            //textBox7.Clear();
            //textBox8.Clear();
            //textBox9.Clear();
            //textBox11.Clear();
            //textBox10.Clear();
            //textBox15.Clear();
            //textBox13.Clear();
            //comboBox2.ResetText();
            //comboBox3.ResetText();
            //comboBox4.ResetText();
            //comboBox5.ResetText();
            //comboBox6.ResetText();
            //textBox16.Clear();
            //textBox17.Clear();
            //textBox12.Clear();
            //textBox14.Clear();
            //textBox18.Clear();
            //textBox19.Clear();
            //textBox20.Clear();
            //textBox21.Clear();
            //comboBox7.ResetText();
            //textBox12.Clear();
            //textBox14.Clear();
            //dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();
            //dataGridView2.DataSource = null;
            //dataGridView2.Rows.Clear();
            //dataGridView3.DataSource = null;
            //dataGridView3.Rows.Clear();
            //dataGridView4.DataSource = null;
            //dataGridView4.Rows.Clear();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        //-------------------------------------- Address Code -------------------------------------------//

        private void textBox13_Click_1(object sender, EventArgs e)
        {
            Address ad = new Address();
            ad.Show();
            ad.AddressUpdate += new Address.AddressUpdateHandler(address_ButtonClicked);
            //Address ad = new Address();
            //ad.Show();
            //ad.AddressUpdate += new address.AddressUpdateHandler(button1_ButtonClicked);
            textBox13.Text = String.Empty;
        }
        private void address_ButtonClicked(object sender, InventoryTools.Address.AddressUpdateEventArgs e)
        {
            textBox13.Text = "";
            textBox13.Text += e.Street + "\r\n";
            textBox13.Text += e.City + "\r\n";
            textBox13.Text += e.State + "\r\n";
            textBox13.Text += e.Country + "\r\n";
            textBox13.Text += e.Postalcode + "\r\n";
            textBox13.Text += e.Remarks + "\r\n";
            textBox13.Text += e.Type + "\r\n";
            textBox18.Text += e.City;
            textBox19.Text += e.State;
            textBox20.Text += e.Country;
            textBox21.Text += e.Postalcode;
            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            cs.Vendorname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dt = cs1.select37(cs);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                textBox4.Text = dt.Rows[i]["vendorname"].ToString();
                textBox5.Text = dt.Rows[i]["balance"].ToString();
                textBox6.Text = dt.Rows[i]["credit"].ToString();
                textBox7.Text = dt.Rows[i]["contactname"].ToString();
                textBox8.Text = dt.Rows[i]["phone"].ToString();
                textBox9.Text = dt.Rows[i]["fax"].ToString();
                textBox11.Text = dt.Rows[i]["email"].ToString();
                textBox10.Text = dt.Rows[i]["website"].ToString();
                textBox15.Text = dt.Rows[i]["remarks"].ToString();
                textBox13.Text = dt.Rows[i]["address"].ToString();
                comboBox2.Text = dt.Rows[i]["paymentterms"].ToString();
                comboBox3.Text = dt.Rows[i]["taxingscheme"].ToString();
                comboBox4.Text = dt.Rows[i]["carrier"].ToString();
                comboBox5.Text = dt.Rows[i]["currency"].ToString();
                textBox16.Text = dt.Rows[i]["alternatecontact"].ToString();
                textBox17.Text = dt.Rows[i]["emergencyphone"].ToString();
                textBox12.Text = dt.Rows[i]["dob"].ToString();
                textBox14.Text = dt.Rows[i]["residence"].ToString();
                textBox18.Text = dt.Rows[i]["city"].ToString();
                textBox19.Text = dt.Rows[i]["state"].ToString();
                textBox20.Text = dt.Rows[i]["country"].ToString();
                textBox21.Text = dt.Rows[i]["zipcode"].ToString();
                String a = dt.Rows[i]["status"].ToString();
                if (a == "Active")
                {
                 
                    btndeactive.Text = "Deactivate";
                }
                else
                {
                  
                    btndeactive.Text = "Reactivate";
                }
            }


            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();

            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();

            BAL.Povname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTable dt1 = new DataTable();
            dt = cs1.selectph(cs);
            if (e.RowIndex >= 0)
            {
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        i = dataGridView4.Rows.Add();
                        dataGridView4.Rows[i].Cells[0].Value = dt1.Rows[i]["date"].ToString();
                        dataGridView4.Rows[i].Cells[1].Value = dt1.Rows[i]["duedate"].ToString();
                        dataGridView4.Rows[i].Cells[2].Value = dt1.Rows[i]["trans"].ToString();
                        dataGridView4.Rows[i].Cells[3].Value = dt1.Rows[i]["amount"].ToString();
                        dataGridView4.Rows[i].Cells[4].Value = dt1.Rows[i]["creditbalance"].ToString();
                        dataGridView4.Rows[i].Cells[5].Value = dt1.Rows[i]["balance"].ToString();
                    }
                }
            }

            dt = cs1.SelectVOrderhis(cs);
            if (e.RowIndex >= 0)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        i = dataGridView3.Rows.Add();
                        dataGridView3.Rows[i].Cells[0].Value = dt.Rows[i]["poorderno"].ToString();
                        dataGridView3.Rows[i].Cells[1].Value = dt.Rows[i]["orderdate"].ToString();
                        dataGridView3.Rows[i].Cells[2].Value = dt.Rows[i]["inventorystatus"].ToString() + "," + dt.Rows[i]["paymentstatus"].ToString();
                        dataGridView3.Rows[i].Cells[3].Value = dt.Rows[i]["total"].ToString();
                        dataGridView3.Rows[i].Cells[4].Value = dt.Rows[i]["paid"].ToString();
                        dataGridView3.Rows[i].Cells[5].Value = dt.Rows[i]["balance"].ToString();
                    }
                }
            }

        }       
        
    }
    }

