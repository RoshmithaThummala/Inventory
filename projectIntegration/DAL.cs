using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace InventoryTools
{
    class DAL
    {
        BAL bal = new BAL();
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=project;User ID=sa;Password=abc");
        public DataTable cusomer()
        {
            SqlCommand cmd = new SqlCommand("sp_customer_orders",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Insertorders(BAL bal)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_order", con);
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.AddWithValue("@sno", bal.Sno1);
                cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                cmd.Parameters.AddWithValue("@contact", bal.Contact);
                cmd.Parameters.AddWithValue("@phone", bal.Phone);
                cmd.Parameters.AddWithValue("@billAdrs", bal.BillingAddress);
                cmd.Parameters.AddWithValue("@terms", bal.Terms);
                cmd.Parameters.AddWithValue("@salesRep", bal.SalesRepr);
                cmd.Parameters.AddWithValue("@location", bal.Location);
                cmd.Parameters.AddWithValue("@orderNo", bal.OrderNo);
                cmd.Parameters.AddWithValue("@orderdate", bal.OrderDate);
                cmd.Parameters.AddWithValue("@inventoryStatus", bal.InventoryStatus);
                cmd.Parameters.AddWithValue("@paymentstatus", bal.PaymenStatus);
                cmd.Parameters.AddWithValue("@shippingaddress", bal.ShippingAddress);
                cmd.Parameters.AddWithValue("@noncustomer", bal.NonCustomer);
                cmd.Parameters.AddWithValue("@taxingscheme", bal.TaxingScheme);
                cmd.Parameters.AddWithValue("@currency", bal.Currency);
                cmd.Parameters.AddWithValue("@shipdate", bal.ShipDate);
                cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                cmd.Parameters.AddWithValue("@subtotal", bal.SubTotal);
                cmd.Parameters.AddWithValue("@frieght", bal.Frieght);
                cmd.Parameters.AddWithValue("@statetax", bal.StateTax);
                cmd.Parameters.AddWithValue("@citytax", bal.CityTax);
                cmd.Parameters.AddWithValue("@total", bal.Total);
                cmd.Parameters.AddWithValue("@paid", bal.Paid);
                cmd.Parameters.AddWithValue("@balance", bal.Balance);
                cmd.Parameters.AddWithValue("@duedate", bal.Duedate);
                cmd.Parameters.AddWithValue("@paying", bal.Paying);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            }
        public void orderitemInsert(BAL bal)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ordritems_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemid", bal.Id);
                cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                cmd.Parameters.AddWithValue("@orderNo", bal.OrderNo);
                cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                cmd.Parameters.AddWithValue("@description", bal.Description);
                cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                cmd.Parameters.AddWithValue("@unitprice", bal.Unitprice);
                cmd.Parameters.AddWithValue("@discount", bal.Discount);
                cmd.Parameters.AddWithValue("@subtotal", bal.SubTotal);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            }
        public DataTable items()
        {
            SqlCommand cmd = new SqlCommand("select productid,itemnameorcode,description from products",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
 
        }
        public DataTable salesrepr()
        {
            SqlCommand cmd = new SqlCommand("sp_select_representative",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable taxing()
        {
            SqlCommand cmd = new SqlCommand("sp_taxing_select",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable pricing()
        {
            SqlCommand cmd = new SqlCommand("sp_pricing_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ordersNo()
        {
            SqlCommand cmd = new SqlCommand("sp_select_orderNo",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable location()
        {
            SqlCommand cmd = new SqlCommand("sp_select_location", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void select(BAL bal)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_select_orders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        bal.CustomerName = dr["customername"].ToString();
                        bal.Contact = dr["contactname"].ToString();
                        bal.Phone = dr["phone"].ToString();
                        bal.BillingAddress = dr["billingaddress"].ToString();
                        bal.Terms = dr["terms"].ToString();
                        bal.SalesRepr = dr["salesrep"].ToString();
                        bal.Location = dr["location"].ToString();
                        bal.OrderNo = dr["orderno"].ToString();
                        bal.OrderDate = Convert.ToDateTime(dr["orderdate"]);
                        bal.InventoryStatus = dr["inventorystatus"].ToString();
                        bal.PaymenStatus = dr["paymentstatus"].ToString();
                        bal.ShippingAddress = dr["shippingaddress"].ToString();
                        bal.NonCustomer = dr["noncustomer"].ToString();
                        bal.TaxingScheme = dr["taxingscheme"].ToString();
                        bal.Currency = dr["pricingorcurrency"].ToString();
                        bal.ShipDate = dr["shipdate"].ToString();
                        bal.Remarks = dr["remarks"].ToString();
                        bal.SubTotal = dr["subtotal"].ToString();
                        bal.Frieght = dr["freight"].ToString();
                        bal.StateTax = dr["statetax"].ToString();
                        bal.CityTax = dr["citytax"].ToString();
                        bal.Total = dr["total"].ToString();
                        bal.Paid = dr["paid"].ToString();
                        bal.Balance = dr["balance"].ToString();
                        bal.Duedate = dr["duedate"].ToString();
                        bal.Paying = dr["paying"].ToString();

                    }

                }
            }
            finally
            {
                con.Close();
            }
        }

        public void showitems(BAL balobj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showitems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@itemname", balobj.Itemname);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {


                    balobj.Itemname = dr["itemnameorcode"].ToString();
                    balobj.Itemtype = dr["type"].ToString();
                    balobj.Category = dr["category"].ToString();
                    balobj.Description1 = dr["description"].ToString();
                    balobj.Normalprice = dr["normalprice"].ToString();
                    balobj.Retailprice = dr["retailpreice"].ToString();
                    balobj.Wholesaleprice = dr["wholesaleprice"].ToString();
                    balobj.Cost = dr["cost"].ToString();
                    balobj.Year = dr["year"].ToString();
                    balobj.Model = dr["model"].ToString();
                    balobj.Picture = dr["picture"].ToString();
                    balobj.Quantityonhand = dr["quantityonhand"].ToString();
                    balobj.Barcode = dr["barcode"].ToString();
                    balobj.Reorderpoint = dr["reorderpoint"].ToString();
                    balobj.Reorderquantity = dr["reorderquantity"].ToString();
                    balobj.Location1 = dr["location"].ToString();
                    balobj.Lastvendor = dr["lastvendor"].ToString();
                    balobj.Standarduom = dr["standarduom"].ToString();
                    balobj.Salesuom = dr["salesuom"].ToString();
                    balobj.Purchasinguom = dr["purchasinguom"].ToString();
                    balobj.Manufacturer = dr["manufacturer"].ToString();
                    balobj.Madein = dr["madein"].ToString();
                    balobj.Length = dr["length"].ToString();
                    balobj.Width = dr["width"].ToString();
                    balobj.Height = dr["height"].ToString();
                    balobj.Weight = dr["weight"].ToString();
                    balobj.Remarks1 = dr["remarks"].ToString();



                }
            }
            con.Close();
        }

            public DataTable select_items(BAL bal)
            {
                SqlCommand cmd=new SqlCommand("sp_select_orderitems",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderno",bal.OrderNo);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                return dt;

            }
            public DataTable inven_select(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_inven",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inventorystatus",bal.InventoryStatus);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable payment_select(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_payment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@paymentstatus", bal.PaymenStatus);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable orderno(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_orderno", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void update_orders(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_orders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cutomername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@contact", bal.Contact);
                    cmd.Parameters.AddWithValue("@phone", bal.Phone);
                    cmd.Parameters.AddWithValue("@billingadrs", bal.BillingAddress);
                    cmd.Parameters.AddWithValue("@terms", bal.Terms);
                    cmd.Parameters.AddWithValue("@salesRep", bal.SalesRepr);
                    cmd.Parameters.AddWithValue("@location", bal.Location);
                    cmd.Parameters.AddWithValue("@orderNo", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@orderdate", bal.OrderDate);
                    cmd.Parameters.AddWithValue("@inventoryStatus", bal.InventoryStatus);
                    cmd.Parameters.AddWithValue("@paymentstatus", bal.PaymenStatus);
                    cmd.Parameters.AddWithValue("@shippingadrs", bal.ShippingAddress);
                    cmd.Parameters.AddWithValue("@noncustomer", bal.NonCustomer);
                    cmd.Parameters.AddWithValue("@taxiingscheme", bal.TaxingScheme);
                    cmd.Parameters.AddWithValue("@currency", bal.Currency);
                    cmd.Parameters.AddWithValue("@shipdate", bal.ShipDate);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@subtotal", bal.SubTotal);
                    cmd.Parameters.AddWithValue("@freight", bal.Frieght);
                    cmd.Parameters.AddWithValue("@statetax", bal.StateTax);
                    cmd.Parameters.AddWithValue("@citytax", bal.CityTax);
                    cmd.Parameters.AddWithValue("@total", bal.Total);
                    cmd.Parameters.AddWithValue("@paid", bal.Paid);
                    cmd.Parameters.AddWithValue("@balance", bal.Balance);
                    cmd.Parameters.AddWithValue("@duedate", bal.Duedate);
                    cmd.Parameters.AddWithValue("@paying", bal.Paying);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            public void insert_returned(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_return", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    cmd.Parameters.AddWithValue("@description", bal.Description);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@returndate", bal.Retrndate);
                    cmd.Parameters.AddWithValue("@discarded", bal.Discarded);
                    cmd.Parameters.AddWithValue("@unitprice", bal.Unitprice);
                    cmd.Parameters.AddWithValue("@discount", bal.Discount);
                    cmd.Parameters.AddWithValue("@subtotal", bal.SubTotal);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@itemtotal", bal.Total);
                    cmd.Parameters.AddWithValue("@statetax", bal.StateTax);
                    cmd.Parameters.AddWithValue("@citytax", bal.CityTax);
                    cmd.Parameters.AddWithValue("@fee", bal.Fee);
                    cmd.Parameters.AddWithValue("@total", bal.Total);
                    cmd.Parameters.AddWithValue("@itemid",bal.Id);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            public void update_returns(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_return", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sno", bal.Sno1);
                    cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    // cmd.Parameters.AddWithValue("@description", bal.Description);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@returndate", bal.Retrndate);
                    cmd.Parameters.AddWithValue("@discarded", bal.Discarded);
                    cmd.Parameters.AddWithValue("@unitprice", bal.Unitprice);
                    cmd.Parameters.AddWithValue("@discount", bal.Discount);
                    cmd.Parameters.AddWithValue("@subtotal", bal.SubTotal);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@itemtotal", bal.Total);
                    cmd.Parameters.AddWithValue("@statetax", bal.StateTax);
                    cmd.Parameters.AddWithValue("@citytax", bal.CityTax);
                    cmd.Parameters.AddWithValue("@fee", bal.Fee);
                    cmd.Parameters.AddWithValue("@total", bal.Total);
                    cmd.Parameters.AddWithValue("@itemid",bal.Id);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public void insert_restcok(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_restock", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    cmd.Parameters.AddWithValue("@description", bal.Description);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@restockdate", bal.RestockDate);
                    cmd.Parameters.AddWithValue("@location", bal.Location);
                    cmd.Parameters.AddWithValue("@reamrks", bal.Remarks);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public DataTable select_return(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_return",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderno",bal.OrderNo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable select_restck(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_restck",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderno",bal.OrderNo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void insert_restck(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_restck", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@sno",bal.Id);
                    cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    cmd.Parameters.AddWithValue("@description", bal.Description);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@restockdate", bal.RestockDate);
                    cmd.Parameters.AddWithValue("@location", bal.Location);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public void update_restck(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_restck", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sno", bal.Id);
                    cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    cmd.Parameters.AddWithValue("@description", bal.Description);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@restockdate", bal.RestockDate);
                    cmd.Parameters.AddWithValue("@location", bal.Location);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            public DataTable select_orderno_restck()
            {
                SqlCommand cmd = new SqlCommand("select orderno from restockitems",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable select_orderno_return()
            {
                SqlCommand cmd = new SqlCommand("select orderno from returneditems", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void update_status(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update orders set inventorystatus='" + bal.InventoryStatus + "' where orderno='" + bal.OrderNo + "'", con);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }

            public void insert_customer(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@balance", bal.Balance);
                    cmd.Parameters.AddWithValue("@credit", bal.Credit);
                    cmd.Parameters.AddWithValue("@contactname", bal.Contact);
                    cmd.Parameters.AddWithValue("@phone", bal.Phone);
                    cmd.Parameters.AddWithValue("@fax", bal.Fax);
                    cmd.Parameters.AddWithValue("@email", bal.Email);
                    cmd.Parameters.AddWithValue("@website", bal.Website);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@address", bal.BillingAddress);
                    cmd.Parameters.AddWithValue("@pricingorcurrency", bal.Currency);
                    cmd.Parameters.AddWithValue("@discount", bal.Discount);
                    cmd.Parameters.AddWithValue("@paymentterms", bal.PaymenStatus);
                    cmd.Parameters.AddWithValue("@taxingscheme", bal.TaxingScheme);
                    cmd.Parameters.AddWithValue("@taxexempt", bal.TaxExcemp);
                    cmd.Parameters.AddWithValue("@alternatecontact", bal.Alternatecon);
                    cmd.Parameters.AddWithValue("@emergencyphone", bal.Emergencycon);
                    cmd.Parameters.AddWithValue("@defaultlocation", bal.DefaultLoc);
                    cmd.Parameters.AddWithValue("@defaultsalesrep", bal.DefaultSalesRep);
                    cmd.Parameters.AddWithValue("@carrier", bal.Carrier);
                    cmd.Parameters.AddWithValue("@paymentmethod", bal.PaymentMeth);
                    cmd.Parameters.AddWithValue("@cardtype", bal.CardType);
                    cmd.Parameters.AddWithValue("@cardnumber", bal.CardNum);
                    cmd.Parameters.AddWithValue("@expiredate", bal.ExpiryDate);
                    cmd.Parameters.AddWithValue("@cardsecuritycode", bal.CardCode);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }

            public void select_customer(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_select_customers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@phone", bal.Phone);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bal.CustomerName = dr["customername"].ToString();
                            bal.Balance = dr["balance"].ToString();
                            bal.Credit = dr["credit"].ToString();
                            bal.Contact = dr["contactname"].ToString();
                            bal.Phone = dr["phone"].ToString();
                            bal.Fax = dr["fax"].ToString();
                            bal.Email = dr["email"].ToString();
                            bal.Website = dr["website"].ToString();
                            bal.Remarks = dr["remarks"].ToString();
                            bal.ShippingAddress = dr["address"].ToString();
                            bal.Currency = dr["pricingorcurrency"].ToString();
                            bal.Discount = dr["discount"].ToString();
                            bal.PaymenStatus = dr["paymentterms"].ToString();
                            bal.TaxingScheme = dr["taxingscheme"].ToString();
                            bal.TaxExcemp = dr["taxexempt"].ToString();
                            bal.Alternatecon = dr["alternatecontact"].ToString();
                            bal.Emergencycon = dr["emergencyphone"].ToString();
                            bal.DefaultLoc = dr["defaultlocation"].ToString();
                            bal.DefaultSalesRep = dr["defaultsalesrep"].ToString();
                            bal.Carrier = dr["carrier"].ToString();
                            bal.PaymentMeth = dr["paymentmethod"].ToString();
                            bal.CardType = dr["cardtype"].ToString();
                            bal.CardNum = dr["cardnumber"].ToString();
                            bal.ExpiryDate = dr["expiredate"].ToString();
                            bal.CardCode = dr["cardsecuritycode"].ToString();
                            bal.Dob1 = dr["dob"].ToString();
                            bal.Residence = dr["residence"].ToString();
                            bal.Addresstype = dr["addresstype"].ToString();
                        }

                    }
                }
                finally
                {
                    con.Close();
                }
            }
            public DataTable select_phn_orders(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_phn_orders",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customername",bal.CustomerName);
                cmd.Parameters.AddWithValue("@phone",bal.Phone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable select_phn_orders1(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_phn_orders1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customername",bal.CustomerName);
                cmd.Parameters.AddWithValue("@phone", bal.Phone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable select_taxing()
            {
                SqlCommand cmd = new SqlCommand("sp_select_taxing",con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void insert_taxing(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_taxing", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@taxschemename", bal.Taxschemename);
                    cmd.Parameters.AddWithValue("@taxname", bal.Taxname);
                    cmd.Parameters.AddWithValue("@taxrate", bal.Taxrate);
                    cmd.Parameters.AddWithValue("@taxonshipping", bal.Taxonshipping);
                    cmd.Parameters.AddWithValue("@secondarytax", bal.Secondarytax);
                    cmd.Parameters.AddWithValue("@secondarytaxrate", bal.Secondarytaxrate);
                    cmd.Parameters.AddWithValue("@secondarytaxon", bal.Secondarytaxon);
                    cmd.Parameters.AddWithValue("@compoundsceondary", bal.Compoondsecondary);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            public void insert_pricing(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_pricing", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sno",bal.Seno);
                    cmd.Parameters.AddWithValue("@pricingname", bal.Pricingname);
                    cmd.Parameters.AddWithValue("@currency", bal.Currency);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public DataTable customer_names()
            {
                SqlCommand cmd = new SqlCommand("select customername,phone from orders",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable customer_id(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("select orderno from orders where customername='"+bal.CustomerName+"'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable customers_name()
            {
                SqlCommand cmd = new SqlCommand("sp_select_customers_name",con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable select_OrdrNo_Restck(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("select orderno from restockitems",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
                
            }

        //=====================================================================================================

            public DataTable selectall(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("selectall112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectprod(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("selectprod", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selecttranc(BAL b)
            {
                con.Open();
                //SqlCommand cmd = new SqlCommand("custshown3", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@status", B.Status);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //con.Close();
                //return dt;
                SqlCommand cmd = new SqlCommand("tranch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans", b.Trans);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            public DataTable selectreciv(BAL b)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("reciv", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans", b.Trans);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            public DataTable selectunst(BAL b)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("unst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans", b.Trans);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            public DataTable selectpick(BAL b)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("pick", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans", b.Trans);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            public DataTable selectfulls(BAL b)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("fulls", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans", b.Trans);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            public DataTable selectrest(BAL b)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("rest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@trans", b.Trans);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            public DataTable selectloc(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("loct", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectlocsch(BAL b)
            {
                SqlCommand cmd = new SqlCommand("locsearch112", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@location", b.Location);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectpro(BAL b)
            {
                SqlCommand cmd = new SqlCommand("pro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemnamerocode", b.Itemname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectdateall(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("dateall", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selecttoday(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("today112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectthisweek(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("thisweek112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectthismonth(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("thismonth112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectquartor(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("quartor112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectthisyear(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("thisyear112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectyesterday(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("yesterday112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectlastweek(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("lastweek112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectlastmonth(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("lastmonth112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectlastquartor(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("lastquartor112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectlastyear(BAL b)
            {
                SqlDataAdapter da = new SqlDataAdapter("lastyear112", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectdatefrom(BAL b)
            {
                SqlCommand cmd = new SqlCommand("fromdate112", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date1", b.Date11);
                cmd.Parameters.AddWithValue("@date2", b.Date22);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable selectview(BAL b)
            {
                SqlCommand cmd = new SqlCommand("spview", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemnamerocode", b.Itemname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        //=====================================================================================================
            public DataTable search_customers(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_search_customers",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customername",bal.CustomerName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void orderitems_update(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_orderitems_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                  //  cmd.Parameters.AddWithValue("@sno", bal.Sno1);
                    cmd.Parameters.AddWithValue("@itemid", bal.Id);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    cmd.Parameters.AddWithValue("@description", bal.Description);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@unitprice", bal.Unitprice);
                    cmd.Parameters.AddWithValue("@discount", bal.Discount);
                    cmd.Parameters.AddWithValue("@subtotal", bal.SubTotal);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            public DataTable customers_contact(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_customers_contact",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contact",bal.Contact);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable customers_phone(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_customers_phone",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@phone",bal.Phone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void update_customer(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_customers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@balance", bal.Balance);
                    cmd.Parameters.AddWithValue("@credit", bal.Credit);
                    cmd.Parameters.AddWithValue("@contactname", bal.Contact);
                    cmd.Parameters.AddWithValue("@phone", bal.Phone);
                    cmd.Parameters.AddWithValue("@fax", bal.Fax);
                    cmd.Parameters.AddWithValue("@email", bal.Email);
                    cmd.Parameters.AddWithValue("@website", bal.Website);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@address", bal.BillingAddress);
                    cmd.Parameters.AddWithValue("@pricingorcurrency", bal.Currency);
                    cmd.Parameters.AddWithValue("@discount", bal.Discount);
                    cmd.Parameters.AddWithValue("@paymentterms", bal.PaymenStatus);
                    cmd.Parameters.AddWithValue("@taxingscheme", bal.TaxingScheme);
                    cmd.Parameters.AddWithValue("@taxexempt", bal.TaxExcemp);
                    cmd.Parameters.AddWithValue("@alternatecontact", bal.Alternatecon);
                    cmd.Parameters.AddWithValue("@emergencyphone", bal.Emergencycon);
                    cmd.Parameters.AddWithValue("@defaultlocation", bal.DefaultLoc);
                    cmd.Parameters.AddWithValue("@defaultsalesrep", bal.DefaultSalesRep);
                    cmd.Parameters.AddWithValue("@carrier", bal.Carrier);
                    cmd.Parameters.AddWithValue("@paymentmethod", bal.PaymentMeth);
                    cmd.Parameters.AddWithValue("@cardtype", bal.CardType);
                    cmd.Parameters.AddWithValue("@cardnumber", bal.CardNum);
                    cmd.Parameters.AddWithValue("@expiredate", bal.ExpiryDate);
                    cmd.Parameters.AddWithValue("@cardsecuritycode", bal.CardCode);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public DataTable select_payterms()
            {
                SqlCommand cmd = new SqlCommand("select paymenttermsname,daysdue from paymentterms",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void insert_paymenthistory(BAL bal)

            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_history", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerid", bal.CustometId);
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@date", bal.OrderDate);
                    cmd.Parameters.AddWithValue("@duedate", bal.Duedate);
                    cmd.Parameters.AddWithValue("@trans", bal.Trans);
                    cmd.Parameters.AddWithValue("@amount", bal.Amount);
                    cmd.Parameters.AddWithValue("@creditbalance", bal.CBal1);
                    cmd.Parameters.AddWithValue("@balance", bal.Balance);
                    cmd.Parameters.AddWithValue("@phone",bal.Phone);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            public DataTable select_paymenthistory(BAL bal)

            {
                SqlCommand cmd = new SqlCommand("sp_select_history",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerid",bal.CustometId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void insert_paymentterms(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_payterms", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@paymenttermsname", bal.Paymentname);
                    cmd.Parameters.AddWithValue("@daysdue", bal.Daysdue);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public void insert_products(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_produts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemnameorcode", bal.Itemname);
                    cmd.Parameters.AddWithValue("@type", bal.Type);
                    cmd.Parameters.AddWithValue("@category", bal.Category);
                    cmd.Parameters.AddWithValue("@description", bal.Description);
                    cmd.Parameters.AddWithValue("@normalprice", bal.Normalpeice);
                    cmd.Parameters.AddWithValue("@retailpreice", bal.Retailprice);
                    cmd.Parameters.AddWithValue("@wholesaleprice", bal.Wholesaleprice);
                    cmd.Parameters.AddWithValue("@cost", bal.Cost);
                    cmd.Parameters.AddWithValue("@year", bal.Year);
                    cmd.Parameters.AddWithValue("@model", bal.Model);
                    cmd.Parameters.AddWithValue("@picture", bal.Picture);
                    cmd.Parameters.AddWithValue("@quantityonhand", bal.Quantityonhand);
                    cmd.Parameters.AddWithValue("@barcode", bal.Barcode);
                    cmd.Parameters.AddWithValue("@reorderpoint", bal.Reorderpoint);
                    cmd.Parameters.AddWithValue("@reorderquantity", bal.Reorderquantity);
                    cmd.Parameters.AddWithValue("@location", bal.DefaultLoc);
                    cmd.Parameters.AddWithValue("@lastvendor", bal.Lastvendor);
                    cmd.Parameters.AddWithValue("@standarduom", bal.Standarduom);
                    cmd.Parameters.AddWithValue("@salesuom", bal.Salesuom);
                    cmd.Parameters.AddWithValue("@purchasinguom", bal.Purchasinguom);
                    cmd.Parameters.AddWithValue("@manufacturer", bal.Manufacturer);
                    cmd.Parameters.AddWithValue("@madein", bal.Madein);
                    cmd.Parameters.AddWithValue("@length", bal.Lenght);
                    cmd.Parameters.AddWithValue("@width", bal.Width);
                    cmd.Parameters.AddWithValue("@height", bal.Height);
                    cmd.Parameters.AddWithValue("@weight", bal.Weight);
                    cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                    cmd.Parameters.AddWithValue("@status", bal.Status1);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public void select_products(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_select_products", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    cmd.Parameters.AddWithValue("@productid", bal.Sno1);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            bal.Itemname = dr["itemnameorcode"].ToString();
                            bal.Type = dr["type"].ToString();
                            bal.Category = dr["category"].ToString();
                            bal.Description = dr["description"].ToString();
                            bal.Normalpeice = dr["normalprice"].ToString();
                            bal.Retailprice = dr["retailpreice"].ToString();
                            bal.Wholesaleprice = dr["wholesaleprice"].ToString();
                            bal.Cost = dr["cost"].ToString();
                            bal.Year = dr["year"].ToString();
                            bal.Model = dr["model"].ToString();
                            bal.Picture = dr["picture"];
                            bal.Quantityonhand = dr["quantityonhand"].ToString();
                            bal.Barcode = dr["barcode"].ToString();
                            bal.Reorderpoint = dr["reorderpoint"].ToString();
                            bal.Reorderquantity = dr["reorderquantity"].ToString();
                            bal.DefaultLoc = dr["location"].ToString();
                            bal.Lastvendor = dr["lastvendor"].ToString();
                            bal.Standarduom = dr["standarduom"].ToString();
                            bal.Salesuom = dr["salesuom"].ToString();
                            bal.Purchasinguom = dr["purchasinguom"].ToString();
                            bal.Manufacturer = dr["manufacturer"].ToString();
                            bal.Madein = dr["madein"].ToString();
                            bal.Lenght = dr["length"].ToString();
                            bal.Width = dr["width"].ToString();
                            bal.Height = dr["height"].ToString();
                            bal.Weight = dr["weight"].ToString();
                            bal.Remarks = dr["remarks"].ToString();
                            bal.Status1 = dr["status"].ToString();

                        }
                    }
                }
                finally
                {
                    con.Close();
                }
                }
            public void select_products12(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_select_products12", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                  //  cmd.Parameters.AddWithValue("@productid", bal.Sno1);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            bal.Itemname = dr["itemnameorcode"].ToString();
                            bal.Type = dr["type"].ToString();
                            bal.Category = dr["category"].ToString();
                            bal.Description = dr["description"].ToString();
                            bal.Normalpeice = dr["normalprice"].ToString();
                            bal.Retailprice = dr["retailpreice"].ToString();
                            bal.Wholesaleprice = dr["wholesaleprice"].ToString();
                            bal.Cost = dr["cost"].ToString();
                            bal.Year = dr["year"].ToString();
                            bal.Model = dr["model"].ToString();
                            bal.Picture = dr["picture"];
                            bal.Quantityonhand = dr["quantityonhand"].ToString();
                            bal.Barcode = dr["barcode"].ToString();
                            bal.Reorderpoint = dr["reorderpoint"].ToString();
                            bal.Reorderquantity = dr["reorderquantity"].ToString();
                            bal.DefaultLoc = dr["location"].ToString();
                            bal.Lastvendor = dr["lastvendor"].ToString();
                            bal.Standarduom = dr["standarduom"].ToString();
                            bal.Salesuom = dr["salesuom"].ToString();
                            bal.Purchasinguom = dr["purchasinguom"].ToString();
                            bal.Manufacturer = dr["manufacturer"].ToString();
                            bal.Madein = dr["madein"].ToString();
                            bal.Lenght = dr["length"].ToString();
                            bal.Width = dr["width"].ToString();
                            bal.Height = dr["height"].ToString();
                            bal.Weight = dr["weight"].ToString();
                            bal.Remarks = dr["remarks"].ToString();
                            bal.Status1 = dr["status"].ToString();

                        }
                    }
                }
                finally
                {
                    con.Close();
                }
            }
            public DataTable select_products1(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_products1",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@item",bal.Itemcode);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            public DataTable select_products_main()
            {
                SqlCommand cmd = new SqlCommand("select productid,itemnameorcode,category from products", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable select_products_barcode(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_products_code", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@barcode", bal.Barcode);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            public DataTable select_products_description(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_products_desc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@category", bal.Category);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            public void insert_salesrep(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_salesrep", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@salesrep", bal.SalesRepr);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public DataTable srch_products(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_search_products",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemname",bal.Itemname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable srch_products1(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_search_products1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productid", bal.Sno1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable srch_cust(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_srch_cust", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                cmd.Parameters.AddWithValue("@phone", bal.Phone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void insert_location(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_location", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@location", bal.Location);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public void insert_orderhistory(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_orderhistory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                    cmd.Parameters.AddWithValue("@type", bal.Type);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@customername", bal.CustomerName);
                    cmd.Parameters.AddWithValue("@date", bal.OrderDate);
                    cmd.Parameters.AddWithValue("@orderstatus", bal.InventoryStatus);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@subtotal", bal.SubTotal);
                    cmd.Parameters.AddWithValue("@itemid",bal.Id);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public void select_qunatityinhand(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_select_quantityonhand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", bal.Sno1);
                    cmd.Parameters.AddWithValue("@itemnameorcode", bal.Itemname);
                    SqlDataReader da = cmd.ExecuteReader();
                    if (da.HasRows)
                    {
                        while (da.Read())
                        {
                            bal.Quantityonhand = da["quantityonhand"].ToString();
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
                }
            public void update_quantityonhand(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_quantityonhand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", bal.Id);
                    cmd.Parameters.AddWithValue("@itemnameorcode", bal.Itemname);
                    cmd.Parameters.AddWithValue("@quantityonhand", bal.Quantityonhand);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                }
            public void insert_movementhistory(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_movement", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemnameorcode", bal.Itemname);
                    cmd.Parameters.AddWithValue("@descrtiption", bal.Description);
                    cmd.Parameters.AddWithValue("@transaction", bal.Trans);
                    cmd.Parameters.AddWithValue("@date", bal.OrderDate);
                    cmd.Parameters.AddWithValue("@location", bal.Location);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@quantityonhand", bal.Quantityonhand);
                    cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
                    cmd.Parameters.AddWithValue("@quantityafter", bal.Quantityafter);
                    cmd.ExecuteNonQuery();
                }

                finally
                {
                    con.Close();
                }
                }

            public void update_orderhistory(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_orderhistory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@orderstatus", BAL.Status);
                    cmd.Parameters.AddWithValue("@quantity",bal.Quantity);
                    cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                    cmd.Parameters.AddWithValue("@itemid", bal.Id);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            public DataTable select_movementhistory(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("sp_select_movementhistory",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemnameorcode",bal.Itemname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable select_orderhistory(BAL bal)
            {
                SqlCommand cmd = new SqlCommand("select_orderhistory",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemname",bal.Itemname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void select_statetax(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select taxonshipping from taxingschemes where taxschemename='" + bal.Taxname + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bal.TaxingScheme = dr["taxonshipping"].ToString();
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
            }
            public void select_citytax(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select secondarytaxon from taxingschemes where taxschemename='" + bal.Taxonshipping + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bal.Taxschemename = dr["secondarytaxon"].ToString();
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
            }
            public DataTable  autogenerate()
            {
                SqlCommand cmd = new SqlCommand("autogenerate",con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void quantity_orders(BAL bal)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select quantity,itemid from orderitems where orderno='" + bal.OrderNo + "' and itemid='" + bal.Id + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bal.Quantityafter = dr["quantity"].ToString();
                            bal.Sno1 = Convert.ToInt32(dr["itemid"].ToString());
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
                }

            public void delete_return(BAL bal)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_return",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderno",bal.OrderNo);
                cmd.Parameters.AddWithValue("@itemid",bal.Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            public void delete_restock(BAL bal)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_restock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderno", bal.OrderNo);
                cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
                cmd.ExecuteNonQuery();
                con.Close();
            }
       // ========================================================================================================
            public void insert(BAL bal)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insertcustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customername", bal.Customername);
                cmd.Parameters.AddWithValue("@balance", bal.Balance);
                cmd.Parameters.AddWithValue("@credit", bal.Credit);
                cmd.Parameters.AddWithValue("@contactname", bal.Contactname);
                cmd.Parameters.AddWithValue("@phone", bal.Phone);
                cmd.Parameters.AddWithValue("@fax", bal.Fax);
                cmd.Parameters.AddWithValue("@email", bal.Email);
                cmd.Parameters.AddWithValue("@website", bal.Website);
                cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
                cmd.Parameters.AddWithValue("@address", bal.Address);
                cmd.Parameters.AddWithValue("@pricingorcurrency", bal.Pricingorcurrency);
                cmd.Parameters.AddWithValue("@discount", bal.Discount);
                cmd.Parameters.AddWithValue("@paymentterms", bal.Paymentterms);
                cmd.Parameters.AddWithValue("@taxingscheme", bal.Taxingscheme);
                cmd.Parameters.AddWithValue("@taxexempt", bal.Taxexempt);
                cmd.Parameters.AddWithValue("@alternatecontact", bal.Alternatecontact);
                cmd.Parameters.AddWithValue("@emergencyphone", bal.Emergencyphone);
                cmd.Parameters.AddWithValue("defaultlocation", bal.Defaultlocation);
                cmd.Parameters.AddWithValue("@defaultsalesrep", bal.Defaultsalesrep);
                cmd.Parameters.AddWithValue("@carrier", bal.Carrier);
                cmd.Parameters.AddWithValue("@paymentmethod", bal.Paymentmethod);
                cmd.Parameters.AddWithValue("@cardtype", bal.Cardtype);
                cmd.Parameters.AddWithValue("@cardnumber", bal.Cardnumber);
                cmd.Parameters.AddWithValue("@expiredate", bal.Expiredate);
                cmd.Parameters.AddWithValue("@cardsecuritycode", bal.Cardsecuritycode);
                cmd.Parameters.AddWithValue("@dob", bal.Dob);
                cmd.Parameters.AddWithValue("@residence", bal.Residence);
                cmd.Parameters.AddWithValue("@status",BAL.Status);
                cmd.Parameters.AddWithValue("@city", BAL.City);
                cmd.Parameters.AddWithValue("@state", BAL.State);
                cmd.Parameters.AddWithValue("@country", BAL.Country);
                cmd.Parameters.AddWithValue("@ziporpostalcode", BAL.Zip);
                cmd.Parameters.AddWithValue("@addresstype", bal.Addresstype);
                cmd.ExecuteNonQuery();
                con.Close();
            }
         public DataTable selectcustomername()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectcustomername", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", BAL.Customer);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
         public DataTable selectall2()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectall2", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectall()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectall", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectall1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectall1", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectsalesrep1(BAL bal)
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectsalesrep2", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@salesrepresentative",bal.DefaultSalesRep);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public void insertsalesrep(BAL bal)
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertsalesrep", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@salesrepresentative", bal.SalesRepr);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public DataTable selectcarrier()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcarrier", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public void insertcarrier(BAL bal)
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertcarrier", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@carrier", bal.Carriertype);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public DataTable selectcarrier1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcarrier1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@carrier",BAL.Carry);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectpaymentmethod1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectpaymentmethod1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@paymentmethod", BAL.Paymethod);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public void insertpay(BAL bal)
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertpaymentmethod", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@paymentmethod", bal.PaymentMeth);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public DataTable selectloc()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectloc", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectsalesrep()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectsalesrep", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectpaymentmethod()
         {
            
             SqlCommand cmd = new SqlCommand("selectpaymentmethod", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             
             return dt;
         }
         public DataTable updatestatus()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("updatecustomer", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@customername", BAL.Contact_name);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable updatestat()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("updatecustomer1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@customername", BAL.Conname);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectstatus()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectstatus", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@status", BAL.Stat);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectnamestatus()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectnamestatus", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectcustomers()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcustomers", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@customername", BAL.Customnam);
             cmd.Parameters.AddWithValue("@contacname", BAL.Con_name);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectcustomer1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcustomer1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@customername", BAL.Customname);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectcustomer()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcustomer", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@contactname", BAL.Contactnam);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable customer()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("customerselect", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@phone", BAL.Phoneno);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectpaymenthistory()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectpaymenthistory", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectpaymentdate()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectpaymentdate", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable paydate()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("paydate", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable datefrom()
         {
             SqlCommand cmd = new SqlCommand("datefrom", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@date1", BAL.Fromdate);
             cmd.Parameters.AddWithValue("@date2", BAL.Todate);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable paymentdate()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("paymentdate", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectpricing()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectpricing", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@pricingname", BAL.Pricing);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public void insertprice(BAL bal)
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertpricing", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@pricingname", bal.Pricingname);
             cmd.Parameters.AddWithValue("@currency", bal.Currency);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public DataTable selectpaymentterms1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectpaymentterms1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@paymenttermsname", BAL.Paymenttr);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         //public void insertpay(BAL bal)
         //{
         //    con.Open();
         //    SqlCommand cmd = new SqlCommand("insertpaymentmethod", con);
         //    cmd.CommandType = CommandType.StoredProcedure;
         //    cmd.Parameters.AddWithValue("@paymentmethod", bal.Paymentmethodname);
         //    cmd.ExecuteNonQuery();
         //    con.Close();
         //}
         public void insertpayment(BAL bal)
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertpaymentterms", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@paymenttermsname", bal.Paymenttermsname);
             cmd.Parameters.AddWithValue("@daysdue", bal.Daysdue);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         //public DataTable datefrom()
         //{
         //    SqlCommand cmd = new SqlCommand("datefrom", con);
         //    cmd.CommandType = CommandType.StoredProcedure;
         //    cmd.Parameters.AddWithValue("@date1", BAL.Fromdate);
         //    cmd.Parameters.AddWithValue("@date2", BAL.Todate);
         //    SqlDataAdapter da = new SqlDataAdapter(cmd);
         //    DataTable dt = new DataTable();
         //    da.Fill(dt);
         //    con.Close();
         //    return dt;
         //}
         public DataTable selectloc1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectloc1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@location", BAL.Loca);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public void insertlocation(BAL bal)
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertlocation", con);
             cmd.CommandType = CommandType.StoredProcedure;
             //cmd.Parameters.AddWithValue("@sno", cbal.Sno2);
             cmd.Parameters.AddWithValue("@location", bal.Locationname);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public DataTable selectcity()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcity", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@statename", BAL.Statename);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectcountry1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcountry1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@countryname",BAL.Countryname);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectcountry()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcountry", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectstate()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectstate", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectpayment()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectpayment", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectorders()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectorders", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@customername", BAL.Customnam);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectpaymenthistory1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectpaymenthistory1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@customername", BAL.Customnam);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }

         public DataTable selectcountry2()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcountry2", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@countryname", BAL.Countryname);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }


         public void insertcountry()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertcountry12", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@countryname", BAL.Country);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public void insertstate()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertstate", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@statename", BAL.Statename);
             cmd.Parameters.AddWithValue("@countryname", BAL.Countryname);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public void insertcity()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("insertcity", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@statename", BAL.Statename);
             cmd.Parameters.AddWithValue("@cityname", BAL.City);
             cmd.ExecuteNonQuery();
             con.Close();
         }
         public DataTable selectstate1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectstate1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@statename", BAL.Statename);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
         public DataTable selectcity1()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("selectcity1", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@cityname", BAL.City);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }




        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="bal"></param>


        public void quonum(BAL bal)
        {
            int a;
            SqlCommand cmd = new SqlCommand("sno", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    a = 1;
                    bal.Quotenumber ="1";
                    bal.Quotenumber = "SQ-" + a.ToString();
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    bal.Quotenumber = "SQ-"+a.ToString();
                }
            }
            con.Close();
        }

        public DataTable quotenumber1(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("quotenumber1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;


        }

        public void itemsinsert(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("itemsinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@customername", bal.Customername);
            cmd.Parameters.AddWithValue("@quoteno", bal.Quotenumber);
            cmd.Parameters.AddWithValue("@itemname", bal.Itemname);
            cmd.Parameters.AddWithValue("@description", bal.Description);
            cmd.Parameters.AddWithValue("@quantity", bal.Quantity);
            cmd.Parameters.AddWithValue("@unitprice", bal.Unitprice);
            cmd.Parameters.AddWithValue("@discount", bal.Discount);
            cmd.Parameters.AddWithValue("@subtotal", bal.Subtotal);
            cmd.ExecuteNonQuery();


            con.Close();
        }

        public void proinsert(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", bal.Customername);
           
            cmd.Parameters.AddWithValue("@contact", bal.Contactname);
            cmd.Parameters.AddWithValue("@phone", bal.Phone);
            cmd.Parameters.AddWithValue("@billingaddress", bal.Billingaddress);
            cmd.Parameters.AddWithValue("@terms", bal.Terms);
            cmd.Parameters.AddWithValue("@salesrep", bal.salesrep);
            cmd.Parameters.AddWithValue("@location", bal.Location);
            cmd.Parameters.AddWithValue("@quotenumber", bal.Quotenumber);
            cmd.Parameters.AddWithValue("@quotedate", bal.Quotedate);
            cmd.Parameters.AddWithValue("@status", bal.Quotestatus);
            cmd.Parameters.AddWithValue("@shippingaddress", bal.Shippingaddress);
            cmd.Parameters.AddWithValue("@noncustomercosts", bal.Noncustomer);
            cmd.Parameters.AddWithValue("@taxingschema", bal.Taxingschema);
            cmd.Parameters.AddWithValue("@pricing", bal.Pricingname);
            cmd.Parameters.AddWithValue("@shipdate", bal.Shippingdate);
            cmd.Parameters.AddWithValue("@remarks", bal.Remarks);
            cmd.Parameters.AddWithValue("@subtotal", bal.Itemamount);
            cmd.Parameters.AddWithValue("@freight", bal.Freight);
            cmd.Parameters.AddWithValue("@statetax", bal.Statetax);
            cmd.Parameters.AddWithValue("@citytax", bal.Citytax);
            cmd.Parameters.AddWithValue("@total", bal.Total);
            cmd.Parameters.AddWithValue("@duedate", bal.Duedate);
            cmd.ExecuteNonQuery();


            con.Close();


        }

        public DataTable updatedquote(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("updatedquote", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable duplication(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("duplication", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@quoteno", bal.Quotenumber);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            return dt;
        }

        public DataTable selectitems(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectitems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable showquotedata(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showquotedata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@quoteno", bal.Quotenumber);
            cmd.Parameters.AddWithValue("@customername", bal.Customername);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    bal.Customerid = dr["sno"].ToString();
                    bal.Customername = dr["customername"].ToString();
                    bal.Contactname = dr["contactname"].ToString();
                    bal.Phone = dr["phone"].ToString();
                    bal.Billingaddress = dr["billingaddress"].ToString();
                    bal.Terms = dr["term"].ToString();
                    bal.salesrep = dr["salesrep"].ToString();
                    bal.Location = dr["location"].ToString();
                    bal.Quotenumber = dr["quoteno"].ToString();
                    bal.Quotedate = Convert.ToDateTime(dr["quotedate"].ToString());
                    bal.Quotestatus = dr["status"].ToString();
                    bal.Shippingaddress = dr["shippingaddress"].ToString();
                    bal.Duedate = dr["duedate"].ToString();
                    bal.Noncustomer = Convert.ToDecimal(dr["noncustomer"].ToString());
                    bal.Pricingname = dr["pricingorcurrency"].ToString();
                    bal.Taxingschema = dr["taxingscheme"].ToString();
                    bal.Shippingdate = dr["shipdate"].ToString();
                    bal.Remarks = dr["remarks"].ToString();
                    bal.Subtotal = Convert.ToDecimal(dr["subtotal"].ToString());
                    bal.Freight = Convert.ToDecimal(dr["freight"].ToString());
                    bal.Total = Convert.ToString(dr["total"].ToString());
                    bal.Statetax = Convert.ToDecimal(dr["statetax"].ToString());
                    bal.Citytax = Convert.ToDecimal(dr["citytax"].ToString());

                }

            }
            con.Close();
            return dt;
        }

        public DataTable itemsearchquote(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("itemsearchquote", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@quotenumber", bal.Quotenumber);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable showquote(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showquote", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@quote", bal.Quotenumber);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable showquote1(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showquote1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", bal.Quotestatus);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable showquote2(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("showquote2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", bal.Quotestatus);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void cancelorder(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("cancelorder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@quotenumber", bal.Quotenumber);
            cmd.Parameters.AddWithValue("@status", bal.Quotestatus);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataTable thisweek(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("thisweekq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable thismonth(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("thismonthq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable thisquarter(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("thisquarterq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable thisyear(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("thisyearq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable lastweek(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastweekq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable lastmonth(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastmonthq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable lastquarter(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastquarterq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable lastyear(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastyearq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable alldates(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("alldates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable lastsevendays(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastsevendays", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable lastthirtydays(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastthirtydays", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable lastnintydays(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastnintydays", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable lastyeardays(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("lastyeardays", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable today(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("todayq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable betweendates(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("betweendates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startdate", bal.Startdate);
            cmd.Parameters.AddWithValue("@enddate", bal.Enddate);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable yesterday(BAL bal)
        {
            SqlCommand cmd = new SqlCommand("yesterdayq", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable searchbycontact(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("searchbycontact", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@contact", bal.Contactname);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable searchcustomer(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("searchcustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", bal.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;

        }


        public DataTable searchnamesgrid(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("searchnamesgrid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", bal.Customername);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        /// <summary>
        /// //////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// 
        public DataTable SelectOrder()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("orderbind", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable SelectVdetails()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvnames", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable SelectVFdetails()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spFillVDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable SelectVname(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spselectVname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@vname", BAL.Nam);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Selectloc()   
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SPLOC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable carrier()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("carrierselect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Selectpay()   
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sppay", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SelectItem()  
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SelectItemForm()   
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spItemForm", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@iname", BAL.Nam);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Selecttax()   
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sptax", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Selecttaxshp(BAL p)   
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("taxonshp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@tsname", p.Potaxscheme);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Selecttaxrate()   
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sptaxrate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void Insertitemorder(BAL p)     
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvitemsinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@iname", p.Iiname);
            cmd.Parameters.AddWithValue("@des", p.Ides);
            cmd.Parameters.AddWithValue("@code", p.Icode);
            cmd.Parameters.AddWithValue("@quant", p.Iquantity);
            cmd.Parameters.AddWithValue("@uprice", p.Iuprice);
            cmd.Parameters.AddWithValue("@dis", p.Idiscount);
            cmd.Parameters.AddWithValue("@stotal", p.Isubtotal);
            cmd.Parameters.AddWithValue("@pid", p.Iid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Insertphistory(BAL p) 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insertpaymenthistory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@date", BAL.Poorderdate);
            cmd.Parameters.AddWithValue("@ddate", p.Poddate);
            cmd.Parameters.AddWithValue("@trans", p.Trans);
            cmd.Parameters.AddWithValue("@amt", p.Pototal);
            cmd.Parameters.AddWithValue("@cbal", p.Cbal);
            cmd.Parameters.AddWithValue("@bal", p.Balph);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertPO(BAL p)  
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("POInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@cname", BAL.Pocname);
            cmd.Parameters.AddWithValue("@ph", BAL.Poph);
            cmd.Parameters.AddWithValue("@addr", BAL.Poaddr);
            cmd.Parameters.AddWithValue("@terms", BAL.Poterms);
            cmd.Parameters.AddWithValue("@loc", BAL.Poloc);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@orderdate", BAL.Datepoorderdate);
            cmd.Parameters.AddWithValue("@istatus", BAL.Poistatus);
            cmd.Parameters.AddWithValue("@pstatus", BAL.Popstatus);
            cmd.Parameters.AddWithValue("@shpaddr", p.Poshpaddr);
            cmd.Parameters.AddWithValue("@carrier", p.Pocarrier);
            cmd.Parameters.AddWithValue("@ddate", BAL.Datepoduedate);
            cmd.Parameters.AddWithValue("@taxscheme", p.Potaxscheme);
            cmd.Parameters.AddWithValue("@nvend", p.Pononvendor);
            cmd.Parameters.AddWithValue("@currency", p.Pocurrency);
            cmd.Parameters.AddWithValue("@rshpdate", BAL.Dateporeqdate);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@stotal", p.Postotal);
            cmd.Parameters.AddWithValue("@freight", p.Pofreight);
            cmd.Parameters.AddWithValue("@stax", p.Postax);
            cmd.Parameters.AddWithValue("@ctax", p.Poctax);
            cmd.Parameters.AddWithValue("@total", p.Pototal);
            cmd.Parameters.AddWithValue("@paid", p.Popaid);
            cmd.Parameters.AddWithValue("@bal", p.Pobalance);
            cmd.Parameters.AddWithValue("@paging", p.Paging);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdatePO(BAL p)  
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("PoUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            //cmd.Parameters.AddWithValue("@odate", BAL.Poorderdate);
            cmd.Parameters.AddWithValue("@odate", BAL.Datepoorderdate);
            cmd.Parameters.AddWithValue("@istatus", BAL.Poistatus);
            cmd.Parameters.AddWithValue("@pstatus", BAL.Popstatus);
            //cmd.Parameters.AddWithValue("@ddate", p.Poddate);
            cmd.Parameters.AddWithValue("@ddate", BAL.Datepoduedate);
            //cmd.Parameters.AddWithValue("@ddate", p.Porshpdate);
            cmd.Parameters.AddWithValue("@rshipdate", BAL.Dateporeqdate);
            cmd.Parameters.AddWithValue("@stotal", p.Postotal);
            cmd.Parameters.AddWithValue("@freight", p.Pofreight);
            cmd.Parameters.AddWithValue("@stax", p.Postax);
            cmd.Parameters.AddWithValue("@ctax", p.Poctax);
            cmd.Parameters.AddWithValue("@total", p.Pototal);
            cmd.Parameters.AddWithValue("@paid", p.Popaid);
            cmd.Parameters.AddWithValue("@bal", p.Pobalance);
            cmd.Parameters.AddWithValue("@paging", p.Paging);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable POIStatusAllVOI()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("vJo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@order", BAL.Poorderno);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SelectReceived(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectreceived", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@order", BAL.Poorderno);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SOwing(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("returselect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@order", BAL.Poorderno);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable FOwing(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("unstockselect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@order", BAL.Poorderno);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Orderall()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("vendorall", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void UpdateInventory(BAL p) 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("upinventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inventory", BAL.Poistatus);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable POIStatus(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Poistatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@istatus", BAL.Poistatus);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable POPStatus(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Popstatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@pstatus", BAL.Popstatus);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SelectOrder1()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ordersearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@order", BAL.Poorderno);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void Updatestatus(BAL p)   
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("popaystatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@istatus", BAL.Poistatus);
            cmd.Parameters.AddWithValue("@pay", BAL.Popstatus);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable locsearch()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("locsearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@loc", BAL.Poloc);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Ordertoday()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sptoday", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderthisweek()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spthisweek", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderthismonth()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spthismonth", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderthisquarter()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spthisquarter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderthisyear()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spthisyear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderlast7days()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splast7days", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderlast30days()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splast30days", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderlast90days()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splast90days", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable Orderlast365days()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splast365days", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderyesterday()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spyesterdar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Orderlastweek()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splastweek", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderlastmonth()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splastmonth", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderlastquarter()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splastquarter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderlastyear()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splastyear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Ordertmrw()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sptmrw", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Ordernextweek()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spnextweek", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Ordernextmonth()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spnextmonth", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Ordernextquarter()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spnextquarter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Ordernextyear()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spnextyear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Orderfromto(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spfromto", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@date1", p.Fdate);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlParameter prm1 = new SqlParameter("@date2", p.Tdate);
            prm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SsearchA()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShowsearchA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Ssearch()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Showsearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable SsearchC(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShowsearchC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter prm = new SqlParameter("@inv", p.Status);
            //prm.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable UpdateOrder()   
        {
            //PurhcaseOrder po = new PurhcaseOrder();
            con.Open();
            SqlCommand cmd = new SqlCommand("voupdate", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void InsertRVOItems(BAL p)  
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insertreceived", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@sno", p.Isno);
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@item", p.Iiname);
            cmd.Parameters.AddWithValue("@des", p.Ides);
            cmd.Parameters.AddWithValue("@vpcode", p.Icode);
            cmd.Parameters.AddWithValue("@quan", p.Iquantity);
            cmd.Parameters.AddWithValue("@loc", BAL.Poloc);
            cmd.Parameters.AddWithValue("@rdate", p.Receiveddate1);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@tordered", p.Tordered1);
            cmd.Parameters.AddWithValue("@treceived", p.Treceived1);
            cmd.Parameters.AddWithValue("@pid", p.Iid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void InsertReturnVOItems(BAL p)  
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insertreturn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@item", p.Iiname);
            cmd.Parameters.AddWithValue("@des", p.Ides);
            cmd.Parameters.AddWithValue("@vpcode", p.Icode);
            cmd.Parameters.AddWithValue("@quan", p.Iquantity);
            cmd.Parameters.AddWithValue("@rdate", p.Returndate1);
            cmd.Parameters.AddWithValue("@up", p.Iuprice);
            cmd.Parameters.AddWithValue("@dis", p.Idiscount);
            cmd.Parameters.AddWithValue("@stotal", p.Isubtotal);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@itotal", p.Itotal);
            cmd.Parameters.AddWithValue("@fee", p.Fee);
            cmd.Parameters.AddWithValue("@total", p.Returntotal1);
            cmd.Parameters.AddWithValue("@pid", p.Iid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertUVOItems(BAL p)  
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insertunstock", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@sno", p.Isno);
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@item", p.Iiname);
            cmd.Parameters.AddWithValue("@des", p.Ides);
            cmd.Parameters.AddWithValue("@quan", p.Iquantity);
            cmd.Parameters.AddWithValue("@unstock", p.Unstock);
            cmd.Parameters.AddWithValue("@loc", BAL.Poloc);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@pid", p.Iid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        ////////////////////////////////////

        public void insertvendors(BAL cs)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spinserts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vendorname", cs.Vendorname);
            cmd.Parameters.AddWithValue("@balance", cs.BalanceV);
            cmd.Parameters.AddWithValue("@credit", cs.CreditV);
            cmd.Parameters.AddWithValue("@contactname", cs.ContactnameV);
            cmd.Parameters.AddWithValue("@phone", cs.PhoneV);
            cmd.Parameters.AddWithValue("@fax", cs.FaxV);
            cmd.Parameters.AddWithValue("@email", cs.EmailV);
            cmd.Parameters.AddWithValue("@website", cs.WebsiteV);
            cmd.Parameters.AddWithValue("@remarks", cs.RemarksV);
            cmd.Parameters.AddWithValue("@address", cs.AddressV);
            cmd.Parameters.AddWithValue("@paymentterms", cs.PaymenttermsV);
            cmd.Parameters.AddWithValue("@taxingscheme", cs.TaxingschemeV);
            cmd.Parameters.AddWithValue("@carrier", cs.CarrierV);
            cmd.Parameters.AddWithValue("@currency", cs.CurrencyV);
            cmd.Parameters.AddWithValue("@alternatecontact", cs.AlternatecontactV);
            cmd.Parameters.AddWithValue("@emergencyphone", cs.EmergencyphoneV);
            cmd.Parameters.AddWithValue("@dob", cs.DobV);
            cmd.Parameters.AddWithValue("@residence", cs.ResidenceV);
            cmd.Parameters.AddWithValue("@city", cs.CityV);
            cmd.Parameters.AddWithValue("@state", cs.StateV);
            cmd.Parameters.AddWithValue("@country", cs.CountryV);
            cmd.Parameters.AddWithValue("@zipcode", cs.ZipcodeV);
            cmd.Parameters.AddWithValue("@status", cs.StatusV);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable select3()
        {
            SqlDataAdapter da = new SqlDataAdapter("spterms", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void insert1(BAL cs)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sptermadd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sno", BAL.SnoV);
            cmd.Parameters.AddWithValue("@paymenttermsname", BAL.PaymenttermsnameV);
            cmd.Parameters.AddWithValue("@daysdue", BAL.DaysdueV);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable select4()
        {
            SqlDataAdapter da = new SqlDataAdapter("sptax", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void insert2(BAL cs)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sptaxing1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sno", BAL.SnoV);
            cmd.Parameters.AddWithValue("@taxschemename", BAL.TaxschemenameV);
            cmd.Parameters.AddWithValue("@taxname", BAL.TaxnameV);
            cmd.Parameters.AddWithValue("@taxrate", BAL.TaxrateV);
            cmd.Parameters.AddWithValue("@taxonshipping", BAL.TaxonshippingV);
            cmd.Parameters.AddWithValue("@secondarytax", BAL.SecondarytaxV);
            cmd.Parameters.AddWithValue("@secondarytaxrate", BAL.SecondarytaxrateV);
            cmd.Parameters.AddWithValue("@secondarytaxon", BAL.SecondarytaxonV);
            cmd.Parameters.AddWithValue("@compoundsceondary", BAL.CompoundsecondaryV);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable select9(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spactive5", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", cs.StatusV);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void update1(BAL cs)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", cs.StatusV);
            cmd.Parameters.AddWithValue("@vendorname", cs.Vendorname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable select11()
        {
            SqlDataAdapter da = new SqlDataAdapter("spcarrier", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable select12()
        {
            SqlDataAdapter da = new SqlDataAdapter("sporders", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select16()
        {
            SqlCommand cmd = new SqlCommand("spcons", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@countryname", BAL.Countryname);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select178(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custonename", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", B.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable select17()
        {
            SqlCommand cmd = new SqlCommand("spstats", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statename", BAL.Statename);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select18()
        {
            SqlDataAdapter da = new SqlDataAdapter("spcont", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select20()
        {
            SqlDataAdapter da = new SqlDataAdapter("spsel", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select21()
        {
            SqlDataAdapter da = new SqlDataAdapter("spcurrency", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select23()
        {
            SqlDataAdapter da = new SqlDataAdapter("spproducts", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select25()
        {
            SqlDataAdapter da = new SqlDataAdapter("spall", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select26()
        {
            SqlDataAdapter da = new SqlDataAdapter("spmax", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select27()
        {
            SqlDataAdapter da = new SqlDataAdapter("spgetadd", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select28()
        {
            SqlDataAdapter da = new SqlDataAdapter("splast", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select29()
        {
            SqlDataAdapter da = new SqlDataAdapter("splast1", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select30()
        {
            SqlCommand cmd = new SqlCommand("spdatefrom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date1", BAL.Date1);
            cmd.Parameters.AddWithValue("@date2", BAL.Date2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select31(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spemail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", cs.Email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select36(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spvendornames1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vendorname", cs.Vendorname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select37(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vendorname", cs.Vendorname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select38(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spcontactname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@contactname", cs.Contactname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable select39(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spemails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", cs.Email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select40()
        {
            SqlDataAdapter da = new SqlDataAdapter("spord", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable select41()
        {
            SqlDataAdapter da = new SqlDataAdapter("sporde", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //////////////////////////////////////////
        public DataTable selectvendor()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spselectvendlist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectvendrname(BAL p)
        {
            con.Open();
             SqlCommand cmd = new SqlCommand("SELECT * FROM vendors WHERE vendorname LIKE  @vendorname+'%'", con);
          //  SqlCommand cmd = new SqlCommand("spvendorname", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", p.Vendorname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectcontact(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spcontactnameL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@contactname", p.Contactname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************************** Search Based On Contact Email *****************//
        public DataTable selectemail(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spemail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@email", p.Email);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************************** Search Based On Vendor Name and Contact Name *****************//
        public DataTable loadvendor2(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvload2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", p.Vendorname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlParameter prm1 = new SqlParameter("@contactname", p.Contactname);
            prm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm1);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************************** Search Based On Vendor Name,Contact Name and email *****************//
        public DataTable loadvendor3(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvload3", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", p.Vendorname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlParameter prm1 = new SqlParameter("@contactname", p.Contactname);
            prm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@email", p.Email);
            prm2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm2);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //************************* SELECT BASED ON Button Click***********//
        public DataTable selectrow(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvendorlist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", p.Vendorname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlParameter prm1 = new SqlParameter("@contactname", p.Contactname);
            prm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@email", p.Email);
            prm2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm2);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************************** Search Based On Show Status*****************//
        public DataTable selecshow(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spselecshow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@status", p.ShowL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //*************** Navigate to Vendor Form based on vendor name***********************// 
        public DataTable selectvendrname1(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sploadvendorname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", BAL.NamL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //******************Show Status in combobox When Navigate to Vendor form*************//
        public DataTable selecshowbtn(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spshowbutton", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@show", p.ShowL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //**********************Update vendor Status in Vendor Form**************// 
        public DataTable updateshow(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@show", p.ShowL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlParameter prm1 = new SqlParameter("@vendorname", p.Vendorname);
            prm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm1);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //*****************load vendor name in vendor form********************//
        public DataTable Lname(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Vname1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", p.Vendorname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //*************Used in Vendor Form ***************//
        public DataTable loadname()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sploadname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //--------------------------------------------------------------------------------------------------------------------//

        //*********************************PUCHAESE ORDERLIST*******************//

        //*********************Bind To Grid in Puchase Order List form ******************//

        public DataTable selectpurclist()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spselectpurclist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //**************************Search Based On Order No********************//
        public DataTable loadorderno(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sporderno", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@poorderno", p.PoordernoL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************************** Search Based On Inventory Sttus ********************//
        public DataTable loadinvtstatus(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spinventstatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@inventorystatus", p.InventorystatusL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //public DataTable loadinvtstatus1(prop p)
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("spinventstatus1", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    SqlParameter prm = new SqlParameter("@inventorystatus", p.Inventorystatus);
        //    prm.Direction = ParameterDirection.Input;
        //    cmd.Parameters.Add(prm);
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}

        //public DataTable selectpurc()
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("spselectpurc", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}

        //*************************Search Based On Payment Status***********************//
        public DataTable loadpaystatus(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sppaystatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@paymentstatus", p.PaymentstatusL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************************ Bind Vendor Names To Grid When VendorName Combo Is Clicked***********************//
        public DataTable loadvname()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //*************************Search Records Based on Selected Vendor Name ***********************//
        public DataTable loadvendname(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvendname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", BAL.NamL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable loadvendname1(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spvendname1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@poorderno", BAL.NamL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //*************************Navigate To Vendor Form Based On Selected VendorName***********************//
        public DataTable Porder(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Porder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@vendorname", p.VendornameL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //***************************Bind OrderNo.To Grid in Puchase Order form**********************//
        public DataTable loadno()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Purchorder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //*************************Search Based On Show Status***********************//
        public DataTable selecshowcanc(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spselecshowcanc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@showcancelled", p.ShowcancelledL);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select98(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", B.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;


        }

        public DataTable select1(BAL B)
        {
            SqlDataAdapter da = new SqlDataAdapter("totalselect", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable select2(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custphon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@phone", B.Phone);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable select3(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custmail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", B.Email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable select4(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custall", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", B.Customername);
            cmd.Parameters.AddWithValue("@phone", B.Phone);
            cmd.Parameters.AddWithValue("@email", B.Email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable select8(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custshow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", B.Status1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select99(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custshown1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", B.Status1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select10(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custshown2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", B.Status1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select11(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custshown3", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", B.Status1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public DataTable select12(BAL B)
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("custrelation", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@customername", B.Customername);
        //    cmd.Parameters.AddWithValue("@phone", B.Phone);
        //    cmd.Parameters.AddWithValue("@contactname", B.Contactname);
        //    cmd.Parameters.AddWithValue("@email", B.Email);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;

        //}
        public DataTable select13(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custcontact", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@contactname", B.Contactname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable select14(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("phoemail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@phone", B.Phone);
            cmd.Parameters.AddWithValue("@email", B.Email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select15(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custinactname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", B.Status1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select16(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("retrive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", B.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select17(BAL B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custonename", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", B.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }

//==============================================================================================================






        public DataTable slect__custmerdetails__to__grid(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("custmerofGRID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SEARCH__BY__CUSTOMER(BAL BL)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("customerSEARCH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", BAL.Cust);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selct_by_payment_ALL(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selct_by_payment_ALL", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select_UNINVOICE(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_UNINVOICE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Paymentstatus", bl.Paymentstatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select_PAID(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_PAID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Paymentstatus", bl.Paymentstatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt); con.Close();
            return dt;
        }
        public DataTable select_Invoiced(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_Invoiced", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Paymentstatus", bl.Paymentstatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select_partial(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_partial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Paymentstatus", bl.Paymentstatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select_Owing(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_Owing", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Paymentstatus", bl.Paymentstatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select_FULLFILLED(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_FULLFILLED", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inventorystatus", bl.Inventorystatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select_UNFULFILLED(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_UNFULFILLED", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inventorystatus", bl.Inventorystatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select_started(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select_started", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inventorystatus", bl.Inventorystatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable searchbynumberlike(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("searchbynumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderno", bl.Orderno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable seacrhbycustomerlike(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("searchbycustname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", bl.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable selectorderno(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectorderno", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable searchbyCUSTOMERNAME(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("searchbycustomername", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customername", bl.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SALESsearchbyORDERNUM(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SALESsearchbyordernum", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderno", bl.Orderno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable directlybindingtoGRID(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("slectingalloforders", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable selectquotes(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectquotes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable ACTIVE(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ACTIVE", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable CANCELLED(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CANCELLED1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inventorystatus", bl.Inventorystatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable THISMONTH(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("THISMONTH", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable THISYAER(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("THISYEAR", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable YESTERDAY(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("yESTREDAY", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LASTMONTH(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("LASTMONTH", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LASTYEAR(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("LASTYEAR", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable TOMARROW(BAL BL)
        {
            con.Open();
            SqlCommand CMD = new SqlCommand("TOMARROW", con);
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable NEXTmonth(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("NEXTMONTH", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable NEXTYEAR(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("NEXTYEAR", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LAST_7_DAYS(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("last7DAYS", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LAST_30_DAYS(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("LAST30DAYS", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LAST_WEEK(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("LASTWEEK", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable THIS_WEEK(BAL bl)
        {
            con.Open(); SqlCommand cmd = new SqlCommand("THISWEEK", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable NEXT_WWEEK(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[NEXTWEEK]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable searchdate_by_frm2todate(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("searchdate_by_frm2todate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@from_date_", bl.From_date_);
            cmd.Parameters.AddWithValue("@to_date_", bl.To_date_);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable searchbynumber_in_custmergrid(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("search_in_custgrid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderno", bl.Orderno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable searchbyCUSNAME_IN_CUSTGRID(BAL bl)
        {
            con.Open();
            SqlCommand cdm = new SqlCommand("searchbyCUSNAME_IN_CUSTGRID", con);
            cdm.CommandType = CommandType.StoredProcedure;
            cdm.Parameters.AddWithValue("@customername", bl.Customername);
            SqlDataAdapter da = new SqlDataAdapter(cdm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable activecancelled(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("activecancelled", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable inventorystatus(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectfulfillofcustORDERLIST", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inventorystatus", bl.Inventorystatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectpaymentORDERFORM(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectpaymentstatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@paymentstatus", bl.Paymentstatus);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable allselected(BAL bl)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("allselected", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public DataTable selectQOH(BAL Prop)
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("selectquantityonhand", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlParameter prm = new SqlParameter("@productid", Prop.Iid);
        //    prm.Direction = ParameterDirection.Input;
        //    cmd.Parameters.Add(prm);
        //    SqlParameter prm1 = new SqlParameter("@itemnameorcode", Prop.Iiname);
        //    prm1.Direction = ParameterDirection.Input;
        //    cmd.Parameters.Add(prm1);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}

        public void updateQOH(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("updatequantityonhand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", Prop.Iid);
            cmd.Parameters.AddWithValue("@itemnameorcode", Prop.Iiname);
            cmd.Parameters.AddWithValue("@quantityonhand", Prop.QuanOnHand1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void OrderHistoryInsert(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ohinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", Prop.Type);
            cmd.Parameters.AddWithValue("@ono", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@cname", BAL.Povname);
            cmd.Parameters.AddWithValue("@date", BAL.Datepoorderdate);
            cmd.Parameters.AddWithValue("@ostatus", BAL.Poistatus);
            cmd.Parameters.AddWithValue("@itemid", Prop.Iid);
            cmd.Parameters.AddWithValue("@iname", Prop.Iiname);
            cmd.Parameters.AddWithValue("@quan", Prop.Iquantity);
            cmd.Parameters.AddWithValue("@stotal", Prop.Isubtotal);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void OrderHistoryUpdate(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ohupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ono", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@ostatus", BAL.Poistatus);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void MovementHistoryInsert(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("mhinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inamercode", Prop.Iiname);
            cmd.Parameters.AddWithValue("@desc", Prop.Ides);
            cmd.Parameters.AddWithValue("@trans", Prop.Trans);
            cmd.Parameters.AddWithValue("@date", BAL.Datepoorderdate);
            cmd.Parameters.AddWithValue("@loc", BAL.Poloc);
            cmd.Parameters.AddWithValue("@ono", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@qoh", Prop.QuanOnHand1);
            cmd.Parameters.AddWithValue("@quan", Prop.Iquantity);
            cmd.Parameters.AddWithValue("@qafter", Prop.QAfter1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable select1()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spselect110", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void updateistatus(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("updateistatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pono", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@istatus", BAL.Poistatus);
            cmd.Parameters.AddWithValue("@pstatus", BAL.Popstatus);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable SelectVName(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("namebind", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //============================================
        //public void insert110(BAL bl)
        //{
        //    SqlCommand cmd = new SqlCommand("spcurrent", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@item", bl.item);
        //    cmd.Parameters.AddWithValue("@description", bl.Description);
        //    cmd.Parameters.AddWithValue("@category", bl.Category);
        //    //cmd.Parameters.AddWithValue("@normalprice", cs.Normalprice);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        public DataTable select()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spitem123", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select111()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spcurrent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select2()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("splocation", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable select333()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spcategory ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectitemname(string item)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_searchname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@item", item);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectloc(string location)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_locationname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@location", location);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectcotegory1(string category)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spcoo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@category", category);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectall10()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_all", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
      
        public DataTable selectpr(string item)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_li", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@item", item);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable selectview(string item)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_view", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@item", item);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //================================================
        public DataTable selectph(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("vendorph", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@vname", BAL.Povname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable selectoh(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("vendororderh", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@vname", BAL.Povname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable SelectVOrderhis(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("vendororderhis", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@vname", BAL.Povname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //////////////////////////////////////////

        public DataTable selectItemCat()
        {
            SqlCommand cmd = new SqlCommand("selectcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void ProductLocationInsert(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insertProductInvLoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pname", Prop.Iiname);
            cmd.Parameters.AddWithValue("@loc", Prop.Loc);
            cmd.Parameters.AddWithValue("@quan", Prop.Quantity);
            cmd.Parameters.AddWithValue("@date", Prop.Idate1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable bindtranstype()
        {
            SqlCommand cmd = new SqlCommand("selecttrans_mh", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selecttranstype(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("movementsearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@trans", bal.Trans);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable selectmovloc(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("movementsearchloc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@loc", bal.Loc);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void updateProductstatus(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("deactive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@item", bal.Iiname);
            cmd.Parameters.AddWithValue("@status", bal.Status1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable TviewParent()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spTreeview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void CategoryInsert(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CategoryInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoryName", bal.CategoryNameC);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CategoryDelete(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CategoryDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoryName", bal.CategoryNameC);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CategoryUpdate(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CategoryUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoryName", bal.CategNameC);
            cmd.Parameters.AddWithValue("@categName", bal.CategoryNameC);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public DataTable CategoryRetrieve(BAL bal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CategoryRetrieve", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlParameter prm = new SqlParameter("@category", bal.CategoryC);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }




        //============================================================================


        public DataTable select115()
        {
            SqlDataAdapter da = new SqlDataAdapter("spselect115", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectgrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("spselectgrid", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectcategory()
        {
            SqlDataAdapter da = new SqlDataAdapter("spselectcategory", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectdesc(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spselectdesc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@description", cs.Description);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectitem(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spselectitem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@itemnameorcode", cs.Itemname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selecttypetext(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spselecttypetext", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", cs.Type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectcattext(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spselectcattext", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@category", cs.Category);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectactive(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spactive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", cs.Status1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectstatus115()
        {
            SqlDataAdapter da = new SqlDataAdapter("spstatus", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable selectname(BAL cs)
        {
            SqlCommand cmd = new SqlCommand("spselectname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@itemnameorcode", cs.Itemname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        //============================================================================
        public DataTable vendsearch()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("vendsearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter prm = new SqlParameter("@vend", BAL.Povname);
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void UpdatePO1(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("PoUpdate1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@cname", BAL.Pocname);
            cmd.Parameters.AddWithValue("@ph", BAL.Poph);
            cmd.Parameters.AddWithValue("@addr", BAL.Poaddr);
            cmd.Parameters.AddWithValue("@terms", BAL.Poterms);
            cmd.Parameters.AddWithValue("@loc", BAL.Poloc);
            cmd.Parameters.AddWithValue("@orderdate", BAL.Datepoorderdate);
            cmd.Parameters.AddWithValue("@istatus", BAL.Poistatus);
            cmd.Parameters.AddWithValue("@pstatus", BAL.Popstatus);
            cmd.Parameters.AddWithValue("@shpaddr", p.Poshpaddr);
            cmd.Parameters.AddWithValue("@carrier", p.Pocarrier);
            cmd.Parameters.AddWithValue("@ddate", BAL.Datepoduedate);
            cmd.Parameters.AddWithValue("@taxscheme", p.Potaxscheme);
            cmd.Parameters.AddWithValue("@nvend", p.Pononvendor);
            cmd.Parameters.AddWithValue("@currency", p.Pocurrency);
            cmd.Parameters.AddWithValue("@rshpdate", BAL.Dateporeqdate);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@stotal", p.Postotal);
            cmd.Parameters.AddWithValue("@freight", p.Pofreight);
            cmd.Parameters.AddWithValue("@stax", p.Postax);
            cmd.Parameters.AddWithValue("@ctax", p.Poctax);
            cmd.Parameters.AddWithValue("@total", p.Pototal);
            cmd.Parameters.AddWithValue("@paid", p.Popaid);
            cmd.Parameters.AddWithValue("@bal", p.Pobalance);
            cmd.Parameters.AddWithValue("@paging", p.Paging);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateReceive(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("updatereceive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@sno", p.Isno);
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@iname", p.Iiname);
            cmd.Parameters.AddWithValue("@desc", p.Ides);
            cmd.Parameters.AddWithValue("@vpcode", p.Icode);
            cmd.Parameters.AddWithValue("@quan", p.Iquantity);
            cmd.Parameters.AddWithValue("@loc", BAL.Poloc);
            cmd.Parameters.AddWithValue("@rdate", p.Receiveddate1);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@tordered", p.Tordered1);
            cmd.Parameters.AddWithValue("@treceived", p.Treceived1);
            cmd.Parameters.AddWithValue("@pid", p.Iid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateReturn(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("updatereturn", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@iname", p.Iiname);
            cmd.Parameters.AddWithValue("@desc", p.Ides);
            cmd.Parameters.AddWithValue("@vpcode", p.Icode);
            cmd.Parameters.AddWithValue("@quan", p.Iquantity);
            cmd.Parameters.AddWithValue("@rdate", p.Returndate1);
            cmd.Parameters.AddWithValue("@unitprice", p.Iuprice);
            cmd.Parameters.AddWithValue("@dis", p.Idiscount);
            cmd.Parameters.AddWithValue("@stotal", p.Isubtotal);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@itotal", p.Itotal);
            cmd.Parameters.AddWithValue("@fee", p.Fee);
            cmd.Parameters.AddWithValue("@total", p.Returntotal1);
            cmd.Parameters.AddWithValue("@pid", p.Iid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateUnstock(BAL p)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("updateunstock", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@sno", p.Isno);
            cmd.Parameters.AddWithValue("@vid", p.Povid);
            cmd.Parameters.AddWithValue("@vname", BAL.Povname);
            cmd.Parameters.AddWithValue("@order", BAL.Poorderno);
            cmd.Parameters.AddWithValue("@iname", p.Iiname);
            cmd.Parameters.AddWithValue("@desc", p.Ides);
            cmd.Parameters.AddWithValue("@quan", p.Iquantity);
            cmd.Parameters.AddWithValue("@udate", p.Unstock);
            cmd.Parameters.AddWithValue("@loc", BAL.Poloc);
            cmd.Parameters.AddWithValue("@remarks", p.Poremarks);
            cmd.Parameters.AddWithValue("@pid", p.Iid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable SelectReceive()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectreceive", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SelectReturn()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectreturn", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SelectUnstock()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectunstock", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void selectQOH(BAL Prop)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectquantityonhand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", Prop.Iid);
            cmd.Parameters.AddWithValue("@itemnameorcode", Prop.Iiname);
            SqlDataReader da = cmd.ExecuteReader();
            if (da.HasRows)
            {
                while (da.Read())
                {
                    Prop.QuanOnHand1 = da["quantityonhand"].ToString();
                }
            }

            con.Close();

        }


        }

    }

//=====================================================================================================

