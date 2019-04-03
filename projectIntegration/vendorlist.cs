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
using System.Configuration;


namespace InventoryTools
{
    public partial class vendorlist : Form
    {
        BAL p = new BAL();
        DAL c = new DAL();
        DataTable dt = new DataTable();

        Panel pnlshow = new Panel();
        CheckBox chkactive = new CheckBox();
        CheckBox chkinactive = new CheckBox();
        CheckBox chkall = new CheckBox();
        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
        public vendorlist()
        {
            InitializeComponent();
            //******************* BIND TO GRID***********//
            dataGridView1.AutoGenerateColumns = false;
            dt = c.selectvendor();
            if(dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
                textBox4.Text = dataGridView1.RowCount.ToString();
            }
        }
        //******************* DISPLAY ROW BASED ON VENDORNAME OR STRTNG LETTR***********//
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            p.Vendorname = textBox1.Text;           
            dt = c.selectvendrname(p);
          
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                textBox4.Text = dataGridView1.RowCount.ToString();
           
        }
        //******************* DISPLAY ROW BASED ON CONTACTNME OR STRTNG LETTR***********//
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            p.Contactname = textBox2.Text;
            dt = c.selectcontact(p);
         
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                textBox4.Text = dataGridView1.RowCount.ToString();
          
           
        }
        //******************* DISPLAY ROW BASED ON EMAIL OR STRTNG LETTR***********//
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            p.Email= textBox3.Text;
            DataTable dt = new DataTable();
            dt = c.selectemail(p);
           
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                textBox4.Text = dataGridView1.RowCount.ToString();
          
        }
        //******************* DISPLAY ROW BASED ON VENDORNAME,CONTACT ***********//
        private void textBox2_Leave(object sender, EventArgs e)
        {
            p.VendornameL = textBox1.Text;
            p.Contactname = textBox2.Text;
            DataTable dt = new DataTable();
            dt = c.loadvendor2(p);
          
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                textBox4.Text = dataGridView1.RowCount.ToString();
           
        }
        //******************* DISPLAY ROW BASED ON GIVEN FULL DETAILS***********//
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = c.selectrow(p);
            if (p.Vendorname == textBox1.Text && p.Contactname == textBox2.Text && p.Email == textBox3.Text)
            {
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    textBox4.Text = dataGridView1.RowCount.ToString();
                }
            }
        }
        //******************* DISPLAY ROW BASED ON GIVEN 3 starting lettrs***********//
        private void textBox3_Leave(object sender, EventArgs e)
        {
            p.Vendorname = textBox1.Text;
            p.Contactname = textBox2.Text;
            p.Email = textBox3.Text;
            DataTable dt = new DataTable();
            dt = c.loadvendor3(p);
            if (p.Vendorname != null && p.Contactname != null && p.Email != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    textBox4.Text = dataGridView1.RowCount.ToString();
                }
            }
        }         
        //******************** SHOW ***********************//
        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.DropDownHeight = 1;
            comboBox1.DropDownWidth = 1;
            pnlshow.Visible = true;
            pnlshow.Location = new Point(96,169);
            pnlshow.Name = "show";
            pnlshow.BackColor = Color.WhiteSmoke;
            pnlshow.BorderStyle = BorderStyle.FixedSingle;
            pnlshow.Size = new Size(699,75);
            this.Controls.Add(pnlshow);
            pnlshow.Controls.Add(chkactive);
            pnlshow.Controls.Add(chkinactive);
            pnlshow.Controls.Add(chkall);
            pnlshow.BringToFront();

            chkactive.Text = "Active";
            chkactive.Location = new Point(3,3);
            chkactive.Size = new Size(80,17);

            chkinactive.Text = "Inactive";
            chkinactive.Location = new Point(3,26);
            chkinactive.Size = new Size(80, 17);

            chkall.Text = "All";
            chkall.Location = new Point(3,49);
            chkall.Size = new Size(80, 17);

            chkactive.CheckedChanged += new EventHandler(chkactive_CheckedChanged);
            chkinactive.CheckedChanged += new EventHandler(chkinactive_CheckedChanged);
            chkall.CheckedChanged += new EventHandler(chkall_CheckedChanged);
        }
        private void chkactive_CheckedChanged(object sender, EventArgs e)
        {
            p.ShowL = comboBox1.Text;
            if (chkactive.Checked == true)                    //*****************ACTIVE***********//
            {
                dt = c.selecshow(p);
                comboBox1.Text = chkactive.Text;
                chkinactive.Checked = false;
                chkall.Checked = false;
                pnlshow.Visible = false;            
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = dataGridView1.RowCount.ToString();
                }
            }
        }
        private void chkinactive_CheckedChanged(object sender, EventArgs e)
        {
                p.ShowL = comboBox1.Text;                     //***********INACTIVE******************//
                dt = c.selecshow(p);
                comboBox1.Text = chkinactive.Text;
                chkactive.Checked = false;
                chkall.Checked = false;
                pnlshow.Visible = false;             
         
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = true;

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = dataGridView1.RowCount.ToString();
           
        }
        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
                p.ShowL = comboBox1.Text;
                dt = c.selectvendor();
                  //*************SHOW ALL*******************//
                comboBox1.Text = chkall.Text;
                chkactive.Checked = false;
                chkinactive.Checked = false;
                pnlshow.Visible = false;
           
                   dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = true;
              
             for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                 checkBoxColumn.TrueValue = CheckState.Unchecked;
                 checkBoxColumn.FalseValue = CheckState.Checked;
                 BAL.Status = Convert.ToString(dataGridView1.Rows[i].Cells[15].Value);
                 if (BAL.Status == "Active")
                 {
                     dataGridView1.Rows[i].Cells[0].Value = checkBoxColumn.TrueValue;
                 }
                 else if (BAL.Status == "Inactive")
                 {
                     dataGridView1.Rows[i].Cells[0].Value = checkBoxColumn.FalseValue;
                 }
             }
             textBox1.Text = "";
             textBox2.Text = "";
             textBox3.Text = "";
             textBox4.Text = dataGridView1.RowCount.ToString();
        }
        private void vendorlist_Load(object sender, EventArgs e)
        {

            panel1.BackColor = ColorTranslator.FromHtml("#FFC041");
            this.BackColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF0B3");
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            pnlshow.Visible = false; 

            checkBoxColumn.HeaderText = "select";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "select";
            dataGridView1.Columns.Insert(0, checkBoxColumn);
            dataGridView1.Columns[0].Visible = false;
            if (dataGridView1.Rows.Count > 0)
            {
                textBox4.Text = dataGridView1.RowCount.ToString();
            }
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                BAL.NamL = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DataTable dt = c.selectvendrname1(p);

                VendorInfo vinfo = new VendorInfo();
            

                if (dt.Rows.Count > 0)
                {
                 
                    vinfo.textBox4.Text = dt.Rows[0]["vendorname"].ToString();
                    vinfo.textBox5.Text = dt.Rows[0]["balance"].ToString();
                    vinfo.textBox6.Text = dt.Rows[0]["credit"].ToString();
                    vinfo.textBox7.Text = dt.Rows[0]["contactname"].ToString();
                    vinfo.textBox8.Text = dt.Rows[0]["phone"].ToString();
                    vinfo.textBox9.Text = dt.Rows[0]["fax"].ToString();
                    vinfo.textBox11.Text = dt.Rows[0]["email"].ToString();
                    vinfo.textBox10.Text = dt.Rows[0]["website"].ToString();
                    vinfo.textBox15.Text = dt.Rows[0]["remarks"].ToString();
                    vinfo.textBox13.Text = dt.Rows[0]["address"].ToString();
                    vinfo.comboBox2.Text = dt.Rows[0]["paymentterms"].ToString();
                    vinfo.comboBox3.Text = dt.Rows[0]["taxingscheme"].ToString();
                    vinfo.comboBox4.Text = dt.Rows[0]["carrier"].ToString();
                    vinfo.comboBox5.Text = dt.Rows[0]["currency"].ToString();
                    vinfo.textBox16.Text = dt.Rows[0]["alternatecontact"].ToString();
                    vinfo.textBox17.Text = dt.Rows[0]["emergencyphone"].ToString();
                    vinfo.textBox12.Text = dt.Rows[0]["dob"].ToString();
                    vinfo.textBox14.Text = dt.Rows[0]["residence"].ToString();
                    vinfo.textBox18.Text = dt.Rows[0]["city"].ToString();
                    vinfo.textBox19.Text = dt.Rows[0]["state"].ToString();
                    vinfo.textBox20.Text = dt.Rows[0]["country"].ToString();
                    vinfo.textBox21.Text = dt.Rows[0]["zipcode"].ToString();
                    vinfo.comboBox7.Text = dt.Rows[0]["status"].ToString();
                    String a = dt.Rows[0]["status"].ToString();
                    if (a == "Active")
                    {
                        vinfo.btndeactive.Text = "Deactivate";
                    }
                    else
                    {
                        vinfo.btndeactive.Text = "Reactivate";
                    }
                    BAL.Nam = "";
                }
         

                vinfo.Show();
              
            }
            }
        
        private void vendorlist_Click(object sender, EventArgs e)
        {
            pnlshow.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                BAL.NamL = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DataTable dt = c.selectvendrname1(p);

                VendorInfo vinfo = new VendorInfo();
           

                if (dt.Rows.Count > 0)
                {
                   
                    vinfo.textBox4.Text = dt.Rows[0]["vendorname"].ToString();
                    vinfo.textBox5.Text = dt.Rows[0]["balance"].ToString();
                    vinfo.textBox6.Text = dt.Rows[0]["credit"].ToString();
                    vinfo.textBox7.Text = dt.Rows[0]["contactname"].ToString();
                    vinfo.textBox8.Text = dt.Rows[0]["phone"].ToString();
                    vinfo.textBox9.Text = dt.Rows[0]["fax"].ToString();
                    vinfo.textBox11.Text = dt.Rows[0]["email"].ToString();
                    vinfo.textBox10.Text = dt.Rows[0]["website"].ToString();
                    vinfo.textBox15.Text = dt.Rows[0]["remarks"].ToString();
                    vinfo.textBox13.Text = dt.Rows[0]["address"].ToString();
                    vinfo.comboBox2.Text = dt.Rows[0]["paymentterms"].ToString();
                    vinfo.comboBox3.Text = dt.Rows[0]["taxingscheme"].ToString();
                    vinfo.comboBox4.Text = dt.Rows[0]["carrier"].ToString();
                    vinfo.comboBox5.Text = dt.Rows[0]["currency"].ToString();
                    vinfo.textBox16.Text = dt.Rows[0]["alternatecontact"].ToString();
                    vinfo.textBox17.Text = dt.Rows[0]["emergencyphone"].ToString();
                    vinfo.textBox12.Text = dt.Rows[0]["dob"].ToString();
                    vinfo.textBox14.Text = dt.Rows[0]["residence"].ToString();
                    vinfo.textBox18.Text = dt.Rows[0]["city"].ToString();
                    vinfo.textBox19.Text = dt.Rows[0]["state"].ToString();
                    vinfo.textBox20.Text = dt.Rows[0]["country"].ToString();
                    vinfo.textBox21.Text = dt.Rows[0]["zipcode"].ToString();
                    vinfo.comboBox7.Text = dt.Rows[0]["status"].ToString();
                    String a = dt.Rows[0]["status"].ToString();
                    if (a == "Active")
                    {
                        vinfo.btndeactive.Text = "Deactivate";
                    }
                    else
                    {
                        vinfo.btndeactive.Text = "Reactivate";
                    }
                    BAL.Nam = "";
                    vinfo.Show();
                }
            }
        }
        }
}


