namespace InventoryTools
{
    partial class Location
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
            this.dgvLocation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocSave = new System.Windows.Forms.Button();
            this.btnLocCancl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocation
            // 
            this.dgvLocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvLocation.Location = new System.Drawing.Point(40, 81);
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.Size = new System.Drawing.Size(327, 199);
            this.dgvLocation.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "location";
            this.Column1.HeaderText = "Location Name";
            this.Column1.Name = "Column1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location";
            // 
            // btnLocSave
            // 
            this.btnLocSave.Location = new System.Drawing.Point(146, 328);
            this.btnLocSave.Name = "btnLocSave";
            this.btnLocSave.Size = new System.Drawing.Size(108, 23);
            this.btnLocSave.TabIndex = 2;
            this.btnLocSave.Text = "Save && Close";
            this.btnLocSave.UseVisualStyleBackColor = true;
            this.btnLocSave.Click += new System.EventHandler(this.btnLocSave_Click);
            // 
            // btnLocCancl
            // 
            this.btnLocCancl.Location = new System.Drawing.Point(259, 328);
            this.btnLocCancl.Name = "btnLocCancl";
            this.btnLocCancl.Size = new System.Drawing.Size(108, 23);
            this.btnLocCancl.TabIndex = 3;
            this.btnLocCancl.Text = "Cancel";
            this.btnLocCancl.UseVisualStyleBackColor = true;
            this.btnLocCancl.Click += new System.EventHandler(this.btnLocCancl_Click);
            // 
            // Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 374);
            this.Controls.Add(this.btnLocCancl);
            this.Controls.Add(this.btnLocSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLocation);
            this.Name = "Location";
            this.Text = "Location";
            this.Load += new System.EventHandler(this.Location_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocSave;
        private System.Windows.Forms.Button btnLocCancl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}