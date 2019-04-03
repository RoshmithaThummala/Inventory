namespace InventoryTools
{
    partial class Pricing
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
            this.dgvPricingAdd = new System.Windows.Forms.DataGridView();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPricingAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPricingAdd
            // 
            this.dgvPricingAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPricingAdd.BackgroundColor = System.Drawing.Color.White;
            this.dgvPricingAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPricingAdd.Location = new System.Drawing.Point(12, 90);
            this.dgvPricingAdd.Name = "dgvPricingAdd";
            this.dgvPricingAdd.Size = new System.Drawing.Size(452, 222);
            this.dgvPricingAdd.TabIndex = 0;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveClose.Location = new System.Drawing.Point(196, 338);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(172, 23);
            this.btnSaveClose.TabIndex = 1;
            this.btnSaveClose.Text = "Save && Close";
            this.btnSaveClose.UseVisualStyleBackColor = false;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pricing / Currency";
            // 
            // Pricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 373);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.dgvPricingAdd);
            this.Name = "Pricing";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Pricing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPricingAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dgvPricingAdd;
        private System.Windows.Forms.Label label1;
    }
}