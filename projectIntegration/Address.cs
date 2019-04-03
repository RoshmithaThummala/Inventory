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
    public partial class Address : Form
    {
        public delegate void AddressUpdateHandler(object sender, AddressUpdateEventArgs e);
        public event AddressUpdateHandler AddressUpdate;
        BAL bal = new BAL();
        DAL dal = new DAL();
        public Address()
        {
            InitializeComponent();
            cmbtype.Items.Add("Commercial");
            cmbtype.Items.Add("Residential");
        }

        private void Address_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Color.YellowGreen;
            DataTable dt = dal.selectcountry();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbcountry.Items.Add(dt.Rows[i]["countryname"].ToString());
            }
            DataTable dt1 = dal.selectstate();
        }
        private void btnok_Click(object sender, EventArgs e)
        {
            string newStreet = txtstreet.Text;
            string newCity = cmbcity.Text;
            String newState = cmbstateprovine.Text;
            String newCountry = cmbcountry.Text;
            String newRemarksaddress = txtremarks.Text;
            String newPostalcode = txtzippostalcode.Text;
            String newAddtype = cmbtype.Text;




            AddressUpdateEventArgs args = new AddressUpdateEventArgs(newStreet, newCity, newState, newCountry, newRemarksaddress, newPostalcode, newAddtype);
            AddressUpdate(this, args);
            this.Dispose();
           
            BAL.City = newCity.ToString();
            BAL.State = newState.ToString();
            BAL.Country = newCountry.ToString();
            BAL.Zip = newPostalcode.ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void cmbcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbstateprovine.Items.Clear();
            BAL.Countryname = cmbcountry.Text;
            if (BAL.Countryname != null ||BAL.Countryname != " ")
            {
                DataTable dt=dal.selectcountry1();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbstateprovine.Items.Add(dt.Rows[i]["statename"].ToString());
                }
            }
        }

        private void cmbstateprovine_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbcity.Items.Clear();
            BAL.Statename = cmbstateprovine.Text;
            if (BAL.Statename != null || BAL.Statename != " ")
            {
                DataTable dt = dal.selectcity();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbcity.Items.Add(dt.Rows[i]["cityname"].ToString());
                }
            }
        }

        private void txtzippostalcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        public class AddressUpdateEventArgs : System.EventArgs
        {
            private String street;

            public String Street
            {
                get { return street; }
                set { street = value; }
            }
            private String city;

            public String City
            {
                get { return city; }
                set { city = value; }
            }
            private String state;

            public String State
            {
                get { return state; }
                set { state = value; }
            }
            private String country;

            public String Country
            {
                get { return country; }
                set { country = value; }
            }

            private string postalcode;

            public string Postalcode
            {
                get { return postalcode; }
                set { postalcode = value; }
            }
            private string remarks;

            public string Remarks
            {
                get { return remarks; }
                set { remarks = value; }
            }
            private string type;

            public string Type
            {
                get { return type; }
                set { type = value; }
            }
            public AddressUpdateEventArgs(String street2, String city2, String state2, String country2, String postalcode2, String remarks2, String type2)
            {
                this.street = street2;
                this.city = city2;
                this.state = state2;
                this.country = country2;
                this.postalcode = postalcode2;
                this.remarks = remarks2;
                this.type = type2;
            }
        }

        private void Address_Click(object sender, EventArgs e)
        {
            if (cmbcountry.Focused == true)
            {
                if (cmbcountry.Text != String.Empty)
                {
                    BAL.Countryname = cmbcountry.Text;
                    DataTable dt = dal.selectcountry2();
                    if (dt.Rows.Count == 0)
                    {
                        BAL.Country = cmbcountry.Text;
                        dal.insertcountry();
                    }
                    else
                    {
                        MessageBox.Show("Already Exisiting Country");
                    }
                }
                else
                {
                    MessageBox.Show("Enter something to Insert");
                }
            }
            if (cmbstateprovine.Focused == true)
            {
                if (cmbstateprovine.Text != String.Empty)
                {
                    BAL.Statename = cmbstateprovine.Text;
                    DataTable dt = dal.selectstate1();
                    if (dt.Rows.Count == 0)
                    {
                        BAL.Countryname = cmbcountry.Text;
                        BAL.Statename = cmbstateprovine.Text;
                        dal.insertstate();
                    }
                    else
                    {
                        MessageBox.Show("Already Existing State");
                    }
                }
                else
                {
                    MessageBox.Show("Enter something to insert");
                }
            }
            if (cmbcity.Focused == true)
            {
                if (cmbcity.Text != String.Empty)
                {
                    BAL.City = cmbcity.Text;
                    DataTable dt = dal.selectcity1();
                    if (dt.Rows.Count == 0)
                    {
                        BAL.Statename = cmbstateprovine.Text;
                        BAL.City = cmbcity.Text;
                        dal.insertcity();
                    }
                    else
                    {
                        MessageBox.Show("Already Existing City");
                    }
                }
                else
                {
                    MessageBox.Show("Enter something to insert");
                }
            }
        }
    }
}
