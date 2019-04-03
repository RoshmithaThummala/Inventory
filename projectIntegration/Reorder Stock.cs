using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
//using reorder_stock_Windows_Model;
using InventoryTools;

namespace InventoryTools
{
    public partial class Reorder_Stock : Form
    {
        public Reorder_Stock()
        {
            InitializeComponent();
        }
   
        private int i;
        DAL dal = new DAL();
        private void Reorder_Stock_Load(object sender, EventArgs e)
        {
           
            DataTable dt = new DataTable();
            dt = dal.select1();
         
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["reorderquantity"].ToString()) > Convert.ToInt32(dr["quantityonhand"].ToString()))
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["itemnameorcode"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["description"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["quantityonhand"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["reorderpoint"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["reorderquantity"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["lastvendor"].ToString();
                }
            
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
                dataGridView1.BackgroundColor = Color.PaleTurquoise;
                this.BackColor = System.Drawing.Color.Blue;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        
    }
}
