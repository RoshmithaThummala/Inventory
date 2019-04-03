using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace InventoryTools
{
    public partial class SaleOrderList : Form
    {
        DAL dl = new DAL();
        BAL bl = new BAL();
        public SaleOrderList()
        {
            InitializeComponent();
        }
        //LOADING THE PAGE......
        private void SaleOrderList_Load(object sender, EventArgs e)
        {
            orderno.Visible = false;
            custname.Visible = false;
            CUSTOMERNAME.Visible = false;
            SEARCHTEXT.Visible = false;
            pictureBox1.BackColor = Color.Violet;
            grouppanel.BackColor = Color.White;
            pictureBox1.Visible = false;
            grouppanel.Visible = false;
            paymentpanel.Visible = false;
            CustomerGrid.Visible = false;
            inventorypanel.Visible = false;
            BACKGRNDPANEL.BackColor = Color.Yellow;
            salesoredrPANEL.BackColor = Color.YellowGreen;
            inventorypanel.BackColor = Color.White;
            paymentpanel.BackColor = Color.White;
            FULLDETAILSgrid.DefaultCellStyle.BackColor = Color.Khaki;
            SALESQUOTE.SelectedItem = null;
            FULLDETAILSgrid.EnableHeadersVisualStyles = false;
            FULLDETAILSgrid.Columns[0].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[1].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[2].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[3].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[4].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[5].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[6].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[7].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[8].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[9].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[10].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[11].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[12].HeaderCell.Style.BackColor = Color.GreenYellow;
            FULLDETAILSgrid.Columns[13].HeaderCell.Style.BackColor = Color.GreenYellow;


            DataTable dt = dl.directlybindingtoGRID(bl);

            foreach (DataRow d in dt.Rows)
            {
                int n = FULLDETAILSgrid.Rows.Add();
                FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
              
                FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();

            }
            
        }
        //SEARCH THE DATA BY ORDER_NO_BY..USING THE TEXTBO....TEXT_CHANGED_EVENT......
        private void order_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            PaymentStatus.Items.Clear();
            Inventorystatus.Items.Clear();
            FULLDETAILSgrid.Rows.Clear();
            SHOWCANCELLED.Text = string.Empty;
            SALESQUOTE.Text = string.Empty;
            ORDERDATE.Text = string.Empty;
            ORDERDATE.Text = string.Empty;
            Customer.Text = string.Empty;
            Customer.Items.Clear();
            try
            {
                bl.Orderno = order.Text;
                DataTable dt = dl.searchbynumberlike(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
              
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        ////WHEN WE ARE ENTER TO THE ORDERDATE....THEN CLEAR THE REMAINIG ALL BOXES DATA.................
        private void ORDERDATE_MouseClick(object sender, MouseEventArgs e)
        {
            FULLDETAILSgrid.Columns[2].Visible = true;
            FULLDETAILSgrid.Columns[3].Visible = true;
            FULLDETAILSgrid.Columns[13].Visible = false;
            CustomerGrid.Visible = false;
            SEARCHTEXT.Visible = false;
            pictureBox1.Visible = false;
            order.Clear();
            pictureBox1.Visible = false;
            inventorypanel.Visible = false;
            paymentpanel.Visible = false;
            Inventorystatus.Text = string.Empty;
            PaymentStatus.Text = string.Empty;
            Customer.Text = string.Empty;
            SALESQUOTE.Text = string.Empty;
            SHOWCANCELLED.Text = string.Empty;
            grouppanel.Visible = true;
            grouppanel.Text = string.Empty;
        }
        //BIND THE THE ALL DATA TO THE FULLDETAILS....GRID..............................
        private void ALLTXT_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = ALLTXT.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.directlybindingtoGRID(bl);
            foreach (DataRow d in dt.Rows)
            {
                int n = FULLDETAILSgrid.Rows.Add();
                FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
            
                FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
            }
            grouppanel.Visible = false;
        }
        //BIND THE THIS MONTH DATA TO THE FULLDETAILGRID............................
        private void ThisMonthtxt_Click(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            ORDERDATE.Text = ThisMonthtxt.Text;
            DataTable dt = dl.THISMONTH(bl);
            //IF DATA IN  THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();

                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
              
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS  TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE LASTYEAR DATA...................
        private void LastYeartxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = LastYeartxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.LASTYEAR(bl);
            //IF DATA IN THIS  TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();

                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS  TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE THISYEAR DATA....................................
        private void ThisYeartct_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = ThisYeartct.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.THISYAER(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS  TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE YSTERDAY DATA.................................
        private void Yesterdaytxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = Yesterdaytxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.YESTERDAY(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE LASTMONTH DATA..............................
        private void LastMonthtxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = LastMonthtxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.LASTMONTH(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS  TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE TOMARROW DATA.................
        private void Tomarrowtxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = Tomarrowtxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.TOMARROW(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                 
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }

            }
            //IF THERS IS NO DATA IN THIS  TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE NEXTMONTH DATA.....................
        private void NextMonthtxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = NextMonthtxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.NEXTmonth(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE NEXT YEAR DATA........................
        private void NextYeartxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = NextYeartxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.NEXTYEAR(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                 
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE LAST_7_DAYS DATA...........................
        private void Last7Daystxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = Last7Daystxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.LAST_7_DAYS(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE LAST_30_DAYS DATA.................................
        private void Last30Daystxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = Last30Daystxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.LAST_30_DAYS(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE LASTWEEK DATA.....................
        private void LastWeektxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = LastWeektxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.LAST_WEEK(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO DATA IN THIS TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE THIS WEEK DATA............................
        private void ThisWeektxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = ThisWeektxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.THIS_WEEK(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO THIS DATA IN TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //DISPLAY THE NEXTWEEK DATA............
        private void NextWeektxt_Click(object sender, EventArgs e)
        {
            ORDERDATE.Text = NextWeektxt.Text;
            FULLDETAILSgrid.Rows.Clear();
            DataTable dt = dl.NEXT_WWEEK(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[7].Value = d["requestedshipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO THIS DATA IN TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //SEARCH THE ORDERDATE RELATED DATABY USING THE CUSTDATERNGE_CLICK...........
        private void CUSTDATERANGE_Click(object sender, EventArgs e)
        {
            bl.From_date_ = FROMDATE.Text;
            bl.To_date_ = TODATE.Text;
            FULLDETAILSgrid.Rows.Clear();
            ORDERDATE.Text = CUSTDATERANGE.Text;
            DataTable dt = dl.searchdate_by_frm2todate(bl);
            //IF DATA IN THIS TABLE THEN IT BIND TO THE FULLDETAILSGRID.........................
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[7].Value = d["requestedshipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF THERS IS NO THIS DATA IN TABLE THEN IT SHOWS THE O DATA AVAILABLEPICTURE....................
            else
            {
                pictureBox1.Visible = true;
            }
            grouppanel.Visible = false;
        }
        //BIND THE DATE VALUE OF FROM DATE INTO FROMDATE__COMBO_................
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.FROM_dateTimePicker1.Value;
            this.FROMDATE.Text = date.ToString("MM/dd/yyyy");
        }
        //BIND THE DATE VALUE OF TO DATE INTO FROMDATE__COMBO_................
        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime date = this.TO_dateTimePicker2.Value;
            this.TODATE.Text = date.ToString("MM/dd/yyyy");
        }

        //TO ADD THE DATA TO THE SALES_QUOTE AND ALSO..TO CLEAR THE REMAINING BOXES DATA......................
        private void SALESQUOTE_DropDown(object sender, EventArgs e)
        {
            inventorypanel.Visible = false;
            paymentpanel.Visible = false;
            orderno.Visible = false;
            custname.Visible = false;
            CUSTOMERNAME.Visible = false;
            CustomerGrid.Visible = false;
            SEARCHTEXT.Visible = false;
            pictureBox1.Visible = false;
            order.Clear();
            Inventorystatus.Text = string.Empty;
            PaymentStatus.Text = string.Empty;
            Customer.Text = string.Empty;
            SHOWCANCELLED.Text = string.Empty;
            ORDERDATE.Text = string.Empty;
            SHOWCANCELLED.Text = string.Empty;
            SALESQUOTE.Items.Clear();
            SALESQUOTE.Items.Add("Orders only");
            SALESQUOTE.Items.Add("Quote only");
            SALESQUOTE.Items.Add("Orders and Quotes");
        }
        private void SALESQUOTE_SelectedIndexChanged(object sender, EventArgs e)
        {

            FULLDETAILSgrid.Rows.Clear();
            //IF WE SELECTED QUOTES ONLY THEN INVENTORYSTATUS and PAYMNETSTATUS...HEADRTEXTS OF FULLDETAIL GRID WILL BE NOT VISIBLE.....
            if (SALESQUOTE.SelectedIndex == 1)
            {
                FULLDETAILSgrid.Columns[13].Visible = true;
                FULLDETAILSgrid.Columns[2].Visible = false;
                FULLDETAILSgrid.Columns[3].Visible = false;
                DataTable dt = dl.selectquotes(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["sno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["shipdate"].ToString();
                
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[7].Value = d["quotedate"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["subtotal"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["subtotal"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[13].Value = d["status"].ToString();
                }
            }
            //IF WE SELECTED ORDERS ONLY THEN STATUS HEADERTEXT OF FULLDETAIL GRID WILL BE NOT VISIBLE................
            if (SALESQUOTE.SelectedIndex == 0)
            {
                FULLDETAILSgrid.Columns[13].Visible = false;
                FULLDETAILSgrid.Columns[2].Visible = true;
                FULLDETAILSgrid.Columns[3].Visible = true;
                DataTable dt = dl.directlybindingtoGRID(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
            
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF WE SELECTED ORDERS and QUOTES THEN...THE TWO TABLES OF ORDERS and QUOTE ARE COMBIND TO DISPLAY IN FULLDETAILGRIDVIEW......
            if (SALESQUOTE.SelectedIndex == 2)
            {
                FULLDETAILSgrid.Columns[13].Visible = true;
                FULLDETAILSgrid.Columns[2].Visible = true;
                FULLDETAILSgrid.Columns[3].Visible = true;
                DataTable dt = dl.selectquotes(bl);
                //IT IS THE TABLE OF QUOTES..................
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["sno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[7].Value = d["quotedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["subtotal"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["subtotal"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[13].Value = d["status"].ToString();
                }
                //THIS IS THE TABLE OF ORDERS...................
                DataTable dt1 = dl.directlybindingtoGRID(bl);
                foreach (DataRow d in dt1.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
               
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
        }

        //ADD THE ITEMS TO THE SHOW CANCELLED AND ALSO TO CLEAR TH DATA OF REMAINIG BOXES.............
        private void SHOWCANCELLED_DropDown(object sender, EventArgs e)
        {
            orderno.Visible = false;
            custname.Visible = false;
            CUSTOMERNAME.Visible = false;
            FULLDETAILSgrid.Columns[2].Visible = true;
            FULLDETAILSgrid.Columns[3].Visible = true;
            FULLDETAILSgrid.Columns[13].Visible = false;
            CustomerGrid.Visible = false;
            SEARCHTEXT.Visible = false;
            pictureBox1.Visible = false;
            order.Clear();
            inventorypanel.Visible = false;
            paymentpanel.Visible = false;
            Inventorystatus.Text = string.Empty;
            PaymentStatus.Text = string.Empty;
            Customer.Text = string.Empty;
            ORDERDATE.Text = string.Empty;
            SALESQUOTE.Text = string.Empty;
            SHOWCANCELLED.Items.Clear();
            SHOWCANCELLED.Items.Add("ActiveOnly");
            SHOWCANCELLED.Items.Add("Cancelled");
            SHOWCANCELLED.Items.Add("Active and CANCELLED");
        }
        //FILL THE DATA TO FULLDEATAILSGRID BY RELATED SELECTEDINDEX OF SHOWCANCELLED..........
        private void SHOWCANCELLED_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IF WE SELECTED ACTIVE ONLYE THEN ACTIVE RELATED DATA BIND TO THE FULLDETAILSGIRD.............
            FULLDETAILSgrid.Rows.Clear();
            if (SHOWCANCELLED.SelectedIndex == 0)
            {

                DataTable dt = dl.ACTIVE(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF WE SELECTED CANCELLED ONLYE THEN CANCELLED RELATED DATA BIND TO THE FULLDETAILSGIRD.............
            if (SHOWCANCELLED.SelectedIndex == 1)
            {
                bl.Inventorystatus = SHOWCANCELLED.Text;
                DataTable dt = dl.CANCELLED(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                 
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
            //IF WE SELECTED BOTH ACTIVE AND CANCELLED INSDEX THEN ACTIVE AND CANCELLED RELATED DATA BIND TO THE FULLDETAILSGIRD...........
            if (SHOWCANCELLED.SelectedIndex == 2)
            {
                //TABLE OF AVTIVE......
                DataTable dt = dl.ACTIVE(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                 
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                //TABEL OF CANCELLED..............
                DataTable dt1 = dl.activecancelled(bl);
                foreach (DataRow d in dt1.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
            }
        }
        //DISPLAY THE ALL CHECKBOXES OF INVENTORY__STATUS__BY USING THE COMBOBOX__ENTER EVENT..............
        //WHEN WE ARE COME TO INVENTORY DROP DOWN THEN REAMAING ALL BOXES DATA WILL BE CLEAR............
        private void Inventorystatus_MouseClick(object sender, MouseEventArgs e)
        {
            FULLDETAILSgrid.Columns[13].Visible = false;
            FULLDETAILSgrid.Columns[2].Visible = true;
            FULLDETAILSgrid.Columns[3].Visible = true;
            orderno.Visible = false;
            custname.Visible = false;
            CUSTOMERNAME.Visible = false;
            SEARCHTEXT.Visible = false;
            pictureBox1.Visible = false;
            ORDERDATE.Text = string.Empty;
            SHOWCANCELLED.Text = string.Empty;
            SALESQUOTE.Text = string.Empty;
            All.Checked = false;
            UnInvoiced.Checked = false;
            Invoiced.Checked = false;
            Partial.Checked = false;
            Paid.Checked = false;
            Owing.Checked = false;
            order.Clear();
            inventorypanel.Visible = true;
            CustomerGrid.Visible = false;
            paymentpanel.Visible = false;
            Customer.Text = string.Empty;
            PaymentStatus.Text = string.Empty;
        }
        //CHECK__BOX...UNFULLFILLED....__BOX OF THE INVENTORY_STATUS__UNFULFILLED.............
        private void Unfulfilled_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            FULLDETAILSgrid.Rows.Clear();
            if (UnFulfilled.Checked == true)
            {

                Fulfilled.Checked = false;
                Started.Checked = false;
                bl.Inventorystatus = UnFulfilled.Text;
                Inventorystatus.Text = UnFulfilled.Text;
                DataTable dt = dl.select_UNFULFILLED(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                inventorypanel.Visible = false;
                paymentpanel.Visible = false;
            }
        }
        //CHECK__BOX...FULLFILLED.....__BOX OF THE INVENTORY_STATUS__FULLFILLED.............
        private void fulfilled_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            FULLDETAILSgrid.Rows.Clear();
            if (Fulfilled.Checked == true)
            {
                bl.Inventorystatus = Fulfilled.Text;
                UnFulfilled.Checked = false;
                Started.Checked = false;
                Inventorystatus.Text = Fulfilled.Text;
                DataTable dt = dl.select_FULLFILLED(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                inventorypanel.Visible = false;
                paymentpanel.Visible = false;
            }
        }
        //CHECK__BOX...STARTED...__BOX OF THE INVENTORY_STATUS__Started.............
        private void Started_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            if (Started.Checked == true)
            {
                UnFulfilled.Checked = false;
                Fulfilled.Checked = false;
                bl.Inventorystatus = Started.Text;
                Inventorystatus.Text = Started.Text;
                DataTable dt = dl.select_started(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                   
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                inventorypanel.Visible = false;
                paymentpanel.Visible = false;
            }
        }
        //DISPLAY THE ALL CHECKBOXES OF PAYMENT__STATUS__BY USING THE COMBOBOX__ENTER EVENT..............

        //WHEN WE ARE ENTER INTO THE PAYMENT DROP DOWN THEN REMAINING ALL BOXES DATA WILL BE CLAR........
        private void PaymentStatus_MouseClick(object sender, MouseEventArgs e)
        {
            FULLDETAILSgrid.Columns[2].Visible = true;
            FULLDETAILSgrid.Columns[3].Visible = true;
            orderno.Visible = false;
            custname.Visible = false;
            CUSTOMERNAME.Visible = false;
            SEARCHTEXT.Visible = false;
            pictureBox1.Visible = false;
            ORDERDATE.Text = string.Empty;
            SHOWCANCELLED.Text = string.Empty;
            SALESQUOTE.Text = string.Empty;
            UnFulfilled.Checked = false;
            Fulfilled.Checked = false;
            Started.Checked = false;
            order.Clear();
            paymentpanel.Visible = true;
            CustomerGrid.Visible = false;
            inventorypanel.Visible = false;
            Customer.Text = string.Empty;
            Inventorystatus.Text = string.Empty;
        }
        //CHECK__BOX..ALL...__BOX OF THE PAYMENT__ALL..............
        private void ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                Invoiced.Checked = false;
                UnInvoiced.Checked = false;
                Paid.Checked = false;
                Partial.Checked = false;
                Owing.Checked = false;

                PaymentStatus.Text = All.Text;
                FULLDETAILSgrid.Rows.Clear();
                DataTable dt = dl.selct_by_payment_ALL(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
              
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                paymentpanel.Visible = false;
            }
        }
        //CHECK__BOX__UNINVOICED....BOX OF THE PAYMENT__UNINVOICE..............
        private void UnInvoiced_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            if (UnInvoiced.Checked == true)
            {
                All.Checked = false;
                Invoiced.Checked = false;
                Paid.Checked = false;
                Partial.Checked = false;
                Owing.Checked = false;
                bl.Paymentstatus = UnInvoiced.Text;
                PaymentStatus.Text = UnInvoiced.Text;
                DataTable dt = dl.select_UNINVOICE(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                   
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                paymentpanel.Visible = false;
            }
        }
        //CHECK__BOX__INVOICED......BOX OF THE PAYMENT__Invoiced..............
        private void Invoiced_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            if (Invoiced.Checked == true)
            {
                All.Checked = false;
                UnInvoiced.Checked = false;
                Paid.Checked = false;
                Partial.Checked = false;
                Owing.Checked = false;
                bl.Paymentstatus = Invoiced.Text;
                PaymentStatus.Text = Invoiced.Text;
                DataTable dt = dl.select_Invoiced(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                paymentpanel.Visible = false;
            }
        }
        //CHECK__BOX__..PARTIAL....BOX OF THE PAYMENT__partial.............
        private void Partial_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            if (Partial.Checked == true)
            {
                All.Checked = false;
                Invoiced.Checked = false;
                UnInvoiced.Checked = false;
                Paid.Checked = false;
                Owing.Checked = false;
                bl.Paymentstatus = Partial.Text;
                PaymentStatus.Text = Partial.Text;
                DataTable dt = dl.select_partial(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                  
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                paymentpanel.Visible = false;
            }
        }
        //CHECK__BOX__..PAID......BOX OF THE PAYMENT__PAID..............
        private void Paid_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            if (Paid.Checked == true)
            {
                All.Checked = false;
                Invoiced.Checked = false;
                UnInvoiced.Checked = false;
                Partial.Checked = false;
                Owing.Checked = false;
                bl.Paymentstatus = Paid.Text;
                PaymentStatus.Text = Paid.Text;
                DataTable dt = dl.select_PAID(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
               
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                paymentpanel.Visible = false;
            }
        }
        //CHECK__BOX__...OWING.......BOX OF THE PAYMENT__Owing.............
        private void Owing_CheckedChanged(object sender, EventArgs e)
        {
            FULLDETAILSgrid.Rows.Clear();
            if (Owing.Checked == true)
            {
                All.Checked = false;
                Invoiced.Checked = false;
                UnInvoiced.Checked = false;
                Paid.Checked = false;
                Partial.Checked = false;
                bl.Paymentstatus = Owing.Text;
                PaymentStatus.Text = Owing.Text;
                DataTable dt = dl.select_Owing(bl);
                foreach (DataRow d in dt.Rows)
                {
                    int n = FULLDETAILSgrid.Rows.Add();
                    FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
                 
                    FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                    FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                }
                paymentpanel.Visible = false;
            }
        }
        //DISPLAY THE ALL THE CUSTOMERS NAMES ,,CONTACTNO  AND ADDRSS...BY USING THE COMBOBOX__ENTER EVENT.........
        private void Customer_Enter_1(object sender, EventArgs e)
        {
        }

        //WHEN WE ARE ENTER INTO THE CUSTOMER DROP DOWN THEN THE REMAINING ALL BOXES DATA WILL BE CLEAR.........
        private void Customer_MouseClick(object sender, MouseEventArgs e)
        {
            FULLDETAILSgrid.Columns[13].Visible = false;
            orderno.Visible = true;
            custname.Visible = true;
            CUSTOMERNAME.Visible = true;
            SEARCHTEXT.Visible = true;
            pictureBox1.Visible = false;
            ORDERDATE.Text = string.Empty;
            SALESQUOTE.Text = string.Empty;
            SHOWCANCELLED.Text = string.Empty;
            UnFulfilled.Checked = false;
            Fulfilled.Checked = false;
            Started.Checked = false;
            All.Checked = false;
            UnInvoiced.Checked = false;
            Invoiced.Checked = false;
            Partial.Checked = false;
            Paid.Checked = false;
            Owing.Checked = false;
            order.Clear();
            CustomerGrid.DefaultCellStyle.BackColor = Color.Khaki;
            CustomerGrid.DataSource = dl.slect__custmerdetails__to__grid(bl);
            CustomerGrid.Visible = true;
            paymentpanel.Visible = false;
            inventorypanel.Visible = false;
            FULLDETAILSgrid.Rows.Clear();
            Customer.Text = string.Empty;
            Inventorystatus.Text = string.Empty;
            PaymentStatus.Text = string.Empty;
            CustomerGrid.EnableHeadersVisualStyles = false;
            CustomerGrid.Columns[0].HeaderCell.Style.BackColor = Color.LawnGreen;
            CustomerGrid.Columns[1].HeaderCell.Style.BackColor = Color.LawnGreen;
            CustomerGrid.Columns[2].HeaderCell.Style.BackColor = Color.LawnGreen;
            CustomerGrid.Columns[3].HeaderCell.Style.BackColor = Color.LawnGreen;
            CustomerGrid.Columns[4].HeaderCell.Style.BackColor = Color.LawnGreen;
            CustomerGrid.Columns[5].HeaderCell.Style.BackColor = Color.LawnGreen;
        }

        //CUSTOMERS DATA IN THE DATAGRIDVIEW TO DISPLY PARTICULAR DATA INTO MAIN FORM BY...DATAGRIDVIEW__CELLCLICK...EVENT........
        private void CustomerGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            BAL.Cust = CustomerGrid.CurrentRow.Cells[0].Value.ToString();
            bl.Customername1 = CustomerGrid.CurrentRow.Cells[0].Value.ToString();
            DataTable dt = dl.SEARCH__BY__CUSTOMER(bl);
            foreach (DataRow d in dt.Rows)
            {
                FULLDETAILSgrid.Rows.Clear();
                int n = FULLDETAILSgrid.Rows.Add();
                FULLDETAILSgrid.Rows[n].Cells[0].Value = d["orderno"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[1].Value = d["orderdate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[2].Value = d["inventorystatus"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[3].Value = d["paymentstatus"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[4].Value = d["customername"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[6].Value = d["location"].ToString();
              
                FULLDETAILSgrid.Rows[n].Cells[8].Value = d["duedate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[9].Value = d["shipdate"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[10].Value = d["total"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[11].Value = d["paid"].ToString();
                FULLDETAILSgrid.Rows[n].Cells[12].Value = d["balance"].ToString();
                CustomerGrid.Visible = false;
                Customer.Text = CustomerGrid.CurrentRow.Cells[0].Value.ToString();
            }
          
            SEARCHTEXT.Visible = false;
            orderno.Visible = false;
            custname.Visible = false;
            CUSTOMERNAME.Visible = false;
        }
        //TO..OFF THE VISIBLE OF CUSTOMERGRID,,INVENTORY PANEL  AND ALSO THE PAYMENTPANEL...........
        private void FULLDETAILSgrid_Enter(object sender, EventArgs e)
        {
            orderno.Visible = false;
            CUSTOMERNAME.Visible = false;
            custname.Visible = false;
            grouppanel.Visible=false;
            CustomerGrid.Visible = false;
            inventorypanel.Visible = false;
            paymentpanel.Visible = false;
            SEARCHTEXT.Visible = false;
            order.Clear();
        }
        //WHEN ENTER TO THE ORDER BOX CLEAR THE ALL REMAINING BOXES DATA............................
        private void order_Enter(object sender, EventArgs e)
        {
            SEARCHTEXT.Visible = false;
            orderno.Visible = false;
            custname.Visible = false;
            CUSTOMERNAME.Visible = false;
            FULLDETAILSgrid.Columns[2].Visible = true;
            FULLDETAILSgrid.Columns[3].Visible = true;
            FULLDETAILSgrid.Columns[13].Visible = false;
            UnFulfilled.Checked = false;
            Fulfilled.Checked = false;
            Started.Checked = false;
          
            UnInvoiced.Checked = false;
            Invoiced.Checked = false;
            Partial.Checked = false;
            Paid.Checked = false;
            Owing.Checked = false;
            Customer.Text = string.Empty;
            CustomerGrid.Visible = false;
            paymentpanel.Visible = false;
            inventorypanel.Visible = false;
        
        }
       
        //TO OFF THE VISIBILITY OF THE PICTUREBOX,,PAYMENTPANEL,,INVENTORYPANEL AND ALSO CUSTOMERGRID DATA ALSO............
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        { 
            CUSTOMERNAME.Visible = false;
            custname.Visible = false;
            orderno.Visible = false;
            SEARCHTEXT.Visible = false;
            grouppanel.Visible = false;
            pictureBox1.Visible = false;
            paymentpanel.Visible = false;
            inventorypanel.Visible = false;
            CustomerGrid.Visible = false;
        }
        private void SEARCHTEXT_TextChanged(object sender, EventArgs e)
        {
                bl.Orderno = SEARCHTEXT.Text;
              CustomerGrid.DataSource = dl.searchbynumber_in_custmergrid(bl);
        }
        private void SEARCH_Click(object sender, EventArgs e)
        {
            bl.Customername = SEARCHTEXT.Text;
            CustomerGrid.DataSource = dl.searchbyCUSNAME_IN_CUSTGRID(bl);
        }
        SaleOrderWith_shipping_details ss = new SaleOrderWith_shipping_details();
        //SELECLECTD DATA ROW IN THIS GRIDVIEW IS DISLPLAY INTO THE CUSTOMER__FORM...................
        private void orderform_Click(object sender, EventArgs e)
        {
            if (UnFulfilled.Checked == true)
            {
                bl.Inventorystatus = Inventorystatus.Text;
                ss.dgvOrder.DataSource = dl.inventorystatus(bl);
                ss.cboInventryStatus.Text = Inventorystatus.Text;
            }
            if (Fulfilled.Checked == true)
            {
                bl.Inventorystatus = Inventorystatus.Text;
                ss.dgvOrder.DataSource = dl.inventorystatus(bl);
                ss.cboInventryStatus.Text = Inventorystatus.Text;
            }
            if (Started.Checked == true)
            {
                bl.Inventorystatus = Inventorystatus.Text;
                ss.dgvOrder.DataSource = dl.inventorystatus(bl);
                ss.cboInventryStatus.Text = Inventorystatus.Text;
            }
                if (UnInvoiced.Checked == true)
                {
                    bl.Paymentstatus = PaymentStatus.Text;
                    ss.cboPaymentStatus.Text = PaymentStatus.Text;
                    ss.dgvOrder.DataSource = dl.selectpaymentORDERFORM(bl);
                }
                if (Invoiced.Checked == true)
                {
                    bl.Paymentstatus = PaymentStatus.Text;
                    ss.cboPaymentStatus.Text = PaymentStatus.Text;
                    ss.dgvOrder.DataSource = dl.selectpaymentORDERFORM(bl);
                }
                if (Partial.Checked == true)
                {
                    bl.Paymentstatus = PaymentStatus.Text;
                    ss.cboPaymentStatus.Text = PaymentStatus.Text;
                    ss.dgvOrder.DataSource = dl.selectpaymentORDERFORM(bl);
                }
                if (Paid.Checked == true)
                {
                    bl.Paymentstatus = PaymentStatus.Text;
                    ss.cboPaymentStatus.Text = PaymentStatus.Text;
                    ss.dgvOrder.DataSource = dl.selectpaymentORDERFORM(bl);
                }
                if (Owing.Checked == true)
                {
                    bl.Paymentstatus = PaymentStatus.Text;
                    ss.cboPaymentStatus.Text = PaymentStatus.Text;
                    ss.dgvOrder.DataSource = dl.selectpaymentORDERFORM(bl);
                }
                
                ss.Show();
                this.Hide();
                if (All.Checked == true)
                {
                    ss.cboPaymentStatus.Text = PaymentStatus.Text;
                    ss.dgvOrder.DataSource = dl.allselected(bl);
                }
                bl.Orderno = order.Text;
                ss.txtSrchOrder.Text = order.Text;
             
            pictureBox1.Visible = false;
        }

        private void CUSTOMERNAME_TextChanged(object sender, EventArgs e)
        {
            bl.Customername = CUSTOMERNAME.Text;
            CustomerGrid.DataSource = dl.seacrhbycustomerlike(bl);
             
        }

        private void FULLDETAILSgrid_Click(object sender, EventArgs e)
        {

        }

        private void FULLDETAILSgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bl.Orderno = FULLDETAILSgrid.CurrentRow.Cells[0].Value.ToString();
            DataTable dt = dl.SALESsearchbyORDERNUM(bl);
            SaleOrderWith_shipping_details ss = new SaleOrderWith_shipping_details();
            foreach (DataRow d in dt.Rows)
            {
               ss.cboSaleCustmr.Text = d["customername"].ToString();
                ss.txtSaleCntct.Text = d["contactname"].ToString();
                ss.txtSalePhn.Text = d["phone"].ToString();
                 ss.txtSaleBillAdrs.Text = d["billingaddress"].ToString();
                 ss.cboSaleTrms.Text = d["terms"].ToString();
                 ss.cboSaleRep.Text = d["salesrep"].ToString();
                 ss.cboSaleLocatn.Text = d["location"].ToString();
                 ss.txtSaleOrdr.Text = d["orderno"].ToString();
                 ss.cboSaleDate.Text = d["orderdate"].ToString();
                 ss.txtSaleShpngAdrs.Text = d["shippingaddress"].ToString();
                 ss.cboSaleNonCustmr.Text = d["noncustomer"].ToString();
                 ss.cboSaleDueDate.Text = d["duedate"].ToString();
                 ss.cboSaleTaxng.Text = d["taxingscheme"].ToString();
                 ss.cboSaleCurrency.Text = d["pricingorcurrency"].ToString();
              
                 ss.txtSaleRemrks.Text = d["remarks"].ToString();
                 ss.txtSaleSubTot.Text = d["subtotal"].ToString();
                 ss.txtSaleFright.Text = d["freight"].ToString();
                 ss.txtSaleTot.Text = d["total"].ToString();
                 ss.txtSalePaid.Text = d["paid"].ToString();
                 ss.txtSaleBlnc.Text = d["balance"].ToString();
                 ss.cboInventryStatus.Text = d["inventorystatus"].ToString();
                 ss.cboPaymentStatus.Text = d["paymentstatus"].ToString();
            }
            ss.dgvOrder.DataSource = FULLDETAILSgrid.CurrentRow.Cells[0].Value.ToString();
            ss.txtSrchOrder.Text = FULLDETAILSgrid.CurrentRow.Cells[0].Value.ToString();
            ss.cboSrchCustmr.Text = FULLDETAILSgrid.CurrentRow.Cells[4].Value.ToString();
            ss.Show();
      
           
        }

        private void BACKGRNDPANEL_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
 














