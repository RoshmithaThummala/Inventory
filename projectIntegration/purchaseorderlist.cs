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
    public partial class purchaseorderlist : Form
    {
        BAL p = new BAL();
        DAL c = new DAL();
        Panel pnlvend = new Panel();
        Panel pnlprclist = new Panel();
        Panel pnlpay = new Panel();

        CheckBox chkunpaid = new CheckBox();
        CheckBox chkpaid = new CheckBox();
        CheckBox chkpartial = new CheckBox();
        CheckBox chkall = new CheckBox();

        CheckBox chkcancel = new CheckBox();
        CheckBox chkreopen = new CheckBox(); 
        DataGridView dvgvend = new DataGridView();
        Button btnvend = new Button();
        DataTable dt = new DataTable();

        public purchaseorderlist()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dt = c.selectpurclist();
            dataGridView1.DataSource = dt;

            //******* bind vendornames list**********//
            dvgvend.DataSource = c.loadvname();
            
        }
        //***************************SEARCH BASED ON ORDER NO*************//
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            p.PoordernoL = textBox1.Text;
            dt = c.loadorderno(p);

            dataGridView1.DataSource = dt;
            textBox2.Text = dataGridView1.RowCount.ToString();
            panel2.Visible = false;
        }
        //---------------------  SEARCH BASED ON INVENTORY STATUS ---------------- //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            p.InventorystatusL = checkBox1.Text;                     // status unfulfilled//
            if (checkBox1.Checked == true)
            {
                comboBox1.Text = checkBox1.Text;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                dt = c.loadinvtstatus(p);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
                }
                panel2.Visible = false;
            }
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
           
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            p.InventorystatusL = checkBox2.Text;                      // status fulfilled //
            if (checkBox2.Checked == true)
            {
                comboBox1.Text = checkBox2.Text;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                dt = c.loadinvtstatus(p);
               
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
                
                panel2.Visible = false;
            }
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
           
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            p.InventorystatusL = checkBox3.Text;                         //  status partial  //
            if (checkBox3.Checked == true)
            {
                comboBox1.Text = checkBox3.Text;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                dt = c.loadinvtstatus(p);
               
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
               
                panel2.Visible = false;
            }
        }
        private void checkBox3_Click(object sender, EventArgs e)
        {
           
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)                           //*** status ALL******* //
            {
                comboBox1.Text = checkBox4.Text;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                dt = c.selectpurclist();
              
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
               
                panel2.Visible = false;
            }
        }
        private void checkBox4_Click(object sender, EventArgs e)
        {
           
        }
        //************** INVENTORY STATUS***************  //
        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.DropDownHeight = 1;
            comboBox1.DropDownWidth = 1;
            panel2.Visible = true;
            panel2.BackColor = Color.White;
            p.InventorystatusL = comboBox1.Text;
            dt = c.loadinvtstatus(p); 
        }
        // ******************PAYMENT STATUS ****************** //
        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.DropDownHeight = 1;
            comboBox2.DropDownWidth = 1;
            panel2.Visible = false;
            pnlvend.Visible = false;
            pnlpay.Visible = true;
            pnlpay.BackColor = Color.White;
            pnlpay.BorderStyle = BorderStyle.FixedSingle;

            pnlpay.Location = new Point(100, 134);
            pnlpay.Name = "payment status";
          
            pnlpay.Size = new Size(699, 75);
            this.Controls.Add(pnlpay);

            pnlpay.Controls.Add(chkunpaid);
            pnlpay.Controls.Add(chkpaid);
            pnlpay.Controls.Add(chkpartial);
            pnlpay.Controls.Add(chkall);
            pnlpay.BringToFront();

            chkunpaid.Text = "Unpaid";
            chkunpaid.Location = new Point(3, 21);
            chkunpaid.Size = new Size(60, 17);

            chkpaid.Text = "Paid";
            chkpaid.Location = new Point(3, 42);
            chkpaid.Size = new Size(47, 17);

            chkpartial.Text = "Partial";
            chkpartial.Location = new Point(3, 57);
            chkpartial.Size = new Size(55, 17);

            chkall.Text = "All";
            chkall.Location = new Point(3, 6);
            chkall.Size = new Size(37, 17);

            chkunpaid.CheckedChanged += new EventHandler(chkunpaid_CheckedChanged);
            chkpaid.CheckedChanged += new EventHandler(chkpaid_CheckedChanged);
            chkpartial.CheckedChanged += new EventHandler(chkpartial_CheckedChanged);
            chkall.CheckedChanged += new EventHandler(chkall_CheckedChanged);

       
        }
        //-----------  PAYMENT STATUS---------------- //
        private void chkunpaid_CheckedChanged(object sender, EventArgs e)
        {
            p.PaymentstatusL = chkunpaid.Text;
            if (chkunpaid.Checked == true)                               // Unpaid//
            {
                chkunpaid.Checked = true;
                dt = c.loadpaystatus(p);
                comboBox2.Text = chkunpaid.Text;
                chkpaid.Checked = false;
                chkpartial.Checked = false;
                chkall.Checked = false;
               
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
              
                pnlpay.Visible = false;
            }
        }
        private void chkpaid_CheckedChanged(object sender, EventArgs e)
        {
            p.PaymentstatusL = chkpaid.Text;
            if (chkpaid.Checked == true)                                 // paid//
            {
                dt = c.loadpaystatus(p);
                comboBox2.Text = chkpaid.Text;
                chkunpaid.Checked = false;
                chkpartial.Checked = false;
                chkall.Checked = false;
              
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
               
                pnlpay.Visible = false;
            }
        }
        private void chkpartial_CheckedChanged(object sender, EventArgs e)
        {
            p.PaymentstatusL = chkpartial.Text;                            // Started//
            if (chkpartial.Checked == true) 
            {
                chkpartial.Checked = true;
                dt = c.loadpaystatus(p);
                comboBox2.Text = chkpartial.Text;
                chkunpaid.Checked = false;
                chkpaid.Checked = false;
                chkall.Checked = false;
              
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
               
                pnlpay.Visible = false;
            }
        }
        
        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            dt = c.selectpurclist();                                // payment status ALL //
            comboBox2.Text = chkall.Text;
            chkunpaid.Checked = false;
            chkpaid.Checked = false;
            chkpartial.Checked = false;
           
                dataGridView1.DataSource = dt;
                textBox2.Text = dataGridView1.RowCount.ToString();
          
            pnlpay.Visible = false;
        }
        //************************** DYNAMIC CREATION OF DATAGRIDVIEW **************//
        //-------------------- vendorName and details------------------------------------//
        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox3.DropDownHeight = 1;
            comboBox3.DropDownWidth = 1;
            pnlpay.Visible = false;
            pnlvend.Visible = true;
            btnvend.Visible = true;
            pnlvend.BackColor=Color.White;
            pnlvend.Location = new Point(98, 171);
            pnlvend.Name = "Vendors";
          
            pnlvend.Size = new Size(699,161);
            this.Controls.Add(pnlvend);
            pnlvend.BorderStyle = BorderStyle.FixedSingle;

            pnlvend.Controls.Add(dvgvend);
            pnlvend.Controls.Add(btnvend);
            pnlvend.BringToFront();

          
            dvgvend.BackgroundColor = Color.White;
            dvgvend.Location = new Point(3,2);
            dvgvend.Size = new Size(688, 117);
            DataGridViewColumn column2 = dvgvend.Columns[0];
            column2.Width = 210;
            DataGridViewColumn column = dvgvend.Columns[1];
            column.Width = 210;
            DataGridViewColumn column1 = dvgvend.Columns[2];
            column1.Width = 210;
         
            dvgvend.Columns[0].Visible = false;
            if (dvgvend.ColumnCount == 3)
            {
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            dvgvend.Columns.Add(lnk);
        
            lnk.HeaderText = "View Details";
            lnk.Name = "View Details";
            lnk.Text = "View Details";
            lnk.ActiveLinkColor = Color.White;
            lnk.Width = 210;
            lnk.LinkBehavior = LinkBehavior.SystemDefault;
            lnk.UseColumnTextForLinkValue = true;
            }
            btnvend.Text = "Add New Name";
            btnvend.Location = new Point(305,126);
            btnvend.Size = new Size(75,23);
            btnvend.BackColor = Color.YellowGreen;
            dvgvend.CellClick -= new DataGridViewCellEventHandler(dvgvend_CellClick);
            dvgvend.CellClick += new DataGridViewCellEventHandler(dvgvend_CellClick);

            dvgvend.CellContentClick -= new DataGridViewCellEventHandler(dvgvend_CellContentClick);
            dvgvend.CellContentClick += new DataGridViewCellEventHandler(dvgvend_CellContentClick);
            btnvend.Click -= new EventHandler(btnvend_Click);
            btnvend.Click += new EventHandler(btnvend_Click);
            pnlvend.Leave += new EventHandler(pnlvend_Leave);
        }
        private void dvgvend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         
         
            if (e.ColumnIndex == 3)
            {
                BAL.NamL = dvgvend.CurrentRow.Cells[0].Value.ToString();

               dt = c.loadvendname1(p);
                PurhcaseOrder pur = new PurhcaseOrder();
                pur.Show();
                pnlvend.Visible = false;
            }
            
        
         
       
        }
        private void dvgvend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                comboBox3.Text = dvgvend.CurrentRow.Cells[1].Value.ToString();
                BAL.NamL = dvgvend.CurrentRow.Cells[1].Value.ToString();
             
                dataGridView1.DataSource = c.loadvendname(p);

                pnlvend.Visible = false;
            }
        }
        private void dvgvend_Leave(object sender, EventArgs e)
        {
            dvgvend.Visible = false;
        }
        private void btnvend_Click(object sender, EventArgs e)
        {
            PurhcaseOrder obj = new PurhcaseOrder();
            obj.Show();
        }
        private void pnlvend_Leave(object sender, EventArgs e)
        {
          
           pnlvend.Visible = false;
        }
        //**************************** Show ******************//
        private void comboBox4_Click(object sender, EventArgs e)
        {
           // comboBox4.DropDownHeight = 1;
           // comboBox4.DropDownWidth = 1;
           // pnlprclist.Visible = true;
           // pnlprclist.BackColor = Color.White;
           // pnlprclist.Location = new Point(100,210);
           // pnlprclist.Name = "Vendors";
           // pnlprclist.BackColor = Color.WhiteSmoke;
           // pnlprclist.BorderStyle = BorderStyle.FixedSingle;
           // pnlprclist.Size = new Size(699,50);
           // this.Controls.Add(pnlprclist);
           // pnlprclist.Controls.Add(chkcancel);
           // pnlprclist.Controls.Add(chkreopen);
           // pnlprclist.BringToFront();

           // chkcancel.Text = "Cancel order";
           // chkcancel.Location = new Point(3, 6);
           // chkcancel.Size = new Size(90, 17);

           // chkreopen.Text = "Reopen order";
           // chkreopen.Location = new Point(3, 22);
           // chkreopen.Size = new Size(90,17);

           // chkcancel.CheckedChanged += new EventHandler(chkcancel_CheckedChanged);
           // chkreopen.CheckedChanged += new EventHandler(chkreopen_CheckedChanged);
           //// pnlvend.Leave += new EventHandler(pnlvend_Leave);

           // p.ShowcancelledL = comboBox4.Text;
           // dt = c.selecshowcanc(p);                //cancel order//
           // //if (dt.Rows.Count > 0)
           // //{
           // //    dataGridView1.DataSource = dt;
           // //}
           // //else if (dt.Rows.Count > 0)              //Reopen order//
           // //{
           // //    dataGridView1.DataSource = dt;
           // //}
        }
        private void chkcancel_CheckedChanged(object sender, EventArgs e)
        {
            p.ShowcancelledL = comboBox4.Text;                   //cancel order//
         
            if (chkcancel.Checked == true)
            {
                comboBox4.Text = chkcancel.Text;
                chkreopen.Checked = false;
                dt = c.selecshowcanc(p);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
                }
                pnlprclist.Visible = false;
            }
        }
        private void chkreopen_CheckedChanged(object sender, EventArgs e)
        {
            p.ShowcancelledL = comboBox4.Text;
            if (chkreopen.Checked == true)                      //Reopen order//
            {
                dt = c.selecshowcanc(p); 
                comboBox4.Text = chkreopen.Text;
                chkcancel.Checked = false;
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    textBox2.Text = dataGridView1.RowCount.ToString();
                }
                pnlprclist.Visible = false;
            }
        }      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)row.Cells[0];
                if (cel.Selected == true)
                {
                    comboBox3.Text = row.Cells[4].Value.ToString();
                }
            }
            BAL.NamL = comboBox3.Text;
            dt = c.loadvendname(p);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                textBox2.Text = dataGridView1.RowCount.ToString();
            }
            string text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (e.ColumnIndex == 0)
            {
                BAL.NamL = text;
                PurhcaseOrder pur = new PurhcaseOrder();
                pur.Show();
                
                pnlvend.Visible = false;
            }
        }
        private void purchaseorderlist_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#FFC041");
            this.BackColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF0B3");
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE066");
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            if (dataGridView1.Rows.Count > 0)
            {
               
                textBox2.Text = dataGridView1.RowCount.ToString();
            }
        }
        private void purchaseorderlist_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            pnlpay.Visible = false;
            pnlvend.Visible = false;
            pnlprclist.Visible = false;
        }
    }
}
