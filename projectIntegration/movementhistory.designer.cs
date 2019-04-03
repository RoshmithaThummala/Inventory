namespace InventoryTools
{
    partial class movementhistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnadd = new System.Windows.Forms.Button();
            this.dgvproduct = new System.Windows.Forms.DataGridView();
            this.dgvlocation = new System.Windows.Forms.DataGridView();
            this.Locations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paneldate = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbto = new System.Windows.Forms.ComboBox();
            this.cmbfrom = new System.Windows.Forms.ComboBox();
            this.lblto = new System.Windows.Forms.Label();
            this.lblfrom = new System.Windows.Forms.Label();
            this.lablstyear = new System.Windows.Forms.Label();
            this.lablstqut = new System.Windows.Forms.Label();
            this.lablstmonth = new System.Windows.Forms.Label();
            this.lablsweek = new System.Windows.Forms.Label();
            this.labyesterday = new System.Windows.Forms.Label();
            this.labthyear = new System.Windows.Forms.Label();
            this.labthquarter = new System.Windows.Forms.Label();
            this.labthmonth = new System.Windows.Forms.Label();
            this.labthweek = new System.Windows.Forms.Label();
            this.labtoday = new System.Windows.Forms.Label();
            this.laball = new System.Windows.Forms.Label();
            this.cmbdate = new System.Windows.Forms.ComboBox();
            this.paneltranc = new System.Windows.Forms.Panel();
            this.chkrestock = new System.Windows.Forms.CheckBox();
            this.chkful = new System.Windows.Forms.CheckBox();
            this.chkpick = new System.Windows.Forms.CheckBox();
            this.chkunstock = new System.Windows.Forms.CheckBox();
            this.chkrecive = new System.Windows.Forms.CheckBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.cmbloc = new System.Windows.Forms.ComboBox();
            this.cmbtrans = new System.Windows.Forms.ComboBox();
            this.cmbitem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvdisplay = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normalprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnamerocode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityonhand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityafter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlocation)).BeginInit();
            this.paneldate.SuspendLayout();
            this.paneltranc.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.dgvlocation);
            this.panel3.Controls.Add(this.paneldate);
            this.panel3.Controls.Add(this.cmbdate);
            this.panel3.Controls.Add(this.paneltranc);
            this.panel3.Controls.Add(this.cmbloc);
            this.panel3.Controls.Add(this.cmbtrans);
            this.panel3.Controls.Add(this.cmbitem);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.dgvdisplay);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(0, -2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 616);
            this.panel3.TabIndex = 4;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnadd);
            this.panel2.Controls.Add(this.dgvproduct);
            this.panel2.Location = new System.Drawing.Point(116, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 119);
            this.panel2.TabIndex = 18;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(453, 85);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 18;
            this.btnadd.Text = "Add New";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // dgvproduct
            // 
            this.dgvproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.items,
            this.descriptions,
            this.category,
            this.normalprice});
            this.dgvproduct.Location = new System.Drawing.Point(0, 0);
            this.dgvproduct.Name = "dgvproduct";
            this.dgvproduct.Size = new System.Drawing.Size(543, 62);
            this.dgvproduct.TabIndex = 17;
            this.dgvproduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvproduct_CellClick);
            this.dgvproduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvproduct_CellContentClick);
            // 
            // dgvlocation
            // 
            this.dgvlocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvlocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Locations});
            this.dgvlocation.Location = new System.Drawing.Point(116, 123);
            this.dgvlocation.Name = "dgvlocation";
            this.dgvlocation.Size = new System.Drawing.Size(648, 150);
            this.dgvlocation.TabIndex = 17;
            this.dgvlocation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlocation_CellClick);
            // 
            // Locations
            // 
            this.Locations.DataPropertyName = "location";
            this.Locations.HeaderText = "Locations";
            this.Locations.Name = "Locations";
            // 
            // paneldate
            // 
            this.paneldate.BackColor = System.Drawing.SystemColors.Control;
            this.paneldate.Controls.Add(this.dateTimePicker2);
            this.paneldate.Controls.Add(this.dateTimePicker1);
            this.paneldate.Controls.Add(this.cmbto);
            this.paneldate.Controls.Add(this.cmbfrom);
            this.paneldate.Controls.Add(this.lblto);
            this.paneldate.Controls.Add(this.lblfrom);
            this.paneldate.Controls.Add(this.lablstyear);
            this.paneldate.Controls.Add(this.lablstqut);
            this.paneldate.Controls.Add(this.lablstmonth);
            this.paneldate.Controls.Add(this.lablsweek);
            this.paneldate.Controls.Add(this.labyesterday);
            this.paneldate.Controls.Add(this.labthyear);
            this.paneldate.Controls.Add(this.labthquarter);
            this.paneldate.Controls.Add(this.labthmonth);
            this.paneldate.Controls.Add(this.labthweek);
            this.paneldate.Controls.Add(this.labtoday);
            this.paneldate.Controls.Add(this.laball);
            this.paneldate.Location = new System.Drawing.Point(116, 157);
            this.paneldate.Name = "paneldate";
            this.paneldate.Size = new System.Drawing.Size(648, 356);
            this.paneldate.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(58, 316);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(590, 20);
            this.dateTimePicker2.TabIndex = 24;
            this.dateTimePicker2.Value = new System.DateTime(2015, 12, 24, 19, 12, 0, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(58, 292);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(590, 20);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cmbto
            // 
            this.cmbto.DropDownHeight = 1;
            this.cmbto.FormattingEnabled = true;
            this.cmbto.IntegralHeight = false;
            this.cmbto.Location = new System.Drawing.Point(58, 295);
            this.cmbto.Name = "cmbto";
            this.cmbto.Size = new System.Drawing.Size(590, 21);
            this.cmbto.TabIndex = 22;
            this.cmbto.TextChanged += new System.EventHandler(this.cmbto_TextChanged);
            this.cmbto.Click += new System.EventHandler(this.cmbto_Click);
            // 
            // cmbfrom
            // 
            this.cmbfrom.DropDownHeight = 1;
            this.cmbfrom.FormattingEnabled = true;
            this.cmbfrom.IntegralHeight = false;
            this.cmbfrom.Location = new System.Drawing.Point(58, 271);
            this.cmbfrom.Name = "cmbfrom";
            this.cmbfrom.Size = new System.Drawing.Size(590, 21);
            this.cmbfrom.TabIndex = 21;
            this.cmbfrom.Click += new System.EventHandler(this.cmbfrom_Click);
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Location = new System.Drawing.Point(-1, 295);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(20, 13);
            this.lblto.TabIndex = 20;
            this.lblto.Text = "To";
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Location = new System.Drawing.Point(0, 271);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(30, 13);
            this.lblfrom.TabIndex = 19;
            this.lblfrom.Text = "From";
            // 
            // lablstyear
            // 
            this.lablstyear.AutoSize = true;
            this.lablstyear.Location = new System.Drawing.Point(0, 234);
            this.lablstyear.Name = "lablstyear";
            this.lablstyear.Size = new System.Drawing.Size(52, 13);
            this.lablstyear.TabIndex = 10;
            this.lablstyear.Text = "Last Year";
            this.lablstyear.Click += new System.EventHandler(this.lablstyear_Click);
            // 
            // lablstqut
            // 
            this.lablstqut.AutoSize = true;
            this.lablstqut.Location = new System.Drawing.Point(0, 208);
            this.lablstqut.Name = "lablstqut";
            this.lablstqut.Size = new System.Drawing.Size(65, 13);
            this.lablstqut.TabIndex = 9;
            this.lablstqut.Text = "Last Quartor";
            this.lablstqut.Click += new System.EventHandler(this.lablstqut_Click);
            // 
            // lablstmonth
            // 
            this.lablstmonth.AutoSize = true;
            this.lablstmonth.Location = new System.Drawing.Point(3, 184);
            this.lablstmonth.Name = "lablstmonth";
            this.lablstmonth.Size = new System.Drawing.Size(60, 13);
            this.lablstmonth.TabIndex = 8;
            this.lablstmonth.Text = "Last Month";
            this.lablstmonth.Click += new System.EventHandler(this.lablstmonth_Click);
            // 
            // lablsweek
            // 
            this.lablsweek.AutoSize = true;
            this.lablsweek.Location = new System.Drawing.Point(-3, 158);
            this.lablsweek.Name = "lablsweek";
            this.lablsweek.Size = new System.Drawing.Size(59, 13);
            this.lablsweek.TabIndex = 7;
            this.lablsweek.Text = "Last Week";
            this.lablsweek.Click += new System.EventHandler(this.lablsweek_Click);
            // 
            // labyesterday
            // 
            this.labyesterday.AutoSize = true;
            this.labyesterday.Location = new System.Drawing.Point(-3, 134);
            this.labyesterday.Name = "labyesterday";
            this.labyesterday.Size = new System.Drawing.Size(54, 13);
            this.labyesterday.TabIndex = 6;
            this.labyesterday.Text = "Yesterday";
            this.labyesterday.Click += new System.EventHandler(this.labyesterday_Click);
            // 
            // labthyear
            // 
            this.labthyear.AutoSize = true;
            this.labthyear.Location = new System.Drawing.Point(-3, 112);
            this.labthyear.Name = "labthyear";
            this.labthyear.Size = new System.Drawing.Size(52, 13);
            this.labthyear.TabIndex = 5;
            this.labthyear.Text = "This Year";
            this.labthyear.Click += new System.EventHandler(this.labthyear_Click);
            // 
            // labthquarter
            // 
            this.labthquarter.AutoSize = true;
            this.labthquarter.Location = new System.Drawing.Point(0, 90);
            this.labthquarter.Name = "labthquarter";
            this.labthquarter.Size = new System.Drawing.Size(62, 13);
            this.labthquarter.TabIndex = 4;
            this.labthquarter.Text = "This Quator";
            this.labthquarter.Click += new System.EventHandler(this.labthquarter_Click);
            // 
            // labthmonth
            // 
            this.labthmonth.AutoSize = true;
            this.labthmonth.Location = new System.Drawing.Point(-1, 67);
            this.labthmonth.Name = "labthmonth";
            this.labthmonth.Size = new System.Drawing.Size(60, 13);
            this.labthmonth.TabIndex = 3;
            this.labthmonth.Text = "This Month";
            this.labthmonth.Click += new System.EventHandler(this.labthmonth_Click);
            // 
            // labthweek
            // 
            this.labthweek.AutoSize = true;
            this.labthweek.Location = new System.Drawing.Point(-1, 44);
            this.labthweek.Name = "labthweek";
            this.labthweek.Size = new System.Drawing.Size(59, 13);
            this.labthweek.TabIndex = 2;
            this.labthweek.Text = "This Week";
            this.labthweek.Click += new System.EventHandler(this.labthweek_Click);
            // 
            // labtoday
            // 
            this.labtoday.AutoSize = true;
            this.labtoday.Location = new System.Drawing.Point(0, 22);
            this.labtoday.Name = "labtoday";
            this.labtoday.Size = new System.Drawing.Size(37, 13);
            this.labtoday.TabIndex = 1;
            this.labtoday.Text = "Today";
            this.labtoday.Click += new System.EventHandler(this.labtoday_Click);
            // 
            // laball
            // 
            this.laball.AutoSize = true;
            this.laball.Location = new System.Drawing.Point(3, 9);
            this.laball.Name = "laball";
            this.laball.Size = new System.Drawing.Size(18, 13);
            this.laball.TabIndex = 0;
            this.laball.Text = "All";
            this.laball.Click += new System.EventHandler(this.laball_Click);
            // 
            // cmbdate
            // 
            this.cmbdate.DropDownHeight = 1;
            this.cmbdate.FormattingEnabled = true;
            this.cmbdate.IntegralHeight = false;
            this.cmbdate.Location = new System.Drawing.Point(116, 136);
            this.cmbdate.Name = "cmbdate";
            this.cmbdate.Size = new System.Drawing.Size(648, 21);
            this.cmbdate.TabIndex = 16;
            this.cmbdate.Click += new System.EventHandler(this.comboBox3_Click);
            // 
            // paneltranc
            // 
            this.paneltranc.BackColor = System.Drawing.SystemColors.Window;
            this.paneltranc.Controls.Add(this.chkrestock);
            this.paneltranc.Controls.Add(this.chkful);
            this.paneltranc.Controls.Add(this.chkpick);
            this.paneltranc.Controls.Add(this.chkunstock);
            this.paneltranc.Controls.Add(this.chkrecive);
            this.paneltranc.Controls.Add(this.chkall);
            this.paneltranc.Location = new System.Drawing.Point(116, 93);
            this.paneltranc.Name = "paneltranc";
            this.paneltranc.Size = new System.Drawing.Size(491, 147);
            this.paneltranc.TabIndex = 18;
            // 
            // chkrestock
            // 
            this.chkrestock.AutoSize = true;
            this.chkrestock.Location = new System.Drawing.Point(3, 114);
            this.chkrestock.Name = "chkrestock";
            this.chkrestock.Size = new System.Drawing.Size(124, 17);
            this.chkrestock.TabIndex = 5;
            this.chkrestock.Text = "Sales Order Restock";
            this.chkrestock.UseVisualStyleBackColor = true;
            this.chkrestock.CheckedChanged += new System.EventHandler(this.chkrestock_CheckedChanged);
            // 
            // chkful
            // 
            this.chkful.AutoSize = true;
            this.chkful.Location = new System.Drawing.Point(3, 95);
            this.chkful.Name = "chkful";
            this.chkful.Size = new System.Drawing.Size(130, 17);
            this.chkful.TabIndex = 4;
            this.chkful.Text = "Sales Order Fulfillment";
            this.chkful.UseVisualStyleBackColor = true;
            this.chkful.CheckedChanged += new System.EventHandler(this.chkful_CheckedChanged);
            // 
            // chkpick
            // 
            this.chkpick.AutoSize = true;
            this.chkpick.Location = new System.Drawing.Point(3, 72);
            this.chkpick.Name = "chkpick";
            this.chkpick.Size = new System.Drawing.Size(119, 17);
            this.chkpick.TabIndex = 3;
            this.chkpick.Text = "Sales Order Picking";
            this.chkpick.UseVisualStyleBackColor = true;
            this.chkpick.CheckedChanged += new System.EventHandler(this.chkpick_CheckedChanged);
            // 
            // chkunstock
            // 
            this.chkunstock.AutoSize = true;
            this.chkunstock.Location = new System.Drawing.Point(3, 49);
            this.chkunstock.Name = "chkunstock";
            this.chkunstock.Size = new System.Drawing.Size(143, 17);
            this.chkunstock.TabIndex = 2;
            this.chkunstock.Text = "Purchase Order Unstock";
            this.chkunstock.UseVisualStyleBackColor = true;
            this.chkunstock.CheckedChanged += new System.EventHandler(this.chkunstock_CheckedChanged);
            // 
            // chkrecive
            // 
            this.chkrecive.AutoSize = true;
            this.chkrecive.Location = new System.Drawing.Point(3, 26);
            this.chkrecive.Name = "chkrecive";
            this.chkrecive.Size = new System.Drawing.Size(137, 17);
            this.chkrecive.TabIndex = 1;
            this.chkrecive.Text = "Purchase Order Recive";
            this.chkrecive.UseVisualStyleBackColor = true;
            this.chkrecive.CheckedChanged += new System.EventHandler(this.chkrecive_CheckedChanged);
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Location = new System.Drawing.Point(3, 3);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(37, 17);
            this.chkall.TabIndex = 0;
            this.chkall.Text = "All";
            this.chkall.UseVisualStyleBackColor = true;
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // cmbloc
            // 
            this.cmbloc.DropDownHeight = 1;
            this.cmbloc.FormattingEnabled = true;
            this.cmbloc.IntegralHeight = false;
            this.cmbloc.Location = new System.Drawing.Point(116, 102);
            this.cmbloc.Name = "cmbloc";
            this.cmbloc.Size = new System.Drawing.Size(648, 21);
            this.cmbloc.TabIndex = 15;
            this.cmbloc.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.cmbloc.Click += new System.EventHandler(this.cmbloc_Click);
            // 
            // cmbtrans
            // 
            this.cmbtrans.DropDownHeight = 1;
            this.cmbtrans.FormattingEnabled = true;
            this.cmbtrans.IntegralHeight = false;
            this.cmbtrans.Location = new System.Drawing.Point(116, 72);
            this.cmbtrans.Name = "cmbtrans";
            this.cmbtrans.Size = new System.Drawing.Size(648, 21);
            this.cmbtrans.TabIndex = 14;
            this.cmbtrans.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // cmbitem
            // 
            this.cmbitem.DropDownHeight = 1;
            this.cmbitem.FormattingEnabled = true;
            this.cmbitem.IntegralHeight = false;
            this.cmbitem.Location = new System.Drawing.Point(116, 44);
            this.cmbitem.Name = "cmbitem";
            this.cmbitem.Size = new System.Drawing.Size(648, 21);
            this.cmbitem.TabIndex = 13;
            this.cmbitem.Click += new System.EventHandler(this.cmbitem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Date";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 27);
            this.panel1.TabIndex = 9;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(190, 29);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 25);
            this.panel4.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(317, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movement History";
            // 
            // dgvdisplay
            // 
            this.dgvdisplay.AllowUserToAddRows = false;
            this.dgvdisplay.BackgroundColor = System.Drawing.Color.White;
            this.dgvdisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemnamerocode,
            this.description,
            this.trans,
            this.date,
            this.location,
            this.orderno,
            this.quantityonhand,
            this.quantity,
            this.quantityafter});
            this.dgvdisplay.Location = new System.Drawing.Point(13, 190);
            this.dgvdisplay.Margin = new System.Windows.Forms.Padding(2);
            this.dgvdisplay.Name = "dgvdisplay";
            this.dgvdisplay.Size = new System.Drawing.Size(778, 422);
            this.dgvdisplay.TabIndex = 0;
            this.dgvdisplay.Click += new System.EventHandler(this.dgvdisplay_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(716, 162);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Transaction Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search";
            // 
            // items
            // 
            this.items.DataPropertyName = "itemnameorcode";
            this.items.HeaderText = "items";
            this.items.Name = "items";
            // 
            // descriptions
            // 
            this.descriptions.DataPropertyName = "description";
            this.descriptions.HeaderText = "descriptions";
            this.descriptions.Name = "descriptions";
            // 
            // category
            // 
            this.category.DataPropertyName = "category";
            this.category.HeaderText = "category";
            this.category.Name = "category";
            // 
            // normalprice
            // 
            this.normalprice.DataPropertyName = "normalprice";
            this.normalprice.HeaderText = "normal price";
            this.normalprice.Name = "normalprice";
            // 
            // itemnamerocode
            // 
            this.itemnamerocode.DataPropertyName = "itemnameorcode";
            this.itemnamerocode.HeaderText = "Item";
            this.itemnamerocode.Name = "itemnamerocode";
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            // 
            // trans
            // 
            this.trans.DataPropertyName = "trans";
            this.trans.HeaderText = "Transaction Type";
            this.trans.Name = "trans";
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            // 
            // location
            // 
            this.location.DataPropertyName = "location";
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            // 
            // orderno
            // 
            this.orderno.DataPropertyName = "orderno";
            this.orderno.HeaderText = "Ordernumber";
            this.orderno.Name = "orderno";
            // 
            // quantityonhand
            // 
            this.quantityonhand.DataPropertyName = "quantityonhand";
            this.quantityonhand.HeaderText = "QtyBefore";
            this.quantityonhand.Name = "quantityonhand";
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Qty";
            this.quantity.Name = "quantity";
            // 
            // quantityafter
            // 
            this.quantityafter.DataPropertyName = "quantityafter";
            this.quantityafter.HeaderText = "QtyAfter";
            this.quantityafter.Name = "quantityafter";
            // 
            // movementhistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 672);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "movementhistory";
            this.Text = "movementhistory";
            this.Load += new System.EventHandler(this.movementhistory_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvproduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlocation)).EndInit();
            this.paneldate.ResumeLayout(false);
            this.paneldate.PerformLayout();
            this.paneltranc.ResumeLayout(false);
            this.paneltranc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvdisplay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbdate;
        private System.Windows.Forms.ComboBox cmbloc;
        private System.Windows.Forms.ComboBox cmbtrans;
        private System.Windows.Forms.ComboBox cmbitem;
        private System.Windows.Forms.DataGridView dgvproduct;
        private System.Windows.Forms.Panel paneltranc;
        private System.Windows.Forms.CheckBox chkrestock;
        private System.Windows.Forms.CheckBox chkful;
        private System.Windows.Forms.CheckBox chkpick;
        private System.Windows.Forms.CheckBox chkunstock;
        private System.Windows.Forms.CheckBox chkrecive;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.DataGridView dgvlocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locations;
        private System.Windows.Forms.Panel paneldate;
        private System.Windows.Forms.Label lablstyear;
        private System.Windows.Forms.Label lablstqut;
        private System.Windows.Forms.Label lablstmonth;
        private System.Windows.Forms.Label lablsweek;
        private System.Windows.Forms.Label labyesterday;
        private System.Windows.Forms.Label labthyear;
        private System.Windows.Forms.Label labthquarter;
        private System.Windows.Forms.Label labthmonth;
        private System.Windows.Forms.Label labthweek;
        private System.Windows.Forms.Label labtoday;
        private System.Windows.Forms.Label laball;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbto;
        private System.Windows.Forms.ComboBox cmbfrom;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridViewTextBoxColumn items;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn normalprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnamerocode;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn trans;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderno;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityonhand;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityafter;
    }
}